namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    partial class frmReleaseLicense
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
            this.pnlLicense = new System.Windows.Forms.Panel();
            this.lbPaidFees = new System.Windows.Forms.Label();
            this.lbPaidFees_Titel = new System.Windows.Forms.Label();
            this.pbSelectedID = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLicense
            // 
            this.pnlLicense.BackColor = System.Drawing.Color.White;
            this.pnlLicense.Controls.Add(this.lbPaidFees);
            this.pnlLicense.Controls.Add(this.lbPaidFees_Titel);
            this.pnlLicense.Controls.Add(this.pbSelectedID);
            this.pnlLicense.Controls.Add(this.tbID);
            this.pnlLicense.Controls.Add(this.lbID);
            this.pnlLicense.Location = new System.Drawing.Point(3, 42);
            this.pnlLicense.Name = "pnlLicense";
            this.pnlLicense.Size = new System.Drawing.Size(330, 64);
            this.pnlLicense.TabIndex = 59;
            // 
            // lbPaidFees
            // 
            this.lbPaidFees.AutoSize = true;
            this.lbPaidFees.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbPaidFees.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPaidFees.Location = new System.Drawing.Point(124, 40);
            this.lbPaidFees.Name = "lbPaidFees";
            this.lbPaidFees.Size = new System.Drawing.Size(15, 17);
            this.lbPaidFees.TabIndex = 55;
            this.lbPaidFees.Text = "0";
            // 
            // lbPaidFees_Titel
            // 
            this.lbPaidFees_Titel.AutoSize = true;
            this.lbPaidFees_Titel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbPaidFees_Titel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPaidFees_Titel.Location = new System.Drawing.Point(4, 39);
            this.lbPaidFees_Titel.Name = "lbPaidFees_Titel";
            this.lbPaidFees_Titel.Size = new System.Drawing.Size(108, 17);
            this.lbPaidFees_Titel.TabIndex = 54;
            this.lbPaidFees_Titel.Text = "PaidFees           :";
            // 
            // pbSelectedID
            // 
            this.pbSelectedID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectedID.Image = global::DVLDWinForm.Properties.Resources.Search;
            this.pbSelectedID.Location = new System.Drawing.Point(287, 6);
            this.pbSelectedID.Name = "pbSelectedID";
            this.pbSelectedID.Size = new System.Drawing.Size(30, 30);
            this.pbSelectedID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedID.TabIndex = 53;
            this.pbSelectedID.TabStop = false;
            this.pbSelectedID.Click += new System.EventHandler(this.pbSelectedID_Click);
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(122, 8);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(114, 28);
            this.tbID.TabIndex = 52;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbID.Location = new System.Drawing.Point(4, 13);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(108, 17);
            this.lbID.TabIndex = 51;
            this.lbID.Text = "Application ID   :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(125, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 58;
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
            this.lbTitel.Location = new System.Drawing.Point(99, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(142, 21);
            this.lbTitel.TabIndex = 57;
            this.lbTitel.Text = "RELEASE LICENSE";
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(342, 148);
            this.Controls.Add(this.pnlLicense);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "frmReleaseLicense";
            this.ShowIcon = false;
            this.Text = "Release License";
            this.Load += new System.EventHandler(this.frmReleaseLicense_Load);
            this.pnlLicense.ResumeLayout(false);
            this.pnlLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLicense;
        private System.Windows.Forms.PictureBox pbSelectedID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label lbPaidFees;
        private System.Windows.Forms.Label lbPaidFees_Titel;
    }
}