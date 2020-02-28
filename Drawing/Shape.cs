using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    abstract class Shape
    {
        bool isSelected;
        public bool IsSelected {
            get { return isSelected; }  
            set { isSelected = value; }  
        }

        // This is the base class for Shapes in the application. It should allow an array or LL
        // to be created containing different kinds of shapes.
        public Shape()// constructor
        {
        }
        public abstract void Draw(Graphics g);
        public abstract double CheckDistance(Point p);
        public abstract void Highlight(Graphics g);
    }

}
