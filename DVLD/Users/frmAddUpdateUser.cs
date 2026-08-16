using DVLD.Controls;
using DVLD_Business.People;
using DVLD_Business.Users;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonId);
        public event DataBackEventHandler DataBack;

        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        private enMode _Mode = enMode.AddNew;
        private int _UserId = -1;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdateUser(int UserId)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _UserId = UserId;
            ctrPersonCardWithFiltercs1.FilterEnabled = false;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";

                _User = new clsUser();

                tbLogInInfo.Enabled = false;

                ctrPersonCardWithFiltercs1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update User Info";
                this.Text = "Update User Info";

                tbLogInInfo.Enabled = true;
            }

            lblUserId.Text = "???";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
        }

        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserId);

            if (_User == null)
            {
                MessageBox.Show(
                    $"No User with the User ID {_UserId} was found.",
                    "User Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            lblUserId.Text = _User.UserDTO.UserID.ToString();

            txtUserName.Text = _User.UserDTO.UserName;
            txtPassword.Text = _User.UserDTO.Password;
            txtConfirmPassword.Text = _User.UserDTO.Password;

            ctrPersonCardWithFiltercs1.LoadPersonInfo( _User.UserDTO.PersonID);

            chkIsActive.Checked = _User.UserDTO.IsActive;
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadUserInfo();
            }
      
        }

        private void tcUser_Selecting( object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tbLogInInfo && ctrPersonCardWithFiltercs1.PersonId == -1)
            {
                e.Cancel = true;

                MessageBox.Show(
                    "Please select a person first!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        

      

        private void txtUserName_Validating( object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtUserName, "Username cannot be blank!");
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(  object sender,   CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;

   errorProvider1.SetError(  txtPassword, "Password cannot be blank!");
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError( txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender,  CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                e.Cancel = true;

                errorProvider1.SetError( txtConfirmPassword,"Confirm Password cannot be blank!");
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError( txtConfirmPassword, "");
            }
        }

      
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (ctrPersonCardWithFiltercs1.PersonId == -1)
            {
                MessageBox.Show(
                    "Select a Person First.",
                    "Select Person",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                ctrPersonCardWithFiltercs1.Focus();
                return;
            }


            if (_Mode == enMode.AddNew && clsUser.IsUserExistsByPersonID(ctrPersonCardWithFiltercs1.PersonId))
            {
                MessageBox.Show(
                    "A user account for this person already exists. Please select another person.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            tbLogInInfo.Enabled = true;
            tcUser.SelectedTab = tbLogInInfo;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew && clsUser.IsUserExistsByPersonID(ctrPersonCardWithFiltercs1.PersonId))
            {
                MessageBox.Show("A user account for this person already exists. Please select another person.",
                    "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcUser.SelectedTab = tbPersonalInfo;
                return;
            }
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Hover over the red icons to see the errors.",
                  "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Passwords do not match !", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                return;

            }


            _User.UserDTO.PersonID = ctrPersonCardWithFiltercs1.PersonId;
            _User.UserDTO.Password = txtPassword.Text.Trim();
            _User.UserDTO.UserName = txtUserName.Text.Trim();
            _User.UserDTO.IsActive = chkIsActive.Checked;
            _User.PersonInfo = clsPerson.Find(ctrPersonCardWithFiltercs1.PersonId);


            if (_User.Save())
            {
                lblUserId.Text = _User.UserDTO.UserID.ToString();
                this.Text = "Update User Info ";
                lblTitle.Text = "Update User Info ";
                MessageBox.Show("Data Saved Successfully.", "Saved",
            MessageBoxButtons.OK, MessageBoxIcon.Information);


                DataBack?.Invoke(this, _User.UserDTO.UserID);

            }
            else
            {
                MessageBox.Show($"Error {_User.LastValidationError} ", " Save Failed ", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ctrPersonCardWithFiltercs1_Load(object sender, EventArgs e)
        {

        }
    }
}