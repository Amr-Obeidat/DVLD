using DVLD.LogIn;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.GlobalClasses;
using DVLD.Applications;
using DVLD.Tests;
using DVLD.People;
using DVLD.Applications.Local_Driving_License;
using DVLD.Licenses.Local_Driving_License;
using DVLD.Applications.Replace_Lost_Or_Damaged;
using DVLD.Drivers;
using DVLD.Licenses.Detain_License;
using DVLD.Applications.Detained_License;
using DVLD.Applications.International_License;
using DVLD.Licenses.International_Licenses;

namespace DVLD
{
    public partial class frmMain : Form
    {

        frmLogin _frmLogin;
        public frmMain(frmLogin form)
        {
            InitializeComponent();
               _frmLogin = form;    
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

     

      

      

        private void pbMainPhoto_Click(object sender, EventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();    
            frm.ShowDialog();   
        }

        private void tsmUserInfo_Click_1(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserDTO.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserDTO.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void usersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();  

            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();    
            frm.ShowDialog();   
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalLicenseApplication frm = new frmNewLocalLicenseApplication();    
            frm.ShowDialog();   
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalLicenseApp frm = new frmListLocalLicenseApp();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenseApplication frm=new frmRenewLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForLossOrDamageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplcaeLostOrDamagedLicenseApplicationcs frm=new frmReplcaeLostOrDamagedLicenseApplicationcs();
            frm.ShowDialog();   
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm=new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainLicenses frm = new frmListDetainLicenses();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication frm=new frmInternationalLicenseApplication();    
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm=new frmListInternationalLicenses();
            frm.ShowDialog();
        }
    }
}
