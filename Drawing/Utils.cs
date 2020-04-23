using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Drawing
{
    public static class Utils
    {
        /// <summary>
        /// Gets distance between two points
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float GetDistance(PointF point1, PointF point2)
        {
            return (float)Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        /// <summary>
        /// Calculates the area of a triangle, defined by three points.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public static float TriangleAreaCalculator(PointF p1, PointF p2, PointF p3)
        {
            return Math.Abs(p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2;
        }

        /// <summary>
        /// Checks if a string is a float.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Find the centre of the line defined by two points.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        internal static PointF FindCentre(PointF point1, PointF point2)
        {
            PointF centre = new PointF();
            centre.X = (point1.X + point2.X) / 2;
            centre.Y = (point1.Y + point2.Y) / 2;
            return centre;
        }

        /// <summary>
        /// Highlight a single pixel
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pixel"></param>
        public static void HighlightPixel(Graphics g, PointF pixel)
        {
            Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
            greenPen.Alignment = PenAlignment.Center;
            g.DrawRectangle(greenPen, pixel.X, pixel.Y, 1, 1);
        }

        /// <summary>
        /// Dehighlight a single pixel.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pixel"></param>
        public static void DeHighlightPixel(Graphics g, PointF pixel)
        {
            Pen eraser = new Pen(GrafPack.ActiveForm.BackColor, 10);
            eraser.Alignment = PenAlignment.Center;
            g.DrawRectangle(eraser, pixel.X, pixel.Y, 1, 1);
        }
    }
}
