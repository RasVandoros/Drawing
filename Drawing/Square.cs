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
    public class Square : Shape
    {
        private List<Point> positions;      // these points identify opposite corners of the square
        public override List<Point> Positions   // property
        {
            get { return positions; }   // get method
            set
            {
                positions = value;
                if (Positions.Count == 2)
                {
                    CalculateMidPoints();
                }
            }  // set method
        }

        double xDiff, yDiff, xMid, yMid;   // range and mid points of x & y 

        public Square(Point keyPt, Point oppPt)   // constructor
        {
            Positions = new List<Point>() { keyPt, oppPt};
            IsSelected = false;
        }

        public override void Draw(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black);            
            // draw square
            g.DrawLine(blackPen, (int)Positions[0].X, (int)Positions[0].Y, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2));
            g.DrawLine(blackPen, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(blackPen, (int)Positions[1].X, (int)Positions[1].Y, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2));
            g.DrawLine(blackPen, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2), (int)Positions[0].X, (int)Positions[0].Y);
        }

        public void CalculateMidPoints()
        {
            // calculate ranges and mid points
            xDiff = Positions[1].X - Positions[0].X;
            yDiff = Positions[1].Y - Positions[0].Y;
            xMid = (Positions[1].X + Positions[0].X) / 2;
            yMid = (Positions[1].Y + Positions[0].Y) / 2;
        }
        
        public override void Highlight(Graphics g)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawLine(greenPen, (int)Positions[0].X, (int)Positions[0].Y, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2));
            g.DrawLine(greenPen, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(greenPen, (int)Positions[1].X, (int)Positions[1].Y, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2));
            g.DrawLine(greenPen, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2), (int)Positions[0].X, (int)Positions[0].Y);
            Draw(g);
        }

        public override double CheckDistance(Point p)
        {
            if (IsInsideRectangle(p))
            {
                Point centre = Utils.FindCentre(Positions[0], Positions[1]);
                double distance = Utils.GetDistance(centre, p);
                return distance;
            }
            return -1;
        }

        bool IsInsideRectangle(Point p)
        {
            if (p.X > Positions[0].X && p.X < Positions[1].X && p.Y > Positions[0].Y && p.Y < Positions[1].Y)
                return true;
            return false;
        }

        public override Shape xTranslate(int displacement)
        {
            Point newPoint1 = this.Positions[0];
            newPoint1.X += displacement;
            Point newPoint2 = this.Positions[1];
            newPoint2.X += displacement;
            Positions = new List<Point>() { newPoint1, newPoint2 };
            return this;
        }
        public override Shape yTranslate(int displacement)
        {
            Point newPoint1 = this.Positions[0];
            newPoint1.Y += displacement;
            Point newPoint2 = this.Positions[1];
            newPoint2.Y += displacement;
            Positions = new List<Point>() { newPoint1, newPoint2 };
            return this;
        }

    }
}
