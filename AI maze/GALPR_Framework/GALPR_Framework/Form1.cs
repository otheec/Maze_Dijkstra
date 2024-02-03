using GALPR_Framework.Image;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            vram = VRAM.CreateFromBitmap(new Bitmap(openFileDialog1.FileName));

            if (vram != null) {

                pictureBoxCustom1.Image = vram.GetBitmap();

                toolStripStatusLabel1.Text = String.Format("{0} x {1} > {2}", vram.Width, vram.Height, openFileDialog1.FileName);
            } 
        }

        private void vRAM100X100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vram = new VRAM(100, 100);

            pictureBoxCustom1.Image = vram.GetBitmap();
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

        private void convertRoGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vram == null) return;

            VRAM temp = vram.Copy();

            ImageProcessing.ConvertToGrayscale(temp);

            pictureBoxCustom2.Image = temp.GetBitmap();
        }

        private void saturateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vram == null) return;

            VRAM temp = vram.Copy();

            ImageProcessing.Saturation(temp, 1.5);

            pictureBoxCustom2.Image = temp.GetBitmap();
        }

        private void hueRotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vram == null) return;

            VRAM temp = vram.Copy();

            ImageProcessing.HueRotation(temp, 20);

            pictureBoxCustom2.Image = temp.GetBitmap();
        }

        private void saturation05ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vram == null) return;

            VRAM temp = vram.Copy();

            ImageProcessing.Saturation(temp, 0.5);

            pictureBoxCustom2.Image = temp.GetBitmap();
        }

        private void hueRotation20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vram == null) return;

            VRAM temp = vram.Copy();

            ImageProcessing.HueRotation(temp, -20);

            pictureBoxCustom2.Image = temp.GetBitmap();
        }
    }
}
