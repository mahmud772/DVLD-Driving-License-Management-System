namespace DVLDWinForm.User_Controls.Display
{
    partial class ucLocalLicenseApplication
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
            this.ucApplication1 = new DVLDWinForm.User_Controls.ucApplication(_sharedContextMenu);
            this.SuspendLayout();
            // 
            // ucApplication1
            // 
            this.ucApplication1.ApplicationInfo = null;
            this.ucApplication1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ucApplication1.Location = new System.Drawing.Point(0, 0);
            this.ucApplication1.Name = "ucApplication1";
            this.ucApplication1.Size = new System.Drawing.Size(381, 161);
            this.ucApplication1.TabIndex = 0;
            this.ucApplication1.Load += new System.EventHandler(this.ucApplication1_Load);
            // 
            // ucLocalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.ucApplication1);
            this.Name = "ucLocalLicenseApplication";
            this.Size = new System.Drawing.Size(381, 161);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controls.ucApplication ucApplication1;
    }
}
