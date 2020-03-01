using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
                if(tb is TextBox)
                {
                    if (!string.IsNullOrEmpty(tb.Text))
                    {
                        if (Double.TryParse(tb.Text, out double num))
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
            string message = "You asked for.:\n ";
            ICollection keys = ht.Keys;
            foreach (string key in keys)
            {
                message = message + key + " of " + ht[key]+ "\n";
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
        }

        private void Rotate(int displacement)
        {
            throw new NotImplementedException();
        }


        public void TranslateX(int displacement)
        {
            for (int i = 0; i < GrafPack.activeShapes.Count; i++)
            {
                if (GrafPack.activeShapes[i].IsSelected)
                {
                    GrafPack.activeShapes[i] = GrafPack.activeShapes[i].xTranslate(displacement);
                    break;
                }
            }
        }

        public void TranslateY(int displacement)
        {
            for (int i = 0; i < GrafPack.activeShapes.Count; i++)
            {
                if (GrafPack.activeShapes[i].IsSelected)
                {
                    GrafPack.activeShapes[i] = GrafPack.activeShapes[i].yTranslate(displacement);
                }
            }
        }

        public void asd(int displacement)
        {
            int index = -1;
            for (int i = 0; i < GrafPack.activeShapes.Count; i++)
            {
                if (GrafPack.activeShapes[i].IsSelected)
                {
                    index = i;
                    if (GrafPack.activeShapes[i].GetType().Name == "Square")
                    {
                        Point newPoint1 = GrafPack.activeShapes[i].Positions[0];
                        newPoint1.X += displacement;
                        Point newPoint2 = GrafPack.activeShapes[i].Positions[1];
                        newPoint2.X += displacement;
                        GrafPack.activeShapes[i] = new Square(newPoint1, newPoint2);

                    }
                    else if (GrafPack.activeShapes[i].GetType().Name == "Triangle")
                    {
                        Point newPoint1 = GrafPack.activeShapes[i].Positions[0];
                        newPoint1.X += displacement;
                        Point newPoint2 = GrafPack.activeShapes[i].Positions[1];
                        newPoint2.X += displacement;
                        Point newPoint3 = GrafPack.activeShapes[i].Positions[2];
                        newPoint2.X += displacement;
                        GrafPack.activeShapes[i] = new Triangle(newPoint1, newPoint2, newPoint3);
                    }
                    else if (GrafPack.activeShapes[i].GetType().Name == "Circle")
                    {
                        Point newPoint1 = GrafPack.activeShapes[i].Positions[0];
                        newPoint1.X += displacement;
                        Point newPoint2 = GrafPack.activeShapes[i].Positions[1];
                        newPoint2.X += displacement;
                        GrafPack.activeShapes[i] = new Circle(newPoint1, newPoint2);
                    }
                    else
                    {
                        return;
                    }
                    break;
                }
            }
        }

    }
}
