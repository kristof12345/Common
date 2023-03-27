using Common.Application;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;

namespace Common.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ3NDkwNkAzMjMxMmUzMTJlMzMzNVRvWjloZzZZZ0EwcGxhOWNTRDJiaXMwMlkzMWFYK1M3WURJYWovRlFkNlE9");

            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddSyncfusionBlazor();

            services.AddScoped<CacheService>();
            services.AddScoped<ToastService>();
            services.AddScoped<ThemeService>();
            services.AddScoped<DragDropService>();

            return services;
        }
    }
}