using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{

    public class CommanderRepo : ICommanderRepo
    {
        private readonly CommandDbContext _context;
        public CommanderRepo(CommandDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = _context.Commands.ToList();

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.Find(id);
        }
    }
}