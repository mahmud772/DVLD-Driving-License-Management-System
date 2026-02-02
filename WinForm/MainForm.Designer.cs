namespace DVLD
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.btnLicenses = new System.Windows.Forms.Button();
            this.btnTestAppointments = new System.Windows.Forms.Button();
            this.btnApplications = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.lbLicenses_Title = new System.Windows.Forms.Label();
            this.lbApplications_Title = new System.Windows.Forms.Label();
            this.lbTests_Title = new System.Windows.Forms.Label();
            this.lbPeople_Titel = new System.Windows.Forms.Label();
            this.btnPeople = new System.Windows.Forms.Button();
            this.pnlTopForm = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lbPageNumber = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.flpUserControls = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvDisplay = new System.Windows.Forms.DataGridView();
            this.cmsUpdate_Delete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSort_Filter = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pnlDisplayMethod = new System.Windows.Forms.Panel();
            this.btnDGV = new System.Windows.Forms.Button();
            this.btnFLP = new System.Windows.Forms.Button();
            this.pnlTypes = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlMainMenu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
            this.cmsUpdate_Delete.SuspendLayout();
            this.pnlDisplayMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMainMenu.Controls.Add(this.btnLicenses);
            this.pnlMainMenu.Controls.Add(this.btnTestAppointments);
            this.pnlMainMenu.Controls.Add(this.btnApplications);
            this.pnlMainMenu.Controls.Add(this.btnDrivers);
            this.pnlMainMenu.Controls.Add(this.btnUsers);
            this.pnlMainMenu.Controls.Add(this.lbLicenses_Title);
            this.pnlMainMenu.Controls.Add(this.lbApplications_Title);
            this.pnlMainMenu.Controls.Add(this.lbTests_Title);
            this.pnlMainMenu.Controls.Add(this.lbPeople_Titel);
            this.pnlMainMenu.Controls.Add(this.btnPeople);
            this.pnlMainMenu.Location = new System.Drawing.Point(0, 5);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(217, 878);
            this.pnlMainMenu.TabIndex = 0;
            this.pnlMainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainMenu_Paint);
            // 
            // btnLicenses
            // 
            this.btnLicenses.BackColor = System.Drawing.SystemColors.Control;
            this.btnLicenses.FlatAppearance.BorderSize = 0;
            this.btnLicenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLicenses.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicenses.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLicenses.Image = global::DVLDWinForm.Properties.Resources.Licenses;
            this.btnLicenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLicenses.Location = new System.Drawing.Point(36, 417);
            this.btnLicenses.Name = "btnLicenses";
            this.btnLicenses.Size = new System.Drawing.Size(160, 30);
            this.btnLicenses.TabIndex = 10;
            this.btnLicenses.Text = "  Licenses";
            this.btnLicenses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLicenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLicenses.UseVisualStyleBackColor = false;
            this.btnLicenses.Click += new System.EventHandler(this.btnLicenses_Click);
            // 
            // btnTestAppointments
            // 
            this.btnTestAppointments.BackColor = System.Drawing.SystemColors.Control;
            this.btnTestAppointments.FlatAppearance.BorderSize = 0;
            this.btnTestAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestAppointments.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestAppointments.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTestAppointments.Image = global::DVLDWinForm.Properties.Resources.TestAppointment;
            this.btnTestAppointments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestAppointments.Location = new System.Drawing.Point(36, 343);
            this.btnTestAppointments.Name = "btnTestAppointments";
            this.btnTestAppointments.Size = new System.Drawing.Size(160, 30);
            this.btnTestAppointments.TabIndex = 9;
            this.btnTestAppointments.Text = "  Test Appointments";
            this.btnTestAppointments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTestAppointments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestAppointments.UseVisualStyleBackColor = false;
            this.btnTestAppointments.Click += new System.EventHandler(this.btnTestAppointments_Click);
            // 
            // btnApplications
            // 
            this.btnApplications.BackColor = System.Drawing.SystemColors.Control;
            this.btnApplications.FlatAppearance.BorderSize = 0;
            this.btnApplications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplications.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplications.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnApplications.Image = global::DVLDWinForm.Properties.Resources.Applications;
            this.btnApplications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplications.Location = new System.Drawing.Point(36, 271);
            this.btnApplications.Name = "btnApplications";
            this.btnApplications.Size = new System.Drawing.Size(160, 30);
            this.btnApplications.TabIndex = 8;
            this.btnApplications.Text = "  Applications";
            this.btnApplications.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApplications.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApplications.UseVisualStyleBackColor = false;
            this.btnApplications.Click += new System.EventHandler(this.btnApplications_Click);
            // 
            // btnDrivers
            // 
            this.btnDrivers.BackColor = System.Drawing.SystemColors.Control;
            this.btnDrivers.FlatAppearance.BorderSize = 0;
            this.btnDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrivers.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrivers.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDrivers.Image = global::DVLDWinForm.Properties.Resources.Drivers;
            this.btnDrivers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrivers.Location = new System.Drawing.Point(36, 199);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(160, 30);
            this.btnDrivers.TabIndex = 7;
            this.btnDrivers.Text = "  Drivers";
            this.btnDrivers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDrivers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDrivers.UseVisualStyleBackColor = false;
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.SystemColors.Control;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUsers.Image = global::DVLDWinForm.Properties.Resources.Users;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(36, 161);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(160, 30);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "  Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // lbLicenses_Title
            // 
            this.lbLicenses_Title.AutoSize = true;
            this.lbLicenses_Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLicenses_Title.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbLicenses_Title.Location = new System.Drawing.Point(7, 391);
            this.lbLicenses_Title.Name = "lbLicenses_Title";
            this.lbLicenses_Title.Size = new System.Drawing.Size(56, 17);
            this.lbLicenses_Title.TabIndex = 5;
            this.lbLicenses_Title.Text = "Licenses";
            // 
            // lbApplications_Title
            // 
            this.lbApplications_Title.AutoSize = true;
            this.lbApplications_Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplications_Title.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbApplications_Title.Location = new System.Drawing.Point(7, 244);
            this.lbApplications_Title.Name = "lbApplications_Title";
            this.lbApplications_Title.Size = new System.Drawing.Size(79, 17);
            this.lbApplications_Title.TabIndex = 4;
            this.lbApplications_Title.Text = "Applications";
            // 
            // lbTests_Title
            // 
            this.lbTests_Title.AutoSize = true;
            this.lbTests_Title.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTests_Title.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTests_Title.Location = new System.Drawing.Point(7, 312);
            this.lbTests_Title.Name = "lbTests_Title";
            this.lbTests_Title.Size = new System.Drawing.Size(37, 17);
            this.lbTests_Title.TabIndex = 3;
            this.lbTests_Title.Text = "Tests";
            // 
            // lbPeople_Titel
            // 
            this.lbPeople_Titel.AutoSize = true;
            this.lbPeople_Titel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPeople_Titel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbPeople_Titel.Location = new System.Drawing.Point(7, 94);
            this.lbPeople_Titel.Name = "lbPeople_Titel";
            this.lbPeople_Titel.Size = new System.Drawing.Size(48, 17);
            this.lbPeople_Titel.TabIndex = 2;
            this.lbPeople_Titel.Text = "People";
            // 
            // btnPeople
            // 
            this.btnPeople.BackColor = System.Drawing.SystemColors.Control;
            this.btnPeople.FlatAppearance.BorderSize = 0;
            this.btnPeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeople.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeople.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPeople.Image = global::DVLDWinForm.Properties.Resources.People;
            this.btnPeople.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPeople.Location = new System.Drawing.Point(36, 123);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(160, 30);
            this.btnPeople.TabIndex = 0;
            this.btnPeople.Text = "  People";
            this.btnPeople.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPeople.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPeople.UseVisualStyleBackColor = false;
            this.btnPeople.Click += new System.EventHandler(this.btnPeople_Click);
            // 
            // pnlTopForm
            // 
            this.pnlTopForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTopForm.Location = new System.Drawing.Point(217, 5);
            this.pnlTopForm.Name = "pnlTopForm";
            this.pnlTopForm.Size = new System.Drawing.Size(1215, 225);
            this.pnlTopForm.TabIndex = 1;
            this.pnlTopForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopForm_Paint);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMain.Controls.Add(this.lbPageNumber);
            this.pnlMain.Controls.Add(this.btnNextPage);
            this.pnlMain.Controls.Add(this.btnPreviousPage);
            this.pnlMain.Controls.Add(this.flpUserControls);
            this.pnlMain.Controls.Add(this.dgvDisplay);
            this.pnlMain.Controls.Add(this.btnAddNew);
            this.pnlMain.Controls.Add(this.btnSort_Filter);
            this.pnlMain.Controls.Add(this.tbSearch);
            this.pnlMain.Controls.Add(this.pnlDisplayMethod);
            this.pnlMain.Controls.Add(this.pnlTypes);
            this.pnlMain.Controls.Add(this.btnSearch);
            this.pnlMain.Location = new System.Drawing.Point(217, 199);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1215, 681);
            this.pnlMain.TabIndex = 2;
            // 
            // lbPageNumber
            // 
            this.lbPageNumber.AutoSize = true;
            this.lbPageNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPageNumber.Location = new System.Drawing.Point(651, 601);
            this.lbPageNumber.Name = "lbPageNumber";
            this.lbPageNumber.Size = new System.Drawing.Size(12, 15);
            this.lbPageNumber.TabIndex = 0;
            this.lbPageNumber.Text = "1";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.Location = new System.Drawing.Point(682, 597);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(38, 21);
            this.btnNextPage.TabIndex = 9;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.Location = new System.Drawing.Point(597, 597);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(38, 21);
            this.btnPreviousPage.TabIndex = 8;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // flpUserControls
            // 
            this.flpUserControls.AutoScroll = true;
            this.flpUserControls.Location = new System.Drawing.Point(0, 81);
            this.flpUserControls.Name = "flpUserControls";
            this.flpUserControls.Size = new System.Drawing.Size(1215, 506);
            this.flpUserControls.TabIndex = 6;
            // 
            // dgvDisplay
            // 
            this.dgvDisplay.AllowUserToAddRows = false;
            this.dgvDisplay.AllowUserToDeleteRows = false;
            this.dgvDisplay.AllowUserToOrderColumns = true;
            this.dgvDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplay.ContextMenuStrip = this.cmsUpdate_Delete;
            this.dgvDisplay.Location = new System.Drawing.Point(0, 81);
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.ReadOnly = true;
            this.dgvDisplay.Size = new System.Drawing.Size(1215, 506);
            this.dgvDisplay.TabIndex = 0;
            this.dgvDisplay.Visible = false;
            this.dgvDisplay.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDown);
            // 
            // cmsUpdate_Delete
            // 
            this.cmsUpdate_Delete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsUpdate_Delete.Name = "cmsUpdate_Delete";
            this.cmsUpdate_Delete.Size = new System.Drawing.Size(113, 48);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateToolStripMenuItem.Image = global::DVLDWinForm.Properties.Resources.Update_Person;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteToolStripMenuItem.Image = global::DVLDWinForm.Properties.Resources.Delete_Person;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(1084, 24);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(116, 40);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSort_Filter
            // 
            this.btnSort_Filter.Location = new System.Drawing.Point(941, 24);
            this.btnSort_Filter.Name = "btnSort_Filter";
            this.btnSort_Filter.Size = new System.Drawing.Size(116, 40);
            this.btnSort_Filter.TabIndex = 4;
            this.btnSort_Filter.Text = "Sort \\ Filter";
            this.btnSort_Filter.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(664, 26);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(189, 38);
            this.tbSearch.TabIndex = 3;
            // 
            // pnlDisplayMethod
            // 
            this.pnlDisplayMethod.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlDisplayMethod.Controls.Add(this.btnDGV);
            this.pnlDisplayMethod.Controls.Add(this.btnFLP);
            this.pnlDisplayMethod.Location = new System.Drawing.Point(292, 26);
            this.pnlDisplayMethod.Name = "pnlDisplayMethod";
            this.pnlDisplayMethod.Size = new System.Drawing.Size(94, 39);
            this.pnlDisplayMethod.TabIndex = 1;
            // 
            // btnDGV
            // 
            this.btnDGV.BackgroundImage = global::DVLDWinForm.Properties.Resources.Menu_Gray_DGV;
            this.btnDGV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDGV.Location = new System.Drawing.Point(53, 4);
            this.btnDGV.Name = "btnDGV";
            this.btnDGV.Size = new System.Drawing.Size(35, 29);
            this.btnDGV.TabIndex = 6;
            this.btnDGV.UseVisualStyleBackColor = true;
            this.btnDGV.Click += new System.EventHandler(this.btnDGV_Click);
            // 
            // btnFLP
            // 
            this.btnFLP.BackgroundImage = global::DVLDWinForm.Properties.Resources.Menu_Gray_FLP;
            this.btnFLP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFLP.Location = new System.Drawing.Point(6, 4);
            this.btnFLP.Name = "btnFLP";
            this.btnFLP.Size = new System.Drawing.Size(35, 29);
            this.btnFLP.TabIndex = 7;
            this.btnFLP.UseVisualStyleBackColor = true;
            this.btnFLP.Click += new System.EventHandler(this.btnFLP_Click);
            // 
            // pnlTypes
            // 
            this.pnlTypes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlTypes.Location = new System.Drawing.Point(6, 26);
            this.pnlTypes.Name = "pnlTypes";
            this.pnlTypes.Size = new System.Drawing.Size(252, 39);
            this.pnlTypes.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(851, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 881);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTopForm);
            this.Controls.Add(this.pnlMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DVLD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlMainMenu.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
            this.cmsUpdate_Delete.ResumeLayout(false);
            this.pnlDisplayMethod.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.Panel pnlTopForm;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlDisplayMethod;
        private System.Windows.Forms.Panel pnlTypes;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSort_Filter;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnFLP;
        private System.Windows.Forms.Button btnDGV;
        private System.Windows.Forms.FlowLayoutPanel flpUserControls;
        private System.Windows.Forms.DataGridView dgvDisplay;
        private System.Windows.Forms.Label lbPageNumber;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Label lbLicenses_Title;
        private System.Windows.Forms.Label lbApplications_Title;
        private System.Windows.Forms.Label lbTests_Title;
        private System.Windows.Forms.Label lbPeople_Titel;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnApplications;
        private System.Windows.Forms.Button btnTestAppointments;
        private System.Windows.Forms.Button btnLicenses;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip cmsUpdate_Delete;
    }
}

