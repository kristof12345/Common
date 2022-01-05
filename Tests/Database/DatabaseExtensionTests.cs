using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Common.Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common.Tests.Database
{
    public class DatabaseExtensionTests
    {
        [Fact]
        public async Task InsertEntityTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB0").Options);

            // Act
            await context.Entities.InsertAsync(new Entity { Id = "1", Content = "a" });

            // Assert
            Assert.Equal(1, context.Entities.Count());
        }

        [Fact]
        public async Task InsertDuplicateTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB1").Options);
            string msg = "";

            // Act
            try
            {
                await AddDuplicateEntity(context);
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

            // Assert
            await Assert.ThrowsAsync<DuplicateException>(async () => await AddDuplicateEntity(context));
            Assert.Equal("An entity already exists with the given ID.", msg);
        }

        private static async Task AddDuplicateEntity(DatabaseContext context)
        {
            try
            {
                await context.Entities.InsertAsync(new Entity { Id = "1", Content = "a" });
                await context.Entities.InsertAsync(new Entity { Id = "1", Content = "b" });
            }
            catch (Exception)
            {
                throw new DuplicateException();
            }
        }

        [Fact]
        public async Task InsertListTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB2").Options);

            // Act
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } });

            // Assert
            Assert.Equal(2, context.Entities.Count());
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB3").Options);
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } });

            // Act
            await context.Entities.DeleteAsync("2");

            // Assert
            Assert.Equal(1, context.Entities.Count());
        }

        [Fact]
        public async Task OrderByAscendingTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB4").Options);
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } });

            // Act
            var list = await context.Entities.OrderByWithDirection(new Ordering<Entity>(e => e.Content, false)).ToListAsync();

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal("1", list.First().Id);
            Assert.Equal("2", list.Last().Id);
        }

        [Fact]
        public async Task OrderByDescendingTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB5").Options);
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } });

            // Act
            var list = await context.Entities.OrderByWithDirection(new Ordering<Entity>(e => e.Content, true)).ToListAsync();

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal("2", list.First().Id);
            Assert.Equal("1", list.Last().Id);
        }

        [Fact]
        public async Task UpdateTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB6").Options);
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } });

            // Act
            await context.Entities.UpdateAsync(new Entity { Id = "1", Content = "c" });
            var list = await context.Entities.OrderBy(e => e.Id).ToListAsync();

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal("1", list.First().Id);
            Assert.Equal("2", list.Last().Id);
            Assert.Equal("c", list.First().Content);
            Assert.Equal("b", list.Last().Content);
        }

        [Fact]
        public void DiscardChangesTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB7").Options);

            // Act
            context.Entities.Add(new Entity { Id = "1", Content = "a" });
            context.DiscardChanges();

            // Assert
            Assert.Empty(context.Entities);
        }

        [Fact]
        public async Task ComplexDiscardChangesTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB8").Options);
            context.Entities.Add(new Entity { Id = "1", Content = "a" });
            context.Entities.Add(new Entity { Id = "2", Content = "b" });
            await context.SaveChangesAsync();

            // Add
            context.Entities.Add(new Entity { Id = "3", Content = "c" });

            // Remove
            var e1 = await context.Entities.FindAsync("1");
            context.Entities.Remove(e1);

            // Modify
            var e2 = await context.Entities.FindAsync("2");
            e2.Content = "d";

            // Act
            context.DiscardChanges();

            // Assert
            Assert.Equal(2, context.Entities.Count());
            Assert.Equal("a", context.Entities.First().Content);
            Assert.Equal("b", context.Entities.Last().Content);
        }

        [Fact]
        public async Task UpdateParentTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB9").Options);
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } });

            // Act
            await context.Entities.UpdateAsync(new Entity { Id = "1", Content = "c" }, context);
            var list = await context.Entities.OrderBy(e => e.Id).ToListAsync();

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal("1", list.First().Id);
            Assert.Equal("2", list.Last().Id);
            Assert.Equal("c", list.First().Content);
            Assert.Equal("b", list.Last().Content);
        }
    }
}