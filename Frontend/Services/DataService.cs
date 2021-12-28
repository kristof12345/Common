using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Common.Web
{
    public class DataService<T>
    {
        public readonly HttpClient Http;
        public readonly MemoryCache Cache;

        public DataService(HttpClient http, MemoryCache cache)
        {
            Http = http;
            Cache = cache;
        }

        public async Task<T> LoadFromJson(string file)
        {
            return await Http.GetFromJsonAsync<T>(file);
        }
    }
}