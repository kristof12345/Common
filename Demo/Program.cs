using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Demo;
using Common.Web;
using Syncfusion.Blazor;
using Blazored.LocalStorage;
using Plk.Blazor.DragDrop;
using MatBlazor;
using MudBlazor.Services;

namespace Common.Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var services = builder.Services;

            services.AddBlazorDragDrop();
            services.AddBlazoredLocalStorage();
            services.AddSyncfusionBlazor();
            services.AddMatBlazor();
            builder.Services.AddMudServices();

            services.AddScoped<ToastService>();
            services.AddScoped<ThemeService>();

            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 95;
                config.VisibleStateDuration = 3000;
            });

            await builder.Build().RunAsync();
        }
    }
}
