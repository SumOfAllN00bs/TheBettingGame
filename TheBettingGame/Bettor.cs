﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    class Bettor
    {
        private int money;
        private Bet current_bet;

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        internal Bet Current_Bet
        {
            get
            {
                return current_bet;
            }

            set
            {
                current_bet = value;
            }
        }
    }
}
