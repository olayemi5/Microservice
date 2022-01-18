using PlatformService.Dtos;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration configuration;

        public MessageBusClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void PublishPlatform(PlatformPublishDto platformPublishDto)
        {
            throw new NotImplementedException();
        }
    }
}