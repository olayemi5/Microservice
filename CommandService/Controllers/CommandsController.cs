using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using CommandService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controller
{
    [ApiController]
    [Route("api/c/platforms/{platformId}/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICommandRepo commandRepo;

        public CommandsController(IMapper mapper, ICommandRepo commandRepo)
        {
            this.mapper = mapper;
            this.commandRepo = commandRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetPlatformCommands(int platformId)
        {
            System.Console.WriteLine($"--> Get command for platform Id {platformId}");

            if (commandRepo.PlatformExists(platformId))
            {
                return Ok(mapper.Map<CommandReadDto>(commandRepo.GetCommandForPlatform(platformId)));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{commandId}", Name = "GetPlatformCommand")]
        public ActionResult<CommandReadDto> GetPlatformCommand(int platformId, int commandId)
        {
            System.Console.WriteLine($"--> Get command for platform Id {platformId} and command Id {commandId}");

            if (commandRepo.PlatformExists(platformId))
            {
                return Ok(mapper.Map<CommandReadDto>(commandRepo.GetCommand(platformId, commandId)));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandDto)
        {
            System.Console.WriteLine($"--> Create platform with platform Id {platformId}");

            if (commandRepo.PlatformExists(platformId))
            {
                if (commandDto != null) return BadRequest(nameof(commandDto));
                var command = mapper.Map<Command>(commandDto);

                commandRepo.CreateCommand(platformId, command);
                var isSaved = commandRepo.SaveChanges();

                if (isSaved)
                {
                    var commadReadDto = mapper.Map<CommandReadDto>(commandDto);
                    return CreatedAtAction(nameof(GetPlatformCommand), new { platformId = commadReadDto.Id, }, commadReadDto);
                }
                else
                {
                    return new StatusCodeResult(500);
                }
            }
            else
            {
                return NotFound();
            }

        }
    }
}