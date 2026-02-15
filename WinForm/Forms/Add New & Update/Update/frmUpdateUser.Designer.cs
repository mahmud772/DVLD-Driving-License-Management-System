namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    partial class frmUpdateUser
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
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.ckcbPermissions = new CheckedComboBox();
            this.lbLicenseClass = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.lbIsActive_Titel = new System.Windows.Forms.Label();
            this.rbDeactivate = new System.Windows.Forms.RadioButton();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.pnlUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.White;
            this.pnlUserInfo.Controls.Add(this.rbDeactivate);
            this.pnlUserInfo.Controls.Add(this.rbActive);
            this.pnlUserInfo.Controls.Add(this.lbIsActive_Titel);
            this.pnlUserInfo.Controls.Add(this.ckcbPermissions);
            this.pnlUserInfo.Controls.Add(this.lbLicenseClass);
            this.pnlUserInfo.Location = new System.Drawing.Point(12, 38);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(330, 86);
            this.pnlUserInfo.TabIndex = 56;
            // 
            // ckcbPermissions
            // 
            this.ckcbPermissions.DropDownHeight = 1;
            this.ckcbPermissions.FormattingEnabled = true;
            this.ckcbPermissions.IntegralHeight = false;
            this.ckcbPermissions.Location = new System.Drawing.Point(123, 45);
            this.ckcbPermissions.Name = "ckcbPermissions";
            this.ckcbPermissions.Size = new System.Drawing.Size(195, 21);
            this.ckcbPermissions.TabIndex = 54;
            // 
            // lbLicenseClass
            // 
            this.lbLicenseClass.AutoSize = true;
            this.lbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseClass.Location = new System.Drawing.Point(5, 45);
            this.lbLicenseClass.Name = "lbLicenseClass";
            this.lbLicenseClass.Size = new System.Drawing.Size(107, 17);
            this.lbLicenseClass.TabIndex = 51;
            this.lbLicenseClass.Text = "Permissions      :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(136, 130);
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
            this.lbTitel.Location = new System.Drawing.Point(118, 7);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(116, 21);
            this.lbTitel.TabIndex = 54;
            this.lbTitel.Text = "UPDATE USER";
            // 
            // lbIsActive_Titel
            // 
            this.lbIsActive_Titel.AutoSize = true;
            this.lbIsActive_Titel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsActive_Titel.Location = new System.Drawing.Point(5, 15);
            this.lbIsActive_Titel.Name = "lbIsActive_Titel";
            this.lbIsActive_Titel.Size = new System.Drawing.Size(106, 17);
            this.lbIsActive_Titel.TabIndex = 55;
            this.lbIsActive_Titel.Text = "Active Status    :";
            // 
            // rbDeactivate
            // 
            this.rbDeactivate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbDeactivate.Location = new System.Drawing.Point(217, 13);
            this.rbDeactivate.Name = "rbDeactivate";
            this.rbDeactivate.Size = new System.Drawing.Size(88, 24);
            this.rbDeactivate.TabIndex = 57;
            this.rbDeactivate.Text = "Deactivate";
            // 
            // rbActive
            // 
            this.rbActive.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbActive.Location = new System.Drawing.Point(124, 13);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(74, 24);
            this.rbActive.TabIndex = 56;
            this.rbActive.Text = "Active";
            // 
            // frmUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(354, 168);
            this.Controls.Add(this.pnlUserInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmUpdateUser";
            this.Text = "Update User";
            this.Load += new System.EventHandler(this.frmUpdateUser_Load);
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlUserInfo;
        private CheckedComboBox ckcbPermissions;
        private System.Windows.Forms.Label lbLicenseClass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label lbIsActive_Titel;
        private System.Windows.Forms.RadioButton rbDeactivate;
        private System.Windows.Forms.RadioButton rbActive;
    }
}