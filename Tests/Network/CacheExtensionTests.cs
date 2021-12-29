using System;
using Common.Application;
using Common.Backend;
using Common.Web;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Common.Tests.Network
{
    public class CacheExtensionTests
    {
        [Fact]
        public void AddToCacheTest()
        {
            // Arrange
            var cache = new MemoryCache(new MemoryCacheOptions());

            // Act
            cache.Set("key", "value");

            // Assert
            Assert.Equal(1, cache.Count);
            Assert.Equal("value", cache.Get("key"));
        }

        [Fact]
        public void ClearCacheTest()
        {
            // Arrange
            var cache = new MemoryCache(new MemoryCacheOptions());

            // Act
            cache.Set("key", "value");
            cache.Clear();

            // Assert
            Assert.Equal(0, cache.Count);
        }
    }
}

