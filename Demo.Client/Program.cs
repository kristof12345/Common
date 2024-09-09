using Common.Application;
using Common.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var services = builder.Services;

            services.AddCommonServices();

            services.AddScoped<LoginService>();
            services.AddScoped<DataService>();
            services.AddScoped<UserService<IUser>>();

            await builder.Build().RunAsync();
        }
    }
}
