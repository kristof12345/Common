using System;
using Microsoft.Extensions.Caching.Memory;

namespace Common.Web
{
    public static class CacheExtensions
    {
        public static void Clear(this MemoryCache cache)
        {
            cache.Compact(1.0);
        }
    }
}