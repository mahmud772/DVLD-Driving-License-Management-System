namespace DVLDWinForm.User_Controls
{
    partial class ucApplication
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
            this.lbApplicationID_Titel = new System.Windows.Forms.Label();
            this.lbPersonID_Title = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.pnlMoreInfo = new System.Windows.Forms.Panel();
            this.lbPaidFees = new System.Windows.Forms.Label();
            this.pctrPaidFees = new System.Windows.Forms.PictureBox();
            this.pctrCountry = new System.Windows.Forms.PictureBox();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.lbApplicationType = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pctrDateOfBirth = new System.Windows.Forms.PictureBox();
            this.pctrGendor = new System.Windows.Forms.PictureBox();
            this.btnUpdate_Delete = new System.Windows.Forms.Button();
            this.pnlIDs.SuspendLayout();
            this.pnlMoreInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPaidFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDateOfBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlIDs
            // 
            this.pnlIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlIDs.Controls.Add(this.lbApplicationID_Titel);
            this.pnlIDs.Controls.Add(this.lbPersonID_Title);
            this.pnlIDs.Controls.Add(this.lbPersonID);
            this.pnlIDs.Controls.Add(this.lbApplicationID);
            this.pnlIDs.Location = new System.Drawing.Point(0, 127);
            this.pnlIDs.Name = "pnlIDs";
            this.pnlIDs.Size = new System.Drawing.Size(381, 33);
            this.pnlIDs.TabIndex = 63;
            // 
            // lbApplicationID_Titel
            // 
            this.lbApplicationID_Titel.AutoSize = true;
            this.lbApplicationID_Titel.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationID_Titel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbApplicationID_Titel.Location = new System.Drawing.Point(185, 8);
            this.lbApplicationID_Titel.Name = "lbApplicationID_Titel";
            this.lbApplicationID_Titel.Size = new System.Drawing.Size(101, 17);
            this.lbApplicationID_Titel.TabIndex = 25;
            this.lbApplicationID_Titel.Text = "Application ID : ";
            // 
            // lbPersonID_Title
            // 
            this.lbPersonID_Title.AutoSize = true;
            this.lbPersonID_Title.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbPersonID_Title.Location = new System.Drawing.Point(12, 8);
            this.lbPersonID_Title.Name = "lbPersonID_Title";
            this.lbPersonID_Title.Size = new System.Drawing.Size(76, 17);
            this.lbPersonID_Title.TabIndex = 24;
            this.lbPersonID_Title.Text = "Person ID : ";
            // 
            // lbPersonID
            // 
            this.lbPersonID.AutoSize = true;
            this.lbPersonID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbPersonID.Location = new System.Drawing.Point(86, 10);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(65, 15);
            this.lbPersonID.TabIndex = 10;
            this.lbPersonID.Text = "1234567890";
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbApplicationID.Location = new System.Drawing.Point(288, 10);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(87, 15);
            this.lbApplicationID.TabIndex = 1;
            this.lbApplicationID.Text = "12001234567890";
            // 
            // pnlMoreInfo
            // 
            this.pnlMoreInfo.BackColor = System.Drawing.Color.White;
            this.pnlMoreInfo.Controls.Add(this.lbPaidFees);
            this.pnlMoreInfo.Controls.Add(this.pctrPaidFees);
            this.pnlMoreInfo.Controls.Add(this.pctrCountry);
            this.pnlMoreInfo.Controls.Add(this.lbApplicationDate);
            this.pnlMoreInfo.Controls.Add(this.lbApplicationType);
            this.pnlMoreInfo.Controls.Add(this.lbStatus);
            this.pnlMoreInfo.Controls.Add(this.pctrDateOfBirth);
            this.pnlMoreInfo.Controls.Add(this.pctrGendor);
            this.pnlMoreInfo.Location = new System.Drawing.Point(12, 29);
            this.pnlMoreInfo.Name = "pnlMoreInfo";
            this.pnlMoreInfo.Size = new System.Drawing.Size(366, 93);
            this.pnlMoreInfo.TabIndex = 61;
            // 
            // lbPaidFees
            // 
            this.lbPaidFees.AutoSize = true;
            this.lbPaidFees.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaidFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbPaidFees.Location = new System.Drawing.Point(250, 16);
            this.lbPaidFees.Name = "lbPaidFees";
            this.lbPaidFees.Size = new System.Drawing.Size(83, 26);
            this.lbPaidFees.TabIndex = 25;
            this.lbPaidFees.Text = "PaidFees";
            // 
            // pctrPaidFees
            // 
            this.pctrPaidFees.Image = global::DVLDWinForm.Properties.Resources.PaidFees;
            this.pctrPaidFees.Location = new System.Drawing.Point(212, 16);
            this.pctrPaidFees.Name = "pctrPaidFees";
            this.pctrPaidFees.Size = new System.Drawing.Size(24, 26);
            this.pctrPaidFees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrPaidFees.TabIndex = 26;
            this.pctrPaidFees.TabStop = false;
            // 
            // pctrCountry
            // 
            this.pctrCountry.Image = global::DVLDWinForm.Properties.Resources.Status;
            this.pctrCountry.Location = new System.Drawing.Point(11, 58);
            this.pctrCountry.Name = "pctrCountry";
            this.pctrCountry.Size = new System.Drawing.Size(24, 26);
            this.pctrCountry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrCountry.TabIndex = 22;
            this.pctrCountry.TabStop = false;
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbApplicationDate.Location = new System.Drawing.Point(250, 58);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(79, 26);
            this.lbApplicationDate.TabIndex = 12;
            this.lbApplicationDate.Text = "0001\\1\\1";
            // 
            // lbApplicationType
            // 
            this.lbApplicationType.AutoSize = true;
            this.lbApplicationType.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbApplicationType.Location = new System.Drawing.Point(48, 16);
            this.lbApplicationType.Name = "lbApplicationType";
            this.lbApplicationType.Size = new System.Drawing.Size(146, 26);
            this.lbApplicationType.TabIndex = 11;
            this.lbApplicationType.Text = "ApplicationType";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbStatus.Location = new System.Drawing.Point(50, 62);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(55, 21);
            this.lbStatus.TabIndex = 15;
            this.lbStatus.Text = "Status";
            // 
            // pctrDateOfBirth
            // 
            this.pctrDateOfBirth.Image = global::DVLDWinForm.Properties.Resources.IssueDate;
            this.pctrDateOfBirth.Location = new System.Drawing.Point(212, 58);
            this.pctrDateOfBirth.Name = "pctrDateOfBirth";
            this.pctrDateOfBirth.Size = new System.Drawing.Size(24, 26);
            this.pctrDateOfBirth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrDateOfBirth.TabIndex = 19;
            this.pctrDateOfBirth.TabStop = false;
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
            this.btnUpdate_Delete.Location = new System.Drawing.Point(11, 2);
            this.btnUpdate_Delete.Name = "btnUpdate_Delete";
            this.btnUpdate_Delete.Size = new System.Drawing.Size(30, 25);
            this.btnUpdate_Delete.TabIndex = 64;
            this.btnUpdate_Delete.Text = ". . .";
            this.btnUpdate_Delete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdate_Delete.UseVisualStyleBackColor = true;
            this.btnUpdate_Delete.Click += new System.EventHandler(this.btnUpdate_Delete_Click);
            // 
            // ucApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlIDs);
            this.Controls.Add(this.pnlMoreInfo);
            this.Controls.Add(this.btnUpdate_Delete);
            this.Name = "ucApplication";
            this.Size = new System.Drawing.Size(381, 161);
            this.pnlIDs.ResumeLayout(false);
            this.pnlIDs.PerformLayout();
            this.pnlMoreInfo.ResumeLayout(false);
            this.pnlMoreInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPaidFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDateOfBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlIDs;
        private System.Windows.Forms.Label lbApplicationID_Titel;
        private System.Windows.Forms.Label lbPersonID_Title;
        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.PictureBox pctrCountry;
        private System.Windows.Forms.PictureBox pctrDateOfBirth;
        private System.Windows.Forms.PictureBox pctrGendor;
        private System.Windows.Forms.Panel pnlMoreInfo;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label lbApplicationType;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnUpdate_Delete;
        private System.Windows.Forms.Label lbPaidFees;
        private System.Windows.Forms.PictureBox pctrPaidFees;
    }
}
