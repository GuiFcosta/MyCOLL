using System.Net.Http.Json;
using MyCOLL.Shared.Models;

namespace MyCOLL.RazorClass.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        // O sistema injeta o HttpClient configurado automaticamente
        public ApiService(HttpClient http)
        {
            _http = http;
        }

        // bsuca produtos da api
        public async Task<List<ProductDto>> GetProdutosAsync()
        {
            try 
            {
                var resultado = await _http.GetFromJsonAsync<List<ProductDto>>("api/Product");
                return resultado ?? new List<ProductDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar produtos: {ex.Message}");
                return new List<ProductDto>();
            }
        }
    }
}