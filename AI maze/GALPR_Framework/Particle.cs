using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALPR_Framework
{
    public class Particle
    {
        public Color color;
        public Boolean start;
        public Boolean end;
        public Boolean canGoUp;
        public Boolean canGoDown;
        public Boolean canGoLeft;
        public Boolean canGoRight;
        public Boolean nod;
        public Boolean deadEnd;

        public Particle(Color color)
        {
            this.color = color;
            Inicializator();
            if (color == MazeGrid.green) start = true;
            if (color == MazeGrid.red) end = true;
        }

        public void Inicializator()
        {
            this.start = false;
            this.end = false;
            this.canGoUp = false;
            this.canGoDown = false;
            this.canGoLeft = false;
            this.canGoRight = false;
            this.nod = false;
            this.deadEnd = false;
        }

        public int NeighboursCounter()
        {
            int ret = 0;
            if (canGoUp == true) ret++;
            if (canGoDown == true) ret++;
            if (canGoLeft == true) ret++;
            if (canGoRight == true) ret++;
            return ret;
        }
        override
        public String ToString()
        {
            string ret = "";
            ret = "start: " + start.ToString();
            ret += "\nend: " + end.ToString();
            ret += "\nup: " + canGoUp.ToString();
            ret += "\ndown: " + canGoDown.ToString();
            ret += "\nleft: " + canGoLeft.ToString();
            ret += "\nright: " + canGoRight.ToString();
            ret += "\nnod: " + nod.ToString();
            ret += "\ndeadend: " + deadEnd.ToString();
            return ret;
        }
    }
}
