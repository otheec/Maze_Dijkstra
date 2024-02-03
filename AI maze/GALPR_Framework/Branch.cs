using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GALPR_Framework
{
    public class Branch
    {
        public Point start;
        public Point end;
        public List<Point> route;

        public Branch (Point start, Point end)
        {
            this.start = start;
            this.end = end;
            this.route = new List<Point>();
        }

        public Branch(Point start, Point end, List<Point> route)
        {
            this.start = start;
            this.end = end;
            this.route = route;
        }

        public VRAM WriteBranchToVRAM(VRAM vram)
        {
            for(int i = 1; i < route.Count - 1; i++)
            {
                vram.SetPixel(route[i].X, route[i].Y, Color.Blue);
            }
            vram.SetPixel(route[0].X, route[0].Y, Color.Orange);
            vram.SetPixel(route[route.Count - 1].X, route[route.Count - 1].Y, Color.Orange);
            return vram;
        }
        
        public Branch Reverse() {
            Point end= this.start;
            Point start = this.end;
            List<Point> route = new List<Point>();
            int revIndex = this.route.Count - 1;
            for (int i = 0; i < this.route.Count; i++)
            {
                route[i] = this.route[revIndex];
                revIndex--;
            }              
            return new Branch (start, end, route);
        }
    }
}
