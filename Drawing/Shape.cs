﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Drawing
{
    public abstract class Shape
    {
        bool isSelected;
        public bool IsSelected {
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

        public PointF Rotate_point(PointF o, float degrees, PointF p)
        {
            /*float s = (float)Math.Sin(angle);
            float c = (float)Math.Cos(angle);

            // translate point back to origin:
            p.X -= pivot.X;
            p.Y -= pivot.Y;

            // rotate point
            float xnew = p.X * c - p.Y * s;
            float ynew = p.X * s + p.Y * c;

            // translate point back:
            p.X = (int)(xnew + pivot.X);
            p.Y = (int)(ynew + pivot.Y);
            return p;
            */
            double angle = (Math.PI / 180) * degrees;
            PointF rotated = new PointF();
            rotated.X = (float)(o.X + Math.Cos(angle) * (p.X - o.X) - Math.Sin(angle) * (p.Y - o.Y));
            rotated.Y = (float)(o.Y + Math.Sin(angle) * (p.X - o.X) + Math.Cos(angle) * (p.Y - o.Y));
            return rotated;
        }

        public void PutPixel(Graphics g, PointF pixel)
        {
            Brush aBrush = (Brush)Brushes.Black;
            // FillRectangle call fills at location x y and is 1 pixel high by 1 pixel wide            
            g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
        }
    }
}
