using System.Net;
using MyCOLL.Admin.ViewModels;

namespace MyCOLL.Admin.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    
    // Injeta o HttpClient via IHttpClientFactory
    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("StoreApi");
    }
    
    // GET all products
    public async Task<List<ProductReadViewModel>?> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync("api/Product");
        if(!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
        {
            throw new Exception("Error fetching products from API");
        }
        return await _httpClient.GetFromJsonAsync<List<ProductReadViewModel>>("api/Product");
    }
    // GET product by ID
    public async Task<ProductReadViewModel?> GetProductByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ProductReadViewModel>($"api/Product/{id}");
    }
    // CREATE a new product
    public async Task CreateProductAsync(ProductViewModel product)
    {
        await _httpClient.PostAsJsonAsync("api/Product", product);
    }
    // UPDATE an existing product
    public async Task UpdateProductAsync(int id, ProductViewModel product)
    {
        await _httpClient.PutAsJsonAsync($"api/Product/{id}", product);
    }
    // DELETE a product
    public async Task DeleteProductAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/Product/{id}");
    }
    
    // GET all categories
    public async Task<List<CategoryViewModel>?> GetCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<CategoryViewModel>>("api/Category");
    }
}