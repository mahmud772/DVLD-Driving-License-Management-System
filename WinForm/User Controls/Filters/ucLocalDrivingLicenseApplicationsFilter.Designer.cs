namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucLocalDrivingLicenseApplicationsFilter
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
            Common.Filters.clsApplicationFilter clsApplicationFilter2 = new Common.Filters.clsApplicationFilter();
            this.ucApplicationsFilter1 = new DVLDWinForm.User_Controls.Filters.ucApplicationsFilter();
            this.pnlLicenseClass = new System.Windows.Forms.Panel();
            this.ckbLicenseClass = new System.Windows.Forms.CheckBox();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.pnlLicenseClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucApplicationsFilter1
            // 
            clsApplicationFilter2.ApplicationStatus = null;
            clsApplicationFilter2.ApplicationTypeID = null;
            clsApplicationFilter2.FromApplicationDate = null;
            clsApplicationFilter2.ToApplicationDate = null;
            this.ucApplicationsFilter1.ApplicationFilter = clsApplicationFilter2;
            this.ucApplicationsFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ucApplicationsFilter1.Location = new System.Drawing.Point(0, 57);
            this.ucApplicationsFilter1.Name = "ucApplicationsFilter1";
            this.ucApplicationsFilter1.Size = new System.Drawing.Size(324, 218);
            this.ucApplicationsFilter1.TabIndex = 0;
            // 
            // pnlLicenseClass
            // 
            this.pnlLicenseClass.BackColor = System.Drawing.Color.White;
            this.pnlLicenseClass.Controls.Add(this.ckbLicenseClass);
            this.pnlLicenseClass.Controls.Add(this.cbLicenseClass);
            this.pnlLicenseClass.Location = new System.Drawing.Point(10, 10);
            this.pnlLicenseClass.Name = "pnlLicenseClass";
            this.pnlLicenseClass.Size = new System.Drawing.Size(311, 44);
            this.pnlLicenseClass.TabIndex = 1;
            // 
            // ckbLicenseClass
            // 
            this.ckbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ckbLicenseClass.Location = new System.Drawing.Point(12, 9);
            this.ckbLicenseClass.Name = "ckbLicenseClass";
            this.ckbLicenseClass.Size = new System.Drawing.Size(152, 24);
            this.ckbLicenseClass.TabIndex = 0;
            this.ckbLicenseClass.Text = "License Class                  :";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.Location = new System.Drawing.Point(170, 12);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(129, 21);
            this.cbLicenseClass.TabIndex = 1;
            // 
            // ucLocalDrivingLicenseApplicationFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlLicenseClass);
            this.Controls.Add(this.ucApplicationsFilter1);
            this.Name = "ucLocalDrivingLicenseApplicationFilter";
            this.Size = new System.Drawing.Size(328, 279);
            this.pnlLicenseClass.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucApplicationsFilter ucApplicationsFilter1;
        private System.Windows.Forms.Panel pnlLicenseClass;
        private System.Windows.Forms.CheckBox ckbLicenseClass;
        private System.Windows.Forms.ComboBox cbLicenseClass;
    }
}
