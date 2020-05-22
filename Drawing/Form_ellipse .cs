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
    public partial class Form_ellipse : Form
    {
        public int X
        {
            get { return Int32.Parse(textBox1.Text); }
        }
        public int Y
        {
            get { return Int32.Parse(textBox2.Text); }
        }
        public int RX
        {
            get { return Int32.Parse(textBox3.Text); }
        }
        public int RY
        {
            get { return Int32.Parse(textBox4.Text); }
        }
        public Form_ellipse()
        {
            InitializeComponent();
        }

        private void Form_ellipse_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics Object = panel1.CreateGraphics();
            midptellipse(RX, RY, X, Y, Object, Color.DarkGreen);

        }
        void PutPixel(Graphics g, float xCenter, float yCenter, float x, float y, Color c)
        {
            Brush bcolor = new SolidBrush(c);

            g.FillRectangle(bcolor, xCenter + x, yCenter + y, 2, 2);
            g.FillRectangle(bcolor, xCenter - x, yCenter + y, 2, 2);
            g.FillRectangle(bcolor, xCenter + x, yCenter - y, 2, 2);
            g.FillRectangle(bcolor, xCenter - x, yCenter - y, 2, 2);

         

        }
        void midptellipse(float rx, float ry, float xc, float yc, Graphics graph, Color lineColor)
        {

            float dx, dy, d1, d2, x, y;
            x = 0;
            y = ry;

            // Initial decision parameter of region 1 
            d1 = (ry * ry) - (rx * rx * ry) +
                            (0.25f * rx * rx);
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            // For region 1 
            while (dx < dy)
            {
                PutPixel(graph, xc, yc, x, y, lineColor);
                if (d1 < 0)
                {
                    x++;
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }
            }
             d2 = ((ry * ry) * ((x + 0.5f) * (x + 0.5f))) 
        + ((rx * rx) * ((y - 1) * (y - 1))) 
        - (rx * rx * ry * ry); 
  
    // Plotting points of region 2 
    while (y >= 0)
    {
        PutPixel(graph, xc, yc, x, y, lineColor);

        if (d2 > 0)
        {
            y--;
            dy = dy - (2 * rx * rx);
            d2 = d2 + (rx * rx) - dy;
        }
        else
        {
            y--;
            x++;
            dx = dx + (2 * ry * ry);
            dy = dy - (2 * rx * rx);
            d2 = d2 + dx - dy + (rx * rx);
        }
    } 
        }
    }
}
