namespace DVLDWinForm.User_Controls
{
    partial class ucTestAppointment
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
            this.pnlIDs = new System.Windows.Forms.Panel();
            this.lbAppointmentID_Titel = new System.Windows.Forms.Label();
            this.lbTestID_Title = new System.Windows.Forms.Label();
            this.lbLocalLicenseAppID = new System.Windows.Forms.Label();
            this.lbAppointmentID = new System.Windows.Forms.Label();
            this.pnlMoreInfo = new System.Windows.Forms.Panel();
            this.lbPaidFees = new System.Windows.Forms.Label();
            this.pctrPaidFees = new System.Windows.Forms.PictureBox();
            this.pctrStatus = new System.Windows.Forms.PictureBox();
            this.lbAppointmentDate = new System.Windows.Forms.Label();
            this.lbTestType = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pctrAppointmentDate = new System.Windows.Forms.PictureBox();
            this.pctrGendor = new System.Windows.Forms.PictureBox();
            this.btnUpdate_Delete = new System.Windows.Forms.Button();
            this.pnlIDs.SuspendLayout();
            this.pnlMoreInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPaidFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrAppointmentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIDs
            // 
            this.pnlIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlIDs.Controls.Add(this.lbAppointmentID_Titel);
            this.pnlIDs.Controls.Add(this.lbTestID_Title);
            this.pnlIDs.Controls.Add(this.lbLocalLicenseAppID);
            this.pnlIDs.Controls.Add(this.lbAppointmentID);
            this.pnlIDs.Location = new System.Drawing.Point(0, 127);
            this.pnlIDs.Name = "pnlIDs";
            this.pnlIDs.Size = new System.Drawing.Size(381, 33);
            this.pnlIDs.TabIndex = 66;
            // 
            // lbAppointmentID_Titel
            // 
            this.lbAppointmentID_Titel.AutoSize = true;
            this.lbAppointmentID_Titel.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentID_Titel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbAppointmentID_Titel.Location = new System.Drawing.Point(176, 8);
            this.lbAppointmentID_Titel.Name = "lbAppointmentID_Titel";
            this.lbAppointmentID_Titel.Size = new System.Drawing.Size(112, 17);
            this.lbAppointmentID_Titel.TabIndex = 25;
            this.lbAppointmentID_Titel.Text = "Appointment ID : ";
            // 
            // lbTestID_Title
            // 
            this.lbTestID_Title.AutoSize = true;
            this.lbTestID_Title.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestID_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbTestID_Title.Location = new System.Drawing.Point(5, 8);
            this.lbTestID_Title.Name = "lbTestID_Title";
            this.lbTestID_Title.Size = new System.Drawing.Size(106, 17);
            this.lbTestID_Title.TabIndex = 24;
            this.lbTestID_Title.Text = "License App ID : ";
            // 
            // lbLocalLicenseAppID
            // 
            this.lbLocalLicenseAppID.AutoSize = true;
            this.lbLocalLicenseAppID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalLicenseAppID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbLocalLicenseAppID.Location = new System.Drawing.Point(108, 10);
            this.lbLocalLicenseAppID.Name = "lbLocalLicenseAppID";
            this.lbLocalLicenseAppID.Size = new System.Drawing.Size(65, 15);
            this.lbLocalLicenseAppID.TabIndex = 10;
            this.lbLocalLicenseAppID.Text = "1234567890";
            // 
            // lbAppointmentID
            // 
            this.lbAppointmentID.AutoSize = true;
            this.lbAppointmentID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbAppointmentID.Location = new System.Drawing.Point(290, 10);
            this.lbAppointmentID.Name = "lbAppointmentID";
            this.lbAppointmentID.Size = new System.Drawing.Size(87, 15);
            this.lbAppointmentID.TabIndex = 1;
            this.lbAppointmentID.Text = "12001234567890";
            // 
            // pnlMoreInfo
            // 
            this.pnlMoreInfo.BackColor = System.Drawing.Color.White;
            this.pnlMoreInfo.Controls.Add(this.lbPaidFees);
            this.pnlMoreInfo.Controls.Add(this.pctrPaidFees);
            this.pnlMoreInfo.Controls.Add(this.pctrStatus);
            this.pnlMoreInfo.Controls.Add(this.lbAppointmentDate);
            this.pnlMoreInfo.Controls.Add(this.lbTestType);
            this.pnlMoreInfo.Controls.Add(this.lbStatus);
            this.pnlMoreInfo.Controls.Add(this.pctrAppointmentDate);
            this.pnlMoreInfo.Controls.Add(this.pctrGendor);
            this.pnlMoreInfo.Location = new System.Drawing.Point(18, 28);
            this.pnlMoreInfo.Name = "pnlMoreInfo";
            this.pnlMoreInfo.Size = new System.Drawing.Size(355, 93);
            this.pnlMoreInfo.TabIndex = 65;
            // 
            // lbPaidFees
            // 
            this.lbPaidFees.AutoSize = true;
            this.lbPaidFees.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaidFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbPaidFees.Location = new System.Drawing.Point(250, 16);
            this.lbPaidFees.Name = "lbPaidFees";
            this.lbPaidFees.Size = new System.Drawing.Size(83, 26);
            this.lbPaidFees.TabIndex = 23;
            this.lbPaidFees.Text = "PaidFees";
            // 
            // pctrPaidFees
            // 
            this.pctrPaidFees.Image = global::DVLDWinForm.Properties.Resources.PaidFees;
            this.pctrPaidFees.Location = new System.Drawing.Point(212, 16);
            this.pctrPaidFees.Name = "pctrPaidFees";
            this.pctrPaidFees.Size = new System.Drawing.Size(24, 26);
            this.pctrPaidFees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrPaidFees.TabIndex = 24;
            this.pctrPaidFees.TabStop = false;
            // 
            // pctrStatus
            // 
            this.pctrStatus.Image = global::DVLDWinForm.Properties.Resources.Status;
            this.pctrStatus.Location = new System.Drawing.Point(11, 58);
            this.pctrStatus.Name = "pctrStatus";
            this.pctrStatus.Size = new System.Drawing.Size(24, 26);
            this.pctrStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrStatus.TabIndex = 22;
            this.pctrStatus.TabStop = false;
            // 
            // lbAppointmentDate
            // 
            this.lbAppointmentDate.AutoSize = true;
            this.lbAppointmentDate.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbAppointmentDate.Location = new System.Drawing.Point(250, 58);
            this.lbAppointmentDate.Name = "lbAppointmentDate";
            this.lbAppointmentDate.Size = new System.Drawing.Size(79, 26);
            this.lbAppointmentDate.TabIndex = 12;
            this.lbAppointmentDate.Text = "0001\\1\\1";
            // 
            // lbTestType
            // 
            this.lbTestType.AutoSize = true;
            this.lbTestType.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbTestType.Location = new System.Drawing.Point(49, 16);
            this.lbTestType.Name = "lbTestType";
            this.lbTestType.Size = new System.Drawing.Size(86, 26);
            this.lbTestType.TabIndex = 11;
            this.lbTestType.Text = "TestType";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbStatus.Location = new System.Drawing.Point(50, 61);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(63, 21);
            this.lbStatus.TabIndex = 15;
            this.lbStatus.Text = "Locked";
            // 
            // pctrAppointmentDate
            // 
            this.pctrAppointmentDate.Image = global::DVLDWinForm.Properties.Resources.IssueDate;
            this.pctrAppointmentDate.Location = new System.Drawing.Point(212, 58);
            this.pctrAppointmentDate.Name = "pctrAppointmentDate";
            this.pctrAppointmentDate.Size = new System.Drawing.Size(24, 26);
            this.pctrAppointmentDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrAppointmentDate.TabIndex = 19;
            this.pctrAppointmentDate.TabStop = false;
            // 
            // pctrGendor
            // 
            this.pctrGendor.Image = global::DVLDWinForm.Properties.Resources.ApplicationType;
            this.pctrGendor.Location = new System.Drawing.Point(11, 16);
            this.pctrGendor.Name = "pctrGendor";
            this.pctrGendor.Size = new System.Drawing.Size(24, 26);
            this.pctrGendor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrGendor.TabIndex = 18;
            this.pctrGendor.TabStop = false;
            // 
            // btnUpdate_Delete
            // 
            this.btnUpdate_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdate_Delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnUpdate_Delete.FlatAppearance.BorderSize = 0;
            this.btnUpdate_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnUpdate_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnUpdate_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_Delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_Delete.Location = new System.Drawing.Point(11, 1);
            this.btnUpdate_Delete.Name = "btnUpdate_Delete";
            this.btnUpdate_Delete.Size = new System.Drawing.Size(30, 25);
            this.btnUpdate_Delete.TabIndex = 67;
            this.btnUpdate_Delete.Text = ". . .";
            this.btnUpdate_Delete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdate_Delete.UseVisualStyleBackColor = true;
            this.btnUpdate_Delete.Click += new System.EventHandler(this.btnUpdate_Delete_Click);
            // 
            // ucTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlIDs);
            this.Controls.Add(this.pnlMoreInfo);
            this.Controls.Add(this.btnUpdate_Delete);
            this.Name = "ucTestAppointment";
            this.Size = new System.Drawing.Size(381, 161);
            this.pnlIDs.ResumeLayout(false);
            this.pnlIDs.PerformLayout();
            this.pnlMoreInfo.ResumeLayout(false);
            this.pnlMoreInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPaidFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrAppointmentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIDs;
        private System.Windows.Forms.Label lbAppointmentID_Titel;
        private System.Windows.Forms.Label lbTestID_Title;
        private System.Windows.Forms.Label lbLocalLicenseAppID;
        private System.Windows.Forms.Label lbAppointmentID;
        private System.Windows.Forms.Panel pnlMoreInfo;
        private System.Windows.Forms.PictureBox pctrStatus;
        private System.Windows.Forms.Label lbAppointmentDate;
        private System.Windows.Forms.Label lbTestType;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.PictureBox pctrAppointmentDate;
        private System.Windows.Forms.PictureBox pctrGendor;
        private System.Windows.Forms.Button btnUpdate_Delete;
        private System.Windows.Forms.Label lbPaidFees;
        private System.Windows.Forms.PictureBox pctrPaidFees;
    }
}
