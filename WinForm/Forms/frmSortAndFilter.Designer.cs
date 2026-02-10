namespace DVLDWinForm.Forms
{
    partial class frmSortAndFilter
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlSort = new System.Windows.Forms.Panel();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.lbSortByTitel = new System.Windows.Forms.Label();
            this.rbASC = new System.Windows.Forms.RadioButton();
            this.rbDESC = new System.Windows.Forms.RadioButton();
            this.pnlSort.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Location = new System.Drawing.Point(28, 87);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(433, 220);
            this.pnlContainer.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(113, 313);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlSort
            // 
            this.pnlSort.BackColor = System.Drawing.Color.White;
            this.pnlSort.Controls.Add(this.cbSortBy);
            this.pnlSort.Controls.Add(this.lbSortByTitel);
            this.pnlSort.Controls.Add(this.rbASC);
            this.pnlSort.Controls.Add(this.rbDESC);
            this.pnlSort.Location = new System.Drawing.Point(39, 45);
            this.pnlSort.Name = "pnlSort";
            this.pnlSort.Size = new System.Drawing.Size(329, 36);
            this.pnlSort.TabIndex = 1;
            // 
            // cbSortBy
            // 
            this.cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Location = new System.Drawing.Point(58, 7);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(121, 21);
            this.cbSortBy.TabIndex = 4;
            // 
            // lbSortByTitel
            // 
            this.lbSortByTitel.AutoSize = true;
            this.lbSortByTitel.Location = new System.Drawing.Point(3, 11);
            this.lbSortByTitel.Name = "lbSortByTitel";
            this.lbSortByTitel.Size = new System.Drawing.Size(49, 13);
            this.lbSortByTitel.TabIndex = 3;
            this.lbSortByTitel.Text = "Sort By :";
            // 
            // rbASC
            // 
            this.rbASC.AutoSize = true;
            this.rbASC.Checked = true;
            this.rbASC.Location = new System.Drawing.Point(203, 11);
            this.rbASC.Name = "rbASC";
            this.rbASC.Size = new System.Drawing.Size(45, 17);
            this.rbASC.TabIndex = 1;
            this.rbASC.TabStop = true;
            this.rbASC.Text = "ASC";
            this.rbASC.UseVisualStyleBackColor = true;
            // 
            // rbDESC
            // 
            this.rbDESC.AutoSize = true;
            this.rbDESC.Location = new System.Drawing.Point(265, 11);
            this.rbDESC.Name = "rbDESC";
            this.rbDESC.Size = new System.Drawing.Size(51, 17);
            this.rbDESC.TabIndex = 0;
            this.rbDESC.Text = "DESC";
            this.rbDESC.UseVisualStyleBackColor = true;
            // 
            // frmSortAndFilter
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 349);
            this.Controls.Add(this.pnlSort);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pnlContainer);
            this.Name = "frmSortAndFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort & Filter";
            this.Load += new System.EventHandler(this.frmSortAndFilter_Load);
            this.pnlSort.ResumeLayout(false);
            this.pnlSort.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlSort;
        private System.Windows.Forms.RadioButton rbASC;
        private System.Windows.Forms.RadioButton rbDESC;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.Label lbSortByTitel;
    }
}