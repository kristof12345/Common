using Microsoft.Extensions.Logging;
using Demo.Mobile.Data;
using Common.Web;

namespace Demo.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

        var services = builder.Services;

        services.AddCommonServices();

        services.AddScoped<LoginService>();
        services.AddScoped<DataService>();

        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();

        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
}

