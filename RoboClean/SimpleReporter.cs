using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboClean
{
    public class SimpleReporter: IReport
    {
        readonly SortedSet<Location> cleanedLocations; 
         
        public SimpleReporter ()
	    {
            cleanedLocations = new SortedSet<Location>();
	    }

        public string ReportOutPut()
        {
 	        return string.Format("=> Cleaned: {0}",cleanedLocations.Count);
        }

        public void RegisterNewPosition(Location position)
        {
            cleanedLocations.Add(position);
        }
    }
}
