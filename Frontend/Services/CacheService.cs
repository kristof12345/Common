using System;
using System.Collections.Generic;

namespace Common.Web
{
    public class CacheService
    {
        private readonly Dictionary<string, object> cache = new Dictionary<string, object>();

        public T Get<T>(string key)
        {
            return (T)cache.GetValueOrDefault(key);
        }

        public void Set<T>(string key, T value)
        {
            cache[key] = value;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void Clear()
        {
            cache.Clear();
        }
    }
}