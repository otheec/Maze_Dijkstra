using GALPR_Framework.Dijkstra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GALPR_Framework
{
    public partial class Form1 : Form
        
    {
        private VRAM vram;
        private DijkstraSolution dijkstra;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //po otevreni
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            vram = VRAM.CreateFromBitmap(new Bitmap(openFileDialog1.FileName));
            if (vram != null) {
                //zakomentovano kvuli testování
                //pictureBoxCustom1.Image = vram.GetBitmap();
                toolStripStatusLabel1.Text = String.Format("{0} x {1} > {2}", vram.Width, vram.Height, openFileDialog1.FileName);
            } 
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (pictureBoxCustom1.Image != null) {

                pictureBoxCustom1.Image.Save(saveFileDialog1.FileName, ImageFormat.Png);

                MessageBox.Show("Image saved" + Environment.NewLine + saveFileDialog1.FileName);
            }
        }

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(vram != null) {
                MazeGrid mazeGrid = new MazeGrid(vram);
                dijkstra = new DijkstraSolution(mazeGrid.ExportMazeGrid());
                pictureBoxCustom1.Image = dijkstra.GetBitmap();
                dijkstra.Solve();
            }
        }


        private void showSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPathBranches(dijkstra);
        }

        private void shortestPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vram = VRAM.CreateFromBitmap(dijkstra.GetBitmap());
            pictureBoxCustom1.Image = vram.GetBitmap();
            for (int i = 0; i < dijkstra.ShortestPath().branches.Count; i++)
            {
                vram = dijkstra.ShortestPath().branches[i].WriteBranchToVRAM(vram);
                pictureBoxCustom1.Image = vram.GetBitmap();
                MessageBox.Show("Next");
            }
        }

        public void ShowPathBranches(DijkstraSolution dijkstra)
        {
            for (int j = 0; j < dijkstra.paths.Count; j++)
            {
                vram = VRAM.CreateFromBitmap(dijkstra.GetBitmap());
                pictureBoxCustom1.Image = vram.GetBitmap();
                for (int i = 0; i < dijkstra.paths[j].branches.Count; i++)
                {
                    vram = dijkstra.paths[j].branches[i].WriteBranchToVRAM(vram);
                    pictureBoxCustom1.Image = vram.GetBitmap();
                    MessageBox.Show("Next");
                }
            }
        }
    }
}
