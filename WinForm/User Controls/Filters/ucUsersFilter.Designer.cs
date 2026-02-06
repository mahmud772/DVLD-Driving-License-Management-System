namespace DVLDWinForm.User_Controls.Filters
{
    partial class ucUsersFilter
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
            this.ucPeopleFilter1 = new DVLDWinForm.User_Controls.Filters.ucPeopleFilter();
            this.SuspendLayout();
            // 
            // ucPeopleFilter1
            // 
            this.ucPeopleFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ucPeopleFilter1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ucPeopleFilter1.Location = new System.Drawing.Point(2, 2);
            this.ucPeopleFilter1.Name = "ucPeopleFilter1";
            this.ucPeopleFilter1.Size = new System.Drawing.Size(426, 169);
            this.ucPeopleFilter1.TabIndex = 0;
            // 
            // ucUsersFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPeopleFilter1);
            this.Name = "ucUsersFilter";
            this.Size = new System.Drawing.Size(433, 181);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPeopleFilter ucPeopleFilter1;
    }
}
