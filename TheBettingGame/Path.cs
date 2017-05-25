using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    public class Path
    {
        private Point A1;
        private Point B1;

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

        public double Length()
        {
            return Math.Sqrt(Math.Pow(B1.X - A1.X, 2) + Math.Pow(B1.Y - A1.Y, 2)); //calculates the length between two points
        }
    }
}
