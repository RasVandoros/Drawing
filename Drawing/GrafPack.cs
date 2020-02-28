using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing
{
    public partial class GrafPack : Form
    {
        private MainMenu mainMenu;
        private bool selectShapeMode = false;
        private bool createShapeMode = false;
        private bool deleteShapeMode = false;

        private bool selectSquareStatus = false;
        private bool selectTriangleStatus = false;
        private bool selectCircleStatus = false;
        
        private int clicknumber = 0;
        private Point one;
        private Point two;
        private Point three;

        List<Shape> activeShapes = new List<Shape>();

        public GrafPack()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            // The following approach uses menu items coupled with mouse clicks
            MainMenu mainMenu = new MainMenu();
            MenuItem createItem = new MenuItem();
            MenuItem selectItem = new MenuItem();
            MenuItem deleteItem = new MenuItem();

            MenuItem squareItem = new MenuItem();
            MenuItem triangleItem = new MenuItem();
            MenuItem circleItem = new MenuItem();

            createItem.Text = "&Create";
            squareItem.Text = "&Square";
            triangleItem.Text = "&Triangle";
            circleItem.Text = "&Circle";
            selectItem.Text = "&Select";
            deleteItem.Text = "&Delete";
            
            mainMenu.MenuItems.Add(createItem);
            mainMenu.MenuItems.Add(selectItem);
            mainMenu.MenuItems.Add(deleteItem);
            createItem.MenuItems.Add(squareItem);
            createItem.MenuItems.Add(triangleItem);
            createItem.MenuItems.Add(circleItem);

            selectItem.Click += new System.EventHandler(this.selectShape);
            deleteItem.Click += new System.EventHandler(this.deleteShape);
            squareItem.Click += new System.EventHandler(this.selectSquare);
            triangleItem.Click += new System.EventHandler(this.selectTriangle);
            circleItem.Click += new System.EventHandler(this.selectCircle);

            this.Menu = mainMenu;
            this.MouseClick += mouseClick;
        }
        // Generally, all methods of the form are usually private
        private void selectSquare(object sender, EventArgs e)
        {
            ResetMode();
            selectSquareStatus = true;
            createShapeMode = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a square");
        }
        private void selectTriangle(object sender, EventArgs e)
        {
            ResetMode();
            selectTriangleStatus = true;
            createShapeMode = true;

            MessageBox.Show("Click OK and then click once each at three locations to create a triangle");
        }
        private void selectCircle(object sender, EventArgs e)
        {
            ResetMode();
            selectCircleStatus = true;
            createShapeMode = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a circle");
        }
        private void selectShape(object sender, EventArgs e)
        {
            ResetMode();
            selectShapeMode = true;
            MessageBox.Show("You selected the Select option...");
        }
        private void deleteShape(object sender, EventArgs e)
        {
            ResetMode();
            for (int i = activeShapes.Count - 1; i >= 0; i--)
            {
                if (activeShapes[i].IsSelected)
                {
                    activeShapes.RemoveAt(i);
                }
            }
            RefreshDrawings();
            MessageBox.Show("You selected the Delete option...");
        }
        // This method is quite important and detects all mouse clicks - other methods may need
        // to be implemented to detect other kinds of event handling eg keyboard presses.
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (createShapeMode)
                {
                    if (selectSquareStatus == true)
                    {
                        CreateSquare(e);
                    }

                    else if (selectTriangleStatus == true)
                    {
                        CreateTriangle(e);
                    }

                    else if (selectCircleStatus == true)
                    {
                        CreateCircle(e);
                    }
                }
                else if (selectShapeMode)
                {
                    Highlight(e);
                }
            }
        }
        private void Highlight(MouseEventArgs e)
        {
            Shape highlighted = null;
            double minDistance = 99999999;
            Point point = new Point(e.X, e.Y);
            foreach (Shape shape in activeShapes)
            {
                double distance = shape.CheckDistance(point);
                if (distance >= 0 && distance <= minDistance)
                {
                    minDistance = distance;
                    highlighted = shape;
                }
            }
            Graphics g = this.CreateGraphics();
            if (highlighted != null)
            {
                if (highlighted.IsSelected)
                {
                    highlighted.IsSelected = false;
                    RefreshDrawings();
                }
                else
                {
                    highlighted.Highlight(g);
                    highlighted.IsSelected = true;
                }
            }
        }
        private void RefreshDrawings()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            foreach (Shape s in activeShapes)
            {
                if (s.IsSelected)
                {
                    s.Highlight(g);
                }
                else
                {
                    s.Draw(g);
                }
            }
        }
        private void CreateCircle(MouseEventArgs e)
        {
            if (clicknumber == 0)
            {
                one = new Point(e.X, e.Y);
                clicknumber = 1;
            }
            else
            {
                two = new Point(e.X, e.Y);
                clicknumber = 0;
                Graphics g = this.CreateGraphics();
                Pen blackpen = new Pen(Color.Black);

                Circle aShape = new Circle(one, two);
                activeShapes.Add(aShape);
                aShape.Draw(g);
            }
        }
        private void CreateTriangle(MouseEventArgs e)
        {
            if (clicknumber == 0)
            {
                one = new Point(e.X, e.Y);
                clicknumber = 1;
            }
            else if (clicknumber == 1)
            {
                two = new Point(e.X, e.Y);
                clicknumber = 2;
            }
            else
            {
                three = new Point(e.X, e.Y);
                clicknumber = 0;
                Graphics g = this.CreateGraphics();
                Pen blackpen = new Pen(Color.Black);

                Triangle aShape = new Triangle(one, two, three);
                activeShapes.Add(aShape);
                aShape.Draw(g);
            }
        }
        private void CreateSquare(MouseEventArgs e)
        {
            if (clicknumber == 0)
            {
                one = new Point(e.X, e.Y);
                clicknumber = 1;
            }
            else
            {
                two = new Point(e.X, e.Y);
                clicknumber = 0;
                Graphics g = this.CreateGraphics();
                Square aShape = new Square(one, two);
                activeShapes.Add(aShape);
                aShape.Draw(g);
            }
        }
        private void ResetMode()
        {
            selectShapeMode = false;
            createShapeMode = false;
            selectSquareStatus = false;
            selectTriangleStatus = false;
            selectCircleStatus = false;
        }

    }
}

