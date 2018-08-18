namespace WindowsFormsApplication1
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.lbl_Counter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gfMain = new WindowsFormsApplication1.ucGameField();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(12, 12);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnReadMap_Click);
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.Location = new System.Drawing.Point(93, 12);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(75, 23);
            this.btnCreateMap.TabIndex = 0;
            this.btnCreateMap.Text = "Create Map";
            this.btnCreateMap.UseVisualStyleBackColor = true;
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreateMap_Click);
            // 
            // lbl_Counter
            // 
            this.lbl_Counter.AutoSize = true;
            this.lbl_Counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Counter.Location = new System.Drawing.Point(575, 15);
            this.lbl_Counter.Name = "lbl_Counter";
            this.lbl_Counter.Size = new System.Drawing.Size(0, 16);
            this.lbl_Counter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(436, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Moves:";
            // 
            // gfMain
            // 
            this.gfMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gfMain.Location = new System.Drawing.Point(12, 41);
            this.gfMain.Name = "gfMain";
            this.gfMain.Size = new System.Drawing.Size(614, 380);
            this.gfMain.TabIndex = 1;
            this.gfMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gfMain_KeyPress);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(638, 433);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Counter);
            this.Controls.Add(this.gfMain);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.btnRestart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "Maze";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnCreateMap;
        private ucGameField gfMain;
        private System.Windows.Forms.Label lbl_Counter;
        private System.Windows.Forms.Label label1;
    }
}