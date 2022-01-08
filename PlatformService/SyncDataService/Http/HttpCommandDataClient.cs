using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        public HttpCommandDataClient(HttpClient client, IConfiguration configuration)
        {
            this.client = client;
            this.configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync($"{configuration["ComamndService"]}/api/c/platforms", httpContent);

            if (response.IsSuccessStatusCode) Console.WriteLine("--> Sync Post to Command Service was ok");
            else
            {
                Console.WriteLine("--> Sync Post to Command Service was bad");
            }
        }
    }
}