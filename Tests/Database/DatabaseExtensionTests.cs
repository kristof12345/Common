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
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB1").Options);

            // Act
            await context.Entities.InsertAsync(new Entity { Id="1", Content="a" }, context);

            // Assert
            Assert.Equal(1, context.Entities.Count());
        }

        [Fact]
        public async Task InsertListTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB2").Options);

            // Act
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } }, context);

            // Assert
            Assert.Equal(2, context.Entities.Count());
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB3").Options);

            // Act
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } }, context);
            await context.Entities.DeleteAsync("2", context);

            // Assert
            Assert.Equal(1, context.Entities.Count());
        }

        [Fact]
        public async Task OrderByAscendingTest()
        {
            // Arrange
            var context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase("DemoDB4").Options);

            // Act
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } }, context);

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

            // Act
            await context.Entities.InsertAsync(new List<Entity> { new Entity { Id = "1", Content = "a" }, new Entity { Id = "2", Content = "b" } }, context);

            var list = await context.Entities.OrderByWithDirection(new Ordering<Entity>(e => e.Content, true)).ToListAsync();

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Equal("2", list.First().Id);
            Assert.Equal("1", list.Last().Id);
        }
    }
}