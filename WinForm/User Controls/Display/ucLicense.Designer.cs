namespace DVLDWinForm.User_Controls
{
    partial class ucLicense
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
            this.lbDateOfBirth = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lbNationalNo_Titel = new System.Windows.Forms.Label();
            this.lbLicenseID = new System.Windows.Forms.Label();
            this.lbNationalNo = new System.Windows.Forms.Label();
            this.lbLicenseID_Title = new System.Windows.Forms.Label();
            this.lbDateOfBirth_Titel = new System.Windows.Forms.Label();
            this.btnShowMore_Less = new System.Windows.Forms.Button();
            this.pbIsActive = new System.Windows.Forms.PictureBox();
            this.lbExpirationDate = new System.Windows.Forms.Label();
            this.pnlMoreInfo = new System.Windows.Forms.Panel();
            this.lbNotes_Titel = new System.Windows.Forms.Label();
            this.lbLicenseClass = new System.Windows.Forms.Label();
            this.lbExpiration_Titel = new System.Windows.Forms.Label();
            this.lbLicenseClass_Titel = new System.Windows.Forms.Label();
            this.lbExpiration = new System.Windows.Forms.Label();
            this.lbIssueDate_Titel = new System.Windows.Forms.Label();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.lbNotes = new System.Windows.Forms.Label();
            this.lbIssueReason = new System.Windows.Forms.Label();
            this.lbIssueReason_Titel = new System.Windows.Forms.Label();
            this.btnUpdate_Delete = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsActive)).BeginInit();
            this.pnlMoreInfo.SuspendLayout();
            this.pnlNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDateOfBirth
            // 
            this.lbDateOfBirth.AutoSize = true;
            this.lbDateOfBirth.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbDateOfBirth.Location = new System.Drawing.Point(269, 118);
            this.lbDateOfBirth.Name = "lbDateOfBirth";
            this.lbDateOfBirth.Size = new System.Drawing.Size(79, 26);
            this.lbDateOfBirth.TabIndex = 33;
            this.lbDateOfBirth.Text = "0001\\1\\1";
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DVLDWinForm.Properties.Resources.User;
            this.pbImage.Location = new System.Drawing.Point(283, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(77, 77);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 35;
            this.pbImage.TabStop = false;
            this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage_Paint);
            // 
            // lbNationalNo_Titel
            // 
            this.lbNationalNo_Titel.AutoSize = true;
            this.lbNationalNo_Titel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalNo_Titel.ForeColor = System.Drawing.Color.DimGray;
            this.lbNationalNo_Titel.Location = new System.Drawing.Point(9, 104);
            this.lbNationalNo_Titel.Name = "lbNationalNo_Titel";
            this.lbNationalNo_Titel.Size = new System.Drawing.Size(80, 15);
            this.lbNationalNo_Titel.TabIndex = 43;
            this.lbNationalNo_Titel.Text = "NATIONAL NO ";
            // 
            // lbLicenseID
            // 
            this.lbLicenseID.AutoSize = true;
            this.lbLicenseID.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lbLicenseID.Location = new System.Drawing.Point(9, 169);
            this.lbLicenseID.Name = "lbLicenseID";
            this.lbLicenseID.Size = new System.Drawing.Size(97, 21);
            this.lbLicenseID.TabIndex = 41;
            this.lbLicenseID.Text = "1234567890";
            // 
            // lbNationalNo
            // 
            this.lbNationalNo.AutoSize = true;
            this.lbNationalNo.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalNo.ForeColor = System.Drawing.Color.Black;
            this.lbNationalNo.Location = new System.Drawing.Point(8, 122);
            this.lbNationalNo.Name = "lbNationalNo";
            this.lbNationalNo.Size = new System.Drawing.Size(130, 21);
            this.lbNationalNo.TabIndex = 40;
            this.lbNationalNo.Text = "12001234567890";
            // 
            // lbLicenseID_Title
            // 
            this.lbLicenseID_Title.AutoSize = true;
            this.lbLicenseID_Title.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseID_Title.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbLicenseID_Title.Location = new System.Drawing.Point(9, 151);
            this.lbLicenseID_Title.Name = "lbLicenseID_Title";
            this.lbLicenseID_Title.Size = new System.Drawing.Size(70, 15);
            this.lbLicenseID_Title.TabIndex = 42;
            this.lbLicenseID_Title.Text = "LICENSE ID   ";
            // 
            // lbDateOfBirth_Titel
            // 
            this.lbDateOfBirth_Titel.AutoSize = true;
            this.lbDateOfBirth_Titel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateOfBirth_Titel.ForeColor = System.Drawing.Color.DimGray;
            this.lbDateOfBirth_Titel.Location = new System.Drawing.Point(270, 104);
            this.lbDateOfBirth_Titel.Name = "lbDateOfBirth_Titel";
            this.lbDateOfBirth_Titel.Size = new System.Drawing.Size(83, 15);
            this.lbDateOfBirth_Titel.TabIndex = 45;
            this.lbDateOfBirth_Titel.Text = "DATE OF BIRTH ";
            // 
            // btnShowMore_Less
            // 
            this.btnShowMore_Less.Location = new System.Drawing.Point(328, 193);
            this.btnShowMore_Less.Name = "btnShowMore_Less";
            this.btnShowMore_Less.Size = new System.Drawing.Size(32, 23);
            this.btnShowMore_Less.TabIndex = 50;
            this.btnShowMore_Less.Text = ">>";
            this.btnShowMore_Less.UseVisualStyleBackColor = true;
            this.btnShowMore_Less.Click += new System.EventHandler(this.btnShowMore_Less_Click);
            // 
            // pbIsActive
            // 
            this.pbIsActive.BackColor = System.Drawing.SystemColors.Control;
            this.pbIsActive.Image = global::DVLDWinForm.Properties.Resources.NotActive;
            this.pbIsActive.Location = new System.Drawing.Point(340, 64);
            this.pbIsActive.Name = "pbIsActive";
            this.pbIsActive.Size = new System.Drawing.Size(16, 16);
            this.pbIsActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIsActive.TabIndex = 51;
            this.pbIsActive.TabStop = false;
            // 
            // lbExpirationDate
            // 
            this.lbExpirationDate.AutoSize = true;
            this.lbExpirationDate.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpirationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbExpirationDate.Location = new System.Drawing.Point(179, 31);
            this.lbExpirationDate.Name = "lbExpirationDate";
            this.lbExpirationDate.Size = new System.Drawing.Size(79, 26);
            this.lbExpirationDate.TabIndex = 39;
            this.lbExpirationDate.Text = "0001\\1\\1";
            // 
            // pnlMoreInfo
            // 
            this.pnlMoreInfo.Controls.Add(this.lbNotes_Titel);
            this.pnlMoreInfo.Controls.Add(this.lbLicenseClass);
            this.pnlMoreInfo.Controls.Add(this.lbExpiration_Titel);
            this.pnlMoreInfo.Controls.Add(this.lbLicenseClass_Titel);
            this.pnlMoreInfo.Controls.Add(this.lbExpiration);
            this.pnlMoreInfo.Controls.Add(this.lbIssueDate_Titel);
            this.pnlMoreInfo.Controls.Add(this.lbIssueDate);
            this.pnlMoreInfo.Controls.Add(this.pnlNotes);
            this.pnlMoreInfo.Location = new System.Drawing.Point(8, 222);
            this.pnlMoreInfo.Name = "pnlMoreInfo";
            this.pnlMoreInfo.Size = new System.Drawing.Size(356, 178);
            this.pnlMoreInfo.TabIndex = 52;
            // 
            // lbNotes_Titel
            // 
            this.lbNotes_Titel.AutoSize = true;
            this.lbNotes_Titel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes_Titel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbNotes_Titel.Location = new System.Drawing.Point(9, 108);
            this.lbNotes_Titel.Name = "lbNotes_Titel";
            this.lbNotes_Titel.Size = new System.Drawing.Size(46, 15);
            this.lbNotes_Titel.TabIndex = 57;
            this.lbNotes_Titel.Text = "NOTES  ";
            // 
            // lbLicenseClass
            // 
            this.lbLicenseClass.AutoSize = true;
            this.lbLicenseClass.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseClass.ForeColor = System.Drawing.Color.Black;
            this.lbLicenseClass.Location = new System.Drawing.Point(9, 76);
            this.lbLicenseClass.Name = "lbLicenseClass";
            this.lbLicenseClass.Size = new System.Drawing.Size(105, 21);
            this.lbLicenseClass.TabIndex = 53;
            this.lbLicenseClass.Text = "License Class";
            // 
            // lbExpiration_Titel
            // 
            this.lbExpiration_Titel.AutoSize = true;
            this.lbExpiration_Titel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpiration_Titel.ForeColor = System.Drawing.Color.DimGray;
            this.lbExpiration_Titel.Location = new System.Drawing.Point(254, 8);
            this.lbExpiration_Titel.Name = "lbExpiration_Titel";
            this.lbExpiration_Titel.Size = new System.Drawing.Size(92, 15);
            this.lbExpiration_Titel.TabIndex = 56;
            this.lbExpiration_Titel.Text = "EXPIRATION DATE";
            // 
            // lbLicenseClass_Titel
            // 
            this.lbLicenseClass_Titel.AutoSize = true;
            this.lbLicenseClass_Titel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenseClass_Titel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbLicenseClass_Titel.Location = new System.Drawing.Point(9, 58);
            this.lbLicenseClass_Titel.Name = "lbLicenseClass_Titel";
            this.lbLicenseClass_Titel.Size = new System.Drawing.Size(91, 15);
            this.lbLicenseClass_Titel.TabIndex = 54;
            this.lbLicenseClass_Titel.Text = "LICENSE CLASS   ";
            // 
            // lbExpiration
            // 
            this.lbExpiration.AutoSize = true;
            this.lbExpiration.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpiration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbExpiration.Location = new System.Drawing.Point(253, 23);
            this.lbExpiration.Name = "lbExpiration";
            this.lbExpiration.Size = new System.Drawing.Size(79, 26);
            this.lbExpiration.TabIndex = 55;
            this.lbExpiration.Text = "0001\\1\\1";
            // 
            // lbIssueDate_Titel
            // 
            this.lbIssueDate_Titel.AutoSize = true;
            this.lbIssueDate_Titel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueDate_Titel.ForeColor = System.Drawing.Color.DimGray;
            this.lbIssueDate_Titel.Location = new System.Drawing.Point(8, 9);
            this.lbIssueDate_Titel.Name = "lbIssueDate_Titel";
            this.lbIssueDate_Titel.Size = new System.Drawing.Size(68, 15);
            this.lbIssueDate_Titel.TabIndex = 54;
            this.lbIssueDate_Titel.Text = "ISSUE DATE  ";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbIssueDate.Location = new System.Drawing.Point(7, 23);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(79, 26);
            this.lbIssueDate.TabIndex = 53;
            this.lbIssueDate.Text = "0001\\1\\1";
            // 
            // pnlNotes
            // 
            this.pnlNotes.BackColor = System.Drawing.Color.LightGray;
            this.pnlNotes.Controls.Add(this.lbNotes);
            this.pnlNotes.Location = new System.Drawing.Point(7, 126);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Size = new System.Drawing.Size(346, 45);
            this.pnlNotes.TabIndex = 53;
            // 
            // lbNotes
            // 
            this.lbNotes.AutoSize = true;
            this.lbNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes.ForeColor = System.Drawing.Color.Black;
            this.lbNotes.Location = new System.Drawing.Point(6, 6);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(136, 17);
            this.lbNotes.TabIndex = 53;
            this.lbNotes.Text = "Notes And Conditions";
            // 
            // lbIssueReason
            // 
            this.lbIssueReason.AutoSize = true;
            this.lbIssueReason.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueReason.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbIssueReason.Location = new System.Drawing.Point(270, 169);
            this.lbIssueReason.Name = "lbIssueReason";
            this.lbIssueReason.Size = new System.Drawing.Size(44, 21);
            this.lbIssueReason.TabIndex = 53;
            this.lbIssueReason.Text = "New";
            // 
            // lbIssueReason_Titel
            // 
            this.lbIssueReason_Titel.AutoSize = true;
            this.lbIssueReason_Titel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueReason_Titel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbIssueReason_Titel.Location = new System.Drawing.Point(270, 151);
            this.lbIssueReason_Titel.Name = "lbIssueReason_Titel";
            this.lbIssueReason_Titel.Size = new System.Drawing.Size(86, 15);
            this.lbIssueReason_Titel.TabIndex = 54;
            this.lbIssueReason_Titel.Text = "ISSUE REASON   ";
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
            this.btnUpdate_Delete.Location = new System.Drawing.Point(8, 0);
            this.btnUpdate_Delete.Name = "btnUpdate_Delete";
            this.btnUpdate_Delete.Size = new System.Drawing.Size(30, 25);
            this.btnUpdate_Delete.TabIndex = 58;
            this.btnUpdate_Delete.Text = ". . .";
            this.btnUpdate_Delete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdate_Delete.UseVisualStyleBackColor = true;
            this.btnUpdate_Delete.Click += new System.EventHandler(this.btnUpdate_Delete_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.lbName.Location = new System.Drawing.Point(5, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(184, 26);
            this.lbName.TabIndex = 32;
            this.lbName.Text = "Name of the Person";
            // 
            // ucLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.btnUpdate_Delete);
            this.Controls.Add(this.lbIssueReason);
            this.Controls.Add(this.lbIssueReason_Titel);
            this.Controls.Add(this.pnlMoreInfo);
            this.Controls.Add(this.pbIsActive);
            this.Controls.Add(this.btnShowMore_Less);
            this.Controls.Add(this.lbDateOfBirth_Titel);
            this.Controls.Add(this.lbNationalNo_Titel);
            this.Controls.Add(this.lbLicenseID);
            this.Controls.Add(this.lbNationalNo);
            this.Controls.Add(this.lbLicenseID_Title);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbDateOfBirth);
            this.Controls.Add(this.lbName);
            this.Name = "ucLicense";
            this.Size = new System.Drawing.Size(367, 406);
            this.Load += new System.EventHandler(this.ucLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsActive)).EndInit();
            this.pnlMoreInfo.ResumeLayout(false);
            this.pnlMoreInfo.PerformLayout();
            this.pnlNotes.ResumeLayout(false);
            this.pnlNotes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lbDateOfBirth;
        //private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.Label lbExpirationDate;
        private System.Windows.Forms.Label lbNationalNo_Titel;
        private System.Windows.Forms.Label lbLicenseID;
        private System.Windows.Forms.Label lbNationalNo;
        private System.Windows.Forms.Label lbLicenseID_Title;
        private System.Windows.Forms.Label lbDateOfBirth_Titel;
        //private System.Windows.Forms.Label lbIssueDate_Titel;
        //private System.Windows.Forms.Label lbExpirationDate_Titel;
        //private System.Windows.Forms.Label lbIssueReason_Titel;
        //private System.Windows.Forms.Label lbIssueReason;
        //private System.Windows.Forms.Label lbLicenseClass_Titel;
        //private System.Windows.Forms.Label lbLicenseClass;
        //private System.Windows.Forms.Label lbNotes_Titel;
        //private clsRoundedPanel clsRoundedPanel1;
        //private System.Windows.Forms.Label lbNotes;
        private System.Windows.Forms.Button btnShowMore_Less;
        private System.Windows.Forms.PictureBox pbIsActive;
        private System.Windows.Forms.Panel pnlMoreInfo;
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Label lbNotes_Titel;
        private System.Windows.Forms.Label lbLicenseClass;
        private System.Windows.Forms.Label lbExpiration_Titel;
        private System.Windows.Forms.Label lbLicenseClass_Titel;
        private System.Windows.Forms.Label lbExpiration;
        private System.Windows.Forms.Label lbIssueDate_Titel;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.Label lbNotes;
        private System.Windows.Forms.Label lbIssueReason;
        private System.Windows.Forms.Label lbIssueReason_Titel;
        private System.Windows.Forms.Button btnUpdate_Delete;
        private System.Windows.Forms.Label lbName;
    }
}
