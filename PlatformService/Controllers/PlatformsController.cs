using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Model;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo platformRepo;
        private readonly IMapper mapper;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            this.platformRepo = platformRepo;
            this.mapper = mapper;
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
            var mappedObj = mapper.Map<Platform>(platformCreateDto);


            return Ok();
        }
    }
}