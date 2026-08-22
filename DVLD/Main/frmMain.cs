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
    }
}
