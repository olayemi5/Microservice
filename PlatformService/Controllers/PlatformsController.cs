using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Model;
using PlatformService.SyncDataService.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo platformRepo;
        private readonly IMapper mapper;
        private readonly ICommandDataClient commandDataClient;

        public PlatformsController(
            IPlatformRepo platformRepo,
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            this.platformRepo = platformRepo;
            this.mapper = mapper;
            this.commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("---> Getting Platforms");

            var platforms = platformRepo.GetAllPlatform();

            var mappedResult = mapper.Map<IEnumerable<PlatformReadDto>>(platforms);

            return Ok(mappedResult);
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.WriteLine("---> Getting Platform by id");

            var platform = platformRepo.GetPlatformById(id);

            if (platform == null) return NotFound();

            var mappedResult = mapper.Map<PlatformReadDto>(platform);

            return Ok(mappedResult);
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            if (platformCreateDto == null) return BadRequest();

            var mappedObj = mapper.Map<Platform>(platformCreateDto);
            platformRepo.CreatePlatform(mappedObj);

            var platformReadDto = mapper.Map<PlatformReadDto>(mappedObj);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}