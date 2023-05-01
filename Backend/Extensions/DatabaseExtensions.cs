using System.Linq.Expressions;
using Common.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Common.Backend;

public static class DatabaseExtensions
{
    public static IOrderedQueryable<TSource> OrderByWithDirection<TSource>(this IQueryable<TSource> entities, Ordering<TSource> ordering)
    {
        return ordering.Descending ? entities.OrderByDescending(ordering.Expression) : entities.OrderBy(ordering.Expression);
    }

    public static async Task<T> FindAsync<T, R>(this IQueryable<T> database, R id) where T : IEntity<R>
    {
        return await database.FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    public static async Task<T> InsertAsync<T>(this DbSet<T> database, T entity) where T : class
    {
        database.Add(entity);
        await database.SaveAsync();
        return entity;
    }

    public static async Task InsertAsync<T>(this DbSet<T> database, IEnumerable<T> entity) where T : class
    {
        database.AddRange(entity);
        await database.SaveAsync();
    }

    public static async Task<T> UpdateAsync<T, R>(this DbSet<T> database, IEntity<R> entity) where T : class, IEntity<R>
    {
        var original = await database.AsTracking().FindAsync(entity.Id);
        if (original != null)
        {
            database.Remove(original);
            database.Add((T)entity);
            await database.SaveAsync();
        }
        return (T)entity;
    }

    public static async Task<T> UpdateAsync<T, R>(this DbSet<T> database, R id, IEntity<R> entity) where T : class, IEntity<R>
    {
        entity.Id = id;
        var original = await database.AsTracking().FindAsync(id);
        if (original != null)
        {
            database.Remove(original);
            database.Add((T)entity);
            await database.SaveAsync();
        }
        return (T)entity;
    }

    public static async Task<T> DeleteAsync<T, R>(this DbSet<T> database, R id) where T : class, IEntity<R>
    {
        var entity = await database.AsTracking().FindAsync(id);
        if (entity != null)
        {
            database.Remove(entity);
            await database.SaveAsync();
        }
        return entity;
    }

    public static async Task DeleteAsync<T>(this DbSet<T> database, Expression<Func<T, bool>> expression) where T : class
    {
        var entities = database.Where(expression);
        database.RemoveRange(entities);
        await database.SaveAsync();
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
