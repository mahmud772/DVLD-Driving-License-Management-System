namespace DVLDWinForm.User_Controls.Display
{
    partial class ucTest
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
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lbNotes_Titel = new System.Windows.Forms.Label();
            this.lbTestResult_Titel = new System.Windows.Forms.Label();
            this.btnUpdate_Delete = new System.Windows.Forms.Button();
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.lbNotes = new System.Windows.Forms.Label();
            this.pnlIDs = new System.Windows.Forms.Panel();
            this.lbAppointmentID_Titel = new System.Windows.Forms.Label();
            this.lbTestID_Title = new System.Windows.Forms.Label();
            this.lbTestID = new System.Windows.Forms.Label();
            this.lbAppointmentID = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.pnlInfo.SuspendLayout();
            this.pnlNotes.SuspendLayout();
            this.pnlIDs.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lbResult);
            this.pnlInfo.Controls.Add(this.pnlNotes);
            this.pnlInfo.Controls.Add(this.lbNotes_Titel);
            this.pnlInfo.Controls.Add(this.lbTestResult_Titel);
            this.pnlInfo.Location = new System.Drawing.Point(7, 27);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(366, 124);
            this.pnlInfo.TabIndex = 65;
            // 
            // lbNotes_Titel
            // 
            this.lbNotes_Titel.AutoSize = true;
            this.lbNotes_Titel.Font = new System.Drawing.Font("Segoe UI Variable Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes_Titel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbNotes_Titel.Location = new System.Drawing.Point(7, 42);
            this.lbNotes_Titel.Name = "lbNotes_Titel";
            this.lbNotes_Titel.Size = new System.Drawing.Size(62, 21);
            this.lbNotes_Titel.TabIndex = 25;
            this.lbNotes_Titel.Text = "Notes :";
            // 
            // lbTestResult_Titel
            // 
            this.lbTestResult_Titel.AutoSize = true;
            this.lbTestResult_Titel.Font = new System.Drawing.Font("Segoe UI Variable Small", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestResult_Titel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbTestResult_Titel.Location = new System.Drawing.Point(6, 11);
            this.lbTestResult_Titel.Name = "lbTestResult_Titel";
            this.lbTestResult_Titel.Size = new System.Drawing.Size(96, 21);
            this.lbTestResult_Titel.TabIndex = 11;
            this.lbTestResult_Titel.Text = "Test Result :";
            // 
            // btnUpdate_Delete
            // 
            this.btnUpdate_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdate_Delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnUpdate_Delete.FlatAppearance.BorderSize = 0;
            this.btnUpdate_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnUpdate_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnUpdate_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_Delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_Delete.Location = new System.Drawing.Point(9, 0);
            this.btnUpdate_Delete.Name = "btnUpdate_Delete";
            this.btnUpdate_Delete.Size = new System.Drawing.Size(30, 25);
            this.btnUpdate_Delete.TabIndex = 66;
            this.btnUpdate_Delete.Text = ". . .";
            this.btnUpdate_Delete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdate_Delete.UseVisualStyleBackColor = true;
            this.btnUpdate_Delete.Click += new System.EventHandler(this.btnUpdate_Delete_Click);
            // 
            // pnlNotes
            // 
            this.pnlNotes.BackColor = System.Drawing.Color.LightGray;
            this.pnlNotes.Controls.Add(this.lbNotes);
            this.pnlNotes.Location = new System.Drawing.Point(2, 72);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Size = new System.Drawing.Size(364, 52);
            this.pnlNotes.TabIndex = 67;
            // 
            // lbNotes
            // 
            this.lbNotes.AutoSize = true;
            this.lbNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes.ForeColor = System.Drawing.Color.Black;
            this.lbNotes.Location = new System.Drawing.Point(6, 6);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(136, 17);
            this.lbNotes.TabIndex = 53;
            this.lbNotes.Text = "Notes And Conditions";
            // 
            // pnlIDs
            // 
            this.pnlIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.pnlIDs.Controls.Add(this.lbAppointmentID_Titel);
            this.pnlIDs.Controls.Add(this.lbTestID_Title);
            this.pnlIDs.Controls.Add(this.lbTestID);
            this.pnlIDs.Controls.Add(this.lbAppointmentID);
            this.pnlIDs.Location = new System.Drawing.Point(0, 151);
            this.pnlIDs.Name = "pnlIDs";
            this.pnlIDs.Size = new System.Drawing.Size(381, 33);
            this.pnlIDs.TabIndex = 68;
            // 
            // lbAppointmentID_Titel
            // 
            this.lbAppointmentID_Titel.AutoSize = true;
            this.lbAppointmentID_Titel.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentID_Titel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbAppointmentID_Titel.Location = new System.Drawing.Point(179, 8);
            this.lbAppointmentID_Titel.Name = "lbAppointmentID_Titel";
            this.lbAppointmentID_Titel.Size = new System.Drawing.Size(108, 17);
            this.lbAppointmentID_Titel.TabIndex = 25;
            this.lbAppointmentID_Titel.Text = "Appointment ID :";
            // 
            // lbTestID_Title
            // 
            this.lbTestID_Title.AutoSize = true;
            this.lbTestID_Title.Font = new System.Drawing.Font("Segoe UI Variable Small Semilig", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestID_Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.lbTestID_Title.Location = new System.Drawing.Point(12, 8);
            this.lbTestID_Title.Name = "lbTestID_Title";
            this.lbTestID_Title.Size = new System.Drawing.Size(58, 17);
            this.lbTestID_Title.TabIndex = 24;
            this.lbTestID_Title.Text = "Test ID : ";
            // 
            // lbTestID
            // 
            this.lbTestID.AutoSize = true;
            this.lbTestID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbTestID.Location = new System.Drawing.Point(70, 10);
            this.lbTestID.Name = "lbTestID";
            this.lbTestID.Size = new System.Drawing.Size(65, 15);
            this.lbTestID.TabIndex = 10;
            this.lbTestID.Text = "1234567890";
            // 
            // lbAppointmentID
            // 
            this.lbAppointmentID.AutoSize = true;
            this.lbAppointmentID.Font = new System.Drawing.Font("Segoe UI Variable Text Semiligh", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppointmentID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbAppointmentID.Location = new System.Drawing.Point(288, 10);
            this.lbAppointmentID.Name = "lbAppointmentID";
            this.lbAppointmentID.Size = new System.Drawing.Size(87, 15);
            this.lbAppointmentID.TabIndex = 1;
            this.lbAppointmentID.Text = "12001234567890";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lbResult.Location = new System.Drawing.Point(106, 11);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(64, 21);
            this.lbResult.TabIndex = 68;
            this.lbResult.Text = "RESULT";
            // 
            // ucTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlIDs);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnUpdate_Delete);
            this.Name = "ucTest";
            this.Size = new System.Drawing.Size(380, 183);
            this.Load += new System.EventHandler(this.ucTest_Load);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlNotes.ResumeLayout(false);
            this.pnlNotes.PerformLayout();
            this.pnlIDs.ResumeLayout(false);
            this.pnlIDs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lbNotes_Titel;
        private System.Windows.Forms.Label lbTestResult_Titel;
        private System.Windows.Forms.Button btnUpdate_Delete;
        private System.Windows.Forms.Panel pnlNotes;
        private System.Windows.Forms.Label lbNotes;
        private System.Windows.Forms.Panel pnlIDs;
        private System.Windows.Forms.Label lbAppointmentID_Titel;
        private System.Windows.Forms.Label lbTestID_Title;
        private System.Windows.Forms.Label lbTestID;
        private System.Windows.Forms.Label lbAppointmentID;
        private System.Windows.Forms.Label lbResult;
    }
}
