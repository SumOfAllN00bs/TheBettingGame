﻿using System;
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
        public Racer racer
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
        public string PunterName
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
            runner.OnWin += BetWon;
            runner.OnLoss += BetLost;
        }
        public void Dispose()
        {
            runner.OnWin -= BetWon;
            runner.OnLoss -= BetLost;
        }

        public void BetWon(object o, EventArgs e)
        {
            //Log.LogWrite("");
            //Log.LogWrite("o: " + ((Racer)o).Me.Tag);
            //Log.LogWrite("Before: " + punter.Money);
            punter.Money = punter.Money * 2;
            //Log.LogWrite("After: " + punter.Money);
        }
        public void BetLost(object o, EventArgs e)
        {
            //Log.LogWrite("");
            //Log.LogWrite("o: " + ((Racer)o).Me.Tag);
            //Log.LogWrite("Before: " + punter.Money);
            punter.Money = punter.Money - amount;
            if (punter.Money <= 0)
            {
                punter.Busted = true;
            }
            //Log.LogWrite("After: " + punter.Money);
        }
    }
}
