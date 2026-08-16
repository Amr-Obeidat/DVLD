using DVLD_Business.Users;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        private readonly int _UserId = -1;
        private clsUser _User;

        public frmChangePassword(int userId)
        {
            InitializeComponent();
            _UserId = userId;
         this.AutoValidate = AutoValidate.Disable;
            ctrUserCard1.EnableEditUserLinkVisibility = false;
            ctrUserCard1.EnableEditUserLink=false;
        }

        private void _ResetDefaultValues()
        {
            ctrUserCard1.ResetUserInfo();
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _User = clsUser.Find(_UserId);

            if (_User == null)
            {
                MessageBox.Show($"Could not find user with ID = {_UserId}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            
            ctrUserCard1.LoadUserInfo(_UserId);
            txtCurrentPassword.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fix the validation errors before saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _User.UserDTO.Password = txtNewPassword.Text.Trim();

            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                string errorMessage = string.IsNullOrEmpty(_User.LastValidationError)
                    ? "Password could not be saved."
                    : _User.LastValidationError;

                MessageBox.Show($"Error: {errorMessage}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();

            if (string.IsNullOrEmpty(currentPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password cannot be empty.");
                return;
            }

            if (currentPassword != _User.UserDTO.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password does not match original password.");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(txtCurrentPassword, null);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New password cannot be empty.");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(txtNewPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(confirmPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm password cannot be empty.");
                return;
            }

            if (confirmPassword != newPassword)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
                return;
            }

            e.Cancel = false;
            errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void ctrUserCard1_Load(object sender, EventArgs e)
        {

        }
    }
}