using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucDetainedLicenseFilter
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;
        private Panel pnlDetainDate;
        private Panel pnlReleaseStatus;
        private Panel pnlReleaseDate;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlReleaseDate = new System.Windows.Forms.Panel();
            this.ckbReleaseDate = new System.Windows.Forms.CheckBox();
            this.lblReleaseFrom = new System.Windows.Forms.Label();
            this.dtpFromRelease = new System.Windows.Forms.DateTimePicker();
            this.lblReleaseTo = new System.Windows.Forms.Label();
            this.dtpToRelease = new System.Windows.Forms.DateTimePicker();
            this.pnlReleaseStatus = new System.Windows.Forms.Panel();
            this.ckbIsReleased = new System.Windows.Forms.CheckBox();
            this.rbReleasedYes = new System.Windows.Forms.RadioButton();
            this.rbReleasedNo = new System.Windows.Forms.RadioButton();
            this.pnlDetainDate = new System.Windows.Forms.Panel();
            this.ckbDetainDate = new System.Windows.Forms.CheckBox();
            this.lblDetainFrom = new System.Windows.Forms.Label();
            this.dtpFromDetain = new System.Windows.Forms.DateTimePicker();
            this.lblDetainTo = new System.Windows.Forms.Label();
            this.dtpToDetain = new System.Windows.Forms.DateTimePicker();
            this.pnlMain.SuspendLayout();
            this.pnlReleaseDate.SuspendLayout();
            this.pnlReleaseStatus.SuspendLayout();
            this.pnlDetainDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlReleaseDate);
            this.pnlMain.Controls.Add(this.pnlReleaseStatus);
            this.pnlMain.Controls.Add(this.pnlDetainDate);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(542, 304);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlReleaseDate
            // 
            this.pnlReleaseDate.BackColor = System.Drawing.Color.White;
            this.pnlReleaseDate.Controls.Add(this.ckbReleaseDate);
            this.pnlReleaseDate.Controls.Add(this.lblReleaseFrom);
            this.pnlReleaseDate.Controls.Add(this.dtpFromRelease);
            this.pnlReleaseDate.Controls.Add(this.lblReleaseTo);
            this.pnlReleaseDate.Controls.Add(this.dtpToRelease);
            this.pnlReleaseDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReleaseDate.Location = new System.Drawing.Point(10, 190);
            this.pnlReleaseDate.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlReleaseDate.Name = "pnlReleaseDate";
            this.pnlReleaseDate.Padding = new System.Windows.Forms.Padding(12);
            this.pnlReleaseDate.Size = new System.Drawing.Size(522, 95);
            this.pnlReleaseDate.TabIndex = 0;
            // 
            // ckbReleaseDate
            // 
            this.ckbReleaseDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbReleaseDate.Location = new System.Drawing.Point(10, 8);
            this.ckbReleaseDate.Name = "ckbReleaseDate";
            this.ckbReleaseDate.Size = new System.Drawing.Size(120, 24);
            this.ckbReleaseDate.TabIndex = 0;
            this.ckbReleaseDate.Text = "Release Date";
            // 
            // lblReleaseFrom
            // 
            this.lblReleaseFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReleaseFrom.Location = new System.Drawing.Point(30, 39);
            this.lblReleaseFrom.Name = "lblReleaseFrom";
            this.lblReleaseFrom.Size = new System.Drawing.Size(44, 16);
            this.lblReleaseFrom.TabIndex = 1;
            this.lblReleaseFrom.Text = "From";
            // 
            // dtpFromRelease
            // 
            this.dtpFromRelease.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromRelease.Location = new System.Drawing.Point(80, 38);
            this.dtpFromRelease.Name = "dtpFromRelease";
            this.dtpFromRelease.Size = new System.Drawing.Size(150, 20);
            this.dtpFromRelease.TabIndex = 2;
            // 
            // lblReleaseTo
            // 
            this.lblReleaseTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReleaseTo.Location = new System.Drawing.Point(260, 39);
            this.lblReleaseTo.Name = "lblReleaseTo";
            this.lblReleaseTo.Size = new System.Drawing.Size(24, 18);
            this.lblReleaseTo.TabIndex = 3;
            this.lblReleaseTo.Text = "To";
            // 
            // dtpToRelease
            // 
            this.dtpToRelease.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToRelease.Location = new System.Drawing.Point(290, 36);
            this.dtpToRelease.Name = "dtpToRelease";
            this.dtpToRelease.Size = new System.Drawing.Size(150, 20);
            this.dtpToRelease.TabIndex = 4;
            // 
            // pnlReleaseStatus
            // 
            this.pnlReleaseStatus.BackColor = System.Drawing.Color.White;
            this.pnlReleaseStatus.Controls.Add(this.ckbIsReleased);
            this.pnlReleaseStatus.Controls.Add(this.rbReleasedYes);
            this.pnlReleaseStatus.Controls.Add(this.rbReleasedNo);
            this.pnlReleaseStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReleaseStatus.Location = new System.Drawing.Point(10, 105);
            this.pnlReleaseStatus.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlReleaseStatus.Name = "pnlReleaseStatus";
            this.pnlReleaseStatus.Padding = new System.Windows.Forms.Padding(12);
            this.pnlReleaseStatus.Size = new System.Drawing.Size(522, 85);
            this.pnlReleaseStatus.TabIndex = 1;
            // 
            // ckbIsReleased
            // 
            this.ckbIsReleased.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbIsReleased.Location = new System.Drawing.Point(10, 8);
            this.ckbIsReleased.Name = "ckbIsReleased";
            this.ckbIsReleased.Size = new System.Drawing.Size(120, 24);
            this.ckbIsReleased.TabIndex = 0;
            this.ckbIsReleased.Text = "Release Status";
            // 
            // rbReleasedYes
            // 
            this.rbReleasedYes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbReleasedYes.Location = new System.Drawing.Point(40, 40);
            this.rbReleasedYes.Name = "rbReleasedYes";
            this.rbReleasedYes.Size = new System.Drawing.Size(104, 24);
            this.rbReleasedYes.TabIndex = 1;
            this.rbReleasedYes.Text = "Released";
            // 
            // rbReleasedNo
            // 
            this.rbReleasedNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbReleasedNo.Location = new System.Drawing.Point(160, 40);
            this.rbReleasedNo.Name = "rbReleasedNo";
            this.rbReleasedNo.Size = new System.Drawing.Size(104, 24);
            this.rbReleasedNo.TabIndex = 2;
            this.rbReleasedNo.Text = "Not Released";
            // 
            // pnlDetainDate
            // 
            this.pnlDetainDate.BackColor = System.Drawing.Color.White;
            this.pnlDetainDate.Controls.Add(this.ckbDetainDate);
            this.pnlDetainDate.Controls.Add(this.lblDetainFrom);
            this.pnlDetainDate.Controls.Add(this.dtpFromDetain);
            this.pnlDetainDate.Controls.Add(this.lblDetainTo);
            this.pnlDetainDate.Controls.Add(this.dtpToDetain);
            this.pnlDetainDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetainDate.Location = new System.Drawing.Point(10, 10);
            this.pnlDetainDate.Name = "pnlDetainDate";
            this.pnlDetainDate.Padding = new System.Windows.Forms.Padding(12);
            this.pnlDetainDate.Size = new System.Drawing.Size(522, 95);
            this.pnlDetainDate.TabIndex = 2;
            // 
            // ckbDetainDate
            // 
            this.ckbDetainDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbDetainDate.Location = new System.Drawing.Point(10, 8);
            this.ckbDetainDate.Name = "ckbDetainDate";
            this.ckbDetainDate.Size = new System.Drawing.Size(104, 24);
            this.ckbDetainDate.TabIndex = 0;
            this.ckbDetainDate.Text = "Detain Date";
            // 
            // lblDetainFrom
            // 
            this.lblDetainFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetainFrom.Location = new System.Drawing.Point(30, 41);
            this.lblDetainFrom.Name = "lblDetainFrom";
            this.lblDetainFrom.Size = new System.Drawing.Size(44, 20);
            this.lblDetainFrom.TabIndex = 1;
            this.lblDetainFrom.Text = "From";
            // 
            // dtpFromDetain
            // 
            this.dtpFromDetain.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDetain.Location = new System.Drawing.Point(80, 40);
            this.dtpFromDetain.Name = "dtpFromDetain";
            this.dtpFromDetain.Size = new System.Drawing.Size(150, 20);
            this.dtpFromDetain.TabIndex = 2;
            // 
            // lblDetainTo
            // 
            this.lblDetainTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDetainTo.Location = new System.Drawing.Point(260, 41);
            this.lblDetainTo.Name = "lblDetainTo";
            this.lblDetainTo.Size = new System.Drawing.Size(24, 20);
            this.lblDetainTo.TabIndex = 3;
            this.lblDetainTo.Text = "To";
            // 
            // dtpToDetain
            // 
            this.dtpToDetain.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDetain.Location = new System.Drawing.Point(290, 40);
            this.dtpToDetain.Name = "dtpToDetain";
            this.dtpToDetain.Size = new System.Drawing.Size(150, 20);
            this.dtpToDetain.TabIndex = 4;
            // 
            // ucDetainedLicenseFilter
            // 
            this.Controls.Add(this.pnlMain);
            this.Name = "ucDetainedLicenseFilter";
            this.Size = new System.Drawing.Size(543, 313);
            this.pnlMain.ResumeLayout(false);
            this.pnlReleaseDate.ResumeLayout(false);
            this.pnlReleaseStatus.ResumeLayout(false);
            this.pnlDetainDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
