namespace DVLDWinForm.Forms.Add_New___Update
{
    partial class frmAddNew_UpdateAppointment
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
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.pnlAppointment = new System.Windows.Forms.Panel();
            this.lbPaidFees = new System.Windows.Forms.Label();
            this.lbPaidFees_Titel = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.lbLicenseClass = new System.Windows.Forms.Label();
            this.pbSelectedID = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.lbAppointmentType = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(145, 55);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(94, 22);
            this.dtpAppointmentDate.TabIndex = 11;
            // 
            // pnlAppointment
            // 
            this.pnlAppointment.BackColor = System.Drawing.Color.White;
            this.pnlAppointment.Controls.Add(this.lbPaidFees);
            this.pnlAppointment.Controls.Add(this.lbPaidFees_Titel);
            this.pnlAppointment.Controls.Add(this.lbType);
            this.pnlAppointment.Controls.Add(this.lbLicenseClass);
            this.pnlAppointment.Controls.Add(this.pbSelectedID);
            this.pnlAppointment.Controls.Add(this.dtpAppointmentDate);
            this.pnlAppointment.Controls.Add(this.tbID);
            this.pnlAppointment.Controls.Add(this.lbID);
            this.pnlAppointment.Controls.Add(this.lbAppointmentType);
            this.pnlAppointment.Location = new System.Drawing.Point(19, 44);
            this.pnlAppointment.Name = "pnlAppointment";
            this.pnlAppointment.Size = new System.Drawing.Size(319, 147);
            this.pnlAppointment.TabIndex = 47;
            // 
            // lbPaidFees
            // 
            this.lbPaidFees.AutoSize = true;
            this.lbPaidFees.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbPaidFees.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPaidFees.Location = new System.Drawing.Point(144, 121);
            this.lbPaidFees.Name = "lbPaidFees";
            this.lbPaidFees.Size = new System.Drawing.Size(15, 17);
            this.lbPaidFees.TabIndex = 52;
            this.lbPaidFees.Text = "0";
            // 
            // lbPaidFees_Titel
            // 
            this.lbPaidFees_Titel.AutoSize = true;
            this.lbPaidFees_Titel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbPaidFees_Titel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPaidFees_Titel.Location = new System.Drawing.Point(5, 120);
            this.lbPaidFees_Titel.Name = "lbPaidFees_Titel";
            this.lbPaidFees_Titel.Size = new System.Drawing.Size(132, 17);
            this.lbPaidFees_Titel.TabIndex = 51;
            this.lbPaidFees_Titel.Text = "PaidFees                 :";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbType.Location = new System.Drawing.Point(141, 91);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(45, 21);
            this.lbType.TabIndex = 49;
            this.lbType.Text = "TYPE";
            // 
            // lbLicenseClass
            // 
            this.lbLicenseClass.AutoSize = true;
            this.lbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseClass.Location = new System.Drawing.Point(3, 55);
            this.lbLicenseClass.Name = "lbLicenseClass";
            this.lbLicenseClass.Size = new System.Drawing.Size(136, 17);
            this.lbLicenseClass.TabIndex = 46;
            this.lbLicenseClass.Text = "Appointment Date   :";
            // 
            // pbSelectedID
            // 
            this.pbSelectedID.Image = global::DVLDWinForm.Properties.Resources.SearchPerson;
            this.pbSelectedID.Location = new System.Drawing.Point(275, 10);
            this.pbSelectedID.Name = "pbSelectedID";
            this.pbSelectedID.Size = new System.Drawing.Size(30, 30);
            this.pbSelectedID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedID.TabIndex = 45;
            this.pbSelectedID.TabStop = false;
            this.pbSelectedID.Click += new System.EventHandler(this.pbSelectedID_Click);
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(145, 11);
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
            this.lbID.Location = new System.Drawing.Point(4, 16);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(135, 17);
            this.lbID.TabIndex = 1;
            this.lbID.Text = "Local App ID            :";
            // 
            // lbAppointmentType
            // 
            this.lbAppointmentType.AutoSize = true;
            this.lbAppointmentType.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentType.Location = new System.Drawing.Point(4, 91);
            this.lbAppointmentType.Name = "lbAppointmentType";
            this.lbAppointmentType.Size = new System.Drawing.Size(135, 17);
            this.lbAppointmentType.TabIndex = 0;
            this.lbAppointmentType.Text = "Test Type                 :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(129, 197);
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
            this.lbTitel.Location = new System.Drawing.Point(69, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(207, 21);
            this.lbTitel.TabIndex = 45;
            this.lbTitel.Text = "ADD NEW APPOINTMENT";
            // 
            // frmAddNew_UpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(352, 233);
            this.Controls.Add(this.pnlAppointment);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmAddNew_UpdateAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Appointment";
            this.Load += new System.EventHandler(this.frmAddNewAppointment_Load);
            this.pnlAppointment.ResumeLayout(false);
            this.pnlAppointment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.Panel pnlAppointment;
        private System.Windows.Forms.Label lbLicenseClass;
        private System.Windows.Forms.PictureBox pbSelectedID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbAppointmentType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbPaidFees;
        private System.Windows.Forms.Label lbPaidFees_Titel;
    }
}