namespace DVLDWinForm.Forms.Add_New___Update.Add_New
{
    partial class frmAddNewInternationalLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewInternationalLicense));
            this.pnlLicense = new System.Windows.Forms.Panel();
            this.pbSelectedDriverID = new System.Windows.Forms.PictureBox();
            this.tbDriverID = new System.Windows.Forms.TextBox();
            this.lbDriverID = new System.Windows.Forms.Label();
            this.pbSelectedApplicationID = new System.Windows.Forms.PictureBox();
            this.tbApplicationID = new System.Windows.Forms.TextBox();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedDriverID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedApplicationID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLicense
            // 
            this.pnlLicense.BackColor = System.Drawing.Color.White;
            this.pnlLicense.Controls.Add(this.pbSelectedDriverID);
            this.pnlLicense.Controls.Add(this.tbDriverID);
            this.pnlLicense.Controls.Add(this.lbDriverID);
            this.pnlLicense.Controls.Add(this.pbSelectedApplicationID);
            this.pnlLicense.Controls.Add(this.tbApplicationID);
            this.pnlLicense.Controls.Add(this.lbApplicationID);
            this.pnlLicense.Location = new System.Drawing.Point(12, 44);
            this.pnlLicense.Name = "pnlLicense";
            this.pnlLicense.Size = new System.Drawing.Size(299, 102);
            this.pnlLicense.TabIndex = 50;
            // 
            // pbSelectedDriverID
            // 
            this.pbSelectedDriverID.Image = ((System.Drawing.Image)(resources.GetObject("pbSelectedDriverID.Image")));
            this.pbSelectedDriverID.Location = new System.Drawing.Point(250, 56);
            this.pbSelectedDriverID.Name = "pbSelectedDriverID";
            this.pbSelectedDriverID.Size = new System.Drawing.Size(26, 24);
            this.pbSelectedDriverID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedDriverID.TabIndex = 56;
            this.pbSelectedDriverID.TabStop = false;
            this.pbSelectedDriverID.Click += new System.EventHandler(this.pbSelectedDriverID_Click);
            // 
            // tbDriverID
            // 
            this.tbDriverID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDriverID.Location = new System.Drawing.Point(120, 55);
            this.tbDriverID.Multiline = true;
            this.tbDriverID.Name = "tbDriverID";
            this.tbDriverID.ReadOnly = true;
            this.tbDriverID.Size = new System.Drawing.Size(114, 28);
            this.tbDriverID.TabIndex = 55;
            // 
            // lbDriverID
            // 
            this.lbDriverID.AutoSize = true;
            this.lbDriverID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbDriverID.Location = new System.Drawing.Point(4, 60);
            this.lbDriverID.Name = "lbDriverID";
            this.lbDriverID.Size = new System.Drawing.Size(104, 17);
            this.lbDriverID.TabIndex = 54;
            this.lbDriverID.Text = "Driver ID          :";
            // 
            // pbSelectedApplicationID
            // 
            this.pbSelectedApplicationID.Image = ((System.Drawing.Image)(resources.GetObject("pbSelectedApplicationID.Image")));
            this.pbSelectedApplicationID.Location = new System.Drawing.Point(250, 12);
            this.pbSelectedApplicationID.Name = "pbSelectedApplicationID";
            this.pbSelectedApplicationID.Size = new System.Drawing.Size(26, 24);
            this.pbSelectedApplicationID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedApplicationID.TabIndex = 45;
            this.pbSelectedApplicationID.TabStop = false;
            this.pbSelectedApplicationID.Click += new System.EventHandler(this.pbSelectedApplicationID_Click);
            // 
            // tbApplicationID
            // 
            this.tbApplicationID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApplicationID.Location = new System.Drawing.Point(120, 11);
            this.tbApplicationID.Multiline = true;
            this.tbApplicationID.Name = "tbApplicationID";
            this.tbApplicationID.ReadOnly = true;
            this.tbApplicationID.Size = new System.Drawing.Size(114, 28);
            this.tbApplicationID.TabIndex = 5;
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbApplicationID.Location = new System.Drawing.Point(5, 16);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(104, 17);
            this.lbApplicationID.TabIndex = 1;
            this.lbApplicationID.Text = "Application ID  :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(116, 152);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lbTitel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTitel.Location = new System.Drawing.Point(18, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(285, 21);
            this.lbTitel.TabIndex = 48;
            this.lbTitel.Text = "ADD NEW INTERNATIONAL LICENSE";
            // 
            // frmAddNewInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(319, 191);
            this.Controls.Add(this.pnlLicense);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmAddNewInternationalLicense";
            this.ShowIcon = false;
            this.Text = "Add New International License";
            this.Load += new System.EventHandler(this.frmAddNewInternationalLicense_Load);
            this.pnlLicense.ResumeLayout(false);
            this.pnlLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedDriverID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedApplicationID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLicense;
        private System.Windows.Forms.PictureBox pbSelectedDriverID;
        private System.Windows.Forms.TextBox tbDriverID;
        private System.Windows.Forms.Label lbDriverID;
        private System.Windows.Forms.PictureBox pbSelectedApplicationID;
        private System.Windows.Forms.TextBox tbApplicationID;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
    }
}