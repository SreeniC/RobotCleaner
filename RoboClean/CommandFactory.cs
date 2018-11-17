using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboClean
{
    public class CommandFactory
    {
        const int MaxSteps = 99999;
        const int MinSteps = 1;

        List<string> inputStrings;

        internal readonly CommandSet commandSet;

        public CommandFactory()
        {
            inputStrings = new List<string>();
            commandSet = new CommandSet();
        }

        public void AddInputs(string input)
        {
            if (!IsInputComplete)
            {
                if (inputStrings.Count == 0)
                {
                    SetCommandCount(input);
                }
                else if (inputStrings.Count == 1)
                {
                    SetStartPosition(input);
                }
                else
                {
                   commandSet.MoveCommands.Add(ParseMoveCommand(input));
                }
                inputStrings.Add(input);
            }
        }

        private MoveCommand ParseMoveCommand(string input)
        {
           MoveCommand moveCommand = new MoveCommand();
           string[] moveInputBits = input.Split(null);
           if (moveInputBits.Length>1)
           {
               switch (moveInputBits[0].ToUpper())
               {
                   case "N": moveCommand.MoveDirection = Direction.North;
                       break;
                   case "E": moveCommand.MoveDirection = Direction.East;
                       break;
                   case "S": moveCommand.MoveDirection = Direction.Sourth;
                       break;
                   case "W": moveCommand.MoveDirection = Direction.West;
                       break;
                   default: moveCommand.MoveDirection = Direction.Unknown;
                       break;
               }
               moveCommand.MoveSteps = int.Parse(moveInputBits[1]);
               
               if (moveCommand.MoveSteps > MaxSteps) moveCommand.MoveSteps = MaxSteps;
               if (moveCommand.MoveSteps < MinSteps) moveCommand.MoveSteps = MinSteps;
           }
           return moveCommand;
        }

        private void SetStartPosition(string input) {
            string[] coordinateBits = input.Split(null);
            if (coordinateBits.Length>1)
            {
                int x = int.Parse(coordinateBits[0]);
                int y = int.Parse(coordinateBits[1]);

              commandSet.StartPosition = new Location(x,y);
            }
        }

        private void SetCommandCount(string input) {
            commandSet.CommandsCount = int.Parse(input);
            if (commandSet.CommandsCount < 0) { commandSet.CommandsCount = 0; }
            else if (commandSet.CommandsCount > 10000) { commandSet.CommandsCount = 10000; }
        }
               

        public bool IsInputComplete 
        { 
            get
            {
                return inputStrings.Count == commandSet.CommandsCount + 2;
            } 
        }

        public CommandSet GetCommandSet()
        {
            if (IsInputComplete)
            {
                return commandSet;
            }
            return null;
        }
    }
}
