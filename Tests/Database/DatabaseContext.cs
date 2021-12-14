using Common.Application;
using Microsoft.EntityFrameworkCore;

namespace Common.Tests.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    public class Entity : IEntity<string>
    {
        public string Id { get; set; }

        public string Content { get; set; }
    }
}
