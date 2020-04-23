using System;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing
{
    public class Circle : Shape
    {
        private List<PointF> positions; // these points identify opposite points of the circle, defining the diameter. 
        public override List<PointF> Positions   // property
        {
            get { return positions; }
            set
            {
                positions = value;
                if (Positions.Count == 2)
                {
                    Center = Utils.FindCentre(Positions[0], Positions[1]);
                    Radius = (int)(Utils.GetDistance(Positions[0], Positions[1]) / 2);
                }
            }
        }
        private PointF centre;
        public override PointF Center
        {
            get { return centre; }
            set { centre = value; }
        }
        private PointF plotPt;
        private int radius;
        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        //Constructor        
        public Circle(PointF point1, PointF point2)
        {
            Positions = new List<PointF>() { point1, point2 };
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
        /// <summary>
        /// Iterate through each pixel of the circle.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="ApplyTechnique"></param>
        public void IterateCircle(Graphics g, Action<Graphics, PointF> ApplyTechnique)
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
        public override float CheckDistance(PointF p)
        {
            float distance = Utils.GetDistance(Center, p);
            if (distance <= radius)
            {
                return distance;
            }
            return -1;
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
