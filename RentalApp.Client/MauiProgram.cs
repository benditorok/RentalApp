using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using RentalApp.Client.RestApi;

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
#endif

        builder.Services.AddSingleton<IRestService, RestService>();

        return builder.Build();
    }
}
