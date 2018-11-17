using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace RoboClean.Tests
{
    [TestClass]
    public class ReportTest
    {
        [TestMethod]
        public void Reporter_CaseExecPerformance()
        {
            SimpleReporter simpleReporter = new SimpleReporter();

            Location currentPosition = new Location(0,0);
            var timer = Stopwatch.StartNew();
            //2300 Cases
            for (int i = 0; i < 2300; i++)
            {
                currentPosition = new Location(currentPosition.X, currentPosition.Y + 1);

                simpleReporter.RegisterNewPosition(currentPosition);
            }
            timer.Stop();
            var elapsedTimeSet1 = timer.Elapsed;

            timer = Stopwatch.StartNew();
            
            //9200 Cases
            for (int i = 0; i < 9200; i++)
            {
                currentPosition = new Location(currentPosition.X, currentPosition.Y + 1);

                simpleReporter.RegisterNewPosition(currentPosition);
            }
            timer.Stop();
            var elapsedTimeSet2 = timer.Elapsed;

            Assert.IsTrue(elapsedTimeSet2.Milliseconds <= elapsedTimeSet1.Milliseconds * 10,
                elapsedTimeSet2.Milliseconds + " Vs " + elapsedTimeSet1.Milliseconds * 10);
        }
    }
}
