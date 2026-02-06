using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucLicensesFilter
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLicenseClass;
        private Panel pnlIssueDate;
        private Panel pnlExpirationDate;
        private Panel pnlIsActive;
        private Panel pnlIssueReason;

        private CheckBox ckbLicenseClass;
        private ComboBox cbLicenseClass;

        private CheckBox ckbIssueDate;
        private Label lblIssueFrom;
        private Label lblIssueTo;
        private DateTimePicker dtpFromIssue;
        private DateTimePicker dtpToIssue;

        private CheckBox ckbExpirationDate;
        private Label lblExpireFrom;
        private Label lblExpireTo;
        private DateTimePicker dtpFromExpire;
        private DateTimePicker dtpToExpire;

        private CheckBox ckbIsActive;
        private RadioButton rbActiveYes;
        private RadioButton rbActiveNo;

        private CheckBox ckbIssueReason;
        private ComboBox cbIssueReason;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlLicenseClass = new System.Windows.Forms.Panel();
            this.ckbLicenseClass = new System.Windows.Forms.CheckBox();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.pnlIssueDate = new System.Windows.Forms.Panel();
            this.ckbIssueDate = new System.Windows.Forms.CheckBox();
            this.lblIssueFrom = new System.Windows.Forms.Label();
            this.dtpFromIssue = new System.Windows.Forms.DateTimePicker();
            this.lblIssueTo = new System.Windows.Forms.Label();
            this.dtpToIssue = new System.Windows.Forms.DateTimePicker();
            this.pnlExpirationDate = new System.Windows.Forms.Panel();
            this.ckbExpirationDate = new System.Windows.Forms.CheckBox();
            this.lblExpireFrom = new System.Windows.Forms.Label();
            this.dtpFromExpire = new System.Windows.Forms.DateTimePicker();
            this.lblExpireTo = new System.Windows.Forms.Label();
            this.dtpToExpire = new System.Windows.Forms.DateTimePicker();
            this.pnlIsActive = new System.Windows.Forms.Panel();
            this.ckbIsActive = new System.Windows.Forms.CheckBox();
            this.rbActiveYes = new System.Windows.Forms.RadioButton();
            this.rbActiveNo = new System.Windows.Forms.RadioButton();
            this.pnlIssueReason = new System.Windows.Forms.Panel();
            this.ckbIssueReason = new System.Windows.Forms.CheckBox();
            this.cbIssueReason = new System.Windows.Forms.ComboBox();
            this.pnlLicenseClass.SuspendLayout();
            this.pnlIssueDate.SuspendLayout();
            this.pnlExpirationDate.SuspendLayout();
            this.pnlIsActive.SuspendLayout();
            this.pnlIssueReason.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLicenseClass
            // 
            this.pnlLicenseClass.BackColor = System.Drawing.Color.White;
            this.pnlLicenseClass.Controls.Add(this.ckbLicenseClass);
            this.pnlLicenseClass.Controls.Add(this.cbLicenseClass);
            this.pnlLicenseClass.Location = new System.Drawing.Point(13, 12);
            this.pnlLicenseClass.Name = "pnlLicenseClass";
            this.pnlLicenseClass.Size = new System.Drawing.Size(392, 70);
            this.pnlLicenseClass.TabIndex = 0;
            // 
            // ckbLicenseClass
            // 
            this.ckbLicenseClass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbLicenseClass.Location = new System.Drawing.Point(10, 10);
            this.ckbLicenseClass.Name = "ckbLicenseClass";
            this.ckbLicenseClass.Size = new System.Drawing.Size(120, 24);
            this.ckbLicenseClass.TabIndex = 0;
            this.ckbLicenseClass.Text = "License Class";
            this.ckbLicenseClass.Click += new System.EventHandler(this.ckbLicenseClass_CheckedChanged);
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.Location = new System.Drawing.Point(30, 38);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(167, 21);
            this.cbLicenseClass.TabIndex = 1;
            // 
            // pnlIssueDate
            // 
            this.pnlIssueDate.BackColor = System.Drawing.Color.White;
            this.pnlIssueDate.Controls.Add(this.ckbIssueDate);
            this.pnlIssueDate.Controls.Add(this.lblIssueFrom);
            this.pnlIssueDate.Controls.Add(this.dtpFromIssue);
            this.pnlIssueDate.Controls.Add(this.lblIssueTo);
            this.pnlIssueDate.Controls.Add(this.dtpToIssue);
            this.pnlIssueDate.Location = new System.Drawing.Point(13, 92);
            this.pnlIssueDate.Name = "pnlIssueDate";
            this.pnlIssueDate.Size = new System.Drawing.Size(197, 95);
            this.pnlIssueDate.TabIndex = 1;
            // 
            // ckbIssueDate
            // 
            this.ckbIssueDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbIssueDate.Location = new System.Drawing.Point(10, 8);
            this.ckbIssueDate.Name = "ckbIssueDate";
            this.ckbIssueDate.Size = new System.Drawing.Size(104, 24);
            this.ckbIssueDate.TabIndex = 0;
            this.ckbIssueDate.Text = "Issue Date";
            this.ckbIssueDate.Click += new System.EventHandler(this.ckbIssueDate_CheckedChanged);
            // 
            // lblIssueFrom
            // 
            this.lblIssueFrom.Location = new System.Drawing.Point(30, 41);
            this.lblIssueFrom.Name = "lblIssueFrom";
            this.lblIssueFrom.Size = new System.Drawing.Size(34, 16);
            this.lblIssueFrom.TabIndex = 1;
            this.lblIssueFrom.Text = "From";
            // 
            // dtpFromIssue
            // 
            this.dtpFromIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromIssue.Location = new System.Drawing.Point(70, 38);
            this.dtpFromIssue.Name = "dtpFromIssue";
            this.dtpFromIssue.Size = new System.Drawing.Size(103, 20);
            this.dtpFromIssue.TabIndex = 2;
            // 
            // lblIssueTo
            // 
            this.lblIssueTo.Location = new System.Drawing.Point(30, 70);
            this.lblIssueTo.Name = "lblIssueTo";
            this.lblIssueTo.Size = new System.Drawing.Size(24, 15);
            this.lblIssueTo.TabIndex = 3;
            this.lblIssueTo.Text = "To";
            // 
            // dtpToIssue
            // 
            this.dtpToIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToIssue.Location = new System.Drawing.Point(70, 70);
            this.dtpToIssue.Name = "dtpToIssue";
            this.dtpToIssue.Size = new System.Drawing.Size(103, 20);
            this.dtpToIssue.TabIndex = 4;
            // 
            // pnlExpirationDate
            // 
            this.pnlExpirationDate.BackColor = System.Drawing.Color.White;
            this.pnlExpirationDate.Controls.Add(this.ckbExpirationDate);
            this.pnlExpirationDate.Controls.Add(this.lblExpireFrom);
            this.pnlExpirationDate.Controls.Add(this.dtpFromExpire);
            this.pnlExpirationDate.Controls.Add(this.lblExpireTo);
            this.pnlExpirationDate.Controls.Add(this.dtpToExpire);
            this.pnlExpirationDate.Location = new System.Drawing.Point(216, 92);
            this.pnlExpirationDate.Name = "pnlExpirationDate";
            this.pnlExpirationDate.Size = new System.Drawing.Size(189, 95);
            this.pnlExpirationDate.TabIndex = 2;
            // 
            // ckbExpirationDate
            // 
            this.ckbExpirationDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbExpirationDate.Location = new System.Drawing.Point(10, 8);
            this.ckbExpirationDate.Name = "ckbExpirationDate";
            this.ckbExpirationDate.Size = new System.Drawing.Size(124, 24);
            this.ckbExpirationDate.TabIndex = 0;
            this.ckbExpirationDate.Text = "Expiration Date";
            this.ckbExpirationDate.Click += new System.EventHandler(this.ckbExpirationDate_CheckedChanged);
            // 
            // lblExpireFrom
            // 
            this.lblExpireFrom.Location = new System.Drawing.Point(30, 39);
            this.lblExpireFrom.Name = "lblExpireFrom";
            this.lblExpireFrom.Size = new System.Drawing.Size(34, 16);
            this.lblExpireFrom.TabIndex = 1;
            this.lblExpireFrom.Text = "From";
            // 
            // dtpFromExpire
            // 
            this.dtpFromExpire.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromExpire.Location = new System.Drawing.Point(70, 38);
            this.dtpFromExpire.Name = "dtpFromExpire";
            this.dtpFromExpire.Size = new System.Drawing.Size(100, 20);
            this.dtpFromExpire.TabIndex = 2;
            // 
            // lblExpireTo
            // 
            this.lblExpireTo.Location = new System.Drawing.Point(30, 69);
            this.lblExpireTo.Name = "lblExpireTo";
            this.lblExpireTo.Size = new System.Drawing.Size(24, 16);
            this.lblExpireTo.TabIndex = 3;
            this.lblExpireTo.Text = "To";
            // 
            // dtpToExpire
            // 
            this.dtpToExpire.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToExpire.Location = new System.Drawing.Point(70, 63);
            this.dtpToExpire.Name = "dtpToExpire";
            this.dtpToExpire.Size = new System.Drawing.Size(100, 20);
            this.dtpToExpire.TabIndex = 4;
            // 
            // pnlIsActive
            // 
            this.pnlIsActive.BackColor = System.Drawing.Color.White;
            this.pnlIsActive.Controls.Add(this.ckbIsActive);
            this.pnlIsActive.Controls.Add(this.rbActiveYes);
            this.pnlIsActive.Controls.Add(this.rbActiveNo);
            this.pnlIsActive.Location = new System.Drawing.Point(216, 193);
            this.pnlIsActive.Name = "pnlIsActive";
            this.pnlIsActive.Size = new System.Drawing.Size(189, 70);
            this.pnlIsActive.TabIndex = 3;
            // 
            // ckbIsActive
            // 
            this.ckbIsActive.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbIsActive.Location = new System.Drawing.Point(10, 8);
            this.ckbIsActive.Name = "ckbIsActive";
            this.ckbIsActive.Size = new System.Drawing.Size(120, 24);
            this.ckbIsActive.TabIndex = 0;
            this.ckbIsActive.Text = "License Status";
            this.ckbIsActive.Click += new System.EventHandler(this.ckbIsActive_CheckedChanged);
            // 
            // rbActiveYes
            // 
            this.rbActiveYes.Location = new System.Drawing.Point(30, 40);
            this.rbActiveYes.Name = "rbActiveYes";
            this.rbActiveYes.Size = new System.Drawing.Size(72, 24);
            this.rbActiveYes.TabIndex = 1;
            this.rbActiveYes.Text = "Active";
            // 
            // rbActiveNo
            // 
            this.rbActiveNo.Location = new System.Drawing.Point(109, 40);
            this.rbActiveNo.Name = "rbActiveNo";
            this.rbActiveNo.Size = new System.Drawing.Size(69, 24);
            this.rbActiveNo.TabIndex = 2;
            this.rbActiveNo.Text = "Inactive";
            // 
            // pnlIssueReason
            // 
            this.pnlIssueReason.BackColor = System.Drawing.Color.White;
            this.pnlIssueReason.Controls.Add(this.ckbIssueReason);
            this.pnlIssueReason.Controls.Add(this.cbIssueReason);
            this.pnlIssueReason.Location = new System.Drawing.Point(13, 193);
            this.pnlIssueReason.Name = "pnlIssueReason";
            this.pnlIssueReason.Size = new System.Drawing.Size(197, 70);
            this.pnlIssueReason.TabIndex = 4;
            // 
            // ckbIssueReason
            // 
            this.ckbIssueReason.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbIssueReason.Location = new System.Drawing.Point(10, 10);
            this.ckbIssueReason.Name = "ckbIssueReason";
            this.ckbIssueReason.Size = new System.Drawing.Size(120, 24);
            this.ckbIssueReason.TabIndex = 0;
            this.ckbIssueReason.Text = "Issue Reason";
            this.ckbIssueReason.Click += new System.EventHandler(this.ckbIssueReason_CheckedChanged);
            // 
            // cbIssueReason
            // 
            this.cbIssueReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIssueReason.Location = new System.Drawing.Point(30, 38);
            this.cbIssueReason.Name = "cbIssueReason";
            this.cbIssueReason.Size = new System.Drawing.Size(129, 21);
            this.cbIssueReason.TabIndex = 1;
            // 
            // ucLicensesFilter
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlLicenseClass);
            this.Controls.Add(this.pnlIssueDate);
            this.Controls.Add(this.pnlExpirationDate);
            this.Controls.Add(this.pnlIssueReason);
            this.Controls.Add(this.pnlIsActive);
            this.Name = "ucLicensesFilter";
            this.Size = new System.Drawing.Size(410, 269);
            this.pnlLicenseClass.ResumeLayout(false);
            this.pnlIssueDate.ResumeLayout(false);
            this.pnlExpirationDate.ResumeLayout(false);
            this.pnlIsActive.ResumeLayout(false);
            this.pnlIssueReason.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
