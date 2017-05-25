using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBettingGame
{
    public partial class Form1 : Form
    {
        //int i = 0;
        private Game bettingGame;
        private List<Racer> RacingAnimals = new List<Racer>();
        private List<Bettor> BettingAnimals = new List<Bettor>();
        private RaceTrack OvalRaceTrack = new RaceTrack();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Point> OvalPoints = new List<Point>() {    new Point(812, 167, false),
                                                            new Point(902, 188, false),
                                                            new Point(988, 221, false),
                                                            new Point(1064, 270, false),
                                                            new Point(1118, 350, false),
                                                            new Point(1116, 417, false),
                                                            new Point(1033, 516, false),
                                                            new Point(932, 562, false),
                                                            new Point(816, 593, false),
                                                            new Point(717, 602, false),
                                                            new Point(1595, 601, false),
                                                            new Point(1471, 582, false),
                                                            new Point(1348, 536, false),
                                                            new Point(1273, 485, false),
                                                            new Point(1222, 410, false),
                                                            new Point(1235, 319, false),
                                                            new Point(1292, 260, false),
                                                            new Point(1366, 215, false),
                                                            new Point(1439, 187, false),
                                                            new Point(1521, 166, true)};
            OvalRaceTrack.TrackPositions = OvalPoints;
            //MessageBox.Show("Width: " + this.ClientSize.Width + " Height: " + this.ClientSize.Height
            for (int i = 0; i < 1; i++)
            {
                Dog d = new Dog(OvalRaceTrack);
                d.Me = radioButton1;
                RacingAnimals.Add(d);
            }
            for(int i = 0; i < 3; i++)
            {
                BettingAnimals.Add(new Bettor());
            }

            bettingGame = new Game(RacingAnimals, OvalRaceTrack, BettingAnimals);
        }

        private void pb_BackGround_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (StreamWriter sw = File.AppendText("points.txt"))
            //    {
            //        sw.WriteLine(i + ": " + Cursor.Position.X + ", " + Cursor.Position.Y);
            //        i++;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void gameTic_Tick(object sender, EventArgs e)
        {
            bettingGame.GameTic();
        }
    }
}
