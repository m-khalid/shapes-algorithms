using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public partial class Form_Circle : Form
    {
        public int X
        {
            get { return Int32.Parse(point_x.Text); }
        }

        public int Y
        {
            get { return Int32.Parse(point_y.Text); }
        }
        public int Radius
        {
            get { return Int32.Parse(num_radius.Text); }
        }
        public Form_Circle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics Object = panel1.CreateGraphics();
            draw_circle(X, Y, Radius, Object, Color.DarkCyan);
        }
        void PutPixel(Graphics g, int xCenter, int yCenter, int x, int y, Color c)
        {
            Brush bcolor = new SolidBrush(c);

            g.FillRectangle(bcolor, xCenter + x, yCenter + y, 2, 2);
            g.FillRectangle(bcolor, xCenter - x, yCenter + y, 2, 2);
            g.FillRectangle(bcolor, xCenter + x, yCenter - y, 2, 2);
            g.FillRectangle(bcolor, xCenter - x, yCenter - y, 2, 2);

            g.FillRectangle(bcolor, xCenter + y, yCenter + x, 2, 2);
            g.FillRectangle(bcolor, xCenter - y, yCenter + x, 2, 2);
            g.FillRectangle(bcolor, xCenter + y, yCenter - x, 2, 2);
            g.FillRectangle(bcolor, xCenter - y, yCenter - x, 2, 2);

        }

        void draw_circle(int xCenter, int yCenter, int radius, Graphics graph, Color lineColor)
        {
            int x = 0, y = radius;
            int p = 1 - radius;
            PutPixel(graph, xCenter, yCenter, x, y, lineColor);
            while (x < y)
            {
                x++;
                if (p < 0)
                {

                    p += +2 * x + 1;
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                PutPixel(graph, xCenter, yCenter, x, y, lineColor);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
