namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucTestsFilter
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
            this.pnlTestResult = new System.Windows.Forms.Panel();
            this.pnlPassFial = new System.Windows.Forms.Panel();
            this.rbPassedYes = new System.Windows.Forms.RadioButton();
            this.rbFailedNo = new System.Windows.Forms.RadioButton();
            this.ckbTestResult = new System.Windows.Forms.CheckBox();
            this.pnlTestResult.SuspendLayout();
            this.pnlPassFial.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReleaseStatus
            // 
            this.pnlTestResult.BackColor = System.Drawing.Color.White;
            this.pnlTestResult.Controls.Add(this.pnlPassFial);
            this.pnlTestResult.Controls.Add(this.ckbTestResult);
            this.pnlTestResult.Location = new System.Drawing.Point(3, 3);
            this.pnlTestResult.Name = "pnlReleaseStatus";
            this.pnlTestResult.Size = new System.Drawing.Size(256, 78);
            this.pnlTestResult.TabIndex = 10;
            // 
            // pnlReleaseNotRelease
            // 
            this.pnlPassFial.BackColor = System.Drawing.Color.White;
            this.pnlPassFial.Controls.Add(this.rbPassedYes);
            this.pnlPassFial.Controls.Add(this.rbFailedNo);
            this.pnlPassFial.Location = new System.Drawing.Point(25, 33);
            this.pnlPassFial.Name = "pnlReleaseNotRelease";
            this.pnlPassFial.Size = new System.Drawing.Size(221, 38);
            this.pnlPassFial.TabIndex = 10;
            // 
            // rbPassedYes
            // 
            this.rbPassedYes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbPassedYes.Location = new System.Drawing.Point(12, 7);
            this.rbPassedYes.Name = "rbPassedYes";
            this.rbPassedYes.Size = new System.Drawing.Size(77, 24);
            this.rbPassedYes.TabIndex = 1;
            this.rbPassedYes.Text = "Passed";
            // 
            // rbFailedNo
            // 
            this.rbFailedNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFailedNo.Location = new System.Drawing.Point(119, 7);
            this.rbFailedNo.Name = "rbFailedNo";
            this.rbFailedNo.Size = new System.Drawing.Size(97, 24);
            this.rbFailedNo.TabIndex = 2;
            this.rbFailedNo.Text = "Fialed";
            // 
            // ckbIsTestResult
            // 
            this.ckbTestResult.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.ckbTestResult.Location = new System.Drawing.Point(6, 3);
            this.ckbTestResult.Name = "ckbIsTestResult";
            this.ckbTestResult.Size = new System.Drawing.Size(120, 24);
            this.ckbTestResult.TabIndex = 0;
            this.ckbTestResult.Text = "Test Result";
            // 
            // ucTestsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlTestResult);
            this.Name = "ucTestsFilter";
            this.Size = new System.Drawing.Size(263, 85);
            this.pnlTestResult.ResumeLayout(false);
            this.pnlPassFial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTestResult;
        private System.Windows.Forms.Panel pnlPassFial;
        private System.Windows.Forms.RadioButton rbPassedYes;
        private System.Windows.Forms.RadioButton rbFailedNo;
        private System.Windows.Forms.CheckBox ckbTestResult;
    }
}
