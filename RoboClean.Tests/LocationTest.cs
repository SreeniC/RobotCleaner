using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboClean.Tests
{
    [TestClass]
    public class LocationTest
    {
        [TestMethod]
        public void CreateLocation_CurrentLocation()
        {
            Location location = new Location(100,200);

            Assert.AreEqual(100, location.X);
            Assert.AreEqual(200, location.Y);
        }

        [TestMethod]
        public void CompareLocation_TwoPositionsSmallXvsLargeX()
        {
            Location location1 = new Location(100, 100);
            Location location2 = new Location(200, 100);

            Assert.AreEqual(-1, location1.CompareTo(location2));
        }

        [TestMethod]
        public void CompareLocation_TwoPositionsLargeXvsSmallX()
        {
            Location location1 = new Location(200, 100);
            Location location2 = new Location(100, 300);

            Assert.AreEqual(1, location1.CompareTo(location2));
        }

        [TestMethod]
        public void CompareLocation_TwoPositionsLargeYvsSmallY()
        {
            Location location1 = new Location(200, 500);
            Location location2 = new Location(200, 300);

            Assert.AreEqual(1, location1.CompareTo(location2));
        }

        [TestMethod]
        public void CompareLocation_TwoPositionsSameXandY()
        {
            Location location1 = new Location(200, 500);
            Location location2 = new Location(200, 500);

            Assert.AreEqual(0, location1.CompareTo(location2));
        }
    }
}
