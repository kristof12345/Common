using System.Collections.Generic;
using System.Linq;

namespace Common.Application;

public class CacheService
{
    private readonly Dictionary<string, (object, int)> cache = new Dictionary<string, (object, int)>();

    public T Get<T>(string key)
    {
        return (T)cache.GetValueOrDefault(key).Item1;
    }

    public void Set<T>(string key, T value, int category)
    {
        cache[key] = (value, category);
    }

    public void Remove(string key)
    {
        cache.Remove(key);
    }

    public void ClearCategory(int category)
    {
        foreach (var item in cache.Where(kvp => kvp.Value.Item2 == category).ToList())
        {
            cache.Remove(item.Key);
        }
    }

    public void ClearAll()
    {
        cache.Clear();
    }
}
