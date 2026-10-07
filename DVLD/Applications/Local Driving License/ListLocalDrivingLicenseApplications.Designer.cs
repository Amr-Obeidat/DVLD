namespace DVLD.Applications.Local_Driving_License
{
    partial class frmListLocalLicenseApp
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
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.lblNumRecordsTag = new System.Windows.Forms.Label();
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterList = new System.Windows.Forms.ComboBox();
            this.lblFilterByTag = new System.Windows.Forms.Label();
            this.dgvLocalApp = new System.Windows.Forms.DataGridView();
            this.lblManageLocalApp = new System.Windows.Forms.Label();
            this.cmsLocalApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsscheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsscheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsscheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLicenseHistorycms = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbManagLocalApplications = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApp)).BeginInit();
            this.cmsLocalApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagLocalApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfRecords.Location = new System.Drawing.Point(136, 650);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(36, 25);
            this.lblNumOfRecords.TabIndex = 15;
            this.lblNumOfRecords.Text = "??";
            // 
            // lblNumRecordsTag
            // 
            this.lblNumRecordsTag.AutoSize = true;
            this.lblNumRecordsTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRecordsTag.Location = new System.Drawing.Point(21, 650);
            this.lblNumRecordsTag.Name = "lblNumRecordsTag";
            this.lblNumRecordsTag.Size = new System.Drawing.Size(109, 25);
            this.lblNumRecordsTag.TabIndex = 14;
            this.lblNumRecordsTag.Text = "# Records";
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterBy.Location = new System.Drawing.Point(339, 248);
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(224, 28);
            this.txtFilterBy.TabIndex = 13;
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
            // 
            // cbFilterList
            // 
            this.cbFilterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterList.FormattingEnabled = true;
            this.cbFilterList.Location = new System.Drawing.Point(116, 246);
            this.cbFilterList.Name = "cbFilterList";
            this.cbFilterList.Size = new System.Drawing.Size(202, 30);
            this.cbFilterList.TabIndex = 12;
            this.cbFilterList.TextChanged += new System.EventHandler(this.cbFilterList_SelectedIndexChanged);
            // 
            // lblFilterByTag
            // 
            this.lblFilterByTag.AutoSize = true;
            this.lblFilterByTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterByTag.Location = new System.Drawing.Point(6, 247);
            this.lblFilterByTag.Name = "lblFilterByTag";
            this.lblFilterByTag.Size = new System.Drawing.Size(104, 25);
            this.lblFilterByTag.TabIndex = 11;
            this.lblFilterByTag.Text = "Filter By :";
            // 
            // dgvLocalApp
            // 
            this.dgvLocalApp.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLocalApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalApp.Location = new System.Drawing.Point(2, 282);
            this.dgvLocalApp.Name = "dgvLocalApp";
            this.dgvLocalApp.RowHeadersWidth = 51;
            this.dgvLocalApp.RowTemplate.Height = 26;
            this.dgvLocalApp.Size = new System.Drawing.Size(1283, 343);
            this.dgvLocalApp.TabIndex = 10;
            this.dgvLocalApp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalApp_CellContentClick);
            this.dgvLocalApp.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLocalApp_CellMouseDown);
            // 
            // lblManageLocalApp
            // 
            this.lblManageLocalApp.AutoSize = true;
            this.lblManageLocalApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageLocalApp.ForeColor = System.Drawing.Color.Red;
            this.lblManageLocalApp.Location = new System.Drawing.Point(347, 153);
            this.lblManageLocalApp.Name = "lblManageLocalApp";
            this.lblManageLocalApp.Size = new System.Drawing.Size(547, 38);
            this.lblManageLocalApp.TabIndex = 8;
            this.lblManageLocalApp.Text = "Local Driving License Applications";
            // 
            // cmsLocalApplications
            // 
            this.cmsLocalApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLocalApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocalApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripSeparator3,
            this.tsmScheduleTests,
            this.toolStripSeparator4,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripSeparator5,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator6,
            this.ShowLicenseHistorycms});
            this.cmsLocalApplications.Name = "cmsLocalApplications";
            this.cmsLocalApplications.Size = new System.Drawing.Size(285, 218);
            this.cmsLocalApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLocalApplications_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(71, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(281, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(281, 6);
            // 
            // tsmScheduleTests
            // 
            this.tsmScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsscheduleVisionTest,
            this.tmsscheduleWrittenTest,
            this.tmsscheduleStreetTest});
            this.tsmScheduleTests.Image = global::DVLD.Properties.Resources.TestType_32;
            this.tsmScheduleTests.Name = "tsmScheduleTests";
            this.tsmScheduleTests.Size = new System.Drawing.Size(284, 26);
            this.tsmScheduleTests.Text = "Schedule Tests";
            this.tsmScheduleTests.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // tmsscheduleVisionTest
            // 
            this.tmsscheduleVisionTest.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.tmsscheduleVisionTest.Name = "tmsscheduleVisionTest";
            this.tmsscheduleVisionTest.Size = new System.Drawing.Size(233, 26);
            this.tmsscheduleVisionTest.Text = "schedule Vision Test";
            this.tmsscheduleVisionTest.Click += new System.EventHandler(this.sechduleVisionTestToolStripMenuItem_Click);
            // 
            // tmsscheduleWrittenTest
            // 
            this.tmsscheduleWrittenTest.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.tmsscheduleWrittenTest.Name = "tmsscheduleWrittenTest";
            this.tmsscheduleWrittenTest.Size = new System.Drawing.Size(233, 26);
            this.tmsscheduleWrittenTest.Text = "schedule Written Test";
            this.tmsscheduleWrittenTest.Click += new System.EventHandler(this.sechduleWrittenTestToolStripMenuItem_Click);
            // 
            // tmsscheduleStreetTest
            // 
            this.tmsscheduleStreetTest.Image = global::DVLD.Properties.Resources.icons8_street_32;
            this.tmsscheduleStreetTest.Name = "tmsscheduleStreetTest";
            this.tmsscheduleStreetTest.Size = new System.Drawing.Size(233, 26);
            this.tmsscheduleStreetTest.Text = "scheduleStreet Test";
            this.tmsscheduleStreetTest.Click += new System.EventHandler(this.sechduleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(281, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License first Time";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(281, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(281, 6);
            // 
            // ShowLicenseHistorycms
            // 
            this.ShowLicenseHistorycms.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.ShowLicenseHistorycms.Name = "ShowLicenseHistorycms";
            this.ShowLicenseHistorycms.Size = new System.Drawing.Size(284, 26);
            this.ShowLicenseHistorycms.Text = "Show Person Licnse History ";
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(1165, 629);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 46);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Local_32;
            this.pictureBox1.Location = new System.Drawing.Point(686, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pbManagLocalApplications
            // 
            this.pbManagLocalApplications.Image = global::DVLD.Properties.Resources.Manage_Applications_64;
            this.pbManagLocalApplications.Location = new System.Drawing.Point(508, 12);
            this.pbManagLocalApplications.Name = "pbManagLocalApplications";
            this.pbManagLocalApplications.Size = new System.Drawing.Size(204, 138);
            this.pbManagLocalApplications.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbManagLocalApplications.TabIndex = 9;
            this.pbManagLocalApplications.TabStop = false;
            // 
            // frmListLocalLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 687);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblNumOfRecords);
            this.Controls.Add(this.lblNumRecordsTag);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.cbFilterList);
            this.Controls.Add(this.lblFilterByTag);
            this.Controls.Add(this.dgvLocalApp);
            this.Controls.Add(this.pbManagLocalApplications);
            this.Controls.Add(this.lblManageLocalApp);
            this.Name = "frmListLocalLicenseApp";
            this.Text = "ListLocalDrivingLicenseApplications";
            this.Load += new System.EventHandler(this.frmListLocalLicenseApp_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmListLocalLicenseApp_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApp)).EndInit();
            this.cmsLocalApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManagLocalApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label lblNumRecordsTag;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.ComboBox cbFilterList;
        private System.Windows.Forms.Label lblFilterByTag;
        private System.Windows.Forms.DataGridView dgvLocalApp;
        private System.Windows.Forms.PictureBox pbManagLocalApplications;
        private System.Windows.Forms.Label lblManageLocalApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsLocalApplications;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem tmsscheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tmsscheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tmsscheduleStreetTest;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseHistorycms;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}