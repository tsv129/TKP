using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKP5
{

    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            if (i == 6)
                button1.Enabled = false;
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(SystemColors.Control);
            drawMinkovskyCurve(g, 10, 200, 390, 200, i);
        }

        public static int drawMinkovskyCurve(Graphics g, int x1, int y1, int x2,
            int y2, int iter)
        {

            Pen BP = new Pen(Color.Black, 1);
            if (iter == 0)
            {
                g.DrawLine(BP, x1, y1, x2, y2);
                return 0;
            }
            int[] x = new int[9];
            int[] y = new int[9];
            x[0] = x1;
            y[0] = y1;
            x[8] = x2;
            y[8] = y2;

            int d;

            if (y1 == y2)
            {
                d = (x2 - x1) / 4;
                x[1] = x[2] = x[0] + d;
                x[3] = x[4] = x[5] = x[2] + d;
                x[6] = x[7] = x[3] + d;
                y[1] = y[4] = y[7] = y[0];
                y[2] = y[3] = y[0] - d;
                y[5] = y[6] = y[0] + d;
            }
            else
            {
                d = (y2 - y1) / 4;
                y[1] = y[2] = y[0] + d;
                y[3] = y[4] = y[5] = y[2] + d;
                y[6] = y[7] = y[3] + d;
                x[1] = x[4] = x[7] = x[0];
                x[2] = x[3] = x[0] - d;
                x[5] = x[6] = x[0] + d;
            }

            for (int i = 0; i < 8; i++)
            {
                drawMinkovskyCurve(g, x[i], y[i], x[i + 1], y[i + 1], iter - 1);
            }
            return 0;

        }
    }
}
