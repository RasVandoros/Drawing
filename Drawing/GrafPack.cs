using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing
{
    public partial class GrafPack : Form
    {
        private bool selectShapeMode = false;
        private bool createShapeMode = false;
        private bool selectSquareStatus = false;
        private bool selectTriangleStatus = false;
        private bool selectCircleStatus = false;
        private int clicknumber = 0;
        private PointF one;
        private PointF two;
        private PointF three;
        private int selectedIndex;
        private ContextMenu mnu;
        public static List<Shape> activeShapes = new List<Shape>();

        public GrafPack()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            MainMenu mainMenu = new MainMenu();
            MenuItem createItem = new MenuItem();
            MenuItem selectItem = new MenuItem();
            MenuItem deleteItem = new MenuItem();
            MenuItem transformItem = new MenuItem();
            MenuItem squareItem = new MenuItem();
            MenuItem triangleItem = new MenuItem();
            MenuItem circleItem = new MenuItem();
            MenuItem moveRotateItem = new MenuItem();

            createItem.Text = "&Create";
            squareItem.Text = "&Square";
            triangleItem.Text = "&Triangle";
            circleItem.Text = "&Circle";
            selectItem.Text = "&Select";
            deleteItem.Text = "&Delete";
            transformItem.Text = "&Transform";
            moveRotateItem.Text = "&Move/Rotate";

            mainMenu.MenuItems.Add(createItem);
            mainMenu.MenuItems.Add(selectItem);
            mainMenu.MenuItems.Add(deleteItem);
            mainMenu.MenuItems.Add(transformItem);
            createItem.MenuItems.Add(squareItem);
            createItem.MenuItems.Add(triangleItem);
            createItem.MenuItems.Add(circleItem);
            transformItem.MenuItems.Add(moveRotateItem);

            selectItem.Click += new System.EventHandler(this.SelectShape);
            deleteItem.Click += new System.EventHandler(this.DeleteShape);
            squareItem.Click += new System.EventHandler(this.SelectSquare);
            triangleItem.Click += new System.EventHandler(this.SelectTriangle);
            circleItem.Click += new System.EventHandler(this.SelectCircle);
            moveRotateItem.Click += new System.EventHandler(this.SelectTransform);
            this.Menu = mainMenu;
            this.MouseClick += mouseClick;
            mnu = new ContextMenu();
            MenuItem mnuTransform = new MenuItem("Transform");
            mnuTransform.Click += new EventHandler(SelectTransform);
            mnu.MenuItems.AddRange(new MenuItem[] { mnuTransform });
            ContextMenu = mnu;
            HideContextMenu();
            selectedIndex = -1;

        }
        private void SelectSquare(object sender, EventArgs e)
        {
            ResetMode();
            selectSquareStatus = true;
            createShapeMode = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a square");
        }
        private void SelectTriangle(object sender, EventArgs e)
        {
            ResetMode();
            selectTriangleStatus = true;
            createShapeMode = true;

            MessageBox.Show("Click OK and then click once each at three locations to create a triangle");
        }
        private void SelectCircle(object sender, EventArgs e)
        {
            ResetMode();
            selectCircleStatus = true;
            createShapeMode = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a circle");
        }
        private void SelectShape(object sender, EventArgs e)
        {
            ResetMode();
            selectShapeMode = true;
        }
        private void SelectTransform(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                TranformationForm rf = new TranformationForm(activeShapes[selectedIndex]);
                rf.ShowDialog();
                this.Controls.Clear();
                RefreshDrawings();
            }
            else
            {
                MessageBox.Show("Please select a shape first!");
                ResetMode();
                selectShapeMode = true;
            }
        }
        private void DeleteShape(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete the selected shape?";
            string title = "Delete Shape";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                for (int i = activeShapes.Count - 1; i >= 0; i--)
                {
                    if (activeShapes[i].IsSelected)
                    {
                        activeShapes.RemoveAt(i);
                        selectedIndex = -1;
                    }
                }
                this.Controls.Clear();
                RefreshDrawings();
            }
            ResetMode();
        }
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
            int newHightlightId = -1;
            float minDistance = 99999999f;
            PointF point = new PointF(e.X, e.Y);
            int oldHightlightId = -1;

            for (int i = 0; i < activeShapes.Count; i++)
            {
                if (activeShapes[i].IsSelected)
                {
                    oldHightlightId = i;
                }
                float distance = activeShapes[i].CheckDistance(point);
                if (distance >= 0 && distance <= minDistance)
                {
                    minDistance = distance;
                    newHightlightId = i;
                }
            }
            Graphics g = this.CreateGraphics();
            if (newHightlightId != -1)
            {
                ShowContextMenu();
                if (oldHightlightId != -1)
                {
                    if (oldHightlightId != newHightlightId)
                    {
                        activeShapes[oldHightlightId].IsSelected = false; //deselected previous selected figure
                        activeShapes[newHightlightId].IsSelected = true;
                        selectedIndex = newHightlightId;
                    }
                    else
                    {
                        activeShapes[oldHightlightId].IsSelected = false; //if same is selected - deselect
                        HideContextMenu();
                        selectedIndex = -1;
                    }
                }
                else
                {
                    activeShapes[newHightlightId].IsSelected = true; //no preselected figure, just select new.
                    selectedIndex = newHightlightId;

                }
                RefreshDrawings();
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
                    PrintCoordinates(Convert.ToInt32(s.Center.X), Convert.ToInt32(s.Center.Y));
                }
                else
                {
                    s.Draw(g);
                    PrintCoordinates(Convert.ToInt32(s.Center.X), Convert.ToInt32(s.Center.Y));
                }
            }
        }
        private void CreateCircle(MouseEventArgs e)
        {
            if (clicknumber == 0)
            {
                one = new PointF(e.X, e.Y);
                clicknumber = 1;
            }
            else
            {
                two = new PointF(e.X, e.Y);
                clicknumber = 0;
                Graphics g = this.CreateGraphics();
                Pen blackpen = new Pen(Color.Black);

                Circle aShape = new Circle(one, two);
                activeShapes.Add(aShape);
                aShape.Draw(g);
            }
            RefreshDrawings();
        }
        private void CreateTriangle(MouseEventArgs e)
        {
            if (clicknumber == 0)
            {
                one = new PointF(e.X, e.Y);
                clicknumber = 1;
            }
            else if (clicknumber == 1)
            {
                two = new PointF(e.X, e.Y);
                clicknumber = 2;
            }
            else
            {
                three = new PointF(e.X, e.Y);
                clicknumber = 0;
                Graphics g = this.CreateGraphics();
                Pen blackpen = new Pen(Color.Black);

                Triangle aShape = new Triangle(one, two, three);
                activeShapes.Add(aShape);
                aShape.Draw(g);
            }
            RefreshDrawings();
        }
        private void CreateSquare(MouseEventArgs e)
        {
            if (clicknumber == 0)
            {
                one = new PointF(e.X, e.Y);
                clicknumber = 1;
            }
            else
            {
                two = new PointF(e.X, e.Y);
                clicknumber = 0;
                Graphics g = this.CreateGraphics();
                Square aShape = new Square(one, two);
                activeShapes.Add(aShape);
                aShape.Draw(g);
            }
            RefreshDrawings();
        }
        private void ResetMode()
        {
            selectShapeMode = false;
            createShapeMode = false;
            selectSquareStatus = false;
            selectTriangleStatus = false;
            selectCircleStatus = false;
            clicknumber = 0;
        }
        private void ShowContextMenu()
        {
            foreach (MenuItem item in mnu.MenuItems)
            {
                item.Visible = true;
            }
        }
        private void HideContextMenu()
        {
            foreach (MenuItem item in mnu.MenuItems)
            {
                item.Visible = false;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        { 
            if (selectedIndex == -1)
            {
                if(activeShapes.Count < 1)
                {
                    return false;
                }
                else
                {
                    selectedIndex = 0;
                    activeShapes[0].IsSelected = true;
                    RefreshDrawings();
                    return true;
                }
            }
            activeShapes[selectedIndex].IsSelected = false;
            if (keyData == Keys.Right)
            {
                if (selectedIndex + 1 < activeShapes.Count)
                {
                    selectedIndex++;
                }
                else
                {
                    selectedIndex = 0;
                }
            }
            if (keyData == Keys.Left)
            {
                if (selectedIndex - 1 >= 0)
                {
                    selectedIndex--;
                }
                else
                {
                    selectedIndex = activeShapes.Count - 1;
                }
            }
            activeShapes[selectedIndex].IsSelected = true;
            RefreshDrawings();
            return true;
        }
        private void GrafPack_Paint(object sender, PaintEventArgs e)
        {
            RefreshDrawings();
        }
        private void PrintCoordinates(int x, int y) //int for visual clarity
        {
            Label pixelCoordinates = new Label();
            pixelCoordinates.Location = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            pixelCoordinates.Text = "(" + x + ", " + y + ")";
            pixelCoordinates.AutoSize = true;
            Controls.Add(pixelCoordinates);
        }
    }
}

