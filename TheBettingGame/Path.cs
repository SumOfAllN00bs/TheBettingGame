using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheBettingGame
{
    public class Path
    {
        private Point A1;
        private Point B1;
        private int radius;

        public Point A
        {
            get
            {
                return A1;
            }

            set
            {
                A1 = value;
            }
        }

        public Point B
        {
            get
            {
                return B1;
            }

            set
            {
                B1 = value;
            }
        }

        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
            }
        }

        public Path()
        {
            radius = 3;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(B1.X - A1.X, 2) + Math.Pow(B1.Y - A1.Y, 2)); //calculates the length between two points
        }

        public bool NearEnd(Point foreign)
        {
            if ((foreign.X > B.X - Radius) && (foreign.X < B.X + Radius) && (foreign.Y > B.Y - Radius) && (foreign.Y < B.Y + Radius))
            {
                return true;
            }
            else return false;
        }
        public bool PastEnd(Point foreign)
        {
            var Distance = Math.Sqrt(Math.Pow(foreign.X - A1.X, 2) + Math.Pow(foreign.Y - A1.Y, 2));

            if (Distance >= this.Length())
            {
                return true;
            }
            else return false;
        }
    }
}
