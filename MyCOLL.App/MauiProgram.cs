using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using MyCOLL.App.Services;
using MyCOLL.Shared.Services;

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
            string apiAddress;
            var devTunnelUrl = "https://1l34c7z5-7004.uks1.devtunnels.ms";

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                // Android Emulator
                apiAddress = devTunnelUrl;
            }
            else
            {
                // Windows Machine
                apiAddress = "https://localhost:7004"; 
            }

            // Cria o HttpClient com o endereço calculado
            return new HttpClient { BaseAddress = new Uri(apiAddress) };
        });
        builder.Services.AddAuthorizationCore();
        builder.Services.AddSingleton<CartService>();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        
        
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}