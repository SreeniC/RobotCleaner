using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboClean
{
   public class Robot
    {
       public Location Position { get; set; }

       CommandSet commandSet;
       readonly IReport reporter;
       readonly Location bottomLeft;
       readonly Location topRight;
       

       public Robot(CommandSet cmdSet, IReport reportOutput) : this(cmdSet, reportOutput, null, null)
       {
       }
        
       public Robot(CommandSet cmdSet, IReport reportOutput,Location blBound, Location trBound)
       {
          commandSet = cmdSet;
          Position = commandSet.StartPosition;
          reporter = reportOutput;
          bottomLeft = blBound;
          topRight = trBound;
       }

       public void ExecuteCommands()
       {
           foreach (MoveCommand cmd in commandSet.MoveCommands)
           {
               for (int i = 0; i < cmd.MoveSteps; i++)
               {
                   MoveRobot(cmd);
               }
           }
       }

       private void MoveRobot(MoveCommand cmd)
       {
           switch (cmd.MoveDirection)
           {
               case Direction.North: Position = new Location(Position.X, Position.Y + 1);
                   break;
               case Direction.East: Position = new Location(Position.X + 1, Position.Y);
                   break;
               case Direction.Sourth: Position = new Location(Position.X, Position.Y - 1);
                   break;
               case Direction.West: Position = new Location(Position.X - 1, Position.Y);
                   break;
 
               default:
                   break;
           }

           Position.Validate(bottomLeft,topRight);
           
           if (reporter != null)
                reporter.RegisterNewPosition(Position);
       }

       internal string ReportOutPut()
       {
           if (reporter == null)
           {
               return "=> Cleaned: unknown";    
           }
           return reporter.ReportOutPut();    
       }
    }
}
