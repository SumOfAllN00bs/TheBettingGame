using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    public class Bettor
    {
        private int money;
        private string name;
        private bool busted = false;

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
                if (money > 0)
                {
                    Busted = false;
                }
                else
                {
                    Busted = true;
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool Busted
        {
            get
            {
                return busted;
            }

            set
            {
                busted = value;
            }
        }

        public Bettor(string _name, int _money)
        {
            money = _money;
            name = _name;
        }
    }
}
