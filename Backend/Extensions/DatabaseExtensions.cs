using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.EntityFrameworkCore;

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

        public static async Task<T> InsertAsync<T>(this DbSet<T> entities, T entity, DbContext context) where T : class
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public static async Task InsertAsync<T>(this DbSet<T> entities, IEnumerable<T> entity, DbContext context) where T : class
        {
            await entities.AddRangeAsync(entity);
            await context.SaveChangesAsync();
        }

        public static async Task<T> DeleteAsync<T, R>(this IQueryable<T> entities, R id, DbContext context) where T : class, IEntity<R>
        {
            var entity = await entities.AsTracking().FindAsync(id);
            if (entity != null)
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
            return entity;
        }
    }
}