namespace DVLDWinForm.Forms
{
    partial class frmCreateApplication
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
            this.pnlApplication = new System.Windows.Forms.Panel();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lbLicenseClass = new System.Windows.Forms.Label();
            this.pbSelectedID = new System.Windows.Forms.PictureBox();
            this.cbApplicationTypes = new System.Windows.Forms.ComboBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.lbApplicationType = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlApplication
            // 
            this.pnlApplication.BackColor = System.Drawing.Color.White;
            this.pnlApplication.Controls.Add(this.cbLicenseClass);
            this.pnlApplication.Controls.Add(this.lbLicenseClass);
            this.pnlApplication.Controls.Add(this.pbSelectedID);
            this.pnlApplication.Controls.Add(this.cbApplicationTypes);
            this.pnlApplication.Controls.Add(this.tbID);
            this.pnlApplication.Controls.Add(this.lbID);
            this.pnlApplication.Controls.Add(this.lbApplicationType);
            this.pnlApplication.Location = new System.Drawing.Point(21, 70);
            this.pnlApplication.Name = "pnlApplication";
            this.pnlApplication.Size = new System.Drawing.Size(373, 130);
            this.pnlApplication.TabIndex = 44;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(142, 95);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(206, 21);
            this.cbLicenseClass.TabIndex = 47;
            // 
            // lbLicenseClass
            // 
            this.lbLicenseClass.AutoSize = true;
            this.lbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseClass.Location = new System.Drawing.Point(2, 95);
            this.lbLicenseClass.Name = "lbLicenseClass";
            this.lbLicenseClass.Size = new System.Drawing.Size(132, 17);
            this.lbLicenseClass.TabIndex = 46;
            this.lbLicenseClass.Text = "License Class           :";
            // 
            // pbSelectedID
            // 
            this.pbSelectedID.Image = global::DVLDWinForm.Properties.Resources.SearchPerson;
            this.pbSelectedID.Location = new System.Drawing.Point(318, 54);
            this.pbSelectedID.Name = "pbSelectedID";
            this.pbSelectedID.Size = new System.Drawing.Size(30, 30);
            this.pbSelectedID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedID.TabIndex = 45;
            this.pbSelectedID.TabStop = false;
            this.pbSelectedID.Click += new System.EventHandler(this.pbSelectedID_Click);
            // 
            // cbApplicationTypes
            // 
            this.cbApplicationTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplicationTypes.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApplicationTypes.FormattingEnabled = true;
            this.cbApplicationTypes.Location = new System.Drawing.Point(142, 13);
            this.cbApplicationTypes.Name = "cbApplicationTypes";
            this.cbApplicationTypes.Size = new System.Drawing.Size(206, 21);
            this.cbApplicationTypes.TabIndex = 10;
            this.cbApplicationTypes.SelectedIndexChanged += new System.EventHandler(this.cbApplicationTypes_SelectedIndexChanged);
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(142, 54);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(114, 28);
            this.tbID.TabIndex = 5;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbID.Location = new System.Drawing.Point(4, 59);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(130, 17);
            this.lbID.TabIndex = 1;
            this.lbID.Text = "Person ID               :";
            // 
            // lbApplicationType
            // 
            this.lbApplicationType.AutoSize = true;
            this.lbApplicationType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationType.Location = new System.Drawing.Point(3, 13);
            this.lbApplicationType.Name = "lbApplicationType";
            this.lbApplicationType.Size = new System.Drawing.Size(131, 17);
            this.lbApplicationType.TabIndex = 0;
            this.lbApplicationType.Text = "Application Type     :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lbTitel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTitel.Location = new System.Drawing.Point(118, 18);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(174, 21);
            this.lbTitel.TabIndex = 42;
            this.lbTitel.Text = "CREATE APPLICATION";
            // 
            // frmCreateApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(406, 251);
            this.Controls.Add(this.pnlApplication);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmCreateApplication";
            this.Text = "Create Application";
            this.Load += new System.EventHandler(this.frmCreateApplication_Load);
            this.pnlApplication.ResumeLayout(false);
            this.pnlApplication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlApplication;
        private System.Windows.Forms.ComboBox cbApplicationTypes;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbApplicationType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.PictureBox pbSelectedID;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lbLicenseClass;
    }
}