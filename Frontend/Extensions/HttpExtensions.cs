using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Web
{
    public static class HttpExtensions
    {
        public static Task<HttpResponseMessage> GetAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
        {
            var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("GET"), requestUri) { Content = content };

            return client.SendAsync(request);
        }

        public static Task<HttpResponseMessage> PatchAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
        {
            var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content };

            return client.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> PostAsync(this HttpClient client, string requestUri)
        {
            return await client.PostAsync(requestUri, null);
        }

        public static async Task<HttpResponseMessage> PutAsync(this HttpClient client, string requestUri)
        {
            return await client.PutAsync(requestUri, null);
        }

        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri)
        {
            return await client.PatchAsync(requestUri, null);
        }

        public static async Task<HttpResponseMessage> HeadAsync(this HttpClient client, string requestUri)
        {
            return await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, requestUri));
        }
    }
}
