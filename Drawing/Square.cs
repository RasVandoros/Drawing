﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Drawing
{
    public class Square : Shape
    {
        private List<PointF> positions;      // these points identify opposite corners of the square
        public override List<PointF> Positions   // property
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

        float xDiff, yDiff;   // range and mid points of x & y 
        
        /// <summary>
        /// The getter method calculates the center of the square
        /// </summary>
        public override PointF Center
        {
            get
            {
                PointF center = new PointF();
                center.X = (Positions[1].X + Positions[0].X) / 2;
                center.Y = (Positions[1].Y + Positions[0].Y) / 2;
                return center;
            }
            set { }

        }

        /// <summary>
        /// Constructor. Adds the relevant positions of the square into the positions list.
        /// </summary>
        /// <param name="keyPt"></param>
        /// <param name="oppPt"></param>
        public Square(PointF keyPt, PointF oppPt)   // constructor
        {
            Positions = new List<PointF>() { keyPt, oppPt };
        }
        public override void Draw(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black);
            // draw square
            g.DrawLine(blackPen, (int)Positions[0].X, (int)Positions[0].Y, (int)(Center.X + yDiff / 2), (int)(Center.Y - xDiff / 2));
            g.DrawLine(blackPen, (int)(Center.X + yDiff / 2), (int)(Center.Y - xDiff / 2), (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(blackPen, (int)Positions[1].X, (int)Positions[1].Y, (int)(Center.X - yDiff / 2), (int)(Center.Y + xDiff / 2));
            g.DrawLine(blackPen, (int)(Center.X - yDiff / 2), (int)(Center.Y + xDiff / 2), (int)Positions[0].X, (int)Positions[0].Y);
            PutPixel(g, new PointF(Center.X, Center.Y));
        }
        public void CalculateMidPoints()
        {
            // calculate ranges and mid points
            xDiff = Positions[1].X - Positions[0].X;
            yDiff = Positions[1].Y - Positions[0].Y;
        }
        public override void Highlight(Graphics g)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawLine(greenPen, (int)Positions[0].X, (int)Positions[0].Y, (int)(Center.X + yDiff / 2), (int)(Center.Y - xDiff / 2));
            g.DrawLine(greenPen, (int)(Center.X + yDiff / 2), (int)(Center.Y - xDiff / 2), (int)Positions[1].X, (int)Positions[1].Y);
            g.DrawLine(greenPen, (int)Positions[1].X, (int)Positions[1].Y, (int)(Center.X - yDiff / 2), (int)(Center.Y + xDiff / 2));
            g.DrawLine(greenPen, (int)(Center.X - yDiff / 2), (int)(Center.Y + xDiff / 2), (int)Positions[0].X, (int)Positions[0].Y);
            Draw(g);
        }
        public override float CheckDistance(PointF p)
        {
            if (IsInsideRectangle(p))
            {
                PointF centre = Utils.FindCentre(Positions[0], Positions[1]);
                float distance = Utils.GetDistance(centre, p);
                return distance;
            }
            return -1;
        }

        /// <summary>
        /// Checks if the click is inside the rectangle 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool IsInsideRectangle(PointF p)
        {
            if (p.X > Positions[0].X && p.X < Positions[1].X && p.Y > Positions[0].Y && p.Y < Positions[1].Y)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// x displacement happens by adding the input value to the x value of the two positions that define the square.
        /// </summary>
        /// <param name="displacement"></param>
        /// <returns></returns>
        public override Shape TranslateX(int displacement)
        {
            PointF newPoint1 = this.Positions[0];
            newPoint1.X += displacement;
            PointF newPoint2 = this.Positions[1];
            newPoint2.X += displacement;
            Positions = new List<PointF>() { newPoint1, newPoint2 };
            return this;
        }
        
        /// <summary>
        /// y displacement happens by adding the input value to the y value of the two positions that define the square.
        /// </summary>
        /// <param name="displacement"></param>
        /// <returns></returns>
        public override Shape TranslateY(int displacement)
        {
            PointF newPoint1 = this.Positions[0];
            newPoint1.Y += displacement;
            PointF newPoint2 = this.Positions[1];
            newPoint2.Y += displacement;
            Positions = new List<PointF>() { newPoint1, newPoint2 };
            return this;
        }

        /// <summary>
        /// Rotation happens by calling the rotate_point method using the input value of the form.
        /// </summary>
        /// <param name="displacement"></param>
        /// <returns></returns>
        public override Shape Rotate(float angle)
        {
            PointF newPoint1 = this.Rotate_point(new PointF(Center.X, Center.Y), angle, Positions[0]);
            PointF newPoint2 = this.Rotate_point(new PointF(Center.X, Center.Y), angle, Positions[1]);
            Positions = new List<PointF>() { newPoint1, newPoint2 };
            return this;
        }

        /// <summary>
        /// Resize happens by calling the resize_point method using the input value of the form.
        /// </summary>
        /// <param name="scale"></param>
        /// <returns></returns>
        public override Shape Resize(float scale)
        {
            PointF newPoint1 = this.Resize_point(Center, scale, Positions[0]);
            PointF newPoint2 = this.Resize_point(Center, scale, Positions[1]);
            Positions = new List<PointF>() { newPoint1, newPoint2 };
            return this;
        }
    }
}
