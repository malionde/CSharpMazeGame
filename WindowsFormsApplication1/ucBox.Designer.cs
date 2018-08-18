namespace WindowsFormsApplication1
{
    partial class ucBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBg)).BeginInit();
            this.SuspendLayout();
            // 
            // picBg
            // 
            this.picBg.Location = new System.Drawing.Point(0, 3);
            this.picBg.Name = "picBg";
            this.picBg.Size = new System.Drawing.Size(23, 24);
            this.picBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBg.TabIndex = 0;
            this.picBg.TabStop = false;
            // 
            // ucBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SpringGreen;
            this.Controls.Add(this.picBg);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "ucBox";
            this.Size = new System.Drawing.Size(53, 55);
            ((System.ComponentModel.ISupportInitialize)(this.picBg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBg;
    }
}
