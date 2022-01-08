using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controller
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }

        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("--> Inbound POST command Service");

            return Ok("Inbound test ok from platform service");
        }
    }
}