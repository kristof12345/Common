﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Demo;
using Common.Web;
using Syncfusion.Blazor;
using Blazored.LocalStorage;
using Blazored.SessionStorage;

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

            services.AddScoped<DataService<DemoStock>>();

            await builder.Build().RunAsync();
        }
    }
}