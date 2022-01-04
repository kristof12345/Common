using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Common.Backend
{
    public static class DatabaseExtensions
    {
        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource>(this IQueryable<TSource> entities, Ordering<TSource> ordering)
        {
            return ordering.Descending ? entities.OrderByDescending(ordering.Expression) : entities.OrderBy(ordering.Expression);
        }

        public static async Task<T> FindAsync<T, R>(this IQueryable<T> entities, R id) where T : IEntity<R>
        {
            return await entities.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public static async Task<T> InsertAsync<T>(this DbSet<T> entities, T entity) where T : class
        {
            entities.Add(entity);
            await entities.SaveAsync();
            return entity;
        }

        public static async Task InsertAsync<T>(this DbSet<T> entities, IEnumerable<T> entity) where T : class
        {
            entities.AddRange(entity);
            await entities.SaveAsync();
        }

        public static async Task<T> UpdateAsync<T, R>(this DbSet<T> entities, IEntity<R> entity) where T : class, IEntity<R>
        {
            var original = await entities.AsTracking().FindAsync(entity.Id);
            if (original != null)
            {
                entities.Remove(original);
                entities.Add((T)entity);
                await entities.SaveAsync();
            }
            return (T)entity;
        }

        public static async Task<T> UpdateAsync<T, R>(this IQueryable<T> entities, IEntity<R> entity, DbContext context) where T : class, IEntity<R>
        {
            var original = await entities.AsTracking().FirstOrDefaultAsync(e => e.Id.Equals(entity.Id));
            if (original != null)
            {
                context.Remove(original);
                context.Add((T)entity);
                await context.SaveChangesAsync();
            }
            return (T)entity;
        }

        public static async Task<T> DeleteAsync<T, R>(this DbSet<T> entities, R id) where T : class, IEntity<R>
        {
            var entity = await entities.AsTracking().FindAsync(id);
            if (entity != null)
            {
                entities.Remove(entity);
                await entities.SaveAsync();
            }
            return entity;
        }

        public static async Task<T> DeleteAsync<T, R>(this IQueryable<T> entities, R id, DbContext context) where T : class, IEntity<R>
        {
            var entity = await entities.AsTracking().FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (entity != null)
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
            return entity;
        }

        public static void DiscardChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        private static async Task SaveAsync<T>(this DbSet<T> entities) where T : class
        {
            await entities.GetService<ICurrentDbContext>().Context.SaveChangesAsync();
        }
    }
}