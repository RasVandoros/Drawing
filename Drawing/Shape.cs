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
        public PointF Rotate_point(PointF o, float degrees, PointF p)
        {
            double angle = (Math.PI / 180) * degrees;
            PointF rotated = new PointF();
            rotated.X = (float)(o.X + Math.Cos(angle) * (p.X - o.X) - Math.Sin(angle) * (p.Y - o.Y));
            rotated.Y = (float)(o.Y + Math.Sin(angle) * (p.X - o.X) + Math.Cos(angle) * (p.Y - o.Y));
            return rotated;
        }
        public PointF Resize_point(PointF o, float scale, PointF p)
        {
            PointF postResizing = new PointF();
            float length = Utils.GetDistance(p, o);
            length = length * scale;
            postResizing.X = (p.X - o.X) * scale + o.X;
            postResizing.Y = (p.Y - o.Y) * scale + o.Y;
            return postResizing;
        }
        public void PutPixel(Graphics g, PointF pixel)
        {
            Brush aBrush = (Brush)Brushes.Black;
            // FillRectangle call fills at location x y and is 1 pixel high by 1 pixel wide            
            g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
        }
    }
}
