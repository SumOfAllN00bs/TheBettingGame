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
        private int currentPath;
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
            currentPath = 0;
            _me = racecontrol;
            _me.Location = new Point((int)racetrack.GetPath(currentPath).A.X, (int)racetrack.GetPath(currentPath).A.Y);
        }
        public void Think()
        {
            if (thinkTime.IsRunning)
            {
                thinkTime.Stop();
                delta_time = thinkTime.ElapsedMilliseconds / 1000.0;
                thinkTime.Reset();
            }
            if (finished)
            {
                return;
            }
            if (racetrack.GetPath(currentPath).PastEnd(Me.Location)) //racer has reached end of current path. Time to swap to the next one
            {
                //Log.LogWrite("racetrack.GetPath(currentPath).B.X: " + racetrack.GetPath(currentPath).B.X +
                //            "\r\nracetrack.GetPath(currentPath).B.Y: " + racetrack.GetPath(currentPath).B.Y + "\r\n");
                if (racetrack.GetPath(currentPath).B.X == racetrack.GetLast().X && racetrack.GetPath(currentPath).B.Y == racetrack.GetLast().Y)
                {
                    OnWin(this, new EventArgs());
                    Me.Location = racetrack.GetLast();
                    finished = true;
                    return;
                }
                currentPath++;
                if (racetrack.GetPath(currentPath) == null)
                {
                    throw new Exception("Unexpected end of path");
                }
                Me.Location = new Point(racetrack.GetPath(currentPath).A.X, racetrack.GetPath(currentPath).A.Y);

            }
            //moving
            var Distance = Math.Sqrt(Math.Pow(racetrack.GetPath(currentPath).B.X - Me.Location.X, 2) + Math.Pow(racetrack.GetPath(currentPath).B.Y - Me.Location.Y, 2));
            var DirectionX = (racetrack.GetPath(currentPath).B.X - Me.Location.X) / Distance;
            var DirectionY = (racetrack.GetPath(currentPath).B.Y - Me.Location.Y) / Distance;
            Me.Location = new Point(Me.Location.X + (int)(DirectionX * speed * delta_time + chaos.Next(10, 100)),
                                        Me.Location.Y + (int)(DirectionY * speed * delta_time));
            //Log.LogWrite(   "Location.X: " + Me.Location.X +
            //                "\r\nLocation.Y: " + Me.Location.Y +
            //                "\r\nDeltaTime: " + delta_time.ToString() + "\r\n");
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
            Speed = 70;
        }
    }
    public class Horse : Racer
    {
        public Horse(RaceTrack rt, Control rc) : base(rt, rc)
        {
            Speed = 150;
        }
    }
}
