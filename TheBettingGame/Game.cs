using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBettingGame
{
    class Game
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
            TheBettingGameForm = _TheBettingGameForm;

            foreach (Racer R in runners)
            {
                R.OnWin += new EventHandler(WinnerFound);
                R.Speed = (int)(R.Speed + R.Speed * (new Random().Next(15, 30) / 100.0));
            }
        }
        public void GameTic()
        {
            foreach (Racer _racer in runners)
            {
                _racer.Think();
            }
        }
        public void WinnerFound(object o, EventArgs e)
        {
            foreach (Racer R in runners)
            {
                if (R.Equals(o))
                {
                    continue;
                }
                else
                {
                    R.ForceLoss();
                    R.ClearEvents();
                }
            }
        }
        public void NewDefaultGame()
        {
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
                PB.Name = "RadioButton_" + i.ToString();
                PB.Text = i.ToString();
                PB.Location = new System.Drawing.Point(52 + (i * 5), 58 + (i * 5));
                PB.Image = global::TheBettingGame.Properties.Resources.dog_running_bw1;
                PB.SizeMode = PictureBoxSizeMode.StretchImage;
                PB.BackColor = Color.Transparent;
                PB.Tag = (i + 1).ToString(); //Used for the Paint Method later on
                PB.Paint += pb_Picture_Paint;
                RacingAnimalsBodies.Add(PB);
                TheBettingGameForm.Controls.Add(PB);
                PB.BringToFront();

                //Create RaceTrack
                RaceTrack RT = new RaceTrack();
                int OffsetSize = 50; //the size of the gap between each racetrack
                int OffsetZero = 2; //2 means third track
                RT.XOffset = (i * OffsetSize) - OffsetSize * OffsetZero; //this will zero out the offset for the OffsetZero Track number
                RT.SetTrackPositions(new List<Point>(OvalPoints));
                trackandfield.Add(RT);

                //Create Racers
                Dog d = new Dog(RT, PB);
                runners.Add(d);
            }
            //Setup Bettors
            for (int i = 0; i < 3; i++)
            {
                //BettingAnimals.Add(new Bettor());
            }
        }
        private void pb_Picture_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Arial", 14))
            {
                e.Graphics.DrawString(((PictureBox)sender).Tag.ToString(), myFont, Brushes.DarkGray, new Point(2, 2));
            }
        }
    }
}
