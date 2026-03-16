namespace DVLDWinForm.Forms.Add_New___Update.Add_New
{
    partial class frmAddNewLicense
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.lbLicenseClass = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.pnlLicense = new System.Windows.Forms.Panel();
            this.pbSelectedID = new System.Windows.Forms.PictureBox();
            this.pnlLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 143);
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
            this.lbTitel.Location = new System.Drawing.Point(123, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(154, 21);
            this.lbTitel.TabIndex = 48;
            this.lbTitel.Text = "ADD NEW LICENSE";
            // 
            // lbLicenseClass
            // 
            this.lbLicenseClass.AutoSize = true;
            this.lbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseClass.Location = new System.Drawing.Point(2, 48);
            this.lbLicenseClass.Name = "lbLicenseClass";
            this.lbLicenseClass.Size = new System.Drawing.Size(136, 17);
            this.lbLicenseClass.TabIndex = 51;
            this.lbLicenseClass.Text = "License Class            :";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbID.Location = new System.Drawing.Point(3, 13);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(136, 17);
            this.lbID.TabIndex = 51;
            this.lbID.Text = "Driver ID                  :";
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(143, 8);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(114, 28);
            this.tbID.TabIndex = 52;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(141, 48);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(206, 21);
            this.cbLicenseClass.TabIndex = 52;
            // 
            // pnlLicense
            // 
            this.pnlLicense.BackColor = System.Drawing.Color.White;
            this.pnlLicense.Controls.Add(this.pbSelectedID);
            this.pnlLicense.Controls.Add(this.cbLicenseClass);
            this.pnlLicense.Controls.Add(this.tbID);
            this.pnlLicense.Controls.Add(this.lbID);
            this.pnlLicense.Controls.Add(this.lbLicenseClass);
            this.pnlLicense.Location = new System.Drawing.Point(19, 42);
            this.pnlLicense.Name = "pnlLicense";
            this.pnlLicense.Size = new System.Drawing.Size(370, 95);
            this.pnlLicense.TabIndex = 50;
            // 
            // pbSelectedID
            // 
            this.pbSelectedID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectedID.Image = global::DVLDWinForm.Properties.Resources.Search;
            this.pbSelectedID.Location = new System.Drawing.Point(308, 9);
            this.pbSelectedID.Name = "pbSelectedID";
            this.pbSelectedID.Size = new System.Drawing.Size(26, 24);
            this.pbSelectedID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedID.TabIndex = 53;
            this.pbSelectedID.TabStop = false;
            this.pbSelectedID.Click += new System.EventHandler(this.pbSelectedID_Click);
            // 
            // frmAddNewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(408, 183);
            this.Controls.Add(this.pnlLicense);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmAddNewLicense";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New License";
            this.Load += new System.EventHandler(this.frmAddNewLicense_Load);
            this.pnlLicense.ResumeLayout(false);
            this.pnlLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label lbLicenseClass;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.PictureBox pbSelectedID;
        private System.Windows.Forms.Panel pnlLicense;
    }
}