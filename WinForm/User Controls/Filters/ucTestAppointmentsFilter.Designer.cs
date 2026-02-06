using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucTestAppointmentsFilter
    {
        private System.ComponentModel.IContainer components = null;

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
            this.ckbTestType = new System.Windows.Forms.CheckBox();
            this.cbTestType = new System.Windows.Forms.ComboBox();
            this.ckbAppointmentDate = new System.Windows.Forms.CheckBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.ckbIsLocked = new System.Windows.Forms.CheckBox();
            this.rbLocked = new System.Windows.Forms.RadioButton();
            this.rbNotLocked = new System.Windows.Forms.RadioButton();
            this.ckbTestResult = new System.Windows.Forms.CheckBox();
            this.rbPassed = new System.Windows.Forms.RadioButton();
            this.rbFailed = new System.Windows.Forms.RadioButton();
            this.pnlAppiontmentDate = new System.Windows.Forms.Panel();
            this.pnlTestType = new System.Windows.Forms.Panel();
            this.pnlLockStatus = new System.Windows.Forms.Panel();
            this.pnlTestResult = new System.Windows.Forms.Panel();
            this.pnlAppiontmentDate.SuspendLayout();
            this.pnlTestType.SuspendLayout();
            this.pnlLockStatus.SuspendLayout();
            this.pnlTestResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbTestType
            // 
            this.ckbTestType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbTestType.Location = new System.Drawing.Point(6, 3);
            this.ckbTestType.Name = "ckbTestType";
            this.ckbTestType.Size = new System.Drawing.Size(104, 22);
            this.ckbTestType.TabIndex = 0;
            this.ckbTestType.Text = "Test Type";
            // 
            // cbTestType
            // 
            this.cbTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestType.Location = new System.Drawing.Point(6, 30);
            this.cbTestType.Name = "cbTestType";
            this.cbTestType.Size = new System.Drawing.Size(161, 21);
            this.cbTestType.TabIndex = 1;
            // 
            // ckbAppointmentDate
            // 
            this.ckbAppointmentDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbAppointmentDate.Location = new System.Drawing.Point(3, 3);
            this.ckbAppointmentDate.Name = "ckbAppointmentDate";
            this.ckbAppointmentDate.Size = new System.Drawing.Size(137, 22);
            this.ckbAppointmentDate.TabIndex = 0;
            this.ckbAppointmentDate.Text = "Appointment Date";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Location = new System.Drawing.Point(13, 31);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(34, 23);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "From";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(53, 31);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // lblToDate
            // 
            this.lblToDate.Location = new System.Drawing.Point(13, 58);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(24, 19);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "To";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(53, 57);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(110, 20);
            this.dtpToDate.TabIndex = 4;
            // 
            // ckbIsLocked
            // 
            this.ckbIsLocked.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbIsLocked.Location = new System.Drawing.Point(6, 3);
            this.ckbIsLocked.Name = "ckbIsLocked";
            this.ckbIsLocked.Size = new System.Drawing.Size(104, 22);
            this.ckbIsLocked.TabIndex = 0;
            this.ckbIsLocked.Text = "Lock Status";
            // 
            // rbLocked
            // 
            this.rbLocked.Location = new System.Drawing.Point(22, 30);
            this.rbLocked.Name = "rbLocked";
            this.rbLocked.Size = new System.Drawing.Size(77, 24);
            this.rbLocked.TabIndex = 1;
            this.rbLocked.Text = "Locked";
            // 
            // rbNotLocked
            // 
            this.rbNotLocked.Location = new System.Drawing.Point(105, 30);
            this.rbNotLocked.Name = "rbNotLocked";
            this.rbNotLocked.Size = new System.Drawing.Size(78, 24);
            this.rbNotLocked.TabIndex = 2;
            this.rbNotLocked.Text = "Not Locked";
            // 
            // ckbTestResult
            // 
            this.ckbTestResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ckbTestResult.Location = new System.Drawing.Point(3, 3);
            this.ckbTestResult.Name = "ckbTestResult";
            this.ckbTestResult.Size = new System.Drawing.Size(104, 22);
            this.ckbTestResult.TabIndex = 0;
            this.ckbTestResult.Text = "Test Result";
            // 
            // rbPassed
            // 
            this.rbPassed.Location = new System.Drawing.Point(18, 30);
            this.rbPassed.Name = "rbPassed";
            this.rbPassed.Size = new System.Drawing.Size(71, 24);
            this.rbPassed.TabIndex = 1;
            this.rbPassed.Text = "Passed";
            // 
            // rbFailed
            // 
            this.rbFailed.Location = new System.Drawing.Point(95, 30);
            this.rbFailed.Name = "rbFailed";
            this.rbFailed.Size = new System.Drawing.Size(70, 24);
            this.rbFailed.TabIndex = 2;
            this.rbFailed.Text = "Failed";
            // 
            // pnlAppiontmentDate
            // 
            this.pnlAppiontmentDate.BackColor = System.Drawing.Color.White;
            this.pnlAppiontmentDate.Controls.Add(this.ckbAppointmentDate);
            this.pnlAppiontmentDate.Controls.Add(this.lblFromDate);
            this.pnlAppiontmentDate.Controls.Add(this.dtpToDate);
            this.pnlAppiontmentDate.Controls.Add(this.dtpFromDate);
            this.pnlAppiontmentDate.Controls.Add(this.lblToDate);
            this.pnlAppiontmentDate.Location = new System.Drawing.Point(215, 10);
            this.pnlAppiontmentDate.Name = "pnlAppiontmentDate";
            this.pnlAppiontmentDate.Size = new System.Drawing.Size(199, 90);
            this.pnlAppiontmentDate.TabIndex = 4;
            // 
            // pnlTestType
            // 
            this.pnlTestType.BackColor = System.Drawing.Color.White;
            this.pnlTestType.Controls.Add(this.ckbTestType);
            this.pnlTestType.Controls.Add(this.cbTestType);
            this.pnlTestType.Location = new System.Drawing.Point(10, 10);
            this.pnlTestType.Name = "pnlTestType";
            this.pnlTestType.Size = new System.Drawing.Size(199, 90);
            this.pnlTestType.TabIndex = 5;
            // 
            // pnlLockStatus
            // 
            this.pnlLockStatus.BackColor = System.Drawing.Color.White;
            this.pnlLockStatus.Controls.Add(this.ckbIsLocked);
            this.pnlLockStatus.Controls.Add(this.rbLocked);
            this.pnlLockStatus.Controls.Add(this.rbNotLocked);
            this.pnlLockStatus.Location = new System.Drawing.Point(10, 106);
            this.pnlLockStatus.Name = "pnlLockStatus";
            this.pnlLockStatus.Size = new System.Drawing.Size(199, 65);
            this.pnlLockStatus.TabIndex = 6;
            // 
            // pnlTestResult
            // 
            this.pnlTestResult.BackColor = System.Drawing.Color.White;
            this.pnlTestResult.Controls.Add(this.ckbTestResult);
            this.pnlTestResult.Controls.Add(this.rbPassed);
            this.pnlTestResult.Controls.Add(this.rbFailed);
            this.pnlTestResult.Location = new System.Drawing.Point(215, 106);
            this.pnlTestResult.Name = "pnlTestResult";
            this.pnlTestResult.Size = new System.Drawing.Size(199, 65);
            this.pnlTestResult.TabIndex = 7;
            // 
            // ucTestAppointmentFilter
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlTestResult);
            this.Controls.Add(this.pnlLockStatus);
            this.Controls.Add(this.pnlTestType);
            this.Controls.Add(this.pnlAppiontmentDate);
            this.Name = "ucTestAppointmentFilter";
            this.Size = new System.Drawing.Size(421, 180);
            this.pnlAppiontmentDate.ResumeLayout(false);
            this.pnlTestType.ResumeLayout(false);
            this.pnlLockStatus.ResumeLayout(false);
            this.pnlTestResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Panel pnlAppiontmentDate;
        private Panel pnlTestType;
        private Panel pnlLockStatus;
        private Panel pnlTestResult;
    }
}
