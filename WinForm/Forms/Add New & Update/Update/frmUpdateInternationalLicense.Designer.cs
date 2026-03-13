namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    partial class frmUpdateInternationalLicense
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
            this.pnlLicense = new System.Windows.Forms.Panel();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbInActive = new System.Windows.Forms.RadioButton();
            this.lbLicenseStatus_Titel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLicense
            // 
            this.pnlLicense.BackColor = System.Drawing.Color.White;
            this.pnlLicense.Controls.Add(this.rbActive);
            this.pnlLicense.Controls.Add(this.rbInActive);
            this.pnlLicense.Controls.Add(this.lbLicenseStatus_Titel);
            this.pnlLicense.Location = new System.Drawing.Point(9, 33);
            this.pnlLicense.Name = "pnlLicense";
            this.pnlLicense.Size = new System.Drawing.Size(319, 32);
            this.pnlLicense.TabIndex = 56;
            // 
            // rbActive
            // 
            this.rbActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbActive.Location = new System.Drawing.Point(117, 6);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(77, 24);
            this.rbActive.TabIndex = 1;
            this.rbActive.Text = "Active";
            // 
            // rbInActive
            // 
            this.rbInActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbInActive.Location = new System.Drawing.Point(224, 6);
            this.rbInActive.Name = "rbInActive";
            this.rbInActive.Size = new System.Drawing.Size(70, 24);
            this.rbInActive.TabIndex = 2;
            this.rbInActive.Text = "Inactive";
            // 
            // lbLicenseStatus_Titel
            // 
            this.lbLicenseStatus_Titel.AutoSize = true;
            this.lbLicenseStatus_Titel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbLicenseStatus_Titel.Location = new System.Drawing.Point(4, 8);
            this.lbLicenseStatus_Titel.Name = "lbLicenseStatus_Titel";
            this.lbLicenseStatus_Titel.Size = new System.Drawing.Size(100, 17);
            this.lbLicenseStatus_Titel.TabIndex = 12;
            this.lbLicenseStatus_Titel.Text = "License Status :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 71);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 55;
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
            this.lbTitel.Location = new System.Drawing.Point(102, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(139, 21);
            this.lbTitel.TabIndex = 54;
            this.lbTitel.Text = "UPDATE LICENSE";
            // 
            // frmUpdateInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(333, 115);
            this.Controls.Add(this.pnlLicense);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmUpdateInternationalLicense";
            this.Text = "Update International License";
            this.Load += new System.EventHandler(this.frmUpdateInternationalLicense_Load);
            this.pnlLicense.ResumeLayout(false);
            this.pnlLicense.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLicense;
        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbInActive;
        private System.Windows.Forms.Label lbLicenseStatus_Titel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
    }
}