namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucApplicationsFilter
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
            this.cbApplicationStatus = new System.Windows.Forms.ComboBox();
            this.cbApplicationType = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lbFromApplicationDate = new System.Windows.Forms.Label();
            this.lbToApplicationDate = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.ckbApplicationType = new System.Windows.Forms.CheckBox();
            this.ckbApplicationStatus = new System.Windows.Forms.CheckBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.pnlFromToDate = new System.Windows.Forms.Panel();
            this.ckbApplicationDate = new System.Windows.Forms.CheckBox();
            this.pnlStatus.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlFromToDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbApplicationStatus
            // 
            this.cbApplicationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplicationStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApplicationStatus.FormattingEnabled = true;
            this.cbApplicationStatus.Location = new System.Drawing.Point(171, 12);
            this.cbApplicationStatus.Name = "cbApplicationStatus";
            this.cbApplicationStatus.Size = new System.Drawing.Size(128, 23);
            this.cbApplicationStatus.TabIndex = 0;
            // 
            // cbApplicationType
            // 
            this.cbApplicationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplicationType.DropDownWidth = 250;
            this.cbApplicationType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApplicationType.FormattingEnabled = true;
            this.cbApplicationType.Location = new System.Drawing.Point(171, 52);
            this.cbApplicationType.Name = "cbApplicationType";
            this.cbApplicationType.Size = new System.Drawing.Size(128, 23);
            this.cbApplicationType.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(58, 9);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(103, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(58, 41);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(103, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lbFromApplicationDate
            // 
            this.lbFromApplicationDate.AutoSize = true;
            this.lbFromApplicationDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFromApplicationDate.Location = new System.Drawing.Point(16, 9);
            this.lbFromApplicationDate.Name = "lbFromApplicationDate";
            this.lbFromApplicationDate.Size = new System.Drawing.Size(35, 15);
            this.lbFromApplicationDate.TabIndex = 6;
            this.lbFromApplicationDate.Text = "From";
            // 
            // lbToApplicationDate
            // 
            this.lbToApplicationDate.AutoSize = true;
            this.lbToApplicationDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToApplicationDate.Location = new System.Drawing.Point(16, 41);
            this.lbToApplicationDate.Name = "lbToApplicationDate";
            this.lbToApplicationDate.Size = new System.Drawing.Size(20, 15);
            this.lbToApplicationDate.TabIndex = 7;
            this.lbToApplicationDate.Text = "To";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.White;
            this.pnlStatus.Controls.Add(this.ckbApplicationType);
            this.pnlStatus.Controls.Add(this.ckbApplicationStatus);
            this.pnlStatus.Controls.Add(this.cbApplicationStatus);
            this.pnlStatus.Controls.Add(this.cbApplicationType);
            this.pnlStatus.Location = new System.Drawing.Point(11, 9);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(308, 86);
            this.pnlStatus.TabIndex = 8;
            // 
            // ckbApplicationType
            // 
            this.ckbApplicationType.AutoSize = true;
            this.ckbApplicationType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ckbApplicationType.Location = new System.Drawing.Point(12, 52);
            this.ckbApplicationType.Name = "ckbApplicationType";
            this.ckbApplicationType.Size = new System.Drawing.Size(148, 19);
            this.ckbApplicationType.TabIndex = 7;
            this.ckbApplicationType.Text = "Application Type          :";
            this.ckbApplicationType.UseVisualStyleBackColor = true;
            // 
            // ckbApplicationStatus
            // 
            this.ckbApplicationStatus.AutoSize = true;
            this.ckbApplicationStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ckbApplicationStatus.Location = new System.Drawing.Point(12, 12);
            this.ckbApplicationStatus.Name = "ckbApplicationStatus";
            this.ckbApplicationStatus.Size = new System.Drawing.Size(150, 19);
            this.ckbApplicationStatus.TabIndex = 6;
            this.ckbApplicationStatus.Text = "Application Status        :";
            this.ckbApplicationStatus.UseVisualStyleBackColor = true;
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.White;
            this.pnlDate.Controls.Add(this.pnlFromToDate);
            this.pnlDate.Controls.Add(this.ckbApplicationDate);
            this.pnlDate.Location = new System.Drawing.Point(11, 102);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(308, 104);
            this.pnlDate.TabIndex = 9;
            // 
            // pnlFromToDate
            // 
            this.pnlFromToDate.BackColor = System.Drawing.Color.White;
            this.pnlFromToDate.Controls.Add(this.dtpFrom);
            this.pnlFromToDate.Controls.Add(this.lbFromApplicationDate);
            this.pnlFromToDate.Controls.Add(this.dtpTo);
            this.pnlFromToDate.Controls.Add(this.lbToApplicationDate);
            this.pnlFromToDate.Location = new System.Drawing.Point(104, 27);
            this.pnlFromToDate.Name = "pnlFromToDate";
            this.pnlFromToDate.Size = new System.Drawing.Size(173, 70);
            this.pnlFromToDate.TabIndex = 9;
            // 
            // ckbApplicationDate
            // 
            this.ckbApplicationDate.AutoSize = true;
            this.ckbApplicationDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.ckbApplicationDate.Location = new System.Drawing.Point(13, 7);
            this.ckbApplicationDate.Name = "ckbApplicationDate";
            this.ckbApplicationDate.Size = new System.Drawing.Size(121, 19);
            this.ckbApplicationDate.TabIndex = 8;
            this.ckbApplicationDate.Text = "Application Date :";
            this.ckbApplicationDate.UseVisualStyleBackColor = true;
            this.ckbApplicationDate.CheckedChanged += new System.EventHandler(this.ckbApplicationDate_CheckedChanged);
            // 
            // ucApplicationsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.pnlStatus);
            this.Name = "ucApplicationsFilter";
            this.Size = new System.Drawing.Size(324, 214);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.pnlFromToDate.ResumeLayout(false);
            this.pnlFromToDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbApplicationStatus;
        private System.Windows.Forms.ComboBox cbApplicationType;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lbFromApplicationDate;
        private System.Windows.Forms.Label lbToApplicationDate;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.CheckBox ckbApplicationType;
        private System.Windows.Forms.CheckBox ckbApplicationStatus;
        private System.Windows.Forms.CheckBox ckbApplicationDate;
        private System.Windows.Forms.Panel pnlFromToDate;
    }
}
