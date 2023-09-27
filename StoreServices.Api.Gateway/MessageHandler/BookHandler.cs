using Newtonsoft.Json;
using StoreServices.API.Gateway.Models;
using System.Diagnostics;

namespace StoreServices.API.Gateway.MessageHandler
{
    public class BookHandler : DelegatingHandler
    {
        private readonly ILogger<BookHandler> _logger;

        public BookHandler(ILogger<BookHandler> logger)
        {
            _logger = logger;
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
                _logger.LogInformation($"Finished request {request.RequestUri} in {time.ElapsedMilliseconds}ms at {DateTime.Now} with response {content}");
            }

            _logger.LogInformation($"Finished request {request.RequestUri} in {time.ElapsedMilliseconds}ms at {DateTime.Now}");
            return response;
        }
    }
}
