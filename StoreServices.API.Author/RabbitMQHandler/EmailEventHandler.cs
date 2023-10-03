using StoreServices.RabbitMQ.Bus;
using StoreServices.RabbitMQ.Bus.EventQueue;

namespace StoreServices.API.Author.RabbitMQHandler
{
    public class EmailEventHandler : IEventHandler<EmailEventQueue>
    {
        private readonly ILogger<EmailEventHandler> _logger;

        public EmailEventHandler(ILogger<EmailEventHandler> logger)
        {
            _logger = logger;
        }

        public EmailEventHandler()
        {
            
        }

        public Task Handle(EmailEventQueue @event)
        {
            _logger.LogInformation($"This is the message value {@event.Title}");
            return Task.CompletedTask;
        }
    }
}
