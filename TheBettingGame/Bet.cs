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
        internal Racer Runner
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
        internal Bettor Punter
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

        public Bet(int _amt, Racer _rcr, Bettor _bttr)
        {
            amount = _amt;
            runner = _rcr;
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
