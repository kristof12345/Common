using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Common.Application;

namespace Common.Web
{
    public class DataService : AppService
    {
        public DataService(HttpClient client, CacheService cache, ToastService toast) : base(client, cache, toast) { }

        public async Task<T> LoadFromJson<T>(string file)
        {
            return await Client.GetFromJsonAsync<T>(file);
        }

        public async Task<T> GetDemoJson<T>() where T : new()
        {
            return await this.GetWithCache<T>("https://jsonplaceholder.typicode.com/posts/1", "Demo");
        }
    }
}