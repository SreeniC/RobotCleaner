using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboClean.Tests
{
    [TestClass]
    public class RoboTest
    {
        [TestMethod]
        public void CreateRobot_RoboCreation()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("0");
            commandFactory.AddInputs("0 0");

            CommandSet commandSet = commandFactory.GetCommandSet();

            Robot robot = new Robot(commandSet,null);

            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void RunRobot_WithNoPositionChange()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("0");
            commandFactory.AddInputs("0 0");

            CommandSet commandSet = commandFactory.GetCommandSet();
            Robot robot = new Robot(commandSet, null);

            robot.ExecuteCommands();

            Assert.AreEqual(commandSet.StartPosition.X, robot.Position.X);
            Assert.AreEqual(commandSet.StartPosition.Y, robot.Position.Y);
        }

        [TestMethod]
        public void RunRobot_ZeroPlaceCleanReport()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("0");
            commandFactory.AddInputs("0 0");

            IReport reporter = new TestReporter();

            CommandSet commandSet = commandFactory.GetCommandSet();
            Robot robot = new Robot(commandSet, reporter);

            robot.ExecuteCommands();
            string report = robot.ReportOutPut();

            Assert.AreEqual("=> Cleaned: 0",report);
        }

        [TestMethod]
        public void RunRobot_EmptyCommandSetWithNullReport()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("0");
            commandFactory.AddInputs("0 0");

            CommandSet commandSet = commandFactory.GetCommandSet();
            Robot robot = new Robot(commandSet, null);

            robot.ExecuteCommands();
            string report = robot.ReportOutPut();

            Assert.AreEqual("=> Cleaned: unknown", report);
        }

        [TestMethod]
        public void RunRobot_SimpleCommandSetWithMovementBy1()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("1");
            commandFactory.AddInputs("0 0");
            commandFactory.AddInputs("N 1");

            CommandSet commandSet = commandFactory.GetCommandSet();
            Robot robot = new Robot(commandSet, null);

            robot.ExecuteCommands();

            Assert.AreEqual(commandSet.StartPosition.X, robot.Position.X);
            Assert.AreEqual(commandSet.StartPosition.Y+1, robot.Position.Y);
        }

        [TestMethod]
        public void RunRobot_OutofBoundsCommandSetWithMovements()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("1");
            commandFactory.AddInputs("100000 100000");
            commandFactory.AddInputs("N 1");

            CommandSet commandSet = commandFactory.GetCommandSet();
            Robot robot = new Robot(commandSet, null,null, new Location(100000,100000));

            robot.ExecuteCommands();

            Assert.AreEqual(commandSet.StartPosition.X, robot.Position.X);
            Assert.AreEqual(commandSet.StartPosition.Y, robot.Position.Y);
        }

        [TestMethod]
        public void RunRobot_SimpleCommandSetReportLocationCleaned()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("1");
            commandFactory.AddInputs("20 20");
            commandFactory.AddInputs("N 1");

            CommandSet commandSet = commandFactory.GetCommandSet();
            IReport reporter = new SimpleReporter();

            Robot robot = new Robot(commandSet, reporter, new Location(-100000, -100000), new Location(100000, 100000));

            robot.ExecuteCommands();

            string report = robot.ReportOutPut();

            Assert.AreEqual("=> Cleaned: 1", report);
        }

        [TestMethod]
        public void RunRobot_CommandSetWithLocationMovements()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("4");
            commandFactory.AddInputs("0 0");
            commandFactory.AddInputs("N 5");
            commandFactory.AddInputs("E 5");
            commandFactory.AddInputs("S 5");
            commandFactory.AddInputs("W 5");

            CommandSet commandSet = commandFactory.GetCommandSet();

            IReport reporter = new SimpleReporter();

            Robot robot = new Robot(commandSet, reporter, new Location(0, 0), new Location(5, 5));

            robot.ExecuteCommands();

            string report = robot.ReportOutPut();

            Assert.AreEqual("=> Cleaned: 20", report);
        }
    }
}
