namespace ImageEditor
{
    partial class ImageEditor
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
            this.OpenButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.FlipVerticalButton = new System.Windows.Forms.Button();
            this.HorizontalFlipButton = new System.Windows.Forms.Button();
            this.RotateButton = new System.Windows.Forms.Button();
            this.InvertButton = new System.Windows.Forms.Button();
            this.SepiaFilterButton = new System.Windows.Forms.Button();
            this.BlackAndWhiteFilterButton = new System.Windows.Forms.Button();
            this.GreenFilterButton = new System.Windows.Forms.Button();
            this.BlueFilterButton = new System.Windows.Forms.Button();
            this.BrightnessHighButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BrightnessLowButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ContrastHighButton = new System.Windows.Forms.Button();
            this.ContrastLowButton = new System.Windows.Forms.Button();
            this.Revert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(636, 379);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(122, 31);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(636, 416);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(122, 31);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PictureBox.Location = new System.Drawing.Point(12, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(590, 386);
            this.PictureBox.TabIndex = 3;
            this.PictureBox.TabStop = false;
            // 
            // FlipVerticalButton
            // 
            this.FlipVerticalButton.Location = new System.Drawing.Point(140, 416);
            this.FlipVerticalButton.Name = "FlipVerticalButton";
            this.FlipVerticalButton.Size = new System.Drawing.Size(122, 31);
            this.FlipVerticalButton.TabIndex = 4;
            this.FlipVerticalButton.Text = "Vertical Flip";
            this.FlipVerticalButton.UseVisualStyleBackColor = true;
            this.FlipVerticalButton.Click += new System.EventHandler(this.FlipVerticalButton_Click);
            // 
            // HorizontalFlipButton
            // 
            this.HorizontalFlipButton.Location = new System.Drawing.Point(12, 416);
            this.HorizontalFlipButton.Name = "HorizontalFlipButton";
            this.HorizontalFlipButton.Size = new System.Drawing.Size(122, 31);
            this.HorizontalFlipButton.TabIndex = 5;
            this.HorizontalFlipButton.Text = "Horizontal Flip";
            this.HorizontalFlipButton.UseVisualStyleBackColor = true;
            this.HorizontalFlipButton.Click += new System.EventHandler(this.HorizontalFlipButton_Click);
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(268, 416);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(122, 31);
            this.RotateButton.TabIndex = 6;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // InvertButton
            // 
            this.InvertButton.Location = new System.Drawing.Point(396, 416);
            this.InvertButton.Name = "InvertButton";
            this.InvertButton.Size = new System.Drawing.Size(122, 31);
            this.InvertButton.TabIndex = 7;
            this.InvertButton.Text = "Invert";
            this.InvertButton.UseVisualStyleBackColor = true;
            this.InvertButton.Click += new System.EventHandler(this.InvertButton_Click);
            // 
            // SepiaFilterButton
            // 
            this.SepiaFilterButton.Location = new System.Drawing.Point(636, 47);
            this.SepiaFilterButton.Name = "SepiaFilterButton";
            this.SepiaFilterButton.Size = new System.Drawing.Size(122, 28);
            this.SepiaFilterButton.TabIndex = 8;
            this.SepiaFilterButton.Text = "Sepia";
            this.SepiaFilterButton.UseVisualStyleBackColor = true;
            this.SepiaFilterButton.Click += new System.EventHandler(this.SepiaFilterButton_Click);
            // 
            // BlackAndWhiteFilterButton
            // 
            this.BlackAndWhiteFilterButton.Location = new System.Drawing.Point(636, 12);
            this.BlackAndWhiteFilterButton.Name = "BlackAndWhiteFilterButton";
            this.BlackAndWhiteFilterButton.Size = new System.Drawing.Size(122, 29);
            this.BlackAndWhiteFilterButton.TabIndex = 9;
            this.BlackAndWhiteFilterButton.Text = "Black && White";
            this.BlackAndWhiteFilterButton.UseVisualStyleBackColor = true;
            this.BlackAndWhiteFilterButton.Click += new System.EventHandler(this.BlackAndWhiteFilterButton_Click);
            // 
            // GreenFilterButton
            // 
            this.GreenFilterButton.Location = new System.Drawing.Point(636, 81);
            this.GreenFilterButton.Name = "GreenFilterButton";
            this.GreenFilterButton.Size = new System.Drawing.Size(122, 28);
            this.GreenFilterButton.TabIndex = 10;
            this.GreenFilterButton.Text = "Green";
            this.GreenFilterButton.UseVisualStyleBackColor = true;
            this.GreenFilterButton.Click += new System.EventHandler(this.GreenFilterButton_Click);
            // 
            // BlueFilterButton
            // 
            this.BlueFilterButton.Location = new System.Drawing.Point(636, 115);
            this.BlueFilterButton.Name = "BlueFilterButton";
            this.BlueFilterButton.Size = new System.Drawing.Size(122, 28);
            this.BlueFilterButton.TabIndex = 11;
            this.BlueFilterButton.Text = "Blue";
            this.BlueFilterButton.UseVisualStyleBackColor = true;
            this.BlueFilterButton.Click += new System.EventHandler(this.BlueFilterButton_Click);
            // 
            // BrightnessHighButton
            // 
            this.BrightnessHighButton.Location = new System.Drawing.Point(745, 172);
            this.BrightnessHighButton.Name = "BrightnessHighButton";
            this.BrightnessHighButton.Size = new System.Drawing.Size(22, 28);
            this.BrightnessHighButton.TabIndex = 12;
            this.BrightnessHighButton.Text = "+";
            this.BrightnessHighButton.UseVisualStyleBackColor = true;
            this.BrightnessHighButton.Click += new System.EventHandler(this.BrightnessHighButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(660, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Brightness";
            // 
            // BrightnessLowButton
            // 
            this.BrightnessLowButton.Location = new System.Drawing.Point(623, 172);
            this.BrightnessLowButton.Name = "BrightnessLowButton";
            this.BrightnessLowButton.Size = new System.Drawing.Size(22, 28);
            this.BrightnessLowButton.TabIndex = 14;
            this.BrightnessLowButton.Text = "-";
            this.BrightnessLowButton.UseVisualStyleBackColor = true;
            this.BrightnessLowButton.Click += new System.EventHandler(this.BrightnessLowButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(660, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Contrast";
            // 
            // ContrastHighButton
            // 
            this.ContrastHighButton.Location = new System.Drawing.Point(745, 206);
            this.ContrastHighButton.Name = "ContrastHighButton";
            this.ContrastHighButton.Size = new System.Drawing.Size(22, 28);
            this.ContrastHighButton.TabIndex = 16;
            this.ContrastHighButton.Text = "+";
            this.ContrastHighButton.UseVisualStyleBackColor = true;
            this.ContrastHighButton.Click += new System.EventHandler(this.ContrastHighButton_Click);
            // 
            // ContrastLowButton
            // 
            this.ContrastLowButton.Location = new System.Drawing.Point(623, 206);
            this.ContrastLowButton.Name = "ContrastLowButton";
            this.ContrastLowButton.Size = new System.Drawing.Size(22, 28);
            this.ContrastLowButton.TabIndex = 17;
            this.ContrastLowButton.Text = "-";
            this.ContrastLowButton.UseVisualStyleBackColor = true;
            this.ContrastLowButton.Click += new System.EventHandler(this.ContrastLowButton_Click);
            // 
            // Revert
            // 
            this.Revert.Location = new System.Drawing.Point(636, 345);
            this.Revert.Name = "Revert";
            this.Revert.Size = new System.Drawing.Size(122, 28);
            this.Revert.TabIndex = 18;
            this.Revert.Text = "Revert";
            this.Revert.UseVisualStyleBackColor = true;
            this.Revert.Click += new System.EventHandler(this.Revert_Click);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 462);
            this.Controls.Add(this.Revert);
            this.Controls.Add(this.ContrastLowButton);
            this.Controls.Add(this.ContrastHighButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrightnessLowButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrightnessHighButton);
            this.Controls.Add(this.BlueFilterButton);
            this.Controls.Add(this.GreenFilterButton);
            this.Controls.Add(this.BlackAndWhiteFilterButton);
            this.Controls.Add(this.SepiaFilterButton);
            this.Controls.Add(this.InvertButton);
            this.Controls.Add(this.RotateButton);
            this.Controls.Add(this.HorizontalFlipButton);
            this.Controls.Add(this.FlipVerticalButton);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.OpenButton);
            this.Name = "ImageEditor";
            this.Text = "ImageEditor";
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button FlipVerticalButton;
        private System.Windows.Forms.Button HorizontalFlipButton;
        private System.Windows.Forms.Button RotateButton;
        private System.Windows.Forms.Button InvertButton;
        private System.Windows.Forms.Button SepiaFilterButton;
        private System.Windows.Forms.Button BlackAndWhiteFilterButton;
        private System.Windows.Forms.Button GreenFilterButton;
        private System.Windows.Forms.Button BlueFilterButton;
        private System.Windows.Forms.Button BrightnessHighButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrightnessLowButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ContrastHighButton;
        private System.Windows.Forms.Button ContrastLowButton;
        private System.Windows.Forms.Button Revert;
    }
}