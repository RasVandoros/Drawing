using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public static class Utils
    {
        public static double GetDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
        public static double TriangleAreaCalculator(Point p1, Point p2, Point p3)
        {
            return Math.Abs(p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2;
        }

        internal static bool IsDouble(string text)
        {
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            isDouble = Double.TryParse(text, out double num);
            return isDouble;
        }

        public static Point GetTriangleCenter(Point p1, Point p2, Point p3)
        {
            Point center = new Point();
            center.X = (p1.X + p2.X + p3.X) / 3;
            center.Y = (p1.Y + p2.Y + p3.Y) / 3;
            return center;
        }
        internal static Point FindCentre(Point point1, Point point2)
        {
            Point centre = new Point();
            centre.X = (point1.X + point2.X) / 2;
            centre.Y = (point1.Y + point2.Y) / 2;
            return centre;
        }
        public static void HighlightPixel(Graphics g, Point pixel)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawRectangle(greenPen, pixel.X, pixel.Y, 1, 1);
        }
        public static void DeHighlightPixel(Graphics g, Point pixel)
        {
            Pen eraser = new Pen(GrafPack.ActiveForm.BackColor, 10);
            eraser.Alignment = PenAlignment.Center;
            g.DrawRectangle(eraser, pixel.X, pixel.Y, 1, 1);
        }
    }
}
