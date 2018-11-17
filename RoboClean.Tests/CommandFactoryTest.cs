using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboClean.Tests
{
    [TestClass]
    public class CommandFactoryTest
    {
        [TestMethod]
        public void CreateCommandFactory_AddTwoInputCommands()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("2");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E 2");
            commandFactory.AddInputs("N 1");

            Assert.IsTrue(commandFactory.IsInputComplete);
        }
        [TestMethod]
        public void CreateCommandFactory_AddThreeInputcommands()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("3");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E 2");
            commandFactory.AddInputs("N 1");
            commandFactory.AddInputs("S 2");

            Assert.IsTrue(commandFactory.IsInputComplete);
        }

        [TestMethod]
        public void CreateCommandFactory_AddZeroInputCommands()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("0");
            commandFactory.AddInputs("10 22");

            Assert.IsTrue(commandFactory.IsInputComplete);
        }

        [TestMethod]
        public void CreateCommandFactory_AddTenThousandInputCommands()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("10000");
            commandFactory.AddInputs("10 22");

            for (int i = 0; i < 10000; i++)
            {
                commandFactory.AddInputs("N 1");
            }

            Assert.IsTrue(commandFactory.IsInputComplete);
        }

        [TestMethod]
        public void CreateCommandFactory_AddNegativeInputCommands()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("-1");
            commandFactory.AddInputs("10 22");

            commandFactory.AddInputs("N 1");

            Assert.IsTrue(commandFactory.IsInputComplete);
        }

        [TestMethod]
        public void CreateCommandFactory_AddTwentyThousandInputCommands()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("12000");
            commandFactory.AddInputs("10 22");

            for (int i = 0; i < 20000; i++)
            {
                commandFactory.AddInputs("N 1");
            }

            Assert.IsTrue(commandFactory.IsInputComplete);
        }

        [TestMethod]
        public void CreateCommandFactory_NormalPosition()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("0");
            commandFactory.AddInputs("10 22");

            Assert.AreEqual(10,commandFactory.commandSet.StartPosition.X);
            Assert.AreEqual(22, commandFactory.commandSet.StartPosition.Y);
        }

        [TestMethod]
        public void CreateCommandFactory_TabSeparatorNormalPosition()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("0");
            commandFactory.AddInputs("10\t22");

            Assert.AreEqual(10, commandFactory.commandSet.StartPosition.X);
            Assert.AreEqual(22, commandFactory.commandSet.StartPosition.Y);
        }

        [TestMethod]
        public void CreateCommandFactory_SingleMoveCommand()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("2");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E 2");

            Assert.AreEqual(1,commandFactory.commandSet.MoveCommands.Count);
        }

        [TestMethod]
        public void CreateCommandFactory_SingleMoveCommandWithMoreSteps()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("2");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E 200000");
            MoveCommand moveCommand = commandFactory.commandSet.MoveCommands[0];

            Assert.AreEqual(99999, moveCommand.MoveSteps);
        }

        [TestMethod]
        public void CreateCommandFactory_SingleMoveCommandWithLessSteps()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("2");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E -1");
            MoveCommand moveCommand = commandFactory.commandSet.MoveCommands[0];

            Assert.AreEqual(1, moveCommand.MoveSteps);
        }

        [TestMethod]
        public void CommandFactory_NullCommandSet()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("3");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E -1");
            
            CommandSet commandSet = commandFactory.GetCommandSet();

            Assert.IsNull(commandSet);
        }

        [TestMethod]
        public void CommandFactory_NotNullCommandSet()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("3");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E -1");
            commandFactory.AddInputs("E -1");
            commandFactory.AddInputs("E -1");

            CommandSet commandSet = commandFactory.GetCommandSet();

            Assert.IsNotNull(commandSet);
        }

        [TestMethod]
        public void CommandFactory_4CommandSet()
        {
            CommandFactory commandFactory = new CommandFactory();
            commandFactory.AddInputs("4");
            commandFactory.AddInputs("10 22");
            commandFactory.AddInputs("E -1");
            commandFactory.AddInputs("E -1");
            commandFactory.AddInputs("E -1");
            commandFactory.AddInputs("E -1");

            CommandSet commandSet = commandFactory.GetCommandSet();

            Assert.AreEqual(4,commandSet.MoveCommands.Count);
        }
    }
}
