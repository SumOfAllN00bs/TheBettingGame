using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    public class Point
    {
        private double _x;
        private double _y;
        private bool _end;

        public Point()
        {
            _x = 0;
            _y = 0;
            _end = false;
        }
        public Point(double x, double y, bool e)
        {
            _x = x;
            _y = y;
            _end = e;
        }

        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public bool End
        {
            get
            {
                return _end;
            }

            set
            {
                _end = value;
            }
        }
    }
}
