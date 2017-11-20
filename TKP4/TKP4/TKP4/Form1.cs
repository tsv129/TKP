using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKP4
{

    public partial class Form1 : Form
    {
        Pen BP = new Pen(Color.Black, 1);
        Brush BB = Brushes.Black;
        int[,] pa = new int[5, 2];

        public Form1()
        {
            InitializeComponent();
        }
        private void Creator()
        {
            pa[0, 0] = 20;
            pa[0, 1] = 34;
            pa[1, 0] = 97;
            pa[1, 1] = 45;
            pa[2, 0] = 165;
            pa[2, 1] = 89;
            pa[3, 0] = 134;
            pa[3, 1] = 180;
            pa[4, 0] = 78;
            pa[4, 1] = 89;
        }

        private void Drawer(PictureBox pb, int[,] arr, int dx, int dy)
        {
            Graphics g = Graphics.FromHwnd(pb.Handle);
            int[,] korXY = new int[5, 2];
            for (int i = 0; i <5; i++)
            {
                korXY[i, 0] = ((arr[i, 0] - 100) * dx) + 100;
                korXY[i, 1] = ((arr[i, 1] - 100) * dy) + 100;
            }
            PointF[] points = new PointF[]{
            new PointF(korXY[0,0],korXY[0,1]), new PointF(korXY[1,0],korXY[1,1]),
            new PointF(korXY[2,0],korXY[2,1]), new PointF(korXY[3,0],korXY[3,1]),
            new PointF(korXY[4,0],korXY[4,1])
            };
            g.FillPolygon(BB, points);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Drawer(pictureBox5, pa, 1, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Creator();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Drawer(pictureBox6, pa, -1, 1);
            Drawer(pictureBox4, pa, -1, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Drawer(pictureBox2, pa, 1, -1);
            Drawer(pictureBox8, pa, 1, -1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Drawer(pictureBox1, pa, -1, -1);
            Drawer(pictureBox3, pa, -1, -1);
            Drawer(pictureBox7, pa, -1, -1);
            Drawer(pictureBox9, pa, -1, -1);
        }
    }
}
