using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    class Bet
    {
        private int amount;
        private Racer runner;
        private Bettor punter;
        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
        internal Racer racer
        {
            get
            {
                return runner;
            }

            set
            {
                runner = value;
            }
        }
        internal Bettor bettor
        {
            get
            {
                return punter;
            }

            set
            {
                punter = value;
            }
        }
        public int Runner
        {
            get; set;
        }
        public string Punter
        {
            get
            {
                return punter.Name;
            }
        }

        public Bet(int _amt, Racer _rcr, int _rcr_indx, Bettor _bttr)
        {
            amount = _amt;
            runner = _rcr;
            Runner = _rcr_indx;
            punter = _bttr;
            runner.OnWin += new EventHandler(BetWon);
            runner.OnLoss += new EventHandler(BetLost);
        }

        protected void BetWon(object o, EventArgs e)
        {
            punter.Money = punter.Money * 2;
        }
        protected void BetLost(object o, EventArgs e)
        {
            punter.Money = punter.Money - amount;
        }
    }
}
