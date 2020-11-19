
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
    public class CommanderControllers:ControllerBase{
        private readonly ICommanderRepo repostory;
        private readonly IMapper _mapper;
        public CommanderControllers(ICommanderRepo repo,IMapper mapper){
            repostory=repo;
            _mapper=mapper;
        }
        [HttpGet]
        public  ActionResult <IEnumerable<CommandDto>> GetAllCommands(){
            var commanders=repostory.GetAppCommands();
            return Ok(_mapper.Map<IEnumerable<CommandDto>>(commanders));
        }
        [HttpGet("{id}")]
        public ActionResult <CommandDto> GetCommandById(int id){
            var commander=repostory.GetCommandById(id);
            if(commander!=null){
                return Ok(_mapper.Map<CommandDto>(commander));
            }
            return NotFound();
        }

    }
}