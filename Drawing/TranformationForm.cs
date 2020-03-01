using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawing
{
    public partial class TranformationForm : Form
    {
        Shape selected;
        public TranformationForm(Shape s1)
        {
            InitializeComponent();
            selected = s1;
            label2.Text = s1.GetType().Name;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> ht = new Dictionary<string, int>();
            foreach (Control tb in this.Controls)
            {
                if (tb is TextBox)
                {
                    if (!string.IsNullOrEmpty(tb.Text))
                    {
                        if (float.TryParse(tb.Text, out float num))
                        {
                            ht.Add(tb.Name, (int)num);
                        }
                        else
                        {
                            MessageBox.Show("Input provided in " + tb.Name + " is incorrect. \nPlease provide a decimal value!");
                        }
                    }
                }
            }
            if (ht.Count == 0)
            {
                return;
            }
            string message = "You asked for.:\n";
            ICollection keys = ht.Keys;
            foreach (string key in keys)
            {
                message = message + "   - " + key + " of " + ht[key] + "\n";
            }
            message = message + "Would you like to confirm your selection?";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                if (ht.ContainsKey("xTranslation"))
                {
                    GrafPack gp = new GrafPack();
                    int displacement = ht["xTranslation"];
                    TranslateX(displacement);
                }
                if (ht.ContainsKey("yTranslation"))
                {
                    int displacement = ht["yTranslation"];
                    GrafPack gp = new GrafPack();
                    TranslateY(displacement);
                }
                if (ht.ContainsKey("rotation"))
                {
                    int displacement = ht["rotation"];
                    Rotate(displacement);
                }
            }
            else
            {
                return;
            }
            this.Close();
        }

        private void Rotate(int displacement)
        {
            selected = selected.Rotate(displacement);
        }


        public void TranslateX(int displacement)
        {
            selected = selected.TranslateX(displacement);
        }

        public void TranslateY(int displacement)
        {
            selected = selected.TranslateY(displacement);
        }
    }
}
