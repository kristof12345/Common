using System;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;

namespace Common.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTUxMDYyQDMxMzkyZTM0MmUzMFRZdXQzMEs2czZOTW9KTVJXQzc3NEVNYWJOSk5JU25wbGMvSnBEL1VQalk9");

            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddSyncfusionBlazor();

            services.AddScoped<MemoryCache>();
            services.AddScoped<ToastService>();
            services.AddScoped<ThemeService>();
            services.AddScoped<DragDropService>();

            return services;
        }
    }
}