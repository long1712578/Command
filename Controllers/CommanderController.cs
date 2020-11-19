
using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommanderControllers:ControllerBase{
        private readonly ICommanderRepo repostory;
        public CommanderControllers(ICommanderRepo repo){
            repostory=repo;
        }
        [HttpGet]
        public  ActionResult <IEnumerable<Command>> GetAllCommands(){
            var commanders=repostory.GetAppCommands();
            return Ok(commanders);
        }
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id){
            var commander=repostory.GetCommandById(id);
            return Ok(commander);
        }

    }
}