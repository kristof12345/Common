using Common.Application;
using Xunit;

namespace Common.Tests.Services
{
    public class CacheServiceTests
    {
        [Fact]
        public void AddToCacheTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Set("Key", "Value", 0);

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
            cache.Set("Key", "Value 1", 0);
            cache.Set("Key", "Value 2", 0);

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
            cache.Set("Key", "Value", 0);
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
            cache.Set("Key", "Value", 0);
            cache.ClearAll();

            // Assert
            Assert.Null(cache.Get<string>("Key"));
        }

        [Fact]
        public void ClearCategoryTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Set("Key1", "Value1", 1);
            cache.Set("Key2", "Value2", 1);
            cache.Set("Key3", "Value3", 2);
            cache.Set("Key4", "Value4", 2);
            cache.ClearCategory(2);

            // Assert
            Assert.NotNull(cache.Get<string>("Key1"));
            Assert.Equal("Value2", cache.Get<string>("Key2"));
            Assert.Null(cache.Get<string>("Key3"));
            Assert.Null(cache.Get<string>("Key4"));
        }

        [Fact]
        public void ClearEmptyCategoryTest()
        {
            // Arrange
            var cache = new CacheService();

            // Act
            cache.Set("Key1", "Value1", 1);
            cache.Set("Key2", "Value2", 1);
            cache.Set("Key3", "Value3", 2);
            cache.Set("Key4", "Value4", 2);
            cache.ClearCategory(3);

            // Assert
            Assert.NotNull(cache.Get<string>("Key1"));
            Assert.Equal("Value2", cache.Get<string>("Key2"));
            Assert.NotNull(cache.Get<string>("Key3"));
            Assert.Equal("Value4", cache.Get<string>("Key4"));
        }
    }
}