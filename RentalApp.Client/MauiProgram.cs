using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using RentalApp.Client.Services;

namespace RentalApp.Client;

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

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.SetMinimumLevel(LogLevel.Information);
        builder.Logging.AddDebug();

        builder.Services.AddSingleton<IConnectionService, ConnectionService>();
#else
        // Add a custom URL when in production
        builder.Services.AddSingleton<IConnectionService>(new ConnectionService("http://example.com/", "Status"));
#endif

        return builder.Build();
    }
}
