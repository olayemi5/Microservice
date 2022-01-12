using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
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
        public ActionResult<IEnumerable<CommandReadDto>> GetPlatformCommands()
        {

        }
    }
}