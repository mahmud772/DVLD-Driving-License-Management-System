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
            this.pnlMain = new System.Windows.Forms.Panel();
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
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeTo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.chkAge);
            this.pnlMain.Controls.Add(this.chkGender);
            this.pnlMain.Controls.Add(this.chkNationality);
            this.pnlMain.Controls.Add(this.nudAgeFrom);
            this.pnlMain.Controls.Add(this.nudAgeTo);
            this.pnlMain.Controls.Add(this.rbMale);
            this.pnlMain.Controls.Add(this.rbFemale);
            this.pnlMain.Controls.Add(this.cboNationality);
            this.pnlMain.Controls.Add(this.lblAgeFrom);
            this.pnlMain.Controls.Add(this.lblAgeTo);
            this.pnlMain.Location = new System.Drawing.Point(10, 10);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 210);
            this.pnlMain.TabIndex = 0;
            // 
            // chkAge
            // 
            this.chkAge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkAge.Location = new System.Drawing.Point(15, 15);
            this.chkAge.Name = "chkAge";
            this.chkAge.Size = new System.Drawing.Size(104, 24);
            this.chkAge.TabIndex = 0;
            this.chkAge.Text = "Age";
            // 
            // chkGender
            // 
            this.chkGender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkGender.Location = new System.Drawing.Point(15, 80);
            this.chkGender.Name = "chkGender";
            this.chkGender.Size = new System.Drawing.Size(104, 24);
            this.chkGender.TabIndex = 1;
            this.chkGender.Text = "Gender";
            // 
            // chkNationality
            // 
            this.chkNationality.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkNationality.Location = new System.Drawing.Point(15, 150);
            this.chkNationality.Name = "chkNationality";
            this.chkNationality.Size = new System.Drawing.Size(104, 24);
            this.chkNationality.TabIndex = 2;
            this.chkNationality.Text = "Nationality";
            // 
            // nudAgeFrom
            // 
            this.nudAgeFrom.Location = new System.Drawing.Point(80, 42);
            this.nudAgeFrom.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudAgeFrom.Name = "nudAgeFrom";
            this.nudAgeFrom.Size = new System.Drawing.Size(120, 24);
            this.nudAgeFrom.TabIndex = 3;
            // 
            // nudAgeTo
            // 
            this.nudAgeTo.Location = new System.Drawing.Point(235, 42);
            this.nudAgeTo.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudAgeTo.Name = "nudAgeTo";
            this.nudAgeTo.Size = new System.Drawing.Size(120, 24);
            this.nudAgeTo.TabIndex = 4;
            // 
            // rbMale
            // 
            this.rbMale.Location = new System.Drawing.Point(35, 110);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(104, 24);
            this.rbMale.TabIndex = 5;
            this.rbMale.Text = "Male";
            // 
            // rbFemale
            // 
            this.rbFemale.Location = new System.Drawing.Point(143, 110);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(104, 24);
            this.rbFemale.TabIndex = 6;
            this.rbFemale.Text = "Female";
            // 
            // cboNationality
            // 
            this.cboNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNationality.Location = new System.Drawing.Point(35, 175);
            this.cboNationality.Name = "cboNationality";
            this.cboNationality.Size = new System.Drawing.Size(250, 25);
            this.cboNationality.TabIndex = 7;
            // 
            // lblAgeFrom
            // 
            this.lblAgeFrom.Location = new System.Drawing.Point(35, 45);
            this.lblAgeFrom.Name = "lblAgeFrom";
            this.lblAgeFrom.Size = new System.Drawing.Size(100, 23);
            this.lblAgeFrom.TabIndex = 8;
            this.lblAgeFrom.Text = "From:";
            // 
            // lblAgeTo
            // 
            this.lblAgeTo.Location = new System.Drawing.Point(200, 45);
            this.lblAgeTo.Name = "lblAgeTo";
            this.lblAgeTo.Size = new System.Drawing.Size(100, 23);
            this.lblAgeTo.TabIndex = 9;
            this.lblAgeTo.Text = "To:";
            // 
            // ucPeopleFilter
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "ucPeopleFilter";
            this.Size = new System.Drawing.Size(420, 230);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgeTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
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
    }
}
