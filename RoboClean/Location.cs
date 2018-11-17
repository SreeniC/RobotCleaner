using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboClean
{
   public class Location : IComparable<Location>
   {
        private int x;
        private int y;

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } }
        public int Y { get { return y; } }

        internal void Validate(Location bottomLeft, Location topRight)
        {
            if (bottomLeft!=null)
            {
                if (x < bottomLeft.x) x = bottomLeft.x; 
                if (y < bottomLeft.y) y = bottomLeft.y;
            }
            if (topRight!=null)
            {
                if (x > topRight.x) x = topRight.x;
                if (y > topRight.y) y = topRight.y;
            }
        }

        public override string ToString()
        {
                return x + "$" + y;
        }

        public int CompareTo(Location other)
        {
            if (this.X == other.X)
            {
                return this.Y.CompareTo(other.Y);      
            }
            else
            {
                return this.X.CompareTo(other.X);
            }
        }
   }
}
