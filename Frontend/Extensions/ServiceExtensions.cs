using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Common.Application;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;

namespace Common.Web;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDAwNTAzNkAzMzMwMmUzMDJlMzAzYjMzMzAzYlJZRTN4RjI4cG5YR2wyQ1F4TEdLdnVVcGpnMVZLMVVqSjNrOWQxRlNFc0E9");

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