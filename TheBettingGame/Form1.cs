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
        private Game bettingGame;
        private List<Racer> RacingAnimals = new List<Racer>();
        private List<Bettor> BettingAnimals = new List<Bettor>();
        private RaceTrack OvalRaceTrack = new RaceTrack();
        public Form1()
        {
            InitializeComponent();
            Log.LogWrite("##############################" +
                         "\r\n" + DateTime.Now.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
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


            OvalRaceTrack.TrackPositions = OvalPoints;
            //MessageBox.Show("Width: " + this.ClientSize.Width + " Height: " + this.ClientSize.Height
            for (int i = 0; i < 3; i++)
            {
                Dog d = new Dog(OvalRaceTrack, radioButton1);
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
            //        sw.WriteLine("new Point(" + this.PointToClient(Cursor.Position).X + ", " + this.PointToClient(Cursor.Position).Y + ", false), \r\n");
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
            this.pb_BackGround.Refresh();
        }

        private void pb_BackGround_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point p in OvalRaceTrack.TrackPositions)
            {
                Rectangle r = new Rectangle((int)p.X - 10, (int)p.Y - 10, 20, 20);
                //Log.LogWrite(r.Left.ToString() + " " + r.Top.ToString() + " " + r.Width.ToString() + " " + r.Height.ToString());
                e.Graphics.FillEllipse(Brushes.Black, r);
            }
        }
    }
}
