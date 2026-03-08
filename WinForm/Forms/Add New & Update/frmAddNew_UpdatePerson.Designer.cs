namespace DVLDWinForm.Forms
{
    partial class frmAddNew_UpdatePerson
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
            this.lbTitel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlNationalNo = new System.Windows.Forms.Panel();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.lbNationalNo = new System.Windows.Forms.Label();
            this.pnlDateofBirthAndGender = new System.Windows.Forms.Panel();
            this.pctrGendor = new System.Windows.Forms.PictureBox();
            this.pctrDateOfBirth = new System.Windows.Forms.PictureBox();
            this.rdbtnFemale = new System.Windows.Forms.RadioButton();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.rdbtnMale = new System.Windows.Forms.RadioButton();
            this.lbGendor = new System.Windows.Forms.Label();
            this.lbDateOfBirth = new System.Windows.Forms.Label();
            this.pnlLocation = new System.Windows.Forms.Panel();
            this.pctrCountry = new System.Windows.Forms.PictureBox();
            this.pctrAddress = new System.Windows.Forms.PictureBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.pctrEmail = new System.Windows.Forms.PictureBox();
            this.pctrPhone = new System.Windows.Forms.PictureBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbThirdName = new System.Windows.Forms.TextBox();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbThirdName = new System.Windows.Forms.Label();
            this.lbSecondName = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.pbImagePath = new System.Windows.Forms.PictureBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pnlNationalNo.SuspendLayout();
            this.pnlDateofBirthAndGender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDateOfBirth)).BeginInit();
            this.pnlLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrAddress)).BeginInit();
            this.pnlContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPhone)).BeginInit();
            this.pnlName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lbTitel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTitel.Location = new System.Drawing.Point(128, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(154, 21);
            this.lbTitel.TabIndex = 6;
            this.lbTitel.Text = "ADD NEW PERSON";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(166, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlNationalNo
            // 
            this.pnlNationalNo.BackColor = System.Drawing.Color.White;
            this.pnlNationalNo.Controls.Add(this.tbNationalNo);
            this.pnlNationalNo.Controls.Add(this.lbNationalNo);
            this.pnlNationalNo.Location = new System.Drawing.Point(27, 52);
            this.pnlNationalNo.Name = "pnlNationalNo";
            this.pnlNationalNo.Size = new System.Drawing.Size(249, 50);
            this.pnlNationalNo.TabIndex = 39;
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalNo.Location = new System.Drawing.Point(87, 12);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(147, 22);
            this.tbNationalNo.TabIndex = 4;
            // 
            // lbNationalNo
            // 
            this.lbNationalNo.AutoSize = true;
            this.lbNationalNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalNo.Location = new System.Drawing.Point(9, 16);
            this.lbNationalNo.Name = "lbNationalNo";
            this.lbNationalNo.Size = new System.Drawing.Size(74, 13);
            this.lbNationalNo.TabIndex = 0;
            this.lbNationalNo.Text = "National No :";
            // 
            // pnlDateofBirthAndGender
            // 
            this.pnlDateofBirthAndGender.BackColor = System.Drawing.Color.White;
            this.pnlDateofBirthAndGender.Controls.Add(this.pctrGendor);
            this.pnlDateofBirthAndGender.Controls.Add(this.pctrDateOfBirth);
            this.pnlDateofBirthAndGender.Controls.Add(this.rdbtnFemale);
            this.pnlDateofBirthAndGender.Controls.Add(this.dtpDateOfBirth);
            this.pnlDateofBirthAndGender.Controls.Add(this.rdbtnMale);
            this.pnlDateofBirthAndGender.Controls.Add(this.lbGendor);
            this.pnlDateofBirthAndGender.Controls.Add(this.lbDateOfBirth);
            this.pnlDateofBirthAndGender.Location = new System.Drawing.Point(27, 337);
            this.pnlDateofBirthAndGender.Name = "pnlDateofBirthAndGender";
            this.pnlDateofBirthAndGender.Size = new System.Drawing.Size(400, 78);
            this.pnlDateofBirthAndGender.TabIndex = 40;
            // 
            // pctrGendor
            // 
            this.pctrGendor.Image = global::DVLDWinForm.Properties.Resources.Gendor;
            this.pctrGendor.Location = new System.Drawing.Point(95, 53);
            this.pctrGendor.Name = "pctrGendor";
            this.pctrGendor.Size = new System.Drawing.Size(16, 16);
            this.pctrGendor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrGendor.TabIndex = 30;
            this.pctrGendor.TabStop = false;
            // 
            // pctrDateOfBirth
            // 
            this.pctrDateOfBirth.Image = global::DVLDWinForm.Properties.Resources.Date_of_birth;
            this.pctrDateOfBirth.Location = new System.Drawing.Point(95, 16);
            this.pctrDateOfBirth.Name = "pctrDateOfBirth";
            this.pctrDateOfBirth.Size = new System.Drawing.Size(16, 16);
            this.pctrDateOfBirth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrDateOfBirth.TabIndex = 31;
            this.pctrDateOfBirth.TabStop = false;
            // 
            // rdbtnFemale
            // 
            this.rdbtnFemale.AutoSize = true;
            this.rdbtnFemale.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnFemale.Location = new System.Drawing.Point(210, 51);
            this.rdbtnFemale.Name = "rdbtnFemale";
            this.rdbtnFemale.Size = new System.Drawing.Size(62, 17);
            this.rdbtnFemale.TabIndex = 11;
            this.rdbtnFemale.TabStop = true;
            this.rdbtnFemale.Text = "Female";
            this.rdbtnFemale.UseVisualStyleBackColor = true;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfBirth.Location = new System.Drawing.Point(126, 14);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(190, 22);
            this.dtpDateOfBirth.TabIndex = 10;
            // 
            // rdbtnMale
            // 
            this.rdbtnMale.AutoSize = true;
            this.rdbtnMale.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnMale.Location = new System.Drawing.Point(125, 51);
            this.rdbtnMale.Name = "rdbtnMale";
            this.rdbtnMale.Size = new System.Drawing.Size(50, 17);
            this.rdbtnMale.TabIndex = 10;
            this.rdbtnMale.TabStop = true;
            this.rdbtnMale.Text = "Male";
            this.rdbtnMale.UseVisualStyleBackColor = true;
            // 
            // lbGendor
            // 
            this.lbGendor.AutoSize = true;
            this.lbGendor.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGendor.Location = new System.Drawing.Point(10, 53);
            this.lbGendor.Name = "lbGendor";
            this.lbGendor.Size = new System.Drawing.Size(77, 13);
            this.lbGendor.TabIndex = 1;
            this.lbGendor.Text = "Gender          :";
            // 
            // lbDateOfBirth
            // 
            this.lbDateOfBirth.AutoSize = true;
            this.lbDateOfBirth.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateOfBirth.Location = new System.Drawing.Point(10, 16);
            this.lbDateOfBirth.Name = "lbDateOfBirth";
            this.lbDateOfBirth.Size = new System.Drawing.Size(78, 13);
            this.lbDateOfBirth.TabIndex = 0;
            this.lbDateOfBirth.Text = "Date of birth :";
            // 
            // pnlLocation
            // 
            this.pnlLocation.BackColor = System.Drawing.Color.White;
            this.pnlLocation.Controls.Add(this.pctrCountry);
            this.pnlLocation.Controls.Add(this.pctrAddress);
            this.pnlLocation.Controls.Add(this.cbCountry);
            this.pnlLocation.Controls.Add(this.tbAddress);
            this.pnlLocation.Controls.Add(this.lbAddress);
            this.pnlLocation.Controls.Add(this.lbCountry);
            this.pnlLocation.Location = new System.Drawing.Point(27, 273);
            this.pnlLocation.Name = "pnlLocation";
            this.pnlLocation.Size = new System.Drawing.Size(400, 50);
            this.pnlLocation.TabIndex = 41;
            // 
            // pctrCountry
            // 
            this.pctrCountry.Image = global::DVLDWinForm.Properties.Resources.Country;
            this.pctrCountry.Location = new System.Drawing.Point(64, 15);
            this.pctrCountry.Name = "pctrCountry";
            this.pctrCountry.Size = new System.Drawing.Size(16, 16);
            this.pctrCountry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrCountry.TabIndex = 34;
            this.pctrCountry.TabStop = false;
            // 
            // pctrAddress
            // 
            this.pctrAddress.Image = global::DVLDWinForm.Properties.Resources.Address;
            this.pctrAddress.Location = new System.Drawing.Point(253, 15);
            this.pctrAddress.Name = "pctrAddress";
            this.pctrAddress.Size = new System.Drawing.Size(16, 16);
            this.pctrAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrAddress.TabIndex = 35;
            this.pctrAddress.TabStop = false;
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(87, 12);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(100, 21);
            this.cbCountry.TabIndex = 10;
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(281, 12);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(100, 22);
            this.tbAddress.TabIndex = 5;
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.Location = new System.Drawing.Point(196, 16);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(57, 13);
            this.lbAddress.TabIndex = 1;
            this.lbAddress.Text = "Address  :";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountry.Location = new System.Drawing.Point(10, 15);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(53, 13);
            this.lbCountry.TabIndex = 0;
            this.lbCountry.Text = "Country :";
            // 
            // pnlContacts
            // 
            this.pnlContacts.BackColor = System.Drawing.Color.White;
            this.pnlContacts.Controls.Add(this.pctrEmail);
            this.pnlContacts.Controls.Add(this.pctrPhone);
            this.pnlContacts.Controls.Add(this.tbEmail);
            this.pnlContacts.Controls.Add(this.tbPhone);
            this.pnlContacts.Controls.Add(this.lbEmail);
            this.pnlContacts.Controls.Add(this.lbPhone);
            this.pnlContacts.Location = new System.Drawing.Point(27, 212);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(400, 46);
            this.pnlContacts.TabIndex = 38;
            // 
            // pctrEmail
            // 
            this.pctrEmail.Image = global::DVLDWinForm.Properties.Resources.Email;
            this.pctrEmail.Location = new System.Drawing.Point(251, 16);
            this.pctrEmail.Name = "pctrEmail";
            this.pctrEmail.Size = new System.Drawing.Size(16, 16);
            this.pctrEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrEmail.TabIndex = 32;
            this.pctrEmail.TabStop = false;
            // 
            // pctrPhone
            // 
            this.pctrPhone.Image = global::DVLDWinForm.Properties.Resources.Phone;
            this.pctrPhone.Location = new System.Drawing.Point(64, 16);
            this.pctrPhone.Name = "pctrPhone";
            this.pctrPhone.Size = new System.Drawing.Size(16, 16);
            this.pctrPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctrPhone.TabIndex = 33;
            this.pctrPhone.TabStop = false;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(281, 12);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(100, 22);
            this.tbEmail.TabIndex = 5;
            // 
            // tbPhone
            // 
            this.tbPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhone.Location = new System.Drawing.Point(87, 12);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(100, 22);
            this.tbPhone.TabIndex = 4;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(196, 16);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(56, 13);
            this.lbEmail.TabIndex = 1;
            this.lbEmail.Text = "Email      :";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.Location = new System.Drawing.Point(10, 16);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(53, 13);
            this.lbPhone.TabIndex = 0;
            this.lbPhone.Text = "Phone    :";
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.Color.White;
            this.pnlName.Controls.Add(this.tbLastName);
            this.pnlName.Controls.Add(this.tbThirdName);
            this.pnlName.Controls.Add(this.tbSecondName);
            this.pnlName.Controls.Add(this.tbFirstName);
            this.pnlName.Controls.Add(this.lbLastName);
            this.pnlName.Controls.Add(this.lbThirdName);
            this.pnlName.Controls.Add(this.lbSecondName);
            this.pnlName.Controls.Add(this.lbFirstName);
            this.pnlName.Location = new System.Drawing.Point(27, 110);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(400, 91);
            this.pnlName.TabIndex = 37;
            // 
            // tbLastName
            // 
            this.tbLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastName.Location = new System.Drawing.Point(281, 57);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(100, 22);
            this.tbLastName.TabIndex = 7;
            // 
            // tbThirdName
            // 
            this.tbThirdName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbThirdName.Location = new System.Drawing.Point(87, 57);
            this.tbThirdName.Name = "tbThirdName";
            this.tbThirdName.Size = new System.Drawing.Size(100, 22);
            this.tbThirdName.TabIndex = 6;
            // 
            // tbSecondName
            // 
            this.tbSecondName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSecondName.Location = new System.Drawing.Point(281, 12);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(100, 22);
            this.tbSecondName.TabIndex = 5;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstName.Location = new System.Drawing.Point(87, 12);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(100, 22);
            this.tbFirstName.TabIndex = 4;
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastName.Location = new System.Drawing.Point(196, 61);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(81, 13);
            this.lbLastName.TabIndex = 3;
            this.lbLastName.Text = "Last Name      :";
            // 
            // lbThirdName
            // 
            this.lbThirdName.AutoSize = true;
            this.lbThirdName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThirdName.Location = new System.Drawing.Point(10, 61);
            this.lbThirdName.Name = "lbThirdName";
            this.lbThirdName.Size = new System.Drawing.Size(72, 13);
            this.lbThirdName.TabIndex = 2;
            this.lbThirdName.Text = "Third Name :";
            // 
            // lbSecondName
            // 
            this.lbSecondName.AutoSize = true;
            this.lbSecondName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSecondName.Location = new System.Drawing.Point(196, 16);
            this.lbSecondName.Name = "lbSecondName";
            this.lbSecondName.Size = new System.Drawing.Size(83, 13);
            this.lbSecondName.TabIndex = 1;
            this.lbSecondName.Text = "Second Name :";
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstName.Location = new System.Drawing.Point(10, 16);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(71, 13);
            this.lbFirstName.TabIndex = 0;
            this.lbFirstName.Text = "First Name  :";
            // 
            // pbImagePath
            // 
            this.pbImagePath.Image = global::DVLDWinForm.Properties.Resources.Image;
            this.pbImagePath.Location = new System.Drawing.Point(392, 89);
            this.pbImagePath.Name = "pbImagePath";
            this.pbImagePath.Size = new System.Drawing.Size(25, 18);
            this.pbImagePath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagePath.TabIndex = 44;
            this.pbImagePath.TabStop = false;
            this.pbImagePath.Click += new System.EventHandler(this.pbImagePath_Click);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DVLDWinForm.Properties.Resources.User;
            this.pbImage.Location = new System.Drawing.Point(317, 40);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(67, 67);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 43;
            this.pbImage.TabStop = false;
            this.pbImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImage_Paint);
            // 
            // frmAddNew_UpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(455, 476);
            this.Controls.Add(this.pbImagePath);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.pnlNationalNo);
            this.Controls.Add(this.pnlDateofBirthAndGender);
            this.Controls.Add(this.pnlLocation);
            this.Controls.Add(this.pnlContacts);
            this.Controls.Add(this.pnlName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmAddNew_UpdatePerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Person";
            this.Load += new System.EventHandler(this.frmAddNew_UpdatePerson_Load);
            this.pnlNationalNo.ResumeLayout(false);
            this.pnlNationalNo.PerformLayout();
            this.pnlDateofBirthAndGender.ResumeLayout(false);
            this.pnlDateofBirthAndGender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrGendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDateOfBirth)).EndInit();
            this.pnlLocation.ResumeLayout(false);
            this.pnlLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrAddress)).EndInit();
            this.pnlContacts.ResumeLayout(false);
            this.pnlContacts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrPhone)).EndInit();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Panel pnlNationalNo;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.Label lbNationalNo;
        private System.Windows.Forms.Panel pnlDateofBirthAndGender;
        private System.Windows.Forms.PictureBox pctrGendor;
        private System.Windows.Forms.PictureBox pctrDateOfBirth;
        private System.Windows.Forms.RadioButton rdbtnFemale;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.RadioButton rdbtnMale;
        private System.Windows.Forms.Label lbGendor;
        private System.Windows.Forms.Label lbDateOfBirth;
        private System.Windows.Forms.Panel pnlLocation;
        private System.Windows.Forms.PictureBox pctrCountry;
        private System.Windows.Forms.PictureBox pctrAddress;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Panel pnlContacts;
        private System.Windows.Forms.PictureBox pctrEmail;
        private System.Windows.Forms.PictureBox pctrPhone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbThirdName;
        private System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbThirdName;
        private System.Windows.Forms.Label lbSecondName;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.PictureBox pbImagePath;
    }
}