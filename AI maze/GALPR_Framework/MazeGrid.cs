using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GALPR_Framework
{
    public class MazeGrid
    {
        public int width;
        public int height;
        public Particle[,] particle;
        public static Color white = Color.FromArgb(255, 255, 255);  //pozadi
        public static Color black = Color.FromArgb(0, 0, 0);        //cesta
        public static Color green = Color.FromArgb(34, 177, 76);    //start
        public static Color red = Color.FromArgb(237, 28, 36);      //cil

        public MazeGrid(VRAM vram)
        {
            this.width = vram.Width;
            this.height = vram.Height;

            particle = new Particle[height, width];

            for(int y = 0; y < height; y++) { 
                for(int x = 0; x < height; x++) { 
                    particle[y, x] = new Particle(vram.GetPixel(y, x));
                }
            }
            InitializeParticleAtributs();
        }

        public void InitializeParticleAtributs()
        {
            List<Color> colorList = new List<Color>() {black, red, green};
            for (int y =  1; y < height - 1; y++) {
                for (int x =  1; x < height - 1; x++)
                {
                    if (colorList.Contains(particle[x, y].color))
                    {
                        if (colorList.Contains(particle[x + 1, y].color)) particle[x, y].canGoRight = true;
                        if (colorList.Contains(particle[x - 1, y].color)) particle[x, y].canGoLeft = true;
                        if (colorList.Contains(particle[x, y + 1].color)) particle[x, y].canGoDown = true;
                        if (colorList.Contains(particle[x, y - 1].color)) particle[x, y].canGoUp = true;
                        if (particle[x, y].NeighboursCounter() > 2) particle[x, y].nod = true;
                        if (particle[x, y].NeighboursCounter() == 1) particle[x, y].deadEnd = true;
                    }
                }
            }
        }

        public void TestCountAtributs()
        {
            int ret = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    if (particle[x, y].canGoDown == true) ret++;
                }
            }
            MessageBox.Show(ret.ToString());
        }

        public Point FindStart() {
            Point ret = new Point();
            for (int y = 0; y < height; y++) { 
                for (int x = 1; x < height; x++)
                {
                    if (particle[x, y].color == green)
                    {
                        ret.X = x;
                        ret.Y = y;
                        break;
                    }
                }
            }
            return ret;
        }

        public Point FindEnd()
        {
            Point ret = new Point();
            for (int y = 0; y < height; y++)
            {
                for (int x = 1; x < height; x++)
                {
                    if (particle[x, y].color == red)
                    {
                        ret.X = x;
                        ret.Y = y;
                        break;
                    }
                }
            }
            return ret;
        }

        public int NodCounter()
        {
            int ret = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 1; x < height; x++)
                {
                    if (particle[x, y].nod == true)
                    {
                        ret++;
                    }
                }
            }
            return ret;
        }

        public int DeadEndCounter()
        {
            int ret = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 1; x < height; x++)
                {
                    if (particle[x, y].deadEnd == true)
                    {
                        ret++;
                    }
                }
            }
            return ret;
        }

        public int BrenchCounter()
        {
            return DeadEndCounter() + NodCounter() - 1;
        }


        public int ParticleCounter()
        {
            int counter = 0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < height; x++)
                {
                    if (particle[x,y].color != white) counter++;
                }
            return counter;
        }

        public Particle[,] ExportMazeGrid()
        {
            return particle;
        }

        public MazeGrid ExportThis()
        {
            return this;
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
                        line[2] = particle[y, x].color.R;
                        line[1] = particle[y, x].color.G;
                        line[0] = particle[y, x].color.B;
                        line += 4;
                    }
                }
            }
            colorBitmap.UnlockBits(bitmap_data);
            return colorBitmap;
        }
    }
}
