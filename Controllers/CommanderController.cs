
using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommanderControllers : ControllerBase
    {
        private readonly ICommanderRepo repostory;
        private readonly IMapper _map;
        public CommanderControllers(ICommanderRepo repo, IMapper map)
        {
            repostory = repo;
            _map = map;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandDto>> GetAllCommands()
        {
            var commanders = repostory.GetAppCommands();
            return Ok(_map.Map<IEnumerable<CommandDto>>(commanders));
        }
        [HttpGet("{id}")]
        public ActionResult<CommandDto> GetCommandById(int id)
        {
            var commander = repostory.GetCommandById(id);
            if (commander != null)
            {
                return Ok(_map.Map<CommandDto>(commander));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<CommandDto> CreateCommand(CommandCreateDto cmdCreate)
        {
            var cmd = _map.Map<Command>(cmdCreate);
            repostory.CreateCommand(cmd);
            return Ok(cmd);
        }

        [HttpPut("{id}")]
        public ActionResult<CommandDto> UpdateCommand(int id, CommandUpdateDto cmdUpdate)
        {
            var cmdModel = repostory.GetCommandById(id);
            if (cmdModel == null)
            {
                return NotFound();
            }
            _map.Map(cmdUpdate, cmdModel);
            repostory.UpdateCommand(cmdModel);
            repostory.SaveChange();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<CommandDto> DeleteCommand(int id)
        {
            var cmd = repostory.GetCommandById(id);
            if (cmd == null)
            {
                return NotFound();
            }
            repostory.DeleteComamd(cmd);
            repostory.SaveChange();
            return NoContent();
        }

    }
}