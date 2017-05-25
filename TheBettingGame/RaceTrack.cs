using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    public class RaceTrack
    {
        private List<Point> trackpositions;
        private int currentPath = -1;

        internal List<Point> TrackPositions
        {
            get
            {
                return trackpositions;
            }

            set
            {
                trackpositions = value;
            }
        }
        public Path GetNext()
        {
            currentPath += 1;
            return GetPath(currentPath);
        }
        protected Path GetPath(int i)
        {
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
    }
}
