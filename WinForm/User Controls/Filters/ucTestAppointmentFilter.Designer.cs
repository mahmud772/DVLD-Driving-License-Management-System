using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucTestAppointmentFilter
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox gbTestType;
        private GroupBox gbAppointmentDate;
        private GroupBox gbLockStatus;
        private GroupBox gbTestResult;

        private CheckBox ckbTestType;
        private ComboBox cbTestType;

        private CheckBox ckbAppointmentDate;
        private Label lblFromDate;
        private Label lblToDate;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;

        private CheckBox ckbIsLocked;
        private RadioButton rbLocked;
        private RadioButton rbNotLocked;

        private CheckBox ckbTestResult;
        private RadioButton rbPassed;
        private RadioButton rbFailed;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbTestType = new System.Windows.Forms.GroupBox();
            this.ckbTestType = new System.Windows.Forms.CheckBox();
            this.cbTestType = new System.Windows.Forms.ComboBox();
            this.gbAppointmentDate = new System.Windows.Forms.GroupBox();
            this.ckbAppointmentDate = new System.Windows.Forms.CheckBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.gbLockStatus = new System.Windows.Forms.GroupBox();
            this.ckbIsLocked = new System.Windows.Forms.CheckBox();
            this.rbLocked = new System.Windows.Forms.RadioButton();
            this.rbNotLocked = new System.Windows.Forms.RadioButton();
            this.gbTestResult = new System.Windows.Forms.GroupBox();
            this.ckbTestResult = new System.Windows.Forms.CheckBox();
            this.rbPassed = new System.Windows.Forms.RadioButton();
            this.rbFailed = new System.Windows.Forms.RadioButton();
            this.gbTestType.SuspendLayout();
            this.gbAppointmentDate.SuspendLayout();
            this.gbLockStatus.SuspendLayout();
            this.gbTestResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTestType
            // 
            this.gbTestType.BackColor = System.Drawing.Color.White;
            this.gbTestType.Controls.Add(this.ckbTestType);
            this.gbTestType.Controls.Add(this.cbTestType);
            this.gbTestType.Location = new System.Drawing.Point(10, 10);
            this.gbTestType.Name = "gbTestType";
            this.gbTestType.Size = new System.Drawing.Size(199, 90);
            this.gbTestType.TabIndex = 0;
            this.gbTestType.TabStop = false;
            // 
            // ckbTestType
            // 
            this.ckbTestType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbTestType.Location = new System.Drawing.Point(10, 8);
            this.ckbTestType.Name = "ckbTestType";
            this.ckbTestType.Size = new System.Drawing.Size(104, 22);
            this.ckbTestType.TabIndex = 0;
            this.ckbTestType.Text = "Test Type";
            // 
            // cbTestType
            // 
            this.cbTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestType.Location = new System.Drawing.Point(25, 39);
            this.cbTestType.Name = "cbTestType";
            this.cbTestType.Size = new System.Drawing.Size(161, 21);
            this.cbTestType.TabIndex = 1;
            // 
            // gbAppointmentDate
            // 
            this.gbAppointmentDate.BackColor = System.Drawing.Color.White;
            this.gbAppointmentDate.Controls.Add(this.ckbAppointmentDate);
            this.gbAppointmentDate.Controls.Add(this.lblFromDate);
            this.gbAppointmentDate.Controls.Add(this.dtpFromDate);
            this.gbAppointmentDate.Controls.Add(this.lblToDate);
            this.gbAppointmentDate.Controls.Add(this.dtpToDate);
            this.gbAppointmentDate.Location = new System.Drawing.Point(215, 10);
            this.gbAppointmentDate.Name = "gbAppointmentDate";
            this.gbAppointmentDate.Size = new System.Drawing.Size(199, 90);
            this.gbAppointmentDate.TabIndex = 1;
            this.gbAppointmentDate.TabStop = false;
            // 
            // ckbAppointmentDate
            // 
            this.ckbAppointmentDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbAppointmentDate.Location = new System.Drawing.Point(10, 8);
            this.ckbAppointmentDate.Name = "ckbAppointmentDate";
            this.ckbAppointmentDate.Size = new System.Drawing.Size(104, 22);
            this.ckbAppointmentDate.TabIndex = 0;
            this.ckbAppointmentDate.Text = "Appointment Date";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(20, 36);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(34, 23);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "From";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(60, 36);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // lblToDate
            // 
            this.lblToDate.Location = new System.Drawing.Point(20, 63);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(24, 19);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "To";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(60, 62);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(110, 20);
            this.dtpToDate.TabIndex = 4;
            // 
            // gbLockStatus
            // 
            this.gbLockStatus.BackColor = System.Drawing.Color.White;
            this.gbLockStatus.Controls.Add(this.ckbIsLocked);
            this.gbLockStatus.Controls.Add(this.rbLocked);
            this.gbLockStatus.Controls.Add(this.rbNotLocked);
            this.gbLockStatus.Location = new System.Drawing.Point(10, 100);
            this.gbLockStatus.Name = "gbLockStatus";
            this.gbLockStatus.Size = new System.Drawing.Size(199, 80);
            this.gbLockStatus.TabIndex = 2;
            this.gbLockStatus.TabStop = false;
            // 
            // ckbIsLocked
            // 
            this.ckbIsLocked.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbIsLocked.Location = new System.Drawing.Point(6, 8);
            this.ckbIsLocked.Name = "ckbIsLocked";
            this.ckbIsLocked.Size = new System.Drawing.Size(104, 22);
            this.ckbIsLocked.TabIndex = 0;
            this.ckbIsLocked.Text = "Lock Status";
            // 
            // rbLocked
            // 
            this.rbLocked.Location = new System.Drawing.Point(25, 35);
            this.rbLocked.Name = "rbLocked";
            this.rbLocked.Size = new System.Drawing.Size(77, 24);
            this.rbLocked.TabIndex = 1;
            this.rbLocked.Text = "Locked";
            // 
            // rbNotLocked
            // 
            this.rbNotLocked.Location = new System.Drawing.Point(108, 35);
            this.rbNotLocked.Name = "rbNotLocked";
            this.rbNotLocked.Size = new System.Drawing.Size(78, 24);
            this.rbNotLocked.TabIndex = 2;
            this.rbNotLocked.Text = "Not Locked";
            // 
            // gbTestResult
            // 
            this.gbTestResult.BackColor = System.Drawing.Color.White;
            this.gbTestResult.Controls.Add(this.ckbTestResult);
            this.gbTestResult.Controls.Add(this.rbPassed);
            this.gbTestResult.Controls.Add(this.rbFailed);
            this.gbTestResult.Location = new System.Drawing.Point(215, 100);
            this.gbTestResult.Name = "gbTestResult";
            this.gbTestResult.Size = new System.Drawing.Size(199, 80);
            this.gbTestResult.TabIndex = 3;
            this.gbTestResult.TabStop = false;
            // 
            // ckbTestResult
            // 
            this.ckbTestResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbTestResult.Location = new System.Drawing.Point(10, 8);
            this.ckbTestResult.Name = "ckbTestResult";
            this.ckbTestResult.Size = new System.Drawing.Size(104, 22);
            this.ckbTestResult.TabIndex = 0;
            this.ckbTestResult.Text = "Test Result";
            // 
            // rbPassed
            // 
            this.rbPassed.Location = new System.Drawing.Point(25, 35);
            this.rbPassed.Name = "rbPassed";
            this.rbPassed.Size = new System.Drawing.Size(71, 24);
            this.rbPassed.TabIndex = 1;
            this.rbPassed.Text = "Passed";
            // 
            // rbFailed
            // 
            this.rbFailed.Location = new System.Drawing.Point(102, 35);
            this.rbFailed.Name = "rbFailed";
            this.rbFailed.Size = new System.Drawing.Size(70, 24);
            this.rbFailed.TabIndex = 2;
            this.rbFailed.Text = "Failed";
            // 
            // ucTestAppointmentFilter
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.gbTestType);
            this.Controls.Add(this.gbAppointmentDate);
            this.Controls.Add(this.gbLockStatus);
            this.Controls.Add(this.gbTestResult);
            this.Name = "ucTestAppointmentFilter";
            this.Size = new System.Drawing.Size(423, 196);
            this.gbTestType.ResumeLayout(false);
            this.gbAppointmentDate.ResumeLayout(false);
            this.gbLockStatus.ResumeLayout(false);
            this.gbTestResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
