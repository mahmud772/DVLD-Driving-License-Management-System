namespace DVLDWinForm.Forms.Add_New___Update.Add_New
{
    partial class frmReserveLicense
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
            this.pnlLicenseDetails = new System.Windows.Forms.Panel();
            this.tbPaidFees = new System.Windows.Forms.TextBox();
            this.lbPaidFees_Titel = new System.Windows.Forms.Label();
            this.pbSelectedID = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlLicenseDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLicenseDetails
            // 
            this.pnlLicenseDetails.BackColor = System.Drawing.Color.White;
            this.pnlLicenseDetails.Controls.Add(this.tbPaidFees);
            this.pnlLicenseDetails.Controls.Add(this.lbPaidFees_Titel);
            this.pnlLicenseDetails.Controls.Add(this.pbSelectedID);
            this.pnlLicenseDetails.Controls.Add(this.tbID);
            this.pnlLicenseDetails.Controls.Add(this.lbID);
            this.pnlLicenseDetails.Location = new System.Drawing.Point(12, 34);
            this.pnlLicenseDetails.Name = "pnlLicenseDetails";
            this.pnlLicenseDetails.Size = new System.Drawing.Size(266, 86);
            this.pnlLicenseDetails.TabIndex = 47;
            // 
            // tbPaidFees
            // 
            this.tbPaidFees.Location = new System.Drawing.Point(86, 56);
            this.tbPaidFees.Name = "tbPaidFees";
            this.tbPaidFees.Size = new System.Drawing.Size(114, 20);
            this.tbPaidFees.TabIndex = 50;
            // 
            // lbPaidFees_Titel
            // 
            this.lbPaidFees_Titel.AutoSize = true;
            this.lbPaidFees_Titel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbPaidFees_Titel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPaidFees_Titel.Location = new System.Drawing.Point(5, 56);
            this.lbPaidFees_Titel.Name = "lbPaidFees_Titel";
            this.lbPaidFees_Titel.Size = new System.Drawing.Size(76, 17);
            this.lbPaidFees_Titel.TabIndex = 49;
            this.lbPaidFees_Titel.Text = "PaidFees   :";
            // 
            // pbSelectedID
            // 
            this.pbSelectedID.Image = global::DVLDWinForm.Properties.Resources.Search;
            this.pbSelectedID.Location = new System.Drawing.Point(224, 10);
            this.pbSelectedID.Name = "pbSelectedID";
            this.pbSelectedID.Size = new System.Drawing.Size(26, 24);
            this.pbSelectedID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedID.TabIndex = 45;
            this.pbSelectedID.TabStop = false;
            this.pbSelectedID.Click += new System.EventHandler(this.pbSelectedID_Click);
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(86, 10);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(114, 28);
            this.tbID.TabIndex = 5;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbID.Location = new System.Drawing.Point(6, 15);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(75, 17);
            this.lbID.TabIndex = 1;
            this.lbID.Text = "License ID :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(98, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 46;
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
            this.lbTitel.Location = new System.Drawing.Point(68, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(144, 21);
            this.lbTitel.TabIndex = 45;
            this.lbTitel.Text = "RESERVE LICENSE";
            // 
            // frmReserveLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(289, 162);
            this.Controls.Add(this.pnlLicenseDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmReserveLicense";
            this.ShowIcon = false;
            this.Text = "Reserve License";
            this.Load += new System.EventHandler(this.frmReserveLicense_Load);
            this.pnlLicenseDetails.ResumeLayout(false);
            this.pnlLicenseDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLicenseDetails;
        private System.Windows.Forms.TextBox tbPaidFees;
        private System.Windows.Forms.Label lbPaidFees_Titel;
        private System.Windows.Forms.PictureBox pbSelectedID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
    }
}