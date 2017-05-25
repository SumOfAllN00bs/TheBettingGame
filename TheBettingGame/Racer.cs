using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBettingGame
{
    public class Racer
    {
        private Control _me;

        private RaceTrack racetrack;
        private Point currentPosition; //where on the screen the racer is currently located at
        private Path currentPath;
        private Random chaos = new Random();
        private bool finished = false;
        private long delta_time;
        private int speed;
        private Stopwatch thinkTime = new Stopwatch();

        protected int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public Control Me
        {
            get
            {
                return _me;
            }

            set
            {
                _me = value;
            }
        }

        public event EventHandler OnWin;    //the event of the racer reaching end.
        public event EventHandler OnLoss;   //the event of the racer being beaten by another racer. Called from ForceLoss which is called from Game class

        public Racer(RaceTrack _track)
        {
            racetrack = _track;
            currentPath = racetrack.GetNext();
            currentPosition = currentPath.A;
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
            else if (currentPosition.Equals(currentPath.B)) //racer has reached end of current path. Time to swap to the next one
            {
                currentPath = racetrack.GetNext();
                if (currentPath == null)
                {
                    throw new Exception("Unexpected end of path");
                }
            }
            currentPosition.X = currentPosition.X + (currentPath.B.X - currentPosition.X) * ((5 * delta_time) / 1);
            currentPosition.Y = currentPosition.Y + (currentPath.B.Y - currentPosition.Y) * ((5 * delta_time) / 1);
            Me.Location = new System.Drawing.Point((int)currentPosition.X, (int)currentPosition.Y);
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

    public class Dog : Racer
    {
        public Dog(RaceTrack rt) : base(rt)
        {
            Speed = 10;
        }
    }
    public class Horse : Racer
    {
        public Horse(RaceTrack rt) : base(rt)
        {
            Speed = 30;
        }
    }
}
