using Newtonsoft.Json;
using StoreServices.API.Gateway.Interfaces;
using StoreServices.API.Gateway.Models;
using System.Diagnostics;
using System.Text;

namespace StoreServices.API.Gateway.MessageHandler
{
    public class BookHandler : DelegatingHandler
    {
        private readonly ILogger<BookHandler> _logger;
        private readonly IAuthor _authorService;

        public BookHandler(ILogger<BookHandler> logger, IAuthor authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        { 
            var time = Stopwatch.StartNew();
            _logger.LogInformation($"Starting request {request.RequestUri} at {DateTime.Now}");
            var response = await base.SendAsync(request, cancellationToken);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Book>(content);
                var authorResponse = await _authorService.GetAuthor(result.AuthorID);
                if (authorResponse.result)
                {
                    var author = authorResponse.author;
                    result.Author = author;
                    response.Content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
                }


                _logger.LogInformation($"Finished request {request.RequestUri} in {time.ElapsedMilliseconds}ms at {DateTime.Now} with response {content}");
            }

            _logger.LogInformation($"Finished request {request.RequestUri} in {time.ElapsedMilliseconds}ms at {DateTime.Now}");
            return response;
        }
    }
}
