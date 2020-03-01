using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Drawing
{
    public static class Utils
    {
        public static float GetDistance(PointF point1, PointF point2)
        {
            return (float)Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
        public static float TriangleAreaCalculator(PointF p1, PointF p2, PointF p3)
        {
            return Math.Abs(p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2;
        }

        internal static bool IsFloat(string text)
        {
            bool isFloat = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            isFloat = float.TryParse(text, out float num);
            return isFloat;
        }

        internal static PointF FindCentre(PointF point1, PointF point2)
        {
            PointF centre = new PointF();
            centre.X = (point1.X + point2.X) / 2;
            centre.Y = (point1.Y + point2.Y) / 2;
            return centre;
        }
        public static void HighlightPixel(Graphics g, PointF pixel)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawRectangle(greenPen, pixel.X, pixel.Y, 1, 1);
        }
        public static void DeHighlightPixel(Graphics g, PointF pixel)
        {
            Pen eraser = new Pen(GrafPack.ActiveForm.BackColor, 10);
            eraser.Alignment = PenAlignment.Center;
            g.DrawRectangle(eraser, pixel.X, pixel.Y, 1, 1);
        }
    }
}
