using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GALPR_Framework
{
    public class Path
    {
        public List<Branch> branches;

        public Path(List<Branch> branches) { 
            this.branches = new List<Branch>();
            for(int i = 0; i < branches.Count; i++)
            {
                this.branches.Add(branches[i]);
            }
        }

        public List<Point> PathExport() {
            List<Point> points = new List<Point>();
            List<Branch> path = new List<Branch>();
            for(int i = 0; i < this.branches.Count - 1; i++)
            {
                if (branches[0].end == branches[i + 1].start)
                {
                    path.Add(this.branches[i]);
                }
                if (branches[i].end == branches[i + 1].end)
                {
                    this.branches[i + 1] = this.branches[i + 1].Reverse();
                    path.Add(this.branches[i]);
                }
                if (branches[i].start == branches[i + 1].start)
                {
                    path.Add(this.branches[i].Reverse());
                }
                if (branches[i].start == branches[i + 1].end)
                {
                    this.branches[i + 1] = this.branches[i + 1].Reverse();
                    path.Add(this.branches[i].Reverse());
                }
            }
            path.Add(this.branches[this.branches.Count - 1]);
            points.Add(path[0].route[0]);
            for(int i = 0; i < path.Count; i++)
            {
                for(int j = 1; j < path[i].route.Count; j++)
                {
                    points.Add(path[i].route[j]);
                }
            }
            return points;
        }
    }
}
