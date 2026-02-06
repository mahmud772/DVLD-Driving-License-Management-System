using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucDetainedLicensesFilter
    {
        private System.ComponentModel.IContainer components = null;

        private CheckBox ckbDetainDate;
        private Label lblDetainFrom;
        private Label lblDetainTo;
        private DateTimePicker dtpFromDetain;
        private DateTimePicker dtpToDetain;

        private CheckBox ckbIsReleased;
        private RadioButton rbReleasedYes;
        private RadioButton rbReleasedNo;

        private CheckBox ckbReleaseDate;
        private Label lblReleaseFrom;
        private Label lblReleaseTo;
        private DateTimePicker dtpFromRelease;
        private DateTimePicker dtpToRelease;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ckbReleaseDate = new System.Windows.Forms.CheckBox();
            this.lblReleaseFrom = new System.Windows.Forms.Label();
            this.dtpFromRelease = new System.Windows.Forms.DateTimePicker();
            this.lblReleaseTo = new System.Windows.Forms.Label();
            this.dtpToRelease = new System.Windows.Forms.DateTimePicker();
            this.ckbIsReleased = new System.Windows.Forms.CheckBox();
            this.rbReleasedYes = new System.Windows.Forms.RadioButton();
            this.rbReleasedNo = new System.Windows.Forms.RadioButton();
            this.ckbDetainDate = new System.Windows.Forms.CheckBox();
            this.lblDetainFrom = new System.Windows.Forms.Label();
            this.dtpFromDetain = new System.Windows.Forms.DateTimePicker();
            this.lblDetainTo = new System.Windows.Forms.Label();
            this.dtpToDetain = new System.Windows.Forms.DateTimePicker();
            this.pnlReleaseStatus = new System.Windows.Forms.Panel();
            this.pnlReleaseNotRelease = new System.Windows.Forms.Panel();
            this.pnlReleaseDate = new System.Windows.Forms.Panel();
            this.pnlFromToReleaseDate = new System.Windows.Forms.Panel();
            this.pnlDetainDate = new System.Windows.Forms.Panel();
            this.pnlFromToDetainDate = new System.Windows.Forms.Panel();
            this.pnlReleaseStatus.SuspendLayout();
            this.pnlReleaseNotRelease.SuspendLayout();
            this.pnlReleaseDate.SuspendLayout();
            this.pnlFromToReleaseDate.SuspendLayout();
            this.pnlDetainDate.SuspendLayout();
            this.pnlFromToDetainDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbReleaseDate
            // 
            this.ckbReleaseDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbReleaseDate.Location = new System.Drawing.Point(3, 2);
            this.ckbReleaseDate.Name = "ckbReleaseDate";
            this.ckbReleaseDate.Size = new System.Drawing.Size(120, 24);
            this.ckbReleaseDate.TabIndex = 0;
            this.ckbReleaseDate.Text = "Release Date";
            this.ckbReleaseDate.Click += new System.EventHandler(this.ckbReleaseDate_CheckedChanged);
            // 
            // lblReleaseFrom
            // 
            this.lblReleaseFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReleaseFrom.Location = new System.Drawing.Point(5, 8);
            this.lblReleaseFrom.Name = "lblReleaseFrom";
            this.lblReleaseFrom.Size = new System.Drawing.Size(44, 16);
            this.lblReleaseFrom.TabIndex = 1;
            this.lblReleaseFrom.Text = "From";
            // 
            // dtpFromRelease
            // 
            this.dtpFromRelease.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromRelease.Location = new System.Drawing.Point(55, 8);
            this.dtpFromRelease.Name = "dtpFromRelease";
            this.dtpFromRelease.Size = new System.Drawing.Size(93, 20);
            this.dtpFromRelease.TabIndex = 2;
            // 
            // lblReleaseTo
            // 
            this.lblReleaseTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReleaseTo.Location = new System.Drawing.Point(5, 36);
            this.lblReleaseTo.Name = "lblReleaseTo";
            this.lblReleaseTo.Size = new System.Drawing.Size(24, 18);
            this.lblReleaseTo.TabIndex = 3;
            this.lblReleaseTo.Text = "To";
            // 
            // dtpToRelease
            // 
            this.dtpToRelease.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToRelease.Location = new System.Drawing.Point(55, 36);
            this.dtpToRelease.Name = "dtpToRelease";
            this.dtpToRelease.Size = new System.Drawing.Size(93, 20);
            this.dtpToRelease.TabIndex = 4;
            // 
            // ckbIsReleased
            // 
            this.ckbIsReleased.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbIsReleased.Location = new System.Drawing.Point(6, 3);
            this.ckbIsReleased.Name = "ckbIsReleased";
            this.ckbIsReleased.Size = new System.Drawing.Size(120, 24);
            this.ckbIsReleased.TabIndex = 0;
            this.ckbIsReleased.Text = "Release Status";
            this.ckbIsReleased.Click += new System.EventHandler(this.ckbIsReleased_CheckedChanged);
            // 
            // rbReleasedYes
            // 
            this.rbReleasedYes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbReleasedYes.Location = new System.Drawing.Point(12, 7);
            this.rbReleasedYes.Name = "rbReleasedYes";
            this.rbReleasedYes.Size = new System.Drawing.Size(77, 24);
            this.rbReleasedYes.TabIndex = 1;
            this.rbReleasedYes.Text = "Released";
            // 
            // rbReleasedNo
            // 
            this.rbReleasedNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbReleasedNo.Location = new System.Drawing.Point(119, 7);
            this.rbReleasedNo.Name = "rbReleasedNo";
            this.rbReleasedNo.Size = new System.Drawing.Size(97, 24);
            this.rbReleasedNo.TabIndex = 2;
            this.rbReleasedNo.Text = "Not Released";
            // 
            // ckbDetainDate
            // 
            this.ckbDetainDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbDetainDate.Location = new System.Drawing.Point(3, 3);
            this.ckbDetainDate.Name = "ckbDetainDate";
            this.ckbDetainDate.Size = new System.Drawing.Size(104, 24);
            this.ckbDetainDate.TabIndex = 0;
            this.ckbDetainDate.Text = "Detain Date";
            this.ckbDetainDate.Click += new System.EventHandler(this.ckbDetainDate_CheckedChanged);
            // 
            // lblDetainFrom
            // 
            this.lblDetainFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetainFrom.Location = new System.Drawing.Point(5, 4);
            this.lblDetainFrom.Name = "lblDetainFrom";
            this.lblDetainFrom.Size = new System.Drawing.Size(37, 19);
            this.lblDetainFrom.TabIndex = 1;
            this.lblDetainFrom.Text = "From";
            // 
            // dtpFromDetain
            // 
            this.dtpFromDetain.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDetain.Location = new System.Drawing.Point(55, 4);
            this.dtpFromDetain.Name = "dtpFromDetain";
            this.dtpFromDetain.Size = new System.Drawing.Size(93, 20);
            this.dtpFromDetain.TabIndex = 2;
            // 
            // lblDetainTo
            // 
            this.lblDetainTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetainTo.Location = new System.Drawing.Point(5, 30);
            this.lblDetainTo.Name = "lblDetainTo";
            this.lblDetainTo.Size = new System.Drawing.Size(24, 20);
            this.lblDetainTo.TabIndex = 3;
            this.lblDetainTo.Text = "To";
            // 
            // dtpToDetain
            // 
            this.dtpToDetain.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDetain.Location = new System.Drawing.Point(55, 30);
            this.dtpToDetain.Name = "dtpToDetain";
            this.dtpToDetain.Size = new System.Drawing.Size(93, 20);
            this.dtpToDetain.TabIndex = 4;
            // 
            // pnlReleaseStatus
            // 
            this.pnlReleaseStatus.BackColor = System.Drawing.Color.White;
            this.pnlReleaseStatus.Controls.Add(this.pnlReleaseNotRelease);
            this.pnlReleaseStatus.Controls.Add(this.ckbIsReleased);
            this.pnlReleaseStatus.Location = new System.Drawing.Point(7, 118);
            this.pnlReleaseStatus.Name = "pnlReleaseStatus";
            this.pnlReleaseStatus.Size = new System.Drawing.Size(256, 78);
            this.pnlReleaseStatus.TabIndex = 9;
            // 
            // pnlReleaseNotRelease
            // 
            this.pnlReleaseNotRelease.BackColor = System.Drawing.Color.White;
            this.pnlReleaseNotRelease.Controls.Add(this.rbReleasedYes);
            this.pnlReleaseNotRelease.Controls.Add(this.rbReleasedNo);
            this.pnlReleaseNotRelease.Location = new System.Drawing.Point(25, 33);
            this.pnlReleaseNotRelease.Name = "pnlReleaseNotRelease";
            this.pnlReleaseNotRelease.Size = new System.Drawing.Size(221, 38);
            this.pnlReleaseNotRelease.TabIndex = 10;
            // 
            // pnlReleaseDate
            // 
            this.pnlReleaseDate.BackColor = System.Drawing.Color.White;
            this.pnlReleaseDate.Controls.Add(this.pnlFromToReleaseDate);
            this.pnlReleaseDate.Controls.Add(this.ckbReleaseDate);
            this.pnlReleaseDate.Location = new System.Drawing.Point(7, 202);
            this.pnlReleaseDate.Name = "pnlReleaseDate";
            this.pnlReleaseDate.Size = new System.Drawing.Size(256, 104);
            this.pnlReleaseDate.TabIndex = 10;
            // 
            // pnlFromToReleaseDate
            // 
            this.pnlFromToReleaseDate.BackColor = System.Drawing.Color.White;
            this.pnlFromToReleaseDate.Controls.Add(this.lblReleaseFrom);
            this.pnlFromToReleaseDate.Controls.Add(this.dtpFromRelease);
            this.pnlFromToReleaseDate.Controls.Add(this.lblReleaseTo);
            this.pnlFromToReleaseDate.Controls.Add(this.dtpToRelease);
            this.pnlFromToReleaseDate.Location = new System.Drawing.Point(87, 32);
            this.pnlFromToReleaseDate.Name = "pnlFromToReleaseDate";
            this.pnlFromToReleaseDate.Size = new System.Drawing.Size(159, 63);
            this.pnlFromToReleaseDate.TabIndex = 9;
            // 
            // pnlDetainDate
            // 
            this.pnlDetainDate.BackColor = System.Drawing.Color.White;
            this.pnlDetainDate.Controls.Add(this.pnlFromToDetainDate);
            this.pnlDetainDate.Controls.Add(this.ckbDetainDate);
            this.pnlDetainDate.Location = new System.Drawing.Point(7, 11);
            this.pnlDetainDate.Name = "pnlDetainDate";
            this.pnlDetainDate.Size = new System.Drawing.Size(256, 104);
            this.pnlDetainDate.TabIndex = 11;
            // 
            // pnlFromToDetainDate
            // 
            this.pnlFromToDetainDate.BackColor = System.Drawing.Color.White;
            this.pnlFromToDetainDate.Controls.Add(this.lblDetainFrom);
            this.pnlFromToDetainDate.Controls.Add(this.dtpFromDetain);
            this.pnlFromToDetainDate.Controls.Add(this.dtpToDetain);
            this.pnlFromToDetainDate.Controls.Add(this.lblDetainTo);
            this.pnlFromToDetainDate.Location = new System.Drawing.Point(87, 33);
            this.pnlFromToDetainDate.Name = "pnlFromToDetainDate";
            this.pnlFromToDetainDate.Size = new System.Drawing.Size(159, 62);
            this.pnlFromToDetainDate.TabIndex = 9;
            // 
            // ucDetainedLicensesFilter
            // 
            this.Controls.Add(this.pnlDetainDate);
            this.Controls.Add(this.pnlReleaseDate);
            this.Controls.Add(this.pnlReleaseStatus);
            this.Name = "ucDetainedLicensesFilter";
            this.Size = new System.Drawing.Size(270, 312);
            this.pnlReleaseStatus.ResumeLayout(false);
            this.pnlReleaseNotRelease.ResumeLayout(false);
            this.pnlReleaseDate.ResumeLayout(false);
            this.pnlFromToReleaseDate.ResumeLayout(false);
            this.pnlDetainDate.ResumeLayout(false);
            this.pnlFromToDetainDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Panel pnlReleaseStatus;
        private Panel pnlReleaseNotRelease;
        private Panel pnlReleaseDate;
        private Panel pnlFromToReleaseDate;
        private Panel pnlDetainDate;
        private Panel pnlFromToDetainDate;
    }
}
