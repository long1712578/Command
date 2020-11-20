using System;
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

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
            _context.SaveChanges();
        }

        public void DeleteComamd(Command deletecmd)
        {
            if (deletecmd == null)
            {
                throw new ArgumentNullException(nameof(deletecmd));
            }
            _context.Commands.Remove(deletecmd);
            _context.SaveChanges();
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

        public bool SaveChange()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCommand(Command updatecmd)
        {
            //
        }
    }
}