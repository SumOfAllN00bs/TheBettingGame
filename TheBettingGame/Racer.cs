using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    class Racer
    {

        private RaceTrack racetrack;
        private Point currentPosition; //where on the screen the racer is currently located at
        private Path currentPath;

        public event EventHandler OnWin;    //the event of the racer reaching end.
        public event EventHandler OnLoss;   //the event of the racer being beaten by another racer. Called from ForceLoss which is called from Game class

        public Racer(RaceTrack _track)
        {
            racetrack = _track;
            currentPath = racetrack.GetPath(0);
        }
        public void ForceLoss()
        {
            if (OnLoss != null)
            {
                OnLoss(this, new EventArgs());
            }
        }
        public void ClearEvents()
        {
            OnWin = null;
            OnLoss = null;
        }

    }
}
