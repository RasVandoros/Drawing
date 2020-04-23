namespace Drawing
{
    partial class TranformationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xDisplacement = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.yDisplacement = new System.Windows.Forms.Label();
            this.rotationDegrees = new System.Windows.Forms.Label();
            this.yTranslation = new System.Windows.Forms.TextBox();
            this.xTranslation = new System.Windows.Forms.TextBox();
            this.rotation = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xDisplacement
            // 
            this.xDisplacement.AutoSize = true;
            this.xDisplacement.Location = new System.Drawing.Point(43, 122);
            this.xDisplacement.Name = "xDisplacement";
            this.xDisplacement.Size = new System.Drawing.Size(80, 13);
            this.xDisplacement.TabIndex = 21;
            this.xDisplacement.Text = "x displacement:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 26);
            this.label7.TabIndex = 20;
            this.label7.Text = "Trasnformation";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yDisplacement
            // 
            this.yDisplacement.AutoSize = true;
            this.yDisplacement.Location = new System.Drawing.Point(43, 162);
            this.yDisplacement.Name = "yDisplacement";
            this.yDisplacement.Size = new System.Drawing.Size(80, 13);
            this.yDisplacement.TabIndex = 19;
            this.yDisplacement.Text = "y displacement:";
            // 
            // rotationDegrees
            // 
            this.rotationDegrees.AutoSize = true;
            this.rotationDegrees.Location = new System.Drawing.Point(43, 201);
            this.rotationDegrees.Name = "rotationDegrees";
            this.rotationDegrees.Size = new System.Drawing.Size(93, 13);
            this.rotationDegrees.TabIndex = 18;
            this.rotationDegrees.Text = "Rotation Degrees:";
            // 
            // yTranslation
            // 
            this.yTranslation.Location = new System.Drawing.Point(158, 158);
            this.yTranslation.Name = "yTranslation";
            this.yTranslation.Size = new System.Drawing.Size(63, 20);
            this.yTranslation.TabIndex = 17;
            // 
            // xTranslation
            // 
            this.xTranslation.Location = new System.Drawing.Point(158, 119);
            this.xTranslation.Name = "xTranslation";
            this.xTranslation.Size = new System.Drawing.Size(63, 20);
            this.xTranslation.TabIndex = 16;
            // 
            // rotation
            // 
            this.rotation.Location = new System.Drawing.Point(158, 198);
            this.rotation.Name = "rotation";
            this.rotation.Size = new System.Drawing.Size(63, 20);
            this.rotation.TabIndex = 22;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(87, 247);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 23;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Examimed shape:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            // 
            // TranformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 299);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.rotation);
            this.Controls.Add(this.xDisplacement);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.yDisplacement);
            this.Controls.Add(this.rotationDegrees);
            this.Controls.Add(this.yTranslation);
            this.Controls.Add(this.xTranslation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TranformationForm";
            this.Text = "Transformation Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label xDisplacement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label yDisplacement;
        private System.Windows.Forms.Label rotationDegrees;
        private System.Windows.Forms.TextBox yTranslation;
        private System.Windows.Forms.TextBox xTranslation;
        private System.Windows.Forms.TextBox rotation;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}