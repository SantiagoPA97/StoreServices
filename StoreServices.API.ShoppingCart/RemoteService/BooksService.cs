using StoreServices.API.ShoppingCart.Interfaces;
using StoreServices.API.ShoppingCart.RemoteModel;
using System.Text.Json;

namespace StoreServices.API.ShoppingCart.RemoteService
{
    public class BooksService : IBooksService
    {
        private readonly IHttpClientFactory _client;
        private readonly ILogger<BooksService> _logger;
        public BooksService(IHttpClientFactory client, ILogger<BooksService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<(bool result, Book book, string errorMessage)> GetBook(Guid BookID)
        {
            try
            {
                var response = await _client.CreateClient("Books").GetAsync($"api/books/{BookID}");
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<Book>(content, options);
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
