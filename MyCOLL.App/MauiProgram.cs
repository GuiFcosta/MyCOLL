using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using MyCOLL.App.Services;

namespace MyCOLL.App;

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
        builder.Services.AddScoped(sp =>
        {
            // Endereço base da API
            string baseAddress;
            // var devTunnelUrl = "https://hrf2r0rh-7004.uks1.devtunnels.ms";

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                // 10.0.2.2 é o "localhost" do PC visto de dentro do emulador Android
                // ATENÇÃO: Verifique a porta da sua API (ex: 7000, 5000, 7234)
                baseAddress = "http://10.0.2.2:5048/"; 
            }
            else
            {
                // Para Windows/Mac usa localhost normal
                baseAddress = "https://localhost:7004/"; 
            }

            return new HttpClient { BaseAddress = new Uri(baseAddress) };
        });
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        
        
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}