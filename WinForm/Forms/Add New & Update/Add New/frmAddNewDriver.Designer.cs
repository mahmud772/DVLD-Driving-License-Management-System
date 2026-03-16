namespace DVLDWinForm.Forms
{
    partial class frmAddNewDriver
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
            this.pnlDriver = new System.Windows.Forms.Panel();
            this.pbSelectedID = new System.Windows.Forms.PictureBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTitel = new System.Windows.Forms.Label();
            this.pnlDriver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDriver
            // 
            this.pnlDriver.BackColor = System.Drawing.Color.White;
            this.pnlDriver.Controls.Add(this.pbSelectedID);
            this.pnlDriver.Controls.Add(this.tbID);
            this.pnlDriver.Controls.Add(this.lbID);
            this.pnlDriver.Location = new System.Drawing.Point(13, 42);
            this.pnlDriver.Name = "pnlDriver";
            this.pnlDriver.Size = new System.Drawing.Size(330, 53);
            this.pnlDriver.TabIndex = 56;
            // 
            // pbSelectedID
            // 
            this.pbSelectedID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectedID.Image = global::DVLDWinForm.Properties.Resources.Search;
            this.pbSelectedID.Location = new System.Drawing.Point(291, 10);
            this.pbSelectedID.Name = "pbSelectedID";
            this.pbSelectedID.Size = new System.Drawing.Size(26, 24);
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
            this.lbID.Size = new System.Drawing.Size(110, 17);
            this.lbID.TabIndex = 51;
            this.lbID.Text = "Person ID          :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(135, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 33);
            this.btnSave.TabIndex = 55;
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
            this.lbTitel.Location = new System.Drawing.Point(109, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(148, 21);
            this.lbTitel.TabIndex = 54;
            this.lbTitel.Text = "ADD NEW DRIVER";
            // 
            // frmAddNewDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(351, 139);
            this.Controls.Add(this.pnlDriver);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTitel);
            this.Name = "frmAddNewDriver";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD NEW";
            this.Load += new System.EventHandler(this.frmAddNew_UpdateDriver_Load);
            this.pnlDriver.ResumeLayout(false);
            this.pnlDriver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDriver;
        private System.Windows.Forms.PictureBox pbSelectedID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTitel;
    }
}