using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controller
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public PlatformsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("--> Inbound POST command Service" + configuration["PlatformService"]);

            return Ok("Inbound test ok from platform service" + configuration["PlatformService"]);
        }
    }
}