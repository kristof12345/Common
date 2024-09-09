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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQyMzEyNUAzMjM2MmUzMDJlMzBtZHpJckpSSlhxUCsrWFg3MzR4MkJLVy9hWlBRalgrNHU4Z0Q3VVpabjFNPQ==");

            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddSyncfusionBlazor();

            services.AddScoped<UserService<IUser>>();
            services.AddScoped<CacheService>();
            services.AddScoped<ToastService>();
            services.AddScoped<ThemeService>();
            services.AddScoped<DragDropService>();

            return services;
        }
    }
}