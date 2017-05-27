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

        private RaceTrack racetrack; //will tell racer what race track is being used.
        private int currentPath; // will tell racer which subsection of the track is currently being run.
        private Random chaos = new Random(); //is the source of chaos for the game.
        private bool finished = false; //will be used to determine if racer needs to continue race
        private double delta_time; // the elapsed time between think calls
        private int base_speed; // the speed of the racers type. Dogs will be one speed Horses another. and more besides if you want to extend the types
        private double speed_delta; //add some variability in speed.
        private Stopwatch thinkTime = new Stopwatch(); //keeptrack of time

        public int Speed
        {
            get
            {
                return base_speed;
            }

            set
            {
                base_speed = value;
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

        public bool Finished
        {
            get
            {
                return finished;
            }

            set
            {
                finished = value;
            }
        }


        public event EventHandler OnWin;    //the event of the racer reaching end.
        public event EventHandler OnLoss;   //the event of the racer being beaten by another racer. Called from ForceLoss which is called from Game class

        public Racer(RaceTrack _track, Control racecontrol)
        {
            racetrack = _track;
            currentPath = 0;
            speed_delta = 1.0;
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
            if (Finished)
            {
                return;
            }
            if (racetrack.GetPath(currentPath).PastEnd(Me.Location)) //racer has reached end of current path. Time to swap to the next one
            {
                //Log.LogWrite("racetrack.GetPath(currentPath).B.X: " + racetrack.GetPath(currentPath).B.X +
                //            "\r\nracetrack.GetPath(currentPath).B.Y: " + racetrack.GetPath(currentPath).B.Y + "\r\n");
                if (racetrack.GetPath(currentPath).B.X == racetrack.GetLast().X && racetrack.GetPath(currentPath).B.Y == racetrack.GetLast().Y)
                {
                    if (OnWin != null)
                    {
                        OnWin(this, new EventArgs());
                    }
                    else
                    {
                        if (OnLoss != null)
                        {
                            OnLoss(this, new EventArgs());
                        }
                    }
                    Me.Location = racetrack.GetLast();
                    Finished = true;
                    return;
                }
                currentPath++;
                if (racetrack.GetPath(currentPath) == null)
                {
                    throw new Exception("Unexpected end of path");
                }
                //Me.Location = new Point(racetrack.GetPath(currentPath).A.X, racetrack.GetPath(currentPath).A.Y);
                speed_delta = chaos.Next(80, 120) / 100.0;
            }
            //moving
            var Distance = Math.Sqrt(Math.Pow(racetrack.GetPath(currentPath).B.X - Me.Location.X, 2) + Math.Pow(racetrack.GetPath(currentPath).B.Y - Me.Location.Y, 2));
            var DirectionX = (racetrack.GetPath(currentPath).B.X - Me.Location.X) / Distance;
            var DirectionY = (racetrack.GetPath(currentPath).B.Y - Me.Location.Y) / Distance;
            Me.Location = new Point(Me.Location.X + (int)(DirectionX * (base_speed * speed_delta) * delta_time),
                                        Me.Location.Y + (int)(DirectionY * (base_speed * speed_delta) * delta_time));
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
            Speed = 100;
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
