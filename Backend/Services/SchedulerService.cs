using System.Net.Http.Headers;
using Hangfire;
using Common.Application;

namespace Common.Backend;

public class SchedulerService : ISchedulerService
{
    private readonly HttpClient Client = new HttpClient();

    public SchedulerService(ITokenService tokenService)
    {
        var user = tokenService.GenerateToken("server", "server", UserType.Server);
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
    }

    public void AddSingleApiCall(string url, HttpMethod method, TimeSpan interval)
    {
        try
        {
            BackgroundJob.Schedule(() => SendApiCall(url, method), interval);
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("Error while scheduling single api call.");
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    public void AddRecurringApiCall(string url, HttpMethod method, string interval)
    {
        try
        {
            RecurringJob.AddOrUpdate(method.ToString() + url, () => SendApiCall(url + "externalData", method), interval);
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("Error while scheduling recurring api call.");
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
    }

    public async Task<bool> SendApiCall(string url, HttpMethod method)
    {
        try
        {
            await Client.SendAsync(new HttpRequestMessage(method, url));
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("Error while executing scheduler call.");
            System.Diagnostics.Debug.WriteLine(e.Message);
            return false;
        }

        return true;
    }
}
