using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using CommandService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controller
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ICommandRepo commandRepo;
        private readonly IMapper mapper;

        public PlatformsController(IConfiguration configuration, ICommandRepo commandRepo, IMapper mapper)
        {
            this.configuration = configuration;
            this.commandRepo = commandRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            var platformItems = commandRepo.GetPlatforms();
            var mappedData = mapper.Map<IEnumerable<PlatformReadDto>>(platformItems);

            return Ok(mappedData);
        }

        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("--> Inbound POST command Service" + configuration["PlatformService"]);

            return Ok("Inbound test ok from platform service" + configuration["PlatformService"]);
        }
    }
}