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
        //Betting Animals is the Players who bet on the race. 
        private List<Bettor> BettingAnimals = new List<Bettor>();
        private List<RaceTrack> OvalRaceTracks = new List<RaceTrack>();
        private List<Bet> Bettors_Bets = new List<Bet>();
        public Form1()
        {
            InitializeComponent();
            //setup the Log file if I'm debugging
            //Log.LogWrite("##############################" +
            //             "\r\n" + DateTime.Now.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup a game and run the NewDefaultGame method to instantiate variables and such
            bettingGame = new Game(RacingAnimals, OvalRaceTracks, BettingAnimals, this);
            bettingGame.NewDefaultGame();
            //Setup Controls for first use I.E. disabling controls we won't need till later on and enabling any that we need immediately
            ToggleControlsEnabled("Bettor", "Bet Race");
            txt_BettorName.Select();
        }
        private void pb_BackGround_Click(object sender, EventArgs e)
        {
            //needed following code to generate the points that would be used to create the RaceTrack still need it in the even that I want other RaceTracks

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
            //This Timer event should run every 33 milliseconds which is roughly 1/30th of a second giving the game about 30.3 frames per second
            bettingGame.GameTic();
            pb_BackGround.Refresh();
        }
        private void pb_BackGround_Paint(object sender, PaintEventArgs e)
        {
            //Used to visually see the points in the race track. Each Racer has an Offset to their track so you should see 4 overlapping ovals of points

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
            RefreshBettorsDataGridView();
            txt_BettorName.Text = "";
        }
        private void btn_FinishBettors_Click(object sender, EventArgs e)
        {
            //Controls Tagged Bet are enabled and Bettor and Race are disabled
            ToggleControlsEnabled("Bet", "Bettor Race");
            txt_BettorName.Text = "";
            //setup next phase of game which is allowing each Bettor to Bet
            bettingGame.CurrentBettor = 0;
            txt_Bet_BettorName.Text = BettingAnimals[bettingGame.CurrentBettor].Name;
            num_BetAmount.Minimum = 5;
            num_BetAmount.Maximum = 15;
            rb_Racer1.Select(); //gain focus
        }
        private void btn_PlaceBet_Click(object sender, EventArgs e)
        {
            //Try to skip over any Bettors who have busted
            if (BettingAnimals[bettingGame.CurrentBettor].Busted)
            {
                if (bettingGame.CurrentBettor < (BettingAnimals.Count - 1))
                {
                    bettingGame.CurrentBettor++;
                    txt_Bet_BettorName.Text = BettingAnimals[bettingGame.CurrentBettor].Name;
                    num_BetAmount.Value = 5;
                    num_BetAmount.Maximum = Math.Min(15, BettingAnimals[bettingGame.CurrentBettor].Money);
                }
                else
                {
                    //if there isn't anyone who is not busted
                    if (BettingAnimals.Find(ba => !ba.Busted) == null)
                    {
                        MessageBox.Show("Game Over");
                        ToggleControlsEnabled("Doesn'tExist", "Bettor Bet Race");
                    }
                }

            }

            //Setup variables to find which Racer was chosen
            Racer RacerToBetOn = null;
            int RacerIndex = -1;

            //Makes sure a racer was chosen
            if (rb_Racer1.Checked) RacerIndex = 0;
            if (rb_Racer2.Checked) RacerIndex = 1;
            if (rb_Racer3.Checked) RacerIndex = 2;
            if (rb_Racer4.Checked) RacerIndex = 3;
            if (RacerIndex == -1)
            {
                MessageBox.Show("Please choose an animal to bet on.");
                return;
            }
            RacerToBetOn = RacingAnimals[RacerIndex];

            //Create Bet and start keeping track of it.
            Bet B = new Bet((int)num_BetAmount.Value, RacerToBetOn, RacerIndex + 1, BettingAnimals[bettingGame.CurrentBettor]);
            Bettors_Bets.Add(B);
            RefreshBetsDataGridView();

            //if there is more bettors then go to next, else get ready to start race
            if (bettingGame.CurrentBettor < (BettingAnimals.Count - 1))
            {
                bettingGame.CurrentBettor++;
                txt_Bet_BettorName.Text = BettingAnimals[bettingGame.CurrentBettor].Name;
                num_BetAmount.Value = 5;
                num_BetAmount.Maximum = Math.Min(15, BettingAnimals[bettingGame.CurrentBettor].Money);
            }
            else
            {
                ToggleControlsEnabled("Race", "Bettor Bet");
                btn_StartRace.Select();
                num_BetAmount.Value = 5;
            }
        }
        public void ToggleControlsEnabled(string EnableString, string DisableString)
        {
            //will enable all controls named in EnableString split by spaces and disable all controls named by DisableString split by spaces
            foreach (Control C in Controls)
            {
                if (C != null)
                {
                    if (C.Tag != null)
                    {
                        foreach (string E_Control in EnableString.Split(' '))
                        {
                            if (C.Tag.ToString() == E_Control)
                            {
                                C.Enabled = true;
                            }
                        }
                        foreach (string D_Control in DisableString.Split(' '))
                        {
                            if (C.Tag.ToString() == D_Control)
                            {
                                C.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        public void StopGame()
        {
            Log.LogWrite("Race ended.");
            //Stop timer
            gameTic.Stop();
            MessageBox.Show("Winner is: " + RacingAnimals.Find(c => c.Won).Name + " on track: " + RacingAnimals.Find(c => c.Won).Me.Tag);

            //Try to reset the state of the racers
            foreach (Racer reset_Racer in RacingAnimals)
            {
                reset_Racer.Finished = false;
                reset_Racer.CurrentPath = 0;
                reset_Racer.Me.Location = new Point((int)reset_Racer.Racetrack.GetPath(reset_Racer.CurrentPath).A.X,
                                                    (int)reset_Racer.Racetrack.GetPath(reset_Racer.CurrentPath).A.Y);
                reset_Racer.Won = false;
                reset_Racer.OnWin += bettingGame.WinnerFound;
            }

            //Get rid of previous races bets
            foreach (Bet B in Bettors_Bets)
            {
                B.Dispose();
            }
            Bettors_Bets.Clear();

            //refresh
            RefreshBettorsDataGridView();
            RefreshBetsDataGridView();

            //if no one exists who is not busted then game over
            if (BettingAnimals.Find(ba => !ba.Busted) == null)
            {
                MessageBox.Show("Game Over");
                ToggleControlsEnabled("Doesn'tExist", "Bettor Bet Race");
                return;
            }
            ToggleControlsEnabled("Bet", "Bettor Race");
            bettingGame.CurrentBettor = 0;

            //Try to skip over any Bettors who have busted
            if (BettingAnimals[bettingGame.CurrentBettor].Busted)
            {
                if (bettingGame.CurrentBettor < (BettingAnimals.Count - 1))
                {
                    bettingGame.CurrentBettor++;
                    txt_Bet_BettorName.Text = BettingAnimals[bettingGame.CurrentBettor].Name;
                    num_BetAmount.Value = 5;
                    num_BetAmount.Maximum = Math.Min(15, BettingAnimals[bettingGame.CurrentBettor].Money);
                    return;
                }
                else
                {
                    //if there isn't anyone who is not busted
                    if (BettingAnimals.Find(ba => !ba.Busted) == null)
                    {
                        MessageBox.Show("Game Over");
                        ToggleControlsEnabled("Doesn'tExist", "Bettor Bet Race");
                    }
                }

            }
            txt_Bet_BettorName.Text = BettingAnimals[bettingGame.CurrentBettor].Name;
            pb_BackGround.Refresh();
            rb_Racer1.Select();
        }
        public void RefreshBettorsDataGridView()
        {
            dgv_Bettors.DataSource = null;
            dgv_Bettors.DataSource = BettingAnimals;
            //make sure the columns are ordered correctly
            dgv_Bettors.Columns["Name"].DisplayIndex = 0;
            dgv_Bettors.Columns["Money"].DisplayIndex = 1;
            dgv_Bettors.Columns["Busted"].DisplayIndex = 2;
        }
        public void RefreshBetsDataGridView()
        {
            //Makse sure Bet is displayed in Datagrid and makes sure the Columns are ordered pleasingly
            dgv_Bets.DataSource = null;
            dgv_Bets.DataSource = Bettors_Bets;
            dgv_Bets.Columns["PunterName"].DisplayIndex = 0;
            dgv_Bets.Columns["Amount"].DisplayIndex = 1;
            dgv_Bets.Columns["Runner"].DisplayIndex = 2;
        }
        private void btn_StartRace_Click(object sender, EventArgs e)
        {
            foreach (Racer R in RacingAnimals)
            {
                //Inheritance based Polymorphism
                R.SetNames();
                R.Name = R.RandomName();
            }
            gameTic.Start();
        }

        private void btn_RestartGame_Click(object sender, EventArgs e)
        {
            foreach (Control C in Controls)
            {
                if (C is PictureBox && C.Name != "pb_BackGround")
                {
                    C.Paint -= pb_BackGround_Paint;
                    C.Dispose();
                    Controls.Remove(C);
                }
            }

            RacingAnimals = new List<Racer>();
            BettingAnimals = new List<Bettor>();
            OvalRaceTracks = new List<RaceTrack>();
            Bettors_Bets = new List<Bet>();
            bettingGame = new Game(RacingAnimals, OvalRaceTracks, BettingAnimals, this);
            bettingGame.NewDefaultGame();
            ToggleControlsEnabled("Bettor", "Bet Race");
            txt_BettorName.Select();

            RefreshBettorsDataGridView();
            RefreshBetsDataGridView();
        }
    }
}
