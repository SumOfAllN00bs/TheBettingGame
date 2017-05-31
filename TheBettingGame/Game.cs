using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBettingGame
{
    public class Game
    {
        private List<Racer> runners = new List<Racer>();
        private List<RaceTrack> trackandfield = new List<RaceTrack>();
        private List<Control> RacingAnimalsBodies = new List<Control>();
        private List<Bettor> puntList = new List<Bettor>();
        Form1 TheBettingGameForm;
        private int currentBettor = -1;

        public int CurrentBettor
        {
            get
            {
                return currentBettor;
            }

            set
            {
                currentBettor = value;
            }
        }
        public Game(List<Racer> _run, List<RaceTrack> _track, List<Bettor> _punt, Form1 _TheBettingGameForm)
        {
            runners = _run;
            trackandfield = _track;
            puntList = _punt;
            //need access to form to do things like Stop the timer
            TheBettingGameForm = _TheBettingGameForm;
        }
        public void GameTic()
        {
            int RacersFinished = 0;
            foreach (Racer _racer in runners)
            {
                if (_racer.Finished)
                {
                    RacersFinished += 1;
                    continue;
                }
                _racer.Think();
                _racer.Me.Refresh();
            }
            if (RacersFinished == runners.Count)
            {
                TheBettingGameForm.StopGame();
            }
        }
        public void WinnerFound(object o, EventArgs e)
        {
            foreach (Racer R in runners)
            {
                if (R.Equals(o))
                {
                    R.Won = true;
                    continue;
                }
                else
                {
                    R.Won = false;
                    R.ForceLoss();
                    R.ClearWin();
                }
            }
        }
        public void NewDefaultGame()
        {
            Log.LogWrite("Game Started.");
            List<Point> OvalPoints = new List<Point>() {    new Point(664, 58),
                                                            new Point(745, 77),
                                                            new Point(817, 99),
                                                            new Point(889, 139),
                                                            new Point(959, 213),
                                                            new Point(974, 290),
                                                            new Point(932, 369),
                                                            new Point(853, 428),
                                                            new Point(740, 469),
                                                            new Point(617, 492),
                                                            new Point(497, 493),
                                                            new Point(384, 485),
                                                            new Point(260, 454),
                                                            new Point(165, 407),
                                                            new Point(99, 346),
                                                            new Point(78, 298),
                                                            new Point(79, 234),
                                                            new Point(131, 156),
                                                            new Point(213, 106),
                                                            new Point(292, 77),
                                                            new Point(351, 63),
                                                            new Point(372, 58)};

            //Setup Racers
            for (int i = 0; i < 4; i++)
            {
                //Create Control
                PictureBox PB = new PictureBox();
                PB.Image = global::TheBettingGame.Properties.Resources.dog_running_bw1;
                PB.SizeMode = PictureBoxSizeMode.StretchImage;
                PB.Name = "Racer_Dog" + i;
                PB.Tag = (i + 1).ToString(); //Used for the Paint Method later on
                PB.Paint += pb_Picture_Paint;
                RacingAnimalsBodies.Add(PB);
                TheBettingGameForm.Controls.Add(PB);
                PB.BringToFront();

                //Create RaceTrack
                RaceTrack RT = new RaceTrack();

                //Using the points in Oval Points each Racer will get an Offset to use to alter the path of the race track so each racer races on their own track.
                //this makes it so that the racers are easier to distinguish when they overlap they only overlap by a small amount
                int OffsetSize = 50; //the size of the gap between each racetrack
                int OffsetZero = 2; //2 means third track
                RT.XOffset = (i * OffsetSize) - OffsetSize * OffsetZero; //this will zero out the offset for the OffsetZero Track number
                RT.SetTrackPositions(new List<Point>(OvalPoints));
                trackandfield.Add(RT);

                //Create Racers
                Dog d = new Dog(RT, PB);
                d.OnWin += WinnerFound;
                runners.Add(d);
            }
        }
        private void pb_Picture_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Arial", 14))
            {
                try
                {
                    //e.Graphics.DrawString(((PictureBox)sender).Tag.ToString(), myFont, Brushes.Blue, new Point(2, 2));
                    e.Graphics.DrawString(runners[Convert.ToInt16(((PictureBox)sender).Tag) - 1].Name, myFont, Brushes.BlueViolet, new Point(2, 2));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
