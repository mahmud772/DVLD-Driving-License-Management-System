namespace DVLDWinForm.Forms.Add_New___Update.Add_New
{
    partial class frmAddNewTest
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
            this.pnlTest = new System.Windows.Forms.Panel();
            this.pbSelectedID = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lbTestAppointmentID_Title = new System.Windows.Forms.Label();
            this.rbPassed = new System.Windows.Forms.RadioButton();
            this.rbFailed = new System.Windows.Forms.RadioButton();
            this.lbTestResult_Titel = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTest
            // 
            this.pnlTest.BackColor = System.Drawing.Color.White;
            this.pnlTest.Controls.Add(this.pbSelectedID);
            this.pnlTest.Controls.Add(this.tbID);
            this.pnlTest.Controls.Add(this.lbTestAppointmentID_Title);
            this.pnlTest.Controls.Add(this.rbPassed);
            this.pnlTest.Controls.Add(this.rbFailed);
            this.pnlTest.Controls.Add(this.lbTestResult_Titel);
            this.pnlTest.Controls.Add(this.tbNotes);
            this.pnlTest.Controls.Add(this.lbID);
            this.pnlTest.Location = new System.Drawing.Point(10, 33);
            this.pnlTest.Name = "pnlTest";
            this.pnlTest.Size = new System.Drawing.Size(319, 137);
            this.pnlTest.TabIndex = 50;
            // 
            // pbSelectedID
            // 
            this.pbSelectedID.Image = global::DVLDWinForm.Properties.Resources.Search;
            this.pbSelectedID.Location = new System.Drawing.Point(277, 9);
            this.pbSelectedID.Name = "pbSelectedID";
            this.pbSelectedID.Size = new System.Drawing.Size(26, 24);
            this.pbSelectedID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedID.TabIndex = 48;
            this.pbSelectedID.TabStop = false;
            this.pbSelectedID.Click += new System.EventHandler(this.pbSelectedID_Click);
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(147, 8);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(114, 28);
            this.tbID.TabIndex = 47;
            // 
            // lbTestAppointmentID_Title
            // 
            this.lbTestAppointmentID_Title.AutoSize = true;
            this.lbTestAppointmentID_Title.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTestAppointmentID_Title.Location = new System.Drawing.Point(4, 13);
            this.lbTestAppointmentID_Title.Name = "lbTestAppointmentID_Title";
            this.lbTestAppointmentID_Title.Size = new System.Drawing.Size(145, 17);
            this.lbTestAppointmentID_Title.TabIndex = 46;
            this.lbTestAppointmentID_Title.Text = "Test Appointment ID  :";
            // 
            // rbPassed
            // 
            this.rbPassed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbPassed.Location = new System.Drawing.Point(117, 41);
            this.rbPassed.Name = "rbPassed";
            this.rbPassed.Size = new System.Drawing.Size(77, 24);
            this.rbPassed.TabIndex = 1;
            this.rbPassed.Text = "Passed";
            // 
            // rbFailed
            // 
            this.rbFailed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFailed.Location = new System.Drawing.Point(224, 41);
            this.rbFailed.Name = "rbFailed";
            this.rbFailed.Size = new System.Drawing.Size(65, 24);
            this.rbFailed.TabIndex = 2;
            this.rbFailed.Text = "Failed";
            // 
            // lbTestResult_Titel
            // 
            this.lbTestResult_Titel.AutoSize = true;
            this.lbTestResult_Titel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbTestResult_Titel.Location = new System.Drawing.Point(4, 43);
            this.lbTestResult_Titel.Name = "lbTestResult_Titel";
            this.lbTestResult_Titel.Size = new System.Drawing.Size(84, 17);
            this.lbTestResult_Titel.TabIndex = 12;
            this.lbTestResult_Titel.Text = "Test Result  :";
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(3, 87);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(313, 46);
            this.tbNotes.TabIndex = 5;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbID.Location = new System.Drawing.Point(3, 67);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(55, 17);
            this.lbID.TabIndex = 1;
            this.lbID.Text = "Notes  :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(125, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbTitel
            // 
            this.lbTitel.AutoSize = true;
            this.lbTitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.lbTitel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTitel.Location = new System.Drawing.Point(70, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(187, 21);
            this.lbTitel.TabIndex = 48;
            this.lbTitel.Text = "ADD NEW TEST RESULT";
            // 
            // frmAddNewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(336, 213);
            this.Controls.Add(this.pnlTest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmAddNewTest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewTest";
            this.Load += new System.EventHandler(this.frmAddNewTest_Load);
            this.pnlTest.ResumeLayout(false);
            this.pnlTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTest;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.RadioButton rbPassed;
        private System.Windows.Forms.RadioButton rbFailed;
        private System.Windows.Forms.Label lbTestResult_Titel;
        private System.Windows.Forms.PictureBox pbSelectedID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lbTestAppointmentID_Title;
    }
}