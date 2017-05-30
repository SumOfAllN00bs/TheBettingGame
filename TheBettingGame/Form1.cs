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
        private List<RaceTrack> OvalRaceTracks = new List<RaceTrack>();
        private List<Bet> Bettors_Bets = new List<Bet>();
        public Form1()
        {
            InitializeComponent();
            //Log.LogWrite("##############################" +
            //             "\r\n" + DateTime.Now.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            bettingGame = new Game(RacingAnimals, OvalRaceTracks, BettingAnimals, this);
            bettingGame.NewDefaultGame();
            //Setup Controls for first use
            foreach (Control C in this.Controls)
            {
                if (C != null)
                {
                    if (C.Tag != null)
                    {
                        if (C.Tag.ToString() == "Bettor")
                        {
                            C.Enabled = true;
                        }
                        if (C.Tag.ToString() == "Bet" || C.Tag.ToString() == "Race")
                        {
                            C.Enabled = false;
                        }  
                    }
                }
            }
            txt_BettorName.Select();
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
            //foreach (RaceTrack RT in OvalRaceTracks)
            //{
            //    foreach (Point p in RT.GetTrackPositions())
            //    {
            //        Rectangle r = new Rectangle((int)p.X - 10, (int)p.Y - 10, 20, 20);
            //        //Log.LogWrite(r.Left.ToString() + " " + r.Top.ToString() + " " + r.Width.ToString() + " " + r.Height.ToString());
            //        e.Graphics.FillEllipse(Brushes.Black, r);
            //    } 
            //}
        }
        private void btn_AddBettor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_BettorName.Text))
            {
                MessageBox.Show("Please choose an name for player");
                return;
            }
            Bettor NewBettor = new Bettor(txt_BettorName.Text, 50);
            BettingAnimals.Add(NewBettor);
            dgv_Bettors.DataSource = null;
            dgv_Bettors.DataSource = BettingAnimals;
            dgv_Bettors.Columns["Name"].DisplayIndex = 0;
            dgv_Bettors.Columns["Money"].DisplayIndex = 1;
            dgv_Bettors.Columns["Busted"].DisplayIndex = 2;
            txt_BettorName.Text = "";
        }
        private void btn_FinishBettors_Click(object sender, EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
                if (C != null)
                {
                    if (C.Tag != null)
                    {
                        if (C.Tag.ToString() == "Bettor" || C.Tag.ToString() == "Race")
                        {
                            C.Enabled = false;
                        }
                        if (C.Tag.ToString() == "Bet")
                        {
                            C.Enabled = true;
                        }
                    }
                }
            }
            txt_BettorName.Text = "";
            bettingGame.CurrentBettor = 0;
            txt_Bet_BettorName.Text = BettingAnimals[bettingGame.CurrentBettor].Name;
            num_BetAmount.Minimum = 5;
            num_BetAmount.Maximum = 15;
            rb_Racer1.Select(); //gain focus
        }
        private void btn_PlaceBet_Click(object sender, EventArgs e)
        {
            Racer RacerToBetOn = null;
            int RacerIndex = -1;
            if (!rb_Racer1.Checked && !rb_Racer2.Checked && !rb_Racer3.Checked && !rb_Racer4.Checked)
            {
                MessageBox.Show("Please choose an animal to bet on.");
                return;
            }
            if (rb_Racer1.Checked) RacerIndex = 0;
            if (rb_Racer2.Checked) RacerIndex = 1;
            if (rb_Racer3.Checked) RacerIndex = 2;
            if (rb_Racer4.Checked) RacerIndex = 3;
            RacerToBetOn = RacingAnimals[RacerIndex];
            //Displayed in Datagridview     Amount       Racerindex     Punter/Bettor
            Bet B = new Bet((int)num_BetAmount.Value, RacerToBetOn, RacerIndex + 1, BettingAnimals[bettingGame.CurrentBettor]);
            Bettors_Bets.Add(B);

            dgv_Bets.DataSource = null;
            dgv_Bets.DataSource = Bettors_Bets;
            dgv_Bets.Columns["Punter"].DisplayIndex = 0;
            dgv_Bets.Columns["Amount"].DisplayIndex = 1;
            dgv_Bets.Columns["Runner"].DisplayIndex = 2;

            if (bettingGame.CurrentBettor < (BettingAnimals.Count - 1))
            {
                bettingGame.CurrentBettor++;
                txt_Bet_BettorName.Text = BettingAnimals[bettingGame.CurrentBettor].Name;
                num_BetAmount.Value = 5;
            }
            else
            {
                foreach (Control C in this.Controls)
                {
                    if (C != null)
                    {
                        if (C.Tag != null)
                        {
                            if (C.Tag.ToString() == "Bettor" || C.Tag.ToString() == "Bet")
                            {
                                C.Enabled = false;
                            }
                            if (C.Tag.ToString() == "Race")
                            {
                                C.Enabled = true;
                            }
                        }
                    }
                }
                btn_StartRace.Select();
            }
        }
    }
}
