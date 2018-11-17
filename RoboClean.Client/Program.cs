using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboClean.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get input commands
            CommandFactory commandFactory = new CommandFactory();

            Console.WriteLine("Enter Inputs:");

            while (!commandFactory.IsInputComplete)
            {
                Console.WriteLine(">");
                commandFactory.AddInputs(Console.ReadLine());
    
            }
            Console.WriteLine("Input Complete, Press any key to continue..");
            Console.ReadLine();
            
            //Execute commands 
            SimpleReporter reporter = new SimpleReporter();
            Robot robo = new Robot(commandFactory.GetCommandSet(), reporter, new Location(0, 0), new Location(10, 10));
            robo.ExecuteCommands();

            //Reports number of places cleaned
            Console.WriteLine(reporter.ReportOutPut());

            Console.ReadLine();
        }
    }
}
