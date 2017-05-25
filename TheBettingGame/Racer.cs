using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Random chaos = new Random();
        private bool finished = false;
        private long delta_time;
        private Stopwatch thinkTime = new Stopwatch();

        public event EventHandler OnWin;    //the event of the racer reaching end.
        public event EventHandler OnLoss;   //the event of the racer being beaten by another racer. Called from ForceLoss which is called from Game class

        public Racer(RaceTrack _track)
        {
            racetrack = _track;
            currentPath = racetrack.GetPath(0);
        }
        public void Think()
        {
            if (thinkTime.IsRunning)
            {
                thinkTime.Stop();
                delta_time = thinkTime.ElapsedMilliseconds;
            }
            if (finished)
            {
                return;
            }
            if (currentPosition.Equals(racetrack.GetLast()))
            {
                OnWin(this, new EventArgs());
                return;
            }
            //currentPosition.X = currentPosition.X + (currentPath.B.X - currentPosition.X) * ((5 * delta_time) / 1);
            //currentPosition.Y = currentPosition.Y + (currentPath.B.Y - currentPosition.Y) * ((5 * delta_time) / 1);
            if (!thinkTime.IsRunning)
            {
                thinkTime.Start();
            }
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
