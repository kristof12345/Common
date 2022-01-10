using System;
using Common.Application;
using Common.Backend;
using Common.Web;
using Xunit;

namespace Common.Tests.Frontend
{
    public class CacheServiceTests
    {
        [Fact]
        public void AddToCacheTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Set("Key", "Value");

            // Assert
            Assert.NotNull(cache.Get<string>("Key"));
            Assert.Equal("Value", cache.Get<string>("Key"));
        }

        [Fact]
        public void UpdateCacheTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Set("Key", "Value 1");
            cache.Set("Key", "Value 2");

            // Assert
            Assert.NotNull(cache.Get<string>("Key"));
            Assert.Equal("Value 2", cache.Get<string>("Key"));
        }

        [Fact]
        public void RemoveFromCacheTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Set("Key", "Value");
            cache.Remove("Key");

            // Assert
            Assert.Null(cache.Get<string>("Key"));
        }

        [Fact]
        public void RemoveFromEmptyCacheTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Remove("Key");

            // Assert
            Assert.Null(cache.Get<string>("Key"));
        }

        [Fact]
        public void ClearCacheTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Set("Key", "Value");
            cache.Clear();

            // Assert
            Assert.Null(cache.Get<string>("Key"));
        }
    }
}