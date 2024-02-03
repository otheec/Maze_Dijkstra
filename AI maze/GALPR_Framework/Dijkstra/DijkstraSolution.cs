using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace GALPR_Framework.Dijkstra
{
    public class DijkstraSolution
    {
        public int width;
        public int height;
        public Particle[,] particle;
        public Point start;
        public Point end;
        public List<Point> nods;
        public List<Point> deadEnd;
        public List<Branch> branches;
        public List<Path> paths;

        public DijkstraSolution(Particle[,] particle)
        {
            this.width = particle.GetLength(0);
            this.height = particle.GetLength(1);
            this.particle = particle;
            this.nods = new List<Point>();
            this.deadEnd = new List<Point>();
            this.branches = new List<Branch>();
            this.paths = new List<Path>();
            FindKeyPoints();
            for (int i = 0; i < FindSolvingPoints().Count; i++)
            {
                for (int j = 0; j < FindSolvingPointsSteps(FindSolvingPoints()[i]).Count; j++)
                {
                    branches.Add(FindWay(FindSolvingPoints()[i], FindSolvingPointsSteps(FindSolvingPoints()[i])[j]));
                }
            }
            RendundantBranchRemover();
        }

        public void Solve()
        {
            List<Branch> brr= new List<Branch>();
            Recursion(brr, start, null);
        }

        public void Recursion(List<Branch> branches, Point point, Branch branch)
        {
            Boolean msgOutput = false;
            if (particle[point.X, point.Y].end == true)
            {
                paths.Add(new Path(branches));
                MessageBox.Show("End found. Brenches: " + branches.Count.ToString());
            }
            else if (particle[point.X, point.Y].deadEnd == true && particle[point.X, point.Y].end != true && point != start && (branches.Count != 0))
            {
                if (msgOutput) MessageBox.Show("Dead end found.");
            }
            else
            {
                for (int i = 0; i < NeighbourBranches(point, branch).Count; i++)
                {
                    if (branches.Contains(NeighbourBranches(point, branch)[i]) == true)
                    {
                        if (msgOutput) MessageBox.Show("Ended due to the loop");
                    }
                    else if (branches.Contains(NeighbourBranches(point, branch)[i]) == false)
                    {
                        if (msgOutput) MessageBox.Show("Recursion iteration");
                        Branch iterationBranch = NeighbourBranches(point, branch)[i];
                        Point iterationBranchSecondEnd = SecondEndOfBranch(point, NeighbourBranches(point, branch)[i]);
                        List<Branch> iterationBranches = new List<Branch>(branches);
                        iterationBranches.Add(NeighbourBranches(point, branch)[i]);
                        Recursion(iterationBranches, iterationBranchSecondEnd, iterationBranch);
                    }
                    else if (msgOutput) MessageBox.Show("None iteration error");
                }
            }
        }

        public List<Branch> NeighbourBranches(Point point, Branch branch)
        {
            List<Branch> ret = new List<Branch>();
            for (int i = 0; i < branches.Count; i++)
            {
                if ((branches[i].start == point || branches[i].end == point) && branches[i] != branch)
                {
                    ret.Add(branches[i]);
                }
            }
            return ret;
        }

        public Point SecondEndOfBranch(Point point, Branch branch)
        {
            if (branch.start == point) return branch.end;
            else if (branch.end == point) return branch.start;
            else {
                MessageBox.Show("Second end of branch returned empty point");
                return Point.Empty;
            }
        }
        
        public Path ShortestPath()
        {
            int retIndex = 0;
            int maxLenght = 0;
            for(int i = 0; i < paths.Count; i++) {
                int lenght = 0;
                for(int j = 0; j < paths[i].branches.Count; j++)
                {
                    lenght += (paths[i].branches[j].route.Count - 1);
                }
                lenght = lenght + 1;
                if(lenght < maxLenght) retIndex = i;
            }
            return paths[retIndex];
        }

        public void RendundantBranchRemover()
        {
            for(int i = 0; i < branches.Count; i++) {
                for(int j = 0; j < branches.Count; j++) {
                    if (branches[i].end == branches[j].start && branches[i].start == branches[j].end && i != j) { 
                        branches.RemoveAt(i);
                        i = 0;
                        j = 0;
                    }
                }
            }
        }

        public List<Point> FindSolvingPoints()
        {
            List<Point> ret = new List<Point>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    if (particle[x, y].nod == true) ret.Add(new Point(x, y));
                    if (particle[x, y].deadEnd == true) ret.Add(new Point(x, y));
                }
            }
            if (particle[start.X, start.Y].nod == false && particle[start.X, start.Y].deadEnd == false) ret.Add(new Point(start.X, start.Y));
            if (particle[end.X, end.Y].nod == false && particle[end.X, end.Y].deadEnd == false) ret.Add(new Point(end.X, end.Y));
            return ret;
        }

        public List<Point> FindSolvingPointsSteps(Point solvingPoint) { 
            List<Point> ret = new List<Point>();
            if (particle[solvingPoint.X, solvingPoint.Y].canGoRight == true) ret.Add(new Point(solvingPoint.X + 1, solvingPoint.Y));
            if (particle[solvingPoint.X, solvingPoint.Y].canGoLeft == true) ret.Add(new Point(solvingPoint.X - 1, solvingPoint.Y));
            if (particle[solvingPoint.X, solvingPoint.Y].canGoDown == true) ret.Add(new Point(solvingPoint.X, solvingPoint.Y + 1));
            if (particle[solvingPoint.X, solvingPoint.Y].canGoUp == true) ret.Add(new Point(solvingPoint.X, solvingPoint.Y - 1));
            return ret;
        }


        public Branch FindWay(Point start0, Point start1)
        {
            Branch branch = new Branch(start0, start1);
            Point actualPosition = start1;
            branch.route.Add(start0);
            branch.route.Add(start1);
            while (EndOfBrenchExecution(actualPosition))
            {
                if (particle[actualPosition.X, actualPosition.Y].canGoRight == true
                    && branch.route[branch.route.Count - 2].X - 1 != actualPosition.X
                    )
                {
                    actualPosition.X++;
                    branch.route.Add(actualPosition);
                    continue;
                }
                if (particle[actualPosition.X, actualPosition.Y].canGoLeft == true
                    && branch.route[branch.route.Count - 2].X + 1 != actualPosition.X
                    )
                {
                    actualPosition.X--;
                    branch.route.Add(actualPosition);
                    continue;
                }
                if (particle[actualPosition.X, actualPosition.Y].canGoUp == true
                    && branch.route[branch.route.Count - 2].Y + 1 != actualPosition.Y
                    )
                {
                    actualPosition.Y--;
                    branch.route.Add(actualPosition);
                    continue;
                }
                if (particle[actualPosition.X, actualPosition.Y].canGoDown == true
                    && branch.route[branch.route.Count - 2].Y - 1 != actualPosition.Y
                    )
                {
                    actualPosition.Y++;
                    branch.route.Add(actualPosition);
                    continue;
                }
            }
            branch.end = actualPosition;
            return branch;
        }

        public void TestCountAtributs() {
            int ret = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    if(particle[x, y].nod == true) ret++;
                }
            }
            MessageBox.Show(ret.ToString());
        }

        public void FindKeyPoints()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    if (particle[x, y].nod == true) nods.Add(new Point(x, y));
                    if (particle[x, y].deadEnd == true) deadEnd.Add(new Point(x, y));
                    if (particle[x, y].start == true) start = new Point(x, y);
                    if (particle[x, y].end == true) end = new Point(x, y);
                }
            }
        }

        public bool EndOfBrenchExecution(Point end) { 
            Boolean ret = true;
            List<Point> endPoints = new List<Point>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    if (particle[x, y].nod == true) endPoints.Add(new Point(x, y));
                    if (particle[x, y].deadEnd == true) endPoints.Add(new Point(x, y));
                    if (particle[x, y].start == true) endPoints.Add(new Point(x, y));
                    if (particle[x, y].end == true) endPoints.Add(new Point(x, y));
                }
            }
            for(int i = 0; i < endPoints.Count; i++) {
                if (end == endPoints[i])
                {
                    ret = false;
                    break;
                }
            }
            return ret;           
        }

        public VRAM ReturnVram()
        {
            VRAM vram = new VRAM(width, height);
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    vram.SetPixel(x, y, particle[x, y].color);
                }
            }
            return vram;
        }

        public Bitmap GetBitmap() //z frameworku od kolcuna (předmět GALP), nejedná se o muj kod
        {
            Bitmap colorBitmap = new Bitmap(width, height, PixelFormat.Format32bppRgb);
            BitmapData bitmap_data = colorBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            unsafe
            {
                byte* line = (byte*)bitmap_data.Scan0.ToPointer();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        line[2] = particle[x, y].color.R;
                        line[1] = particle[x, y].color.G;
                        line[0] = particle[x, y].color.B;
                        line += 4;
                    }
                }
            }
            colorBitmap.UnlockBits(bitmap_data);
            return colorBitmap;
        }
    }
}
