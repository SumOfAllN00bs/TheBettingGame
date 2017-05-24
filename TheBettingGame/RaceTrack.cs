using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    class RaceTrack
    {
        private List<Point> trackpositions;

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
    }
}
