using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
        public void CreateCommand(Command cmd);

        public void UpdateCommand(Command updatecmd);
        public void DeleteComamd(Command deletecmd);

        public bool SaveChange();
    }
}