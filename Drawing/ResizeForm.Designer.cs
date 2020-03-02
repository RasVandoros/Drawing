namespace Drawing
{
    partial class ResizeForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.xDisplacement = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.yDisplacement = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.resizeTrack = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resizeTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(85, 248);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 33;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // xDisplacement
            // 
            this.xDisplacement.AutoSize = true;
            this.xDisplacement.Location = new System.Drawing.Point(9, 169);
            this.xDisplacement.Name = "xDisplacement";
            this.xDisplacement.Size = new System.Drawing.Size(30, 13);
            this.xDisplacement.TabIndex = 31;
            this.xDisplacement.Text = "7.5%";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(81, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 26);
            this.label7.TabIndex = 30;
            this.label7.Text = "Resize";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yDisplacement
            // 
            this.yDisplacement.AutoSize = true;
            this.yDisplacement.Location = new System.Drawing.Point(112, 169);
            this.yDisplacement.Name = "yDisplacement";
            this.yDisplacement.Size = new System.Drawing.Size(33, 13);
            this.yDisplacement.TabIndex = 29;
            this.yDisplacement.Text = "100%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Examimed shape:";
            // 
            // resizeTrack
            // 
            this.resizeTrack.Location = new System.Drawing.Point(12, 186);
            this.resizeTrack.Name = "resizeTrack";
            this.resizeTrack.Size = new System.Drawing.Size(237, 45);
            this.resizeTrack.TabIndex = 35;
            this.resizeTrack.Tag = "Scale";
            this.resizeTrack.Value = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "200%";
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 299);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resizeTrack);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.xDisplacement);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.yDisplacement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResizeForm";
            this.Text = "ResizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.resizeTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label xDisplacement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label yDisplacement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar resizeTrack;
        private System.Windows.Forms.Label label3;
    }
}