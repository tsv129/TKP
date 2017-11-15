using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKP3
{
    public partial class Form1 : Form
    {
        Pen BlackPen = new Pen(Color.Black, 1);
        Pen BrownPen = new Pen(Color.Brown, 1);
        Brush BrownBrush = Brushes.Brown;
        Brush BlackBrush = Brushes.Black;
        Brush BlueBrush = Brushes.Blue;
        Brush GreenBrush = Brushes.Green;
        Brush YellowBrush = Brushes.Yellow;
        Brush TBlackBrush = Brushes.SlateGray;
        Brush TBrownBrush = Brushes.Chocolate;

        public Form1()
        {
            InitializeComponent();
        }

        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }
        private static int IPart(float x)
        {
            return (int)x;
        }
        private static float FPart(float x)
        {
            while (x >= 0)
                x--;
            x++;
            return x;
        }

        public static void AlgorithmWu(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);
            if (dx == 0 || dy == 0)
            {
                g.DrawLine(new Pen(clr), x0, y0, x1, y1);
                return;
            }

            if (dy < dx)
            {
                if (x1 < x0)
                {
                    x1 += x0; x0 = x1 - x0; x1 -= x0;
                    y1 += y0; y0 = y1 - y0; y1 -= y0;
                }
                float grad = (float)dy / dx;
                float intery = y0 + grad;
                PutPixel(g, clr, x0, y0, 255);

                for (int x = x0 + 1; x < x1; x++)
                {
                    PutPixel(g, clr, x, IPart(intery), (int)(255 - FPart(intery) * 255));
                    PutPixel(g, clr, x, IPart(intery) + 1, (int)(FPart(intery) * 255));
                    intery += grad;
                }
                PutPixel(g, clr, x1, y1, 255);
            }
            else
            {
                if (y1 < y0)
                {
                    x1 += x0; x0 = x1 - x0; x1 -= x0;
                    y1 += y0; y0 = y1 - y0; y1 -= y0;
                }
                float grad = (float)dx / dy;
                float interx = x0 + grad;
                PutPixel(g, clr, x0, y0, 255);

                for (int y = y0 + 1; y < y1; y++)
                {
                    PutPixel(g, clr, IPart(interx), y, 255 - (int)(FPart(interx) * 255));
                    PutPixel(g, clr, IPart(interx) + 1, y, (int)(FPart(interx) * 255));
                    interx += grad;
                }
                PutPixel(g, clr, x1, y1, 255);
            }
        }

        public static void BresenhamCircle(Graphics g, Color clr, int _x, int _y, int radius)
        {
            int x = 0, y = radius, gap = 0, delta = (2 - 2 * radius);
            while (y >= 0)
            {
                PutPixel(g, clr, _x + x, _y + y, 255);
                PutPixel(g, clr, _x + x, _y - y, 255);
                PutPixel(g, clr, _x - x, _y - y, 255);
                PutPixel(g, clr, _x - x, _y + y, 255);
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x++;
                    delta += 2 * x + 1;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2 * y + 1;
                    continue;
                }
                x++;
                delta += 2 * (x - y);
                y--;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointF[] points = new PointF[]{
            new PointF(170,150), new PointF(230,150), new PointF(245,180), new PointF(155,180)
            };
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawRectangle(BlackPen, 0, 0, 399, 299);
            g.FillRectangle(BlackBrush, 130, 50, 140, 75);
            g.FillRectangle(BlueBrush, 135, 55, 130, 30);
            g.FillRectangle(GreenBrush, 135, 85, 130, 35);
            g.FillPolygon(TBlackBrush, points);
            g.FillRectangle(BlackBrush, 185, 125, 30, 30);
            g.DrawLine(BlackPen, 170, 150, 230, 150);
            g.DrawLine(BlackPen, 170, 150, 155, 180);
            //g.DrawLine(BlackPen, 230, 150, 240, 170);
            g.DrawLine(BlackPen, 155, 180, 245, 180);
            g.DrawRectangle(BlackPen, 130, 50, 140, 75);
            //g.FillEllipse(YellowBrush, 245, 60, 13, 13);
            for (int ib = 1; ib < 10; ib++)
            BresenhamCircle(g, Color.Yellow, 245, 65, ib);
            AlgorithmWu(g, Color.Black, 230, 150, 245, 180);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF[] points = new PointF[]{
            new PointF(80, 140), new PointF(320, 140), new PointF(360, 220), new PointF(40, 220)
            };
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawRectangle(BlackPen, 0, 0, 399, 299);
            g.FillPolygon(TBrownBrush, points);
            g.FillRectangle(BrownBrush, 70, 220, 20, 79);
            g.FillRectangle(BrownBrush, 100, 220, 17, 69);
            g.FillRectangle(BrownBrush, 310, 220, 20, 79);
            g.FillRectangle(BrownBrush, 283, 220, 17, 69);
            g.FillRectangle(TBrownBrush, 40, 220, 321, 10);
            g.FillPie(YellowBrush, 75, 100, 250, 100, 180, 180);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(SystemColors.Control);
        }
    }
}
