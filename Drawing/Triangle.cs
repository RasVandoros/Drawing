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
    public class Triangle : Shape
    {

        private List<Point> positions;      // these points identify opposite corners of the square
        public override List<Point> Positions   // property
        {
            get { return positions; }
            set
            {
                positions = value;
            }
        }
        public double Area
        {
            get { return Utils.TriangleAreaCalculator(Positions[0], Positions[1], Positions[2]); }
        }

        public Triangle(Point point1, Point point2, Point point3)   // constructor
        {
            Positions = new List<Point>() { point1, point2, point3 };
        }

        public override void Highlight(Graphics g)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawLine(greenPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(greenPen, (int)Positions[1].X, (int)Positions[1].Y, (int)Positions[2].X, (int)Positions[2].Y);
            g.DrawLine(greenPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[2].X, (int)Positions[2].Y);
            Draw(g);
        }

        public override void Draw(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black);
            // draw triangle
            g.DrawLine(blackPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(blackPen, (int)Positions[1].X, (int)Positions[1].Y, (int)Positions[2].X, (int)Positions[2].Y);
            g.DrawLine(blackPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[2].X, (int)Positions[2].Y);
        }

        public override double CheckDistance(Point p)
        {
            if (IsInsideTriangle(p))
            {
                Point centre = Utils.GetTriangleCenter(Positions[0], Positions[1], Positions[2]);
                double distance = Utils.GetDistance(centre, p);
                return distance;
            }
            return -1;
        }

        public bool IsInsideTriangle(Point p)
        {
            double myTriangleArea = Area;
            double area1 = Utils.TriangleAreaCalculator(p, Positions[0], Positions[1]);
            double area2 = Utils.TriangleAreaCalculator(p, Positions[1], Positions[2]);
            double area3 = Utils.TriangleAreaCalculator(p, Positions[0], Positions[2]);
            double temp1 = area1 + area2 + area3;
            double temp2 = myTriangleArea - temp1;
            if  (temp2 <= 4 && temp2 >= -4)
            {
                return true;
            }
            return false;
        }

        public override Shape xTranslate(int displacement)
        {
            Point newPoint1 = this.Positions[0];
            newPoint1.X += displacement;
            Point newPoint2 = this.Positions[1];
            newPoint2.X += displacement;
            Point newPoint3 = this.Positions[2];
            newPoint3.X += displacement;
            Positions = new List<Point>() { newPoint1, newPoint2, newPoint3 };
            return this;
        }
        public override Shape yTranslate(int displacement)
        {
            Point newPoint1 = this.Positions[0];
            newPoint1.Y += displacement;
            Point newPoint2 = this.Positions[1];
            newPoint2.Y += displacement;
            Point newPoint3 = this.Positions[2];
            newPoint3.Y += displacement;
            Positions = new List<Point>() { newPoint1, newPoint2, newPoint3 };
            return this;
        }
    }
}
