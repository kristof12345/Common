using Common.Application;
using System.Text.Json;

namespace Common.Web
{
    public class DataService : AppService
    {
        public DataService(HttpClient client, CacheService cache, ToastService toast) : base(client, cache, toast) { }

        public async Task<T> LoadFromJson<T>(string file)
        {
            var stream = await FileSystem.OpenAppPackageFileAsync(file);
            return await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<T> GetDemoJson<T>() where T : new()
        {
            return await GetWithCache<T>("https://jsonplaceholder.typicode.com/posts/1", "Demo");
        }
    }
}