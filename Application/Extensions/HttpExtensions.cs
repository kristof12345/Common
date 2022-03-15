using System.Text;
using System.Text.Json;

namespace Common.Application;

public static class HttpExtensions
{
    private static readonly JsonSerializerOptions options = new JsonSerializerOptions {  PropertyNameCaseInsensitive = true };

    public static Task<HttpResponseMessage> GetAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
    {
        var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(new HttpMethod("GET"), requestUri) { Content = content };

        return client.SendAsync(request);
    }

    public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
    {
        var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(new HttpMethod("POST"), requestUri) { Content = content };

        return client.SendAsync(request);
    }

    public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string requestUri, T value)
    {
        var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(new HttpMethod("PUT"), requestUri) { Content = content };

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

    public static async Task<T> ReadAsAsync<T>(this HttpContent content)
    {
        return JsonSerializer.Deserialize<T>(await content.ReadAsStringAsync(), options);
    }
}
