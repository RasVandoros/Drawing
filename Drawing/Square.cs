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
    class Square : Shape
    {
        Point keyPt, oppPt;      // these points identify opposite corners of the square
        double xDiff, yDiff, xMid, yMid;   // range and mid points of x & y 

        public Square(Point keyPt, Point oppPt)   // constructor
        {
            this.keyPt = keyPt;
            this.oppPt = oppPt;
            CalculateMidPoints();
            IsSelected = false;
        }

        public override void Draw(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black);            
            // draw square
            g.DrawLine(blackPen, (int)keyPt.X, (int)keyPt.Y, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2));
            g.DrawLine(blackPen, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), (int)oppPt.X, (int)oppPt.Y);
            g.DrawLine(blackPen, (int)oppPt.X, (int)oppPt.Y, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2));
            g.DrawLine(blackPen, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2), (int)keyPt.X, (int)keyPt.Y);
        }

        public void CalculateMidPoints()
        {
            // calculate ranges and mid points
            xDiff = oppPt.X - keyPt.X;
            yDiff = oppPt.Y - keyPt.Y;
            xMid = (oppPt.X + keyPt.X) / 2;
            yMid = (oppPt.Y + keyPt.Y) / 2;
        }
        
        public override void Highlight(Graphics g)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawLine(greenPen, (int)keyPt.X, (int)keyPt.Y, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2));
            g.DrawLine(greenPen, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), (int)oppPt.X, (int)oppPt.Y);
            g.DrawLine(greenPen, (int)oppPt.X, (int)oppPt.Y, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2));
            g.DrawLine(greenPen, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2), (int)keyPt.X, (int)keyPt.Y);
            Draw(g);
        }

        public override double CheckDistance(Point p)
        {
            if (IsInsideRectangle(p))
            {
                Point centre = Utils.FindCentre(keyPt, oppPt);
                double distance = Utils.GetDistance(centre, p);
                return distance;
            }
            return -1;
        }

        bool IsInsideRectangle(Point p)
        {
            if (p.X > keyPt.X && p.X < oppPt.X && p.Y > keyPt.Y && p.Y < oppPt.Y)
                return true;
            return false;
        }
    }
}
