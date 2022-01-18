using CommandService.EventProcessing;

namespace CommandService.AsyncDataServices
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly IEventProcessor eventProcessor;

        public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
        {
            this.configuration = configuration;
            this.eventProcessor = eventProcessor;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}