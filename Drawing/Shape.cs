using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing
{
    public abstract class Shape
    {
        bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        public abstract PointF Center
        {
            get;
            set;
        }
        public abstract List<PointF> Positions
        {
            get;
            set;
        }
        public Shape()// constructor
        {
            IsSelected = false;
        }
        public abstract void Draw(Graphics g);
        public abstract float CheckDistance(PointF p);
        public abstract void Highlight(Graphics g);
        public abstract Shape TranslateX(int displacement);
        public abstract Shape TranslateY(int displacement);
        public abstract Shape Rotate(float angles);
        public abstract Shape Resize(float scale);

        /// <summary>
        /// Rotate a point, around on a second point.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="degrees"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public PointF Rotate_point(PointF o, float degrees, PointF p)
        {
            double angle = (Math.PI / 180) * degrees;
            PointF rotated = new PointF();
            rotated.X = (float)(o.X + Math.Cos(angle) * (p.X - o.X) - Math.Sin(angle) * (p.Y - o.Y));
            rotated.Y = (float)(o.Y + Math.Sin(angle) * (p.X - o.X) + Math.Cos(angle) * (p.Y - o.Y));
            return rotated;
        }

        /// <summary>
        /// Resize a point, based on a second point.
        /// That is performed by adjusting the distance between the two points accorind to the resizing coefficient.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="scale"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public PointF Resize_point(PointF o, float scale, PointF p)
        {
            PointF postResizing = new PointF();
            float length = Utils.GetDistance(p, o);
            length = length * scale;
            postResizing.X = (p.X - o.X) * scale + o.X;
            postResizing.Y = (p.Y - o.Y) * scale + o.Y;
            return postResizing;
        }
        /// <summary>
        /// Draw a single pixel on a point
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pixel"></param>
        public void PutPixel(Graphics g, PointF pixel)
        {
            Brush aBrush = (Brush)Brushes.Black;
            // FillRectangle call fills at location x y and is 1 pixel high by 1 pixel wide            
            g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
        }
    }
}
