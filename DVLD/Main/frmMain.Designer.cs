namespace DVLD
{
    partial class frmMain
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
            this.pbMainPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tsmSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMain = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForLossOrDamageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replcaeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalDrivingLicenseApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangePa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPhoto)).BeginInit();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMainPhoto
            // 
            this.pbMainPhoto.BackColor = System.Drawing.Color.Transparent;
            this.pbMainPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbMainPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMainPhoto.FillColor = System.Drawing.Color.Transparent;
            this.pbMainPhoto.Image = global::DVLD.Properties.Resources.MainPhoto;
            this.pbMainPhoto.ImageRotate = 0F;
            this.pbMainPhoto.Location = new System.Drawing.Point(0, 0);
            this.pbMainPhoto.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pbMainPhoto.Name = "pbMainPhoto";
            this.pbMainPhoto.Size = new System.Drawing.Size(936, 612);
            this.pbMainPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMainPhoto.TabIndex = 1;
            this.pbMainPhoto.TabStop = false;
            this.pbMainPhoto.Click += new System.EventHandler(this.pbMainPhoto_Click);
            // 
            // tsmSignOut
            // 
            this.tsmSignOut.Image = global::DVLD.Properties.Resources.SignOut;
            this.tsmSignOut.Name = "tsmSignOut";
            this.tsmSignOut.Size = new System.Drawing.Size(32, 19);
            this.tsmSignOut.Text = "Sign Out";
            this.tsmSignOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsmChangePassword
            // 
            this.tsmChangePassword.Image = global::DVLD.Properties.Resources.Keys;
            this.tsmChangePassword.Name = "tsmChangePassword";
            this.tsmChangePassword.Size = new System.Drawing.Size(32, 19);
            this.tsmChangePassword.Text = "Change Password";
            this.tsmChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmsMain
            // 
            this.cmsMain.BackColor = System.Drawing.Color.MintCream;
            this.cmsMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.cmsMain.Location = new System.Drawing.Point(0, 0);
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(936, 40);
            this.cmsMain.TabIndex = 9;
            this.cmsMain.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicenseToolStripMenuItem,
            this.managApplicationToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.ApplicationTypesToolStripMenuItem,
            this.TestTypesToolStripMenuItem});
            this.applicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Applications2;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(138, 36);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // drivingLicenseToolStripMenuItem
            // 
            this.drivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.replacementForLossOrDamageToolStripMenuItem,
            this.replcaeToolStripMenuItem});
            this.drivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.driver_license;
            this.drivingLicenseToolStripMenuItem.Name = "drivingLicenseToolStripMenuItem";
            this.drivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.drivingLicenseToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_driving_license_64;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Local_32;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(240, 38);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            this.internationalLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.DrivingLicenseType;
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(240, 38);
            this.internationalLicenseToolStripMenuItem.Text = "International License";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Renew;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // replacementForLossOrDamageToolStripMenuItem
            // 
            this.replacementForLossOrDamageToolStripMenuItem.Image = global::DVLD.Properties.Resources.Relpcae;
            this.replacementForLossOrDamageToolStripMenuItem.Name = "replacementForLossOrDamageToolStripMenuItem";
            this.replacementForLossOrDamageToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.replacementForLossOrDamageToolStripMenuItem.Text = "Replacement  for loss or damage";
            this.replacementForLossOrDamageToolStripMenuItem.Click += new System.EventHandler(this.replacementForLossOrDamageToolStripMenuItem_Click);
            // 
            // replcaeToolStripMenuItem
            // 
            this.replcaeToolStripMenuItem.Image = global::DVLD.Properties.Resources.unlock;
            this.replcaeToolStripMenuItem.Name = "replcaeToolStripMenuItem";
            this.replcaeToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.replcaeToolStripMenuItem.Text = "Release Detained License";
            // 
            // managApplicationToolStripMenuItem
            // 
            this.managApplicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationToolStripMenuItem,
            this.internationalDrivingLicenseApplicationToolStripMenuItem});
            this.managApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Manage_Applications_32;
            this.managApplicationToolStripMenuItem.Name = "managApplicationToolStripMenuItem";
            this.managApplicationToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.managApplicationToolStripMenuItem.Text = "Manag Application";
            // 
            // localDrivingLicenseApplicationToolStripMenuItem
            // 
            this.localDrivingLicenseApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.LocalDriving_License;
            this.localDrivingLicenseApplicationToolStripMenuItem.Name = "localDrivingLicenseApplicationToolStripMenuItem";
            this.localDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(373, 38);
            this.localDrivingLicenseApplicationToolStripMenuItem.Text = "Local Driving License Application";
            this.localDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // internationalDrivingLicenseApplicationToolStripMenuItem
            // 
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.International_32;
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Name = "internationalDrivingLicenseApplicationToolStripMenuItem";
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Size = new System.Drawing.Size(373, 38);
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Text = "International Driving License Application";
            this.internationalDrivingLicenseApplicationToolStripMenuItem.Click += new System.EventHandler(this.internationalDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.releaseToolStripMenuItem,
            this.detainLicenseToolStripMenuItem1,
            this.manageDetainedLicensesToolStripMenuItem});
            this.detainLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_locked_user_64;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // releaseToolStripMenuItem
            // 
            this.releaseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Release;
            this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            this.releaseToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.releaseToolStripMenuItem.Text = "Release License";
            this.releaseToolStripMenuItem.Click += new System.EventHandler(this.releaseToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem1
            // 
            this.detainLicenseToolStripMenuItem1.Image = global::DVLD.Properties.Resources.Detain;
            this.detainLicenseToolStripMenuItem1.Name = "detainLicenseToolStripMenuItem1";
            this.detainLicenseToolStripMenuItem1.Size = new System.Drawing.Size(281, 38);
            this.detainLicenseToolStripMenuItem1.Text = "Detain License";
            this.detainLicenseToolStripMenuItem1.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem1_Click);
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.icons8_manage_32;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicensesToolStripMenuItem_Click);
            // 
            // ApplicationTypesToolStripMenuItem
            // 
            this.ApplicationTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.ApplicationTypesToolStripMenuItem.Name = "ApplicationTypesToolStripMenuItem";
            this.ApplicationTypesToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.ApplicationTypesToolStripMenuItem.Text = "Manage Application Types";
            this.ApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // TestTypesToolStripMenuItem
            // 
            this.TestTypesToolStripMenuItem.Image = global::DVLD.Properties.Resources.TestTypes;
            this.TestTypesToolStripMenuItem.Name = "TestTypesToolStripMenuItem";
            this.TestTypesToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.TestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.TestTypesToolStripMenuItem.Click += new System.EventHandler(this.applicationTypesToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::DVLD.Properties.Resources.People;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(100, 36);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLD.Properties.Resources.Car;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(101, 36);
            this.driversToolStripMenuItem.Text = "Drivers";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::DVLD.Properties.Resources.Users;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(90, 36);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click_1);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUserInfo,
            this.tsmChangePa,
            this.toolStripMenuItem3});
            this.accountSettingsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Settings;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(166, 36);
            this.accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // tsmUserInfo
            // 
            this.tsmUserInfo.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.tsmUserInfo.Name = "tsmUserInfo";
            this.tsmUserInfo.Size = new System.Drawing.Size(219, 38);
            this.tsmUserInfo.Text = "Current User Info";
            this.tsmUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmUserInfo.Click += new System.EventHandler(this.tsmUserInfo_Click_1);
            // 
            // tsmChangePa
            // 
            this.tsmChangePa.Image = global::DVLD.Properties.Resources.Keys;
            this.tsmChangePa.Name = "tsmChangePa";
            this.tsmChangePa.Size = new System.Drawing.Size(219, 38);
            this.tsmChangePa.Text = "Change Password";
            this.tsmChangePa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmChangePa.Click += new System.EventHandler(this.toolStripMenuItem2_Click_1);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::DVLD.Properties.Resources.SignOut;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(219, 38);
            this.toolStripMenuItem3.Text = "Sign Out";
            this.toolStripMenuItem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click_1);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 612);
            this.Controls.Add(this.cmsMain);
            this.Controls.Add(this.pbMainPhoto);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPhoto)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.cmsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tsmSignOut;
        private System.Windows.Forms.ToolStripMenuItem tsmChangePassword;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2PictureBox pbMainPhoto;
        private System.Windows.Forms.MenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmUserInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmChangePa;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForLossOrDamageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replcaeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalDrivingLicenseApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem1;
    }
}