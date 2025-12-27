using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyCOLL.RazorClass.Services;
using MyCOLL.WEB.Client; // Namespace do Client

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Atenção: Garante que "App" existe. Se der erro, verifica se tens App.razor no projeto Client
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura a API (A porta da tua API MyCOLL)
string apiAddress = "http://localhost:5048"; 
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiAddress) });

// Regista o Serviço
builder.Services.AddScoped<ApiService>();

await builder.Build().RunAsync();