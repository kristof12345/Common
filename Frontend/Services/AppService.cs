using Common.Application;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Web;

public abstract class AppService
{
    protected readonly HttpClient Client;
    protected readonly CacheService Cache;
    protected readonly ToastService Toast;

    protected AppService(HttpClient client, CacheService cache, ToastService toast)
    {
        Client = client;
        Cache = cache;
        Toast = toast;
    }

    protected async Task<T> GetWithCache<T>(string url, string key, int category = 0) where T : new()
    {
        var value = Cache.Get<T>(key);
        if (value != null)
        {
            await Task.Delay(5);
            return await Task.FromResult(value);
        }
        else
        {
            var response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                value = await response.Content.ReadAsAsync<T>();
                Cache.Set(key, value, category);
                return value;
            }
            else
            {
                var error = await response.Content.ReadAsAsync<Response>();
                await Toast.Add(error.Content, ToastType.Danger);
                return new T();
            }
        }
    }

    protected async Task<T> Get<T>(string url) where T : new()
    {
        var response = await Client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<T>();
        }
        else
        {
            var error = await response.Content.ReadAsAsync<Response>();
            await Toast.Add(error.Content, ToastType.Danger);
            return new T();
        }
    }
}
