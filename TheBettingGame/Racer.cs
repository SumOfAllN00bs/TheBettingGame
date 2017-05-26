using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TheBettingGame
{
    public class Racer
    {
        private Control _me;

        private RaceTrack racetrack;
        private Path currentPath;
        private Random chaos = new Random();
        private bool finished = false;
        private double delta_time;
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

        public Racer(RaceTrack _track, Control racecontrol)
        {
            racetrack = _track;
            currentPath = racetrack.GetNext();
            _me = racecontrol;
            _me.Location = new Point((int)currentPath.A.X, (int)currentPath.A.Y);
        }
        public void Think()
        {
            if (thinkTime.IsRunning)
            {
                thinkTime.Stop();
                delta_time = thinkTime.ElapsedMilliseconds/1000.0;
                thinkTime.Reset();
            }
            if (finished)
            {
                return;
            }
            if (Me.Location.Equals(racetrack.GetLast()))
            {
                OnWin(this, new EventArgs());
                return;
            }
            else if (currentPath.NearEnd(Me.Location)) //racer has reached end of current path. Time to swap to the next one
            {
                currentPath = racetrack.GetNext();
                Me.Location = new Point(currentPath.A.X, currentPath.A.Y);
                if (currentPath == null)
                {
                    throw new Exception("Unexpected end of path");
                }
            }
            //moving
            var VectorLength = Math.Sqrt(Math.Pow(currentPath.B.X - Me.Location.X, 2) + Math.Pow(currentPath.B.Y - Me.Location.Y, 2));
            Me.Location = new Point(    Me.Location.X + (int)((currentPath.B.X/VectorLength) * speed * delta_time), 
                                        Me.Location.Y + (int)((currentPath.B.Y/VectorLength) * speed * delta_time));
            Log.LogWrite("Location.X: " + Me.Location.X +
                        "\r\nLocation.Y: " + Me.Location.Y +
                        "\r\nDeltaTime: " + delta_time.ToString() + "\r\n");
            Me.Location = new Point((int)Me.Location.X, (int)Me.Location.Y);
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
        public Dog(RaceTrack rt, Control rc) : base(rt, rc)
        {
            Speed = 10;
        }
    }
    public class Horse : Racer
    {
        public Horse(RaceTrack rt, Control rc) : base(rt, rc)
        {
            Speed = 30;
        }
    }
}
