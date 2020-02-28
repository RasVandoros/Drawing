using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    class Circle : Shape
    {
        private Point centre;
        public Point Centre
        {
            get { return centre; }
            set { centre = value; }
        }
        Point plotPt;

        private int radius;
        public int Radious
        {
            get { return radius; }
            set { radius= value; }
        }
        //Constructor        
        public Circle(Point point1, Point point2)        
        {
            centre = Utils.FindCentre(point1, point2);
            radius = (int)(Utils.GetDistance(point1, point2) / 2);
            IsSelected = false;
        }

        // Method fills in one pixel only        
        private void PutPixel(Graphics g, Point pixel)
        {
            Brush aBrush = (Brush)Brushes.Black;
            // FillRectangle call fills at location x y and is 1 pixel high by 1 pixel wide            
            g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
        }
        public override void Highlight(Graphics g)
        {
            IterateCircle(g, Utils.HighlightPixel);
            Draw(g);
        }
        public override void Draw(Graphics g)
        {
            IterateCircle(g, PutPixel);
        }
        public void IterateCircle(Graphics g, Action<Graphics, Point> ApplyTechnique)
        {
            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;
            // initial value           
            while (x <= y)
            {
                // put pixel in each octant
                plotPt.X = x + centre.X;
                plotPt.Y = y + centre.Y;
                ApplyTechnique(g, plotPt);
                plotPt.X = y + centre.X;
                plotPt.Y = x + centre.Y;
                ApplyTechnique(g, plotPt);
                plotPt.X = y + centre.X;
                plotPt.Y = -x + centre.Y;
                ApplyTechnique(g, plotPt);
                plotPt.X = x + centre.X;
                plotPt.Y = -y + centre.Y;
                ApplyTechnique(g, plotPt);
                plotPt.X = -x + centre.X;
                plotPt.Y = -y + centre.Y;
                ApplyTechnique(g, plotPt);
                plotPt.X = -y + centre.X;
                plotPt.Y = -x + centre.Y;
                ApplyTechnique(g, plotPt);
                plotPt.X = -y + centre.X;
                plotPt.Y = x + centre.Y;
                ApplyTechnique(g, plotPt);
                plotPt.X = -x + centre.X;
                plotPt.Y = y + centre.Y;
                ApplyTechnique(g, plotPt);

                // update d value                 
                if (d <= 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }
        public override double CheckDistance(Point p)
        {
            double distance = Utils.GetDistance(centre, p);
            if (distance <= radius)
            {
                return distance;
            }
            return -1;
        }
    }
}
