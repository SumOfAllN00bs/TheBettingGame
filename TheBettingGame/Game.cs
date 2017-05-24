using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    class Game
    {
        private List<Racer> runners = new List<Racer>();
        private RaceTrack trackandfield = new RaceTrack();
        private List<Bettor> puntList = new List<Bettor>();

        public Game(List<Racer> _run, RaceTrack _track, List<Bettor> _punt)
        {
            runners = _run;
            trackandfield = _track;
            puntList = _punt;

            foreach (Racer R in runners)
            {
                R.OnWin += new EventHandler(WinnerFound);
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
    }
}
