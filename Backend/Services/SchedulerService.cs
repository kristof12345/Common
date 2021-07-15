using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hangfire;
using Common.Application;

namespace Common.Backend
{
    public class SchedulerService : ISchedulerService
    {
        private readonly HttpClient Client = new HttpClient();

        public SchedulerService(ITokenService tokenService)
        {
            var user = tokenService.GenerateToken("admin", new Name(), UserType.Admin);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
        }

        public void AddSingleApiCall(string url, HttpMethod method, TimeSpan interval)
        {
            BackgroundJob.Schedule(() => SendApiCall(url + "externalData", method), interval);
        }

        public void AddRecurringApiCall(string url, HttpMethod method, string interval)
        {
            RecurringJob.AddOrUpdate(() => SendApiCall(url + "externalData", method), interval);
        }

        public async Task SendApiCall(string url, HttpMethod method)
        {
            try
            {
                await Client.SendAsync(new HttpRequestMessage(method, url));
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error while executing scheduler call.");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
