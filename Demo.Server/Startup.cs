using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Syncfusion.Blazor;
using Microsoft.Extensions.Hosting;
using Common.Web;
using Common.Application;
using System.Net.Http;
using System;
using Blazored.SessionStorage;


namespace Demo.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5000/") });

            services.AddSignalR(e => { e.MaximumReceiveMessageSize = 102400000; });
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddHttpClient();

            services.AddCommonServices();
            var a = services.BuildServiceProvider();

            services.AddSingleton<LoginService>(new LoginService(new HttpClient { BaseAddress = new Uri("https://localhost:10002/") }, a.GetRequiredService<ILocalStorageService>(), a.GetRequiredService<ISessionStorageService>()));
            services.AddScoped<DataService<DemoStock>>();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/Host");
            });
        }
    }
}
