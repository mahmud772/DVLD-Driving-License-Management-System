namespace DVLDWinForm
{
    partial class ucDriver
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
            this.ctrlPerson1 = new DVLDWinForm.ucPerson();
            this.lbDriverID = new System.Windows.Forms.Label();
            this.lbDriverID_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlPerson1
            // 
            this.ctrlPerson1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ctrlPerson1.Location = new System.Drawing.Point(-2, 0);
            this.ctrlPerson1.Name = "ctrlPerson1";
            this.ctrlPerson1.Size = new System.Drawing.Size(383, 296);
            this.ctrlPerson1.TabIndex = 0;
            this.ctrlPerson1.Load += new System.EventHandler(this.ctrlPerson1_Load);
            // 
            // lbDriverID
            // 
            this.lbDriverID.AutoSize = true;
            this.lbDriverID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.lbDriverID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDriverID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbDriverID.Location = new System.Drawing.Point(270, 272);
            this.lbDriverID.Name = "lbDriverID";
            this.lbDriverID.Size = new System.Drawing.Size(65, 15);
            this.lbDriverID.TabIndex = 25;
            this.lbDriverID.Text = "1234567890";
            // 
            // lbDriverID_Title
            // 
            this.lbDriverID_Title.AutoSize = true;
            this.lbDriverID_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.lbDriverID_Title.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDriverID_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbDriverID_Title.Location = new System.Drawing.Point(198, 270);
            this.lbDriverID_Title.Name = "lbDriverID_Title";
            this.lbDriverID_Title.Size = new System.Drawing.Size(70, 17);
            this.lbDriverID_Title.TabIndex = 26;
            this.lbDriverID_Title.Text = "Driver ID : ";
            // 
            // ctrlDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbDriverID);
            this.Controls.Add(this.lbDriverID_Title);
            this.Controls.Add(this.ctrlPerson1);
            this.Name = "ctrlDriver";
            this.Size = new System.Drawing.Size(381, 296);
            this.Load += new System.EventHandler(this.ctrlDriver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPerson ctrlPerson1;
        private System.Windows.Forms.Label lbDriverID;
        private System.Windows.Forms.Label lbDriverID_Title;
    }
}
