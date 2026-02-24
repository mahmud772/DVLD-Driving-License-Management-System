namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucPeopleFilter
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.chkAge = new System.Windows.Forms.CheckBox();
            this.chkGender = new System.Windows.Forms.CheckBox();
            this.chkNationality = new System.Windows.Forms.CheckBox();
            this.nudAgeFrom = new System.Windows.Forms.NumericUpDown();
            this.nudAgeTo = new System.Windows.Forms.NumericUpDown();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.cboNationality = new System.Windows.Forms.ComboBox();
            this.lblAgeFrom = new System.Windows.Forms.Label();
            this.lblAgeTo = new System.Windows.Forms.Label();
            this.pnlAge = new System.Windows.Forms.Panel();
            this.pnlFromToAge = new System.Windows.Forms.Panel();
            this.pnlGender = new System.Windows.Forms.Panel();
            this.pnlMaleFemale = new System.Windows.Forms.Panel();
            this.pnlNNationality = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeTo)).BeginInit();
            this.pnlAge.SuspendLayout();
            this.pnlFromToAge.SuspendLayout();
            this.pnlGender.SuspendLayout();
            this.pnlMaleFemale.SuspendLayout();
            this.pnlNNationality.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAge
            // 
            this.chkAge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkAge.Location = new System.Drawing.Point(3, 3);
            this.chkAge.Name = "chkAge";
            this.chkAge.Size = new System.Drawing.Size(59, 24);
            this.chkAge.TabIndex = 0;
            this.chkAge.Text = "Age";
            this.chkAge.Click += new System.EventHandler(this.chkAge_CheckedChanged);
            // 
            // chkGender
            // 
            this.chkGender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkGender.Location = new System.Drawing.Point(3, 3);
            this.chkGender.Name = "chkGender";
            this.chkGender.Size = new System.Drawing.Size(74, 24);
            this.chkGender.TabIndex = 1;
            this.chkGender.Text = "Gender";
            this.chkGender.Click += new System.EventHandler(this.chkGender_CheckedChanged);
            // 
            // chkNationality
            // 
            this.chkNationality.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkNationality.Location = new System.Drawing.Point(4, 3);
            this.chkNationality.Name = "chkNationality";
            this.chkNationality.Size = new System.Drawing.Size(104, 24);
            this.chkNationality.TabIndex = 2;
            this.chkNationality.Text = "Nationality";
            this.chkNationality.Click += new System.EventHandler(this.chkNationality_CheckedChanged);
            // 
            // nudAgeFrom
            // 
            this.nudAgeFrom.Location = new System.Drawing.Point(50, 7);
            this.nudAgeFrom.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudAgeFrom.Name = "nudAgeFrom";
            this.nudAgeFrom.Size = new System.Drawing.Size(60, 24);
            this.nudAgeFrom.TabIndex = 3;
            // 
            // nudAgeTo
            // 
            this.nudAgeTo.Location = new System.Drawing.Point(210, 7);
            this.nudAgeTo.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudAgeTo.Name = "nudAgeTo";
            this.nudAgeTo.Size = new System.Drawing.Size(60, 24);
            this.nudAgeTo.TabIndex = 4;
            // 
            // rbMale
            // 
            this.rbMale.Location = new System.Drawing.Point(14, 5);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(74, 24);
            this.rbMale.TabIndex = 5;
            this.rbMale.Text = "Male";
            // 
            // rbFemale
            // 
            this.rbFemale.Location = new System.Drawing.Point(107, 5);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(79, 24);
            this.rbFemale.TabIndex = 6;
            this.rbFemale.Text = "Female";
            // 
            // cboNationality
            // 
            this.cboNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNationality.Location = new System.Drawing.Point(4, 33);
            this.cboNationality.Name = "cboNationality";
            this.cboNationality.Size = new System.Drawing.Size(196, 25);
            this.cboNationality.TabIndex = 7;
            // 
            // lblAgeFrom
            // 
            this.lblAgeFrom.Location = new System.Drawing.Point(3, 7);
            this.lblAgeFrom.Name = "lblAgeFrom";
            this.lblAgeFrom.Size = new System.Drawing.Size(46, 19);
            this.lblAgeFrom.TabIndex = 8;
            this.lblAgeFrom.Text = "From";
            // 
            // lblAgeTo
            // 
            this.lblAgeTo.Location = new System.Drawing.Point(163, 8);
            this.lblAgeTo.Name = "lblAgeTo";
            this.lblAgeTo.Size = new System.Drawing.Size(29, 21);
            this.lblAgeTo.TabIndex = 9;
            this.lblAgeTo.Text = "To";
            // 
            // pnlAge
            // 
            this.pnlAge.BackColor = System.Drawing.Color.White;
            this.pnlAge.Controls.Add(this.chkAge);
            this.pnlAge.Controls.Add(this.pnlFromToAge);
            this.pnlAge.Location = new System.Drawing.Point(9, 9);
            this.pnlAge.Name = "pnlAge";
            this.pnlAge.Size = new System.Drawing.Size(412, 78);
            this.pnlAge.TabIndex = 10;
            // 
            // pnlFromToAge
            // 
            this.pnlFromToAge.BackColor = System.Drawing.Color.White;
            this.pnlFromToAge.Controls.Add(this.lblAgeFrom);
            this.pnlFromToAge.Controls.Add(this.nudAgeFrom);
            this.pnlFromToAge.Controls.Add(this.nudAgeTo);
            this.pnlFromToAge.Controls.Add(this.lblAgeTo);
            this.pnlFromToAge.Location = new System.Drawing.Point(56, 27);
            this.pnlFromToAge.Name = "pnlFromToAge";
            this.pnlFromToAge.Size = new System.Drawing.Size(298, 43);
            this.pnlFromToAge.TabIndex = 9;
            // 
            // pnlGender
            // 
            this.pnlGender.BackColor = System.Drawing.Color.White;
            this.pnlGender.Controls.Add(this.chkGender);
            this.pnlGender.Controls.Add(this.pnlMaleFemale);
            this.pnlGender.Location = new System.Drawing.Point(222, 93);
            this.pnlGender.Name = "pnlGender";
            this.pnlGender.Size = new System.Drawing.Size(199, 67);
            this.pnlGender.TabIndex = 11;
            // 
            // pnlMaleFemale
            // 
            this.pnlMaleFemale.BackColor = System.Drawing.Color.White;
            this.pnlMaleFemale.Controls.Add(this.rbFemale);
            this.pnlMaleFemale.Controls.Add(this.rbMale);
            this.pnlMaleFemale.Location = new System.Drawing.Point(3, 27);
            this.pnlMaleFemale.Name = "pnlMaleFemale";
            this.pnlMaleFemale.Size = new System.Drawing.Size(192, 33);
            this.pnlMaleFemale.TabIndex = 9;
            // 
            // pnlNNationality
            // 
            this.pnlNNationality.BackColor = System.Drawing.Color.White;
            this.pnlNNationality.Controls.Add(this.cboNationality);
            this.pnlNNationality.Controls.Add(this.chkNationality);
            this.pnlNNationality.Location = new System.Drawing.Point(9, 93);
            this.pnlNNationality.Name = "pnlNNationality";
            this.pnlNNationality.Size = new System.Drawing.Size(207, 67);
            this.pnlNNationality.TabIndex = 12;
            // 
            // ucPeopleFilter
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlGender);
            this.Controls.Add(this.pnlAge);
            this.Controls.Add(this.pnlNNationality);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "ucPeopleFilter";
            this.Size = new System.Drawing.Size(426, 169);
            this.Load += new System.EventHandler(this.ucPeopleFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeTo)).EndInit();
            this.pnlAge.ResumeLayout(false);
            this.pnlFromToAge.ResumeLayout(false);
            this.pnlGender.ResumeLayout(false);
            this.pnlMaleFemale.ResumeLayout(false);
            this.pnlNNationality.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkAge;
        private System.Windows.Forms.CheckBox chkGender;
        private System.Windows.Forms.CheckBox chkNationality;
        private System.Windows.Forms.NumericUpDown nudAgeFrom;
        private System.Windows.Forms.NumericUpDown nudAgeTo;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.ComboBox cboNationality;
        private System.Windows.Forms.Label lblAgeFrom;
        private System.Windows.Forms.Label lblAgeTo;
        private System.Windows.Forms.Panel pnlAge;
        private System.Windows.Forms.Panel pnlFromToAge;
        private System.Windows.Forms.Panel pnlGender;
        private System.Windows.Forms.Panel pnlMaleFemale;
        private System.Windows.Forms.Panel pnlNNationality;
    }
}
