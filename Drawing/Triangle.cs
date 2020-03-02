using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Drawing
{
    public class Triangle : Shape
    {
        private List<PointF> positions;      // these points identify opposite corners of the square
        public override List<PointF> Positions   // property
        {
            get { return positions; }
            set
            {
                positions = value;
            }
        }
        public float Area
        {
            get { return Utils.TriangleAreaCalculator(Positions[0], Positions[1], Positions[2]); }
        }
        public override PointF Center
        {
            get
            {
                PointF center = new PointF();
                center.X = (Positions[0].X + Positions[1].X + Positions[2].X) / 3;
                center.Y = (Positions[0].Y + Positions[1].Y + Positions[2].Y) / 3;
                return center;
            }
            set { }

        }
        public Triangle(PointF point1, PointF point2, PointF point3)   // constructor
        {
            Positions = new List<PointF>() { point1, point2, point3 };
        }
        public override void Highlight(Graphics g)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawLine(greenPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(greenPen, (int)Positions[1].X, (int)Positions[1].Y, (int)Positions[2].X, (int)Positions[2].Y);
            g.DrawLine(greenPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[2].X, (int)Positions[2].Y);






            ;
        }
        public override void Draw(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black);
            // draw triangle
            g.DrawLine(blackPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(blackPen, (int)Positions[1].X, (int)Positions[1].Y, (int)Positions[2].X, (int)Positions[2].Y);
            g.DrawLine(blackPen, (int)Positions[0].X, (int)Positions[0].Y, (int)Positions[2].X, (int)Positions[2].Y);
            PutPixel(g, Center);

            Label origin = new Label();
            GrafPack gp = new GrafPack();
            origin.Text = ("(" + Center.X + ", " + Center.Y + ")");
            origin.Location = new Point((int)Center.X, (int)Center.Y);
            gp.Controls.Add(origin);
        }
        public override float CheckDistance(PointF p)
        {
            if (IsInsideTriangle(p))
            {
                float distance = Utils.GetDistance(Center, p);
                return distance;
            }
            return -1;
        }
        public bool IsInsideTriangle(PointF p)
        {
            float myTriangleArea = Area;
            float area1 = Utils.TriangleAreaCalculator(p, Positions[0], Positions[1]);
            float area2 = Utils.TriangleAreaCalculator(p, Positions[1], Positions[2]);
            float area3 = Utils.TriangleAreaCalculator(p, Positions[0], Positions[2]);
            float temp1 = area1 + area2 + area3;
            float temp2 = myTriangleArea - temp1;
            if (temp2 <= 4 && temp2 >= -4)
            {
                return true;
            }
            return false;
        }
        public override Shape TranslateX(int displacement)
        {
            PointF newPoint1 = this.Positions[0];
            newPoint1.X += displacement;
            PointF newPoint2 = this.Positions[1];
            newPoint2.X += displacement;
            PointF newPoint3 = this.Positions[2];
            newPoint3.X += displacement;
            Positions = new List<PointF>() { newPoint1, newPoint2, newPoint3 };
            return this;
        }
        public override Shape TranslateY(int displacement)
        {
            PointF newPoint1 = this.Positions[0];
            newPoint1.Y += displacement;
            PointF newPoint2 = this.Positions[1];
            newPoint2.Y += displacement;
            PointF newPoint3 = this.Positions[2];
            newPoint3.Y += displacement;
            Positions = new List<PointF>() { newPoint1, newPoint2, newPoint3 };
            return this;
        }
        public override Shape Rotate(float angle)
        {
            PointF newPoint1 = this.Rotate_point(Center, angle, Positions[0]);
            PointF newPoint2 = this.Rotate_point(Center, angle, Positions[1]);
            PointF newPoint3 = this.Rotate_point(Center, angle, Positions[2]);
            Positions = new List<PointF>() { newPoint1, newPoint2, newPoint3 };
            return this;
        }
        public override Shape Resize(float scale)
        {
            PointF newPoint1 = this.Resize_point(Center, scale, Positions[0]);
            PointF newPoint2 = this.Resize_point(Center, scale, Positions[1]);
            PointF newPoint3 = this.Resize_point(Center, scale, Positions[2]);
            Positions = new List<PointF>() { newPoint1, newPoint2, newPoint3 };
            return this;
        }
    }
}
