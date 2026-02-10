namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    partial class frmUpdateApplication
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
            this.cbApplicationTypes = new System.Windows.Forms.ComboBox();
            this.lbPaidFees = new System.Windows.Forms.Label();
            this.lbApplicationType = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.lbPaidFeesValue = new System.Windows.Forms.Label();
            this.chbCancel = new System.Windows.Forms.CheckBox();
            this.lbApplicationStatus = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lbLicenseClass = new System.Windows.Forms.Label();
            this.pnlApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlApplication
            // 
            this.pnlApplication.BackColor = System.Drawing.Color.White;
            this.pnlApplication.Controls.Add(this.cbLicenseClass);
            this.pnlApplication.Controls.Add(this.lbLicenseClass);
            this.pnlApplication.Controls.Add(this.lbApplicationStatus);
            this.pnlApplication.Controls.Add(this.chbCancel);
            this.pnlApplication.Controls.Add(this.lbPaidFeesValue);
            this.pnlApplication.Controls.Add(this.cbApplicationTypes);
            this.pnlApplication.Controls.Add(this.lbPaidFees);
            this.pnlApplication.Controls.Add(this.lbApplicationType);
            this.pnlApplication.Location = new System.Drawing.Point(21, 42);
            this.pnlApplication.Name = "pnlApplication";
            this.pnlApplication.Size = new System.Drawing.Size(370, 150);
            this.pnlApplication.TabIndex = 47;
            // 
            // cbApplicationTypes
            // 
            this.cbApplicationTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplicationTypes.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApplicationTypes.FormattingEnabled = true;
            this.cbApplicationTypes.Location = new System.Drawing.Point(141, 13);
            this.cbApplicationTypes.Name = "cbApplicationTypes";
            this.cbApplicationTypes.Size = new System.Drawing.Size(206, 21);
            this.cbApplicationTypes.TabIndex = 10;
            this.cbApplicationTypes.SelectedIndexChanged += new System.EventHandler(this.cbApplicationTypes_SelectedIndexChanged);
            // 
            // lbPaidFees
            // 
            this.lbPaidFees.AutoSize = true;
            this.lbPaidFees.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbPaidFees.Location = new System.Drawing.Point(3, 114);
            this.lbPaidFees.Name = "lbPaidFees";
            this.lbPaidFees.Size = new System.Drawing.Size(136, 17);
            this.lbPaidFees.TabIndex = 1;
            this.lbPaidFees.Text = "Paid Fees                 :";
            // 
            // lbApplicationType
            // 
            this.lbApplicationType.AutoSize = true;
            this.lbApplicationType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationType.Location = new System.Drawing.Point(3, 13);
            this.lbApplicationType.Name = "lbApplicationType";
            this.lbApplicationType.Size = new System.Drawing.Size(135, 17);
            this.lbApplicationType.TabIndex = 0;
            this.lbApplicationType.Text = "Application Type      :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 46;
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
            this.lbTitel.Location = new System.Drawing.Point(125, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(179, 21);
            this.lbTitel.TabIndex = 45;
            this.lbTitel.Text = "UPDATE APPLICATION";
            // 
            // lbPaidFeesValue
            // 
            this.lbPaidFeesValue.AutoSize = true;
            this.lbPaidFeesValue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaidFeesValue.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbPaidFeesValue.Location = new System.Drawing.Point(147, 114);
            this.lbPaidFeesValue.Name = "lbPaidFeesValue";
            this.lbPaidFeesValue.Size = new System.Drawing.Size(57, 21);
            this.lbPaidFeesValue.TabIndex = 48;
            this.lbPaidFeesValue.Text = "VALUE";
            // 
            // chbCancel
            // 
            this.chbCancel.AutoSize = true;
            this.chbCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chbCancel.Location = new System.Drawing.Point(149, 77);
            this.chbCancel.Name = "chbCancel";
            this.chbCancel.Size = new System.Drawing.Size(77, 25);
            this.chbCancel.TabIndex = 49;
            this.chbCancel.Text = "Cancel";
            this.chbCancel.UseVisualStyleBackColor = true;
            // 
            // lbApplicationStatus
            // 
            this.lbApplicationStatus.AutoSize = true;
            this.lbApplicationStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationStatus.Location = new System.Drawing.Point(3, 80);
            this.lbApplicationStatus.Name = "lbApplicationStatus";
            this.lbApplicationStatus.Size = new System.Drawing.Size(137, 17);
            this.lbApplicationStatus.TabIndex = 50;
            this.lbApplicationStatus.Text = "Application Status    :";
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
            // frmUpdateApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(405, 241);
            this.Controls.Add(this.pnlApplication);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmUpdateApplication";
            this.Text = "Update Application";
            this.Load += new System.EventHandler(this.frmUpdateApplication_Load);
            this.pnlApplication.ResumeLayout(false);
            this.pnlApplication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlApplication;
        private System.Windows.Forms.ComboBox cbApplicationTypes;
        private System.Windows.Forms.Label lbPaidFees;
        private System.Windows.Forms.Label lbApplicationType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label lbPaidFeesValue;
        private System.Windows.Forms.CheckBox chbCancel;
        private System.Windows.Forms.Label lbApplicationStatus;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lbLicenseClass;
    }
}