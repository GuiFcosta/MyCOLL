using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyCOLL.WEB.Client.Pages;
using MyCOLL.WEB.Components;
using MyCOLL.RazorClass.Services;
using MyCOLL.WEB; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 2. Configura a ligação à API
string apiAddress = "https://localhost:5048"; 
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiAddress) });

// 3. Regista serviço de produtos
builder.Services.AddScoped<ApiService>();

await builder.Build().RunAsync();