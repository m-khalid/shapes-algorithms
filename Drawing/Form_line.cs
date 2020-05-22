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
    public partial class Form_line : Form
    {
        public int x1
        {
            get { return Int32.Parse(textBox1.Text); }
        }

        public int y1
        {
            get { return Int32.Parse(textBox2.Text); }
        }

        public int x2
        {
            get { return Int32.Parse(textBox3.Text); }
        }

        public int y2
        {
            get { return Int32.Parse(textBox4.Text); }
        }

        public Form_line()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics Object1 = panel1.CreateGraphics();
            drawLineBy_DDA(x1, x2, y1, y2, Object1, Color.Blue);
        }
        void PutPixel(Graphics g, int x, int y, Color c)
        {
            Brush bcolor = new SolidBrush(c);
            g.FillRectangle(bcolor, x, y, 2, 2);
        }

        void drawLineBy_DDA(int x0, int xEnd, int y0, int yEnd, Graphics graph, Color lineColor)
        {
            int dx = xEnd - x0, dy = yEnd - y0, steps, k;
            float xIncrement, yIncrement, x = x0, y = y0;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = (float)dx / (float)steps;
            yIncrement = (float)dy / (float)steps;


            PutPixel(graph, (int)Math.Round(x), (int)Math.Round(y), lineColor);
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;

                PutPixel(graph, (int)Math.Round(x), (int)Math.Round(y), lineColor);

            }


        }
        // drawLIineby_Bresenham(x1, x2, y1, y2, Object1, Color.Black);

        public void drawLIineby_Bresenham(int x0, int xEnd, int y0, int yEnd, Graphics graph, Color lineColor)
        {
            int dx = Math.Abs(xEnd - x0), dy = Math.Abs(yEnd - y0);
            int x, y, p = 2 * dy - dx;
            int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);

            /* Determine which endpoint to use as start position.  */
            if (x0 > xEnd)
            {
                x = xEnd;
                y = yEnd;
                xEnd = x0;
            }
            else
            {
                x = x0;
                y = y0;
            }
            PutPixel(graph, x, y, lineColor);

            while (x < xEnd)
            {
                x++;
                if (p < 0)
                {
                    p += twoDy;

                }
                else
                {
                    y++;
                    p += twoDyMinusDx;
                }
                PutPixel(graph, x, y, lineColor);

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics Object1 = panel2.CreateGraphics();
            drawLIineby_Bresenham(x1, x2, y1, y2, Object1, Color.Black);
        }
    }
}
