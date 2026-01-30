namespace DVLDWinForm.Forms
{
    partial class frmFind
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
            this.pnlFind = new System.Windows.Forms.Panel();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.tbFindBy = new System.Windows.Forms.TextBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlFind.Controls.Add(this.cbFindBy);
            this.pnlFind.Controls.Add(this.tbFindBy);
            this.pnlFind.Controls.Add(this.pbSearch);
            this.pnlFind.Location = new System.Drawing.Point(12, 12);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(225, 40);
            this.pnlFind.TabIndex = 2;
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Location = new System.Drawing.Point(164, 9);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(15, 21);
            this.cbFindBy.TabIndex = 2;
            // 
            // tbFindBy
            // 
            this.tbFindBy.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFindBy.Location = new System.Drawing.Point(20, 8);
            this.tbFindBy.Name = "tbFindBy";
            this.tbFindBy.Size = new System.Drawing.Size(147, 22);
            this.tbFindBy.TabIndex = 47;
            // 
            // pbSearch
            // 
            this.pbSearch.Image = global::DVLDWinForm.Properties.Resources.Search;
            this.pbSearch.Location = new System.Drawing.Point(184, 8);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(22, 22);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 46;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Location = new System.Drawing.Point(12, 68);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(448, 217);
            this.pnlContainer.TabIndex = 3;
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 316);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlFind);
            this.Name = "frmFind";
            this.Text = "frmFind";
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFind;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.TextBox tbFindBy;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Panel pnlContainer;
    }
}