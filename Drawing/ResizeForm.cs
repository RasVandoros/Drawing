using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public partial class ResizeForm : Form
    {
        Shape selected;

        public ResizeForm(Shape s1)
        {
            InitializeComponent();
            selected = s1;
            label2.Text = s1.GetType().Name;
        }

        /// <summary>
        /// When the submit button is pressed, the input from the resize tracking bar on the form is gathered. 
        /// Depending on the selected tick, a value of resizing is defined.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {

            int resizeTracker = resizeTrack.Value;
            float scale = 0.0f;
            switch (resizeTracker)
            {
                case 0:
                    scale = 0.125f;
                    break;
                case 1:
                    scale = 0.25f;
                    break;
                case 2:
                    scale = 0.5f;
                    break;
                case 3:
                    scale = 0.75f;
                    break;
                case 4:
                    scale = 0.875f;
                    break;
                case 5:
                    scale = 1.0f;
                    break;
                case 6:
                    scale = 1.125f;
                    break;
                case 7:
                    scale = 1.25f;
                    break;
                case 8:
                    scale = 1.5f;
                    break;
                case 9:
                    scale = 1.75f;
                    break;
                case 10:
                    scale = 2.0f;
                    break;
            }
            string message = "You asked for resize of ";
            message = message + scale + " of the original shape.";
            message = message + "Would you like to confirm your selection?";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                selected.Resize(scale);
            }
            else
            {
                return;
            }
            this.Close();
        }

        private void ResizeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
