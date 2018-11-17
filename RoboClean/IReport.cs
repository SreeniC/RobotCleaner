using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboClean
{
    public interface IReport
    {
        string ReportOutPut();

        void RegisterNewPosition(Location Position);
    }
}
