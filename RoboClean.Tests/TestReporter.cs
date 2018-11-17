using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboClean.Tests
{
    class TestReporter : IReport
    {
        public string ReportOutPut()
        {
            return "=> Cleaned: 0";
        }

        public void RegisterNewPosition(Location Position)
        {
           
        }
    }
}
