using System;
using Microsoft.Extensions.Caching.Memory;

namespace Common.Application
{
    public static class CacheExtensions
    {
        public static void Clear(this MemoryCache cache)
        {
            cache.Compact(1.0);
        }
    }
}