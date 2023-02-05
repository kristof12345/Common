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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkXlpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSH5ad0VnWnxadHZRQg==;Mgo+DSMBPh8sVXJ0S0J+XE9AdFRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Td0VqWH9ac3dRQmVdVQ==;ORg4AjUWIQA/Gnt2VVhkQlFacl1JXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRjUH5edHdWQmRaVkA=;OTA0MzQ5QDMyMzAyZTM0MmUzMGxmUGc1MnBISHc3NTM3OURHeEthU1dSWWZ1SzBxOGw5QWE5YXdXMFIrWEU9;OTA0MzUwQDMyMzAyZTM0MmUzMGNkNnFPMUFRckJaQ0Fmc09BTDI0NzZ4ZU1sM3FFS2pOZ2hGN21oS05sRlU9;NRAiBiAaIQQuGjN/V0Z+WE9EaFtAVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUViWXZfcHBWRWRZVkVy;OTA0MzUyQDMyMzAyZTM0MmUzMFRrK0tTcnp6Z3FhMURkUEluenR0bG82NThVdUhUeWpQRnIzbGZuenluUm89;OTA0MzUzQDMyMzAyZTM0MmUzMFZQSjB0NkgrTFJPWmJ1Y1VDVVVWZUpTalY2T0FZT0JXTnZhYVlOcDcrRnM9;Mgo+DSMBMAY9C3t2VVhkQlFacl1JXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRjUH5edHdWQmZZVUA=;OTA0MzU1QDMyMzAyZTM0MmUzME1SMHRZRSt0dE02TU1ldFRTWEF5eURyNndiUmFFODl0MjgxUDVDK2Rzbms9;OTA0MzU2QDMyMzAyZTM0MmUzMGtCQkwxU21xeVFhWGtSUEpvUGZUbUk2VE9oSGo2c2NLWkZCR0RhUHpwc1E9;OTA0MzU3QDMyMzAyZTM0MmUzMFRrK0tTcnp6Z3FhMURkUEluenR0bG82NThVdUhUeWpQRnIzbGZuenluUm89");

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