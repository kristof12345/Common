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
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWH1fc3VUQ2ReUk1xXEI=");

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