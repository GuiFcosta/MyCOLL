using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage; 
using Microsoft.AspNetCore.Components.Authorization;
using MyCOLL.Shared.Interface;

namespace MyCOLL.Web.Services;

public class ClientAuthStateProvider : AuthenticationStateProvider, IAuthService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;

    public ClientAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage = localStorage;
        _http = http;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // ler o token do navegador
        var token = await _localStorage.GetItemAsync<string>("authToken");

        // se não houver token, o utilizador é anónimo
        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        // se houver token, configurar o HttpClient para o usar sempre
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

        // ler as claims (dados) de dentro do token e avisar a App que estamos logados
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
    }
    
    public async Task Login(string token)
    {
        // guardar no LocalStorage
        await _localStorage.SetItemAsync("authToken", token);
        
        // configurar Header
        _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
        
        // avisar a App que mudou o estado
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        _http.DefaultRequestHeaders.Authorization = null;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}