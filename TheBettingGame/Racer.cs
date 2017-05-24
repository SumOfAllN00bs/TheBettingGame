using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBettingGame
{
    class Racer
    {
        private Point startingPosition; //where the racer is calculating it's journey from. 
                                        //(the journey isn't the whole race track just a section of it)

        private Point currentPosition; //where on the screen the racer is currently located at

        private Point targetPosition; //where the racer is currently trying to head towards


        public event EventHandler OnWin;    //the event of the racer reaching end.
        public event EventHandler OnLoss;

        public void ForceLoss()
        {
            if (OnLoss != null)
            {
                OnLoss(this, new EventArgs());
            }
        }
        public void ClearEvents()
        {
            OnWin = null;
            OnLoss = null;
        }

    }
}
