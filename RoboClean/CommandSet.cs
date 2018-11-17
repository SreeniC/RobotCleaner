using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboClean
{
    public class CommandSet
    {
        private int commandsCount;
        public int CommandsCount 
        { 
            get 
            { 
                return commandsCount; 
            }
            set 
            {
                commandsCount = value;
            }
        }

        private Location startPosition;
        public Location StartPosition 
        { 
            get
            {
                return startPosition;
            }
            set
            {
                startPosition = value;
            }
        }

        private List<MoveCommand> moveCommands;

        public List<MoveCommand> MoveCommands
        {
            get { return moveCommands; }
        }

        public CommandSet()
        {
            moveCommands = new List<MoveCommand>();
        }
    }
}
