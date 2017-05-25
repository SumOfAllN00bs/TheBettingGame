using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    public class Point : Object
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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Point p = obj as Point;
            if ((Object)p == null)
            {
                return false;
            }
            return (_x == p.X) && (_y == p.Y);
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
