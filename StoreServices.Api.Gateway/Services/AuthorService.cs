using StoreServices.API.Gateway.Interfaces;
using StoreServices.API.Gateway.Models;
using System.Text.Json;

namespace StoreServices.API.Gateway.Services
{
    public class AuthorService : IAuthor
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IHttpClientFactory httpClientFactory, ILogger<AuthorService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<(bool result, Author author, string errorMessage)> GetAuthor(Guid authorId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("AuthorService");
                var response = await client.GetAsync($"/author/{authorId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Author>(content, options);
                    return (true, result, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
