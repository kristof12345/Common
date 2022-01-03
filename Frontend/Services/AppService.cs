using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.Extensions.Caching.Memory;

namespace Common.Web
{
    public abstract class AppService
    {
        protected readonly HttpClient Client;
        protected readonly MemoryCache Cache;
        protected readonly ToastService Toast;

        protected AppService(HttpClient client, MemoryCache cache, ToastService toast)
        {
            Client = client;
            Cache = cache;
            Toast = toast;
        }

        protected async Task<T> Get<T>(string url, ICacheEntry cache) where T : new()
        {
            var response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                cache.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
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
}

