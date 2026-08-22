using DVLD.GlobalClasses;
using DVLD_Business.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LogIn
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string Password = "";   

            if(clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                CkRememberMe.Checked = true;
            }
            else
            {
                CkRememberMe.Checked = false;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "User Name Can't be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Password Can't be empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            if(!this.ValidateChildren())
            {
             
                MessageBox.Show("Please fill all required fields", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            clsUser User = clsUser.Find(txtUserName.Text.Trim(), txtPassword.Text.Trim());



            if (User != null)
            {


                if(!User.UserDTO.IsActive)
                {
                    MessageBox.Show("User is Inactive. Please contact Admin", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               

                if (CkRememberMe.Checked==true)
                {
                   clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }


                   clsGlobal.CurrentUser = User;

                this.Hide();
                frmMain MainForm = new frmMain(this);    
                MainForm.ShowDialog();  



            }
            else
            {
                MessageBox.Show("Invalid User Name or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }










        }

        private void btnPassImage_Click(object sender, EventArgs e)
        {

         
        }

        private void pbpasswordimage_Click(object sender, EventArgs e)
        {
            


            txtPassword.UseSystemPasswordChar =!txtPassword.UseSystemPasswordChar;

          

            pbpasswordimage.Image = txtPassword.UseSystemPasswordChar ? Properties.Resources.closedeye : Properties.Resources.opendeye;
            txtPassword.Focus();
        }
    }
}
