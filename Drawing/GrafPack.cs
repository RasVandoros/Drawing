using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing
{
    public partial class GrafPack : Form
    {
        // Booleans to control the enabled mode
        private bool selectShapeMode = false;
        private bool createShapeMode = false;
        private bool selectSquareStatus = false;
        private bool selectTriangleStatus = false;
        private bool selectCircleStatus = false;

        //Get-Set methods for boolean mode variables. Set updates the display.
        public bool SelectShapeMode
        {
            get { return selectShapeMode; }
            set
            {
                selectShapeMode = value;
                Controls.Clear();
                UpdateModeDisplay();
            }
        }
        public bool CreateShapeMode
        {
            get { return createShapeMode; }
            set
            {
                createShapeMode = value;
                Controls.Clear();
                UpdateModeDisplay();
            }
        }
        public bool SelectSquareStatus
        {
            get { return selectSquareStatus; }
            set
            {
                selectSquareStatus = value;
                Controls.Clear();
                UpdateModeDisplay();
            }
        }
        public bool SelectTriangleStatus
        {
            get { return selectTriangleStatus; }
            set
            {
                selectTriangleStatus = value;
                Controls.Clear();
                UpdateModeDisplay();
            }
        }
        public bool SelectCircleStatus
        {
            get { return selectCircleStatus; }
            set
            {
                selectCircleStatus = value;
                Controls.Clear();
                UpdateModeDisplay();
            }
        }

        private int clicknumber = 0; // Counts clicks
        private PointF one;
        private PointF two;
        private PointF three;
        private int selectedIndex; //Stores index of the selected shape
        private ContextMenu mnu;
        public static List<Shape> activeShapes = new List<Shape>(); //Stores the shapes on the active on the canvas
        public Label modeDisplay; //Label desplaying the activated Mode

        public GrafPack()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            //Adding menu items
            MainMenu mainMenu = new MainMenu();
            MenuItem createItem = new MenuItem();
            MenuItem selectItem = new MenuItem();
            MenuItem deleteItem = new MenuItem();
            MenuItem transformItem = new MenuItem();
            MenuItem resizeItem = new MenuItem();
            MenuItem squareItem = new MenuItem();
            MenuItem triangleItem = new MenuItem();
            MenuItem circleItem = new MenuItem();
            MenuItem moveRotateItem = new MenuItem();
            MenuItem exitItem = new MenuItem();

            createItem.Text = "&Create";
            squareItem.Text = "&Square";
            triangleItem.Text = "&Triangle";
            circleItem.Text = "&Circle";
            selectItem.Text = "&Select";
            deleteItem.Text = "&Delete";
            transformItem.Text = "&Transform";
            moveRotateItem.Text = "&Move/Rotate";
            resizeItem.Text = "&Resize";
            exitItem.Text = "&Exit";

            mainMenu.MenuItems.Add(createItem);
            mainMenu.MenuItems.Add(selectItem);
            mainMenu.MenuItems.Add(deleteItem);
            mainMenu.MenuItems.Add(transformItem);
            mainMenu.MenuItems.Add(exitItem);

            createItem.MenuItems.Add(squareItem);
            createItem.MenuItems.Add(triangleItem);
            createItem.MenuItems.Add(circleItem);
            transformItem.MenuItems.Add(moveRotateItem);
            transformItem.MenuItems.Add(resizeItem);

            //Setting the on click events for the menu options
            selectItem.Click += new System.EventHandler(this.SelectShape);
            deleteItem.Click += new System.EventHandler(this.OnDeleteClick);
            squareItem.Click += new System.EventHandler(this.SelectSquare);
            triangleItem.Click += new System.EventHandler(this.SelectTriangle);
            circleItem.Click += new System.EventHandler(this.SelectCircle);
            moveRotateItem.Click += new System.EventHandler(this.OnTransformClick);
            resizeItem.Click += new EventHandler(this.OnResizeClick);
            exitItem.Click += new EventHandler(this.OnExitClick);

            this.Menu = mainMenu;
            this.MouseClick += OnMouseClick;

            mnu = new ContextMenu();
            MenuItem mnuTransform = new MenuItem("Transform");
            MenuItem mnuResize = new MenuItem("Resize");
            MenuItem mnuDeselect = new MenuItem("Deselect");

            mnuTransform.Click += new EventHandler(OnTransformClick);
            mnuResize.Click += new EventHandler(OnResizeClick);
            mnuDeselect.Click += new EventHandler(OnDeselectClick);

            mnu.MenuItems.AddRange(new MenuItem[] { mnuTransform, mnuResize, mnuDeselect });
            ContextMenu = mnu;
            HideContextMenu();
            selectedIndex = -1;
            SelectShapeMode = true; //On startup, selection mode is enabled.
            CreateShapeMode = false;
            SelectSquareStatus = false;
            SelectTriangleStatus = false;
            SelectCircleStatus = false;
        }

        /// <summary>
        /// Exit Click close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExitClick(object sender, EventArgs e)
        {
            string message = "Are you sure you would like to exit?";
            string title = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
            else
            {
                return;
            }
            ResetMode();
        }

        /// <summary>
        /// Deselects the previously selected shape clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeselectClick(object sender, EventArgs e)
        {
            DeselectShape();
        }

        /// <summary>
        /// Deselects the selected shape.
        /// </summary>
        private void DeselectShape()
        {
            activeShapes[selectedIndex].IsSelected = false;
            selectedIndex = -1;
            RefreshDrawings();
        }

        /// <summary>
        /// Initiates resizing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnResizeClick(object sender, EventArgs e)
        {
            ResizeShape();
        }

        /// <summary>
        /// Resizes the selected shape
        /// </summary>
        private void ResizeShape()
        {
            if (selectedIndex != -1)
            {
                ResizeForm resizeForm = new ResizeForm(activeShapes[selectedIndex]);
                resizeForm.ShowDialog();
                this.Controls.Clear();
                SelectShapeMode = true;
                RefreshDrawings();
            }
            else
            {
                MessageBox.Show("Please select a shape first!");
                ResetMode();
                SelectShapeMode = true;
            }
        }

        /// <summary>
        /// Initiate Create Square mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectSquare(object sender, EventArgs e)
        {
            ResetMode();
            SelectSquareStatus = true;
            CreateShapeMode = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a square");
        }

        /// <summary>
        /// Initiate Create Triangle mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTriangle(object sender, EventArgs e)
        {
            ResetMode();
            SelectTriangleStatus = true;
            CreateShapeMode = true;

            MessageBox.Show("Click OK and then click once each at three locations to create a triangle");
        }

        /// <summary>
        /// Initiate Create Circle mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCircle(object sender, EventArgs e)
        {
            ResetMode();
            SelectCircleStatus = true;
            CreateShapeMode = true;
            MessageBox.Show("Click OK and then click once each at two locations to create a circle");
        }

        /// <summary>
        /// Initiate select shape mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectShape(object sender, EventArgs e)
        {
            ResetMode();
            SelectShapeMode = true;
        }

        /// <summary>
        /// Initiate Transformation of the shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTransformClick(object sender, EventArgs e)
        {
            TransformShape();
        }

        /// <summary>
        /// Initiate the tranformation form. Pass the selected object.
        /// </summary>
        private void TransformShape()
        {
            if (selectedIndex != -1)
            {
                TranformationForm rf = new TranformationForm(activeShapes[selectedIndex]);
                rf.ShowDialog();
                this.Controls.Clear();
                SelectShapeMode = true;
                RefreshDrawings();
            }
            else
            {
                MessageBox.Show("Please select a shape first!");
                ResetMode();
                SelectShapeMode = true;
            }
        }
        private void OnDeleteClick(object sender, EventArgs e)
        {
            DeleteShape();
        }
        
        /// <summary>
        /// Delete selected shape.
        /// </summary>
        private void DeleteShape()
        {
            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select a shape first!");
                ResetMode();
                SelectShapeMode = true;
                return;
            }
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
                        activeShapes.RemoveAt(i); //Remove the shape from the list of active shapes
                        selectedIndex = -1; //Set the selected index to -1 to indecate that no shape is selected
                    }
                }
                this.Controls.Clear();
                RefreshDrawings();
                SelectShapeMode = true;
            }
            ResetMode();
        }

        /// <summary>
        /// Record left clicks. Act depending on the active mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (CreateShapeMode)
                {
                    if (SelectSquareStatus == true)
                    {
                        CreateSquare(e);
                    }

                    else if (SelectTriangleStatus == true)
                    {
                        CreateTriangle(e);
                    }

                    else if (SelectCircleStatus == true)
                    {
                        CreateCircle(e);
                    }
                }
                else if (SelectShapeMode)
                {
                    Highlight(e);
                }
            }
        }

        /// <summary>
        /// Highlight shape. If clicked shape is already highlighted, deselect it.
        /// </summary>
        /// <param name="e"></param>
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
                    oldHightlightId = i; //find the previously highlighted shape id
                }
                float distance = activeShapes[i].CheckDistance(point);
                //find the shape closest to the captured click and set its id as the id of the selected shape
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

        /// <summary>
        /// Refresh drawings on the screen by cleaning up and redrawing based on the activeShapes list
        /// </summary>
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

        /// <summary>
        /// Draw a circle, by capturing 2 clicks to define the diameter.
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// Draw a triangle, by capturing 3 clicks to define each angle point.
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// Draw a square, by capturing 2 clicks to define two oposite diagonal points.
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        ///  Reset the mode by setting all mode booleans to false.
        /// </summary>
        private void ResetMode()
        {
            SelectShapeMode = false;
            CreateShapeMode = false;
            SelectSquareStatus = false;
            SelectTriangleStatus = false;
            SelectCircleStatus = false;
            clicknumber = 0;
        }

        /// <summary>
        /// Show context menu items
        /// </summary>
        private void ShowContextMenu()
        {
            foreach (MenuItem item in mnu.MenuItems)
            {
                item.Visible = true;
            }
        }

        /// <summary>
        /// Hide context menu items
        /// </summary>
        private void HideContextMenu()
        {
            foreach (MenuItem item in mnu.MenuItems)
            {
                item.Visible = false;
            }
        }

        /// <summary>
        /// Captures key presses. 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (selectedIndex == -1)
            {
                if (activeShapes.Count < 1)
                {
                    return false;
                }
                else
                {
                    if (keyData == Keys.Right || keyData == Keys.Left) //If no item is selected, Left and right arrow press sets first item as selected
                    {
                        selectedIndex = 0;
                        activeShapes[0].IsSelected = true;
                        RefreshDrawings();
                        return true;
                    }
                }
            }
            if (keyData == Keys.D) //When "D" is pressed, delete selected shape.
            {
                DeleteShape();
                return true;
            }
            else if (keyData == Keys.T) //When "T" is pressed, transform selected shape.
            {
                TransformShape();
                return true;
            }
            else if (keyData == Keys.R)//When "T" is pressed, resize selected shape.
            {
                ResizeShape();
                return true;
            }
            activeShapes[selectedIndex].IsSelected = false;
            if (keyData == Keys.Right) //Left and right arrow press rotates selected item index within the active shapes list
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
            else if (keyData == Keys.Left)
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
        
        /// <summary>
        /// On paint, refresh the drawings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrafPack_Paint(object sender, PaintEventArgs e)
        {
            RefreshDrawings();
        }

        /// <summary>
        /// Prin the coordinates of the center of each shape on the canvas.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PrintCoordinates(int x, int y) //int for visual clarity
        {
            Label pixelCoordinates = new Label();
            pixelCoordinates.Location = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
            pixelCoordinates.Text = "(" + x + ", " + y + ")";
            pixelCoordinates.AutoSize = true;
            Controls.Add(pixelCoordinates);
        }
        
        /// <summary>
        /// Updates the display showing the mode selected.
        /// </summary>
        private void UpdateModeDisplay()
        {
            modeDisplay = new Label();
            modeDisplay.Font = new Font("Arial", 16, FontStyle.Bold); ;
            modeDisplay.Dock = DockStyle.Bottom;
            modeDisplay.TextAlign = ContentAlignment.BottomRight;
            if (SelectShapeMode)
            {
                modeDisplay.Text = "Active Mode: Selection";
            }
            else if (CreateShapeMode)
            {
                modeDisplay.Text = "Active Mode: Creation Mode";
                if (SelectSquareStatus)
                {
                    modeDisplay.Text = "Active Mode: Square Creation Mode";
                }
                else if (SelectTriangleStatus)
                {
                    modeDisplay.Text = "Active Mode: Triangle Creation Mode";
                }
                else if (SelectCircleStatus)
                {
                    modeDisplay.Text = "Active Mode: Circle Creation Mode"; ;
                }
            }
            this.Controls.Add(modeDisplay);
        }
    }
}

