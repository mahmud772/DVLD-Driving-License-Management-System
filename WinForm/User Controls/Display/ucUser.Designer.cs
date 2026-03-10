namespace DVLDWinForm.User_Controls
{
    partial class ucUser
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
            this.lbUserID = new System.Windows.Forms.Label();
            this.lbUserID_Title = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.pbIsActive = new System.Windows.Forms.PictureBox();
            this.ctrlPerson1 = new DVLDWinForm.ucPerson(_sharedContextMenu);
            ((System.ComponentModel.ISupportInitialize)(this.pbIsActive)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.lbUserID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbUserID.Location = new System.Drawing.Point(265, 271);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(65, 15);
            this.lbUserID.TabIndex = 27;
            this.lbUserID.Text = "1234567890";
            // 
            // lbUserID_Title
            // 
            this.lbUserID_Title.AutoSize = true;
            this.lbUserID_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.lbUserID_Title.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbUserID_Title.Location = new System.Drawing.Point(198, 270);
            this.lbUserID_Title.Name = "lbUserID_Title";
            this.lbUserID_Title.Size = new System.Drawing.Size(62, 17);
            this.lbUserID_Title.TabIndex = 28;
            this.lbUserID_Title.Text = "User ID : ";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lbUserName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.DimGray;
            this.lbUserName.Location = new System.Drawing.Point(17, 44);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(66, 12);
            this.lbUserName.TabIndex = 29;
            this.lbUserName.Text = "User Name";
            // 
            // pbIsActive
            // 
            this.pbIsActive.BackColor = System.Drawing.SystemColors.Control;
            this.pbIsActive.Image = global::DVLDWinForm.Properties.Resources.Active;
            this.pbIsActive.Location = new System.Drawing.Point(345, 74);
            this.pbIsActive.Name = "pbIsActive";
            this.pbIsActive.Size = new System.Drawing.Size(16, 16);
            this.pbIsActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIsActive.TabIndex = 30;
            this.pbIsActive.TabStop = false;
            // 
            // ctrlPerson1
            // 
            this.ctrlPerson1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ctrlPerson1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPerson1.Name = "ctrlPerson1";
            this.ctrlPerson1.PersonInfo = null;
            this.ctrlPerson1.Size = new System.Drawing.Size(381, 296);
            this.ctrlPerson1.TabIndex = 0;
            this.ctrlPerson1.Load += new System.EventHandler(this.ctrlPerson1_Load);
            // 
            // ucUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbIsActive);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbUserID);
            this.Controls.Add(this.lbUserID_Title);
            this.Controls.Add(this.ctrlPerson1);
            this.Name = "ucUser";
            this.Size = new System.Drawing.Size(381, 296);
            this.Load += new System.EventHandler(this.ctrlUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIsActive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPerson ctrlPerson1;
        private System.Windows.Forms.Label lbUserID;
        private System.Windows.Forms.Label lbUserID_Title;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.PictureBox pbIsActive;
    }
}
