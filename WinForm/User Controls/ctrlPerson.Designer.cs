namespace DVLDWinForm
{
    partial class ctrlPerson
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
            this.components = new System.ComponentModel.Container();
            this.lbName = new System.Windows.Forms.Label();
            this.lbNationalNo_Titel = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.lbNationalNo = new System.Windows.Forms.Label();
            this.lbPersonID_Title = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbDateOfBirth = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.lbGendor = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.btnShowMore_Less = new System.Windows.Forms.Button();
            this.pnlMoreInfo = new System.Windows.Forms.Panel();
            this.pctrCountry = new System.Windows.Forms.PictureBox();
            this.pctrDateOfBirth = new System.Windows.Forms.PictureBox();
            this.pctrAddress = new System.Windows.Forms.PictureBox();
            this.pctrGendor = new System.Windows.Forms.PictureBox();
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.pctrPhone = new System.Windows.Forms.PictureBox();
            this.pctrEmail = new System.Windows.Forms.PictureBox();
            this.pnlIDs = new System.Windows.Forms.Panel();
            this.tmrAnimationSize = new System.Windows.Forms.Timer(this.components);
            this.btnUpdate_Delete = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pnlMoreInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDateOfBirth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).BeginInit();
            this.pnlContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrEmail)).BeginInit();
            this.pnlIDs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.lbName.Location = new System.Drawing.Point(13, 23);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(184, 26);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name of the Person";
            // 
            // lbNationalNo_Titel
            // 
            this.lbNationalNo_Titel.AutoSize = true;
            this.lbNationalNo_Titel.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalNo_Titel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbNationalNo_Titel.Location = new System.Drawing.Point(185, 8);
            this.lbNationalNo_Titel.Name = "lbNationalNo_Titel";
            this.lbNationalNo_Titel.Size = new System.Drawing.Size(87, 17);
            this.lbNationalNo_Titel.TabIndex = 25;
            this.lbNationalNo_Titel.Text = "NationalNo : ";
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
            // lbNationalNo
            // 
            this.lbNationalNo.AutoSize = true;
            this.lbNationalNo.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalNo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbNationalNo.Location = new System.Drawing.Point(270, 10);
            this.lbNationalNo.Name = "lbNationalNo";
            this.lbNationalNo.Size = new System.Drawing.Size(87, 15);
            this.lbNationalNo.TabIndex = 1;
            this.lbNationalNo.Text = "12001234567890";
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
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbAddress.Location = new System.Drawing.Point(52, 57);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(81, 26);
            this.lbAddress.TabIndex = 16;
            this.lbAddress.Text = "Address";
            // 
            // lbDateOfBirth
            // 
            this.lbDateOfBirth.AutoSize = true;
            this.lbDateOfBirth.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbDateOfBirth.Location = new System.Drawing.Point(250, 58);
            this.lbDateOfBirth.Name = "lbDateOfBirth";
            this.lbDateOfBirth.Size = new System.Drawing.Size(79, 26);
            this.lbDateOfBirth.TabIndex = 12;
            this.lbDateOfBirth.Text = "0001\\1\\1";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbCountry.Location = new System.Drawing.Point(51, 16);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(82, 26);
            this.lbCountry.TabIndex = 15;
            this.lbCountry.Text = "Country";
            // 
            // lbGendor
            // 
            this.lbGendor.AutoSize = true;
            this.lbGendor.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGendor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbGendor.Location = new System.Drawing.Point(250, 16);
            this.lbGendor.Name = "lbGendor";
            this.lbGendor.Size = new System.Drawing.Size(75, 26);
            this.lbGendor.TabIndex = 11;
            this.lbGendor.Text = "Gendor";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbPhone.Location = new System.Drawing.Point(51, 9);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(109, 26);
            this.lbPhone.TabIndex = 14;
            this.lbPhone.Text = "1234567890";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI Variable Display", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbEmail.Location = new System.Drawing.Point(51, 47);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(194, 26);
            this.lbEmail.TabIndex = 13;
            this.lbEmail.Text = "personml@gmail.com";
            // 
            // btnShowMore_Less
            // 
            this.btnShowMore_Less.Location = new System.Drawing.Point(342, 127);
            this.btnShowMore_Less.Name = "btnShowMore_Less";
            this.btnShowMore_Less.Size = new System.Drawing.Size(32, 23);
            this.btnShowMore_Less.TabIndex = 51;
            this.btnShowMore_Less.Text = ">>";
            this.btnShowMore_Less.UseVisualStyleBackColor = true;
            this.btnShowMore_Less.Click += new System.EventHandler(this.btnShowMore_Less_Click);
            // 
            // pnlMoreInfo
            // 
            this.pnlMoreInfo.BackColor = System.Drawing.Color.White;
            this.pnlMoreInfo.Controls.Add(this.lbAddress);
            this.pnlMoreInfo.Controls.Add(this.pctrCountry);
            this.pnlMoreInfo.Controls.Add(this.lbDateOfBirth);
            this.pnlMoreInfo.Controls.Add(this.lbGendor);
            this.pnlMoreInfo.Controls.Add(this.lbCountry);
            this.pnlMoreInfo.Controls.Add(this.pctrDateOfBirth);
            this.pnlMoreInfo.Controls.Add(this.pctrAddress);
            this.pnlMoreInfo.Controls.Add(this.pctrGendor);
            this.pnlMoreInfo.Location = new System.Drawing.Point(18, 160);
            this.pnlMoreInfo.Name = "pnlMoreInfo";
            this.pnlMoreInfo.Size = new System.Drawing.Size(355, 93);
            this.pnlMoreInfo.TabIndex = 53;
            // 
            // pctrCountry
            // 
            this.pctrCountry.Image = global::DVLDWinForm.Properties.Resources.Country;
            this.pctrCountry.Location = new System.Drawing.Point(11, 16);
            this.pctrCountry.Name = "pctrCountry";
            this.pctrCountry.Size = new System.Drawing.Size(24, 26);
            this.pctrCountry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrCountry.TabIndex = 22;
            this.pctrCountry.TabStop = false;
            // 
            // pctrDateOfBirth
            // 
            this.pctrDateOfBirth.Image = global::DVLDWinForm.Properties.Resources.Date_of_birth;
            this.pctrDateOfBirth.Location = new System.Drawing.Point(212, 58);
            this.pctrDateOfBirth.Name = "pctrDateOfBirth";
            this.pctrDateOfBirth.Size = new System.Drawing.Size(24, 26);
            this.pctrDateOfBirth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrDateOfBirth.TabIndex = 19;
            this.pctrDateOfBirth.TabStop = false;
            // 
            // pctrAddress
            // 
            this.pctrAddress.Image = global::DVLDWinForm.Properties.Resources.Address;
            this.pctrAddress.Location = new System.Drawing.Point(11, 58);
            this.pctrAddress.Name = "pctrAddress";
            this.pctrAddress.Size = new System.Drawing.Size(24, 26);
            this.pctrAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrAddress.TabIndex = 23;
            this.pctrAddress.TabStop = false;
            // 
            // pctrGendor
            // 
            this.pctrGendor.Image = global::DVLDWinForm.Properties.Resources.Gendor;
            this.pctrGendor.Location = new System.Drawing.Point(212, 16);
            this.pctrGendor.Name = "pctrGendor";
            this.pctrGendor.Size = new System.Drawing.Size(24, 26);
            this.pctrGendor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrGendor.TabIndex = 18;
            this.pctrGendor.TabStop = false;
            // 
            // pnlContacts
            // 
            this.pnlContacts.BackColor = System.Drawing.Color.White;
            this.pnlContacts.Controls.Add(this.lbPhone);
            this.pnlContacts.Controls.Add(this.pctrPhone);
            this.pnlContacts.Controls.Add(this.lbEmail);
            this.pnlContacts.Controls.Add(this.pctrEmail);
            this.pnlContacts.Location = new System.Drawing.Point(18, 63);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(268, 87);
            this.pnlContacts.TabIndex = 54;
            // 
            // pctrPhone
            // 
            this.pctrPhone.Image = global::DVLDWinForm.Properties.Resources.Phone;
            this.pctrPhone.Location = new System.Drawing.Point(12, 9);
            this.pctrPhone.Name = "pctrPhone";
            this.pctrPhone.Size = new System.Drawing.Size(24, 26);
            this.pctrPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrPhone.TabIndex = 21;
            this.pctrPhone.TabStop = false;
            // 
            // pctrEmail
            // 
            this.pctrEmail.Image = global::DVLDWinForm.Properties.Resources.Email;
            this.pctrEmail.Location = new System.Drawing.Point(12, 50);
            this.pctrEmail.Name = "pctrEmail";
            this.pctrEmail.Size = new System.Drawing.Size(24, 26);
            this.pctrEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrEmail.TabIndex = 20;
            this.pctrEmail.TabStop = false;
            // 
            // pnlIDs
            // 
            this.pnlIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlIDs.Controls.Add(this.lbNationalNo_Titel);
            this.pnlIDs.Controls.Add(this.lbPersonID_Title);
            this.pnlIDs.Controls.Add(this.lbPersonID);
            this.pnlIDs.Controls.Add(this.lbNationalNo);
            this.pnlIDs.Location = new System.Drawing.Point(0, 262);
            this.pnlIDs.Name = "pnlIDs";
            this.pnlIDs.Size = new System.Drawing.Size(381, 33);
            this.pnlIDs.TabIndex = 55;
            // 
            // tmrAnimationSize
            // 
            this.tmrAnimationSize.Tick += new System.EventHandler(this.tmrAnimationSize_Tick);
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
            this.btnUpdate_Delete.Location = new System.Drawing.Point(11, 3);
            this.btnUpdate_Delete.Name = "btnUpdate_Delete";
            this.btnUpdate_Delete.Size = new System.Drawing.Size(30, 25);
            this.btnUpdate_Delete.TabIndex = 57;
            this.btnUpdate_Delete.Text = ". . .";
            this.btnUpdate_Delete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdate_Delete.UseVisualStyleBackColor = true;
            this.btnUpdate_Delete.Click += new System.EventHandler(this.btnUpdate_Delete_Click);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DVLDWinForm.Properties.Resources.User;
            this.pbImage.Location = new System.Drawing.Point(293, 10);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(77, 77);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 29;
            this.pbImage.TabStop = false;
            this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage_Paint);
            // 
            // ctrlPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.btnUpdate_Delete);
            this.Controls.Add(this.pnlIDs);
            this.Controls.Add(this.pnlContacts);
            this.Controls.Add(this.pnlMoreInfo);
            this.Controls.Add(this.btnShowMore_Less);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lbName);
            this.Name = "ctrlPerson";
            this.Size = new System.Drawing.Size(381, 296);
            this.Load += new System.EventHandler(this.ctrlPerson_Load);
            this.pnlMoreInfo.ResumeLayout(false);
            this.pnlMoreInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDateOfBirth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).EndInit();
            this.pnlContacts.ResumeLayout(false);
            this.pnlContacts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrEmail)).EndInit();
            this.pnlIDs.ResumeLayout(false);
            this.pnlIDs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbNationalNo;
        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.Label lbGendor;
        private System.Windows.Forms.Label lbDateOfBirth;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.PictureBox pctrGendor;
        private System.Windows.Forms.PictureBox pctrDateOfBirth;
        private System.Windows.Forms.PictureBox pctrEmail;
        private System.Windows.Forms.PictureBox pctrPhone;
        private System.Windows.Forms.PictureBox pctrCountry;
        private System.Windows.Forms.PictureBox pctrAddress;
        private System.Windows.Forms.Label lbPersonID_Title;
        private System.Windows.Forms.Label lbNationalNo_Titel;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnShowMore_Less;
        private System.Windows.Forms.Panel pnlMoreInfo;
        private System.Windows.Forms.Panel pnlContacts;
        private System.Windows.Forms.Panel pnlIDs;
        private System.Windows.Forms.Timer tmrAnimationSize;
        private System.Windows.Forms.Button btnUpdate_Delete;
        //private ctrlImage ctrlImage1;
    }
}
