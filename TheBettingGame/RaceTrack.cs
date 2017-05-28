using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheBettingGame
{
    public class RaceTrack
    {
        private List<Point> trackpositions;
        private int _XOffset = 0;
        private int _YOffset = 0;
        
        public int XOffset
        {
            get
            {
                return _XOffset;
            }

            set
            {
                _XOffset = value;
            }
        }

        public int YOffset
        {
            get
            {
                return _YOffset;
            }

            set
            {
                _YOffset = value;
            }
        }

        public Path GetPath(int i)
        {
            Log.LogWrite("i: " + i);
            if (trackpositions.Count > 1 && i < trackpositions.Count - 1)
            {
                Path p = new Path();
                p.A = trackpositions[i];
                p.B = trackpositions[i + 1];

                return p;
            }
            return null;
        }
        public Point GetLast()
        {
            return trackpositions.Last();
        }

        public void SetTrackPositions(List<Point> _trackPos) //accepts a list of points and offsets the points if needed
        {
            trackpositions = _trackPos;
            if (_XOffset != 0)
            {
                for (int i = 0; i < trackpositions.Count; i++)
                {
                    trackpositions[i] = new Point( trackpositions[i].X + _XOffset, trackpositions[i].Y);
                }
            }
            if (_YOffset != 0)
            {
                for (int i = 0; i < trackpositions.Count; i++)
                {
                    trackpositions[i] = new Point(trackpositions[i].X, trackpositions[i].Y + _YOffset);
                }
            }
        }
        public List<Point> GetTrackPositions()
        {
            return trackpositions;
        }
    }
}
