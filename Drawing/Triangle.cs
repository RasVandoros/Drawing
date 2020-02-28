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
    class Triangle : Shape
    {
        private Point keyA;
        public Point KeyA
        {
            get { return keyA; }
            set { keyA = value; }
        }

        private Point keyB;
        public Point KeyB
        {
            get { return keyB; }
            set { keyB = value; }
        }
        private Point keyC;
        public Point KeyC
        {
            get { return keyC; }
            set { keyC = value; }
        }

        public double Area
        {
            get { return Utils.TriangleAreaCalculator(KeyA, KeyB, KeyC); }
        }

        public Triangle(Point point1, Point point2, Point point3)   // constructor
        {
            this.keyA = point1;
            this.keyB = point2;
            this.keyC = point3;
            IsSelected = false;
        }

        public override void Highlight(Graphics g)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawLine(greenPen, (int)keyA.X, (int)keyA.Y, (int)keyB.X, (int)keyB.Y);
            g.DrawLine(greenPen, (int)keyB.X, (int)keyB.Y, (int)keyC.X, (int)keyC.Y);
            g.DrawLine(greenPen, (int)keyA.X, (int)keyA.Y, (int)keyC.X, (int)keyC.Y);
            Draw(g);
        }

        public override void Draw(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black);
            // draw triangle
            g.DrawLine(blackPen, (int)keyA.X, (int)keyA.Y, (int)keyB.X, (int)keyB.Y);
            g.DrawLine(blackPen, (int)keyB.X, (int)keyB.Y, (int)keyC.X, (int)keyC.Y);
            g.DrawLine(blackPen, (int)keyA.X, (int)keyA.Y, (int)keyC.X, (int)keyC.Y);
        }

        public override double CheckDistance(Point p)
        {
            if (IsInsideTriangle(p))
            {
                Point centre = Utils.GetTriangleCenter(KeyA, KeyB, KeyC);
                double distance = Utils.GetDistance(centre, p);
                return distance;
            }
            return -1;
        }

        public bool IsInsideTriangle(Point p)
        {
            double myTriangleArea = Area;
            double area1 = Utils.TriangleAreaCalculator(p, KeyA, KeyB);
            double area2 = Utils.TriangleAreaCalculator(p, KeyB, KeyC);
            double area3 = Utils.TriangleAreaCalculator(p, KeyA, KeyC);
            double temp1 = area1 + area2 + area3;
            double temp2 = myTriangleArea - temp1;
            if  (temp2 <= 4 && temp2 >= -4)
            {
                return true;
            }
            return false;
        }
    }
}
