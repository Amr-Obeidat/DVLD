
using DVLD.GlobalClasses;
using DVLD.Licenses;
using DVLD_Business.Licenses;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Licenses.Detain_License
{
    public partial class frmDetainLicense : Form
    {
        private int _DetainId = -1;
        private int _SelectedLicenseId = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        public frmDetainLicense(int licenseId)
        {
            InitializeComponent();
            _SelectedLicenseId = licenseId;
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
          
            ctrDriverLicenseInfoWithFilterscs1.OnLicenseSelected += ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected;

         
            lblDetainDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserDTO.UserName;
            lblDetainId.Text = "[???]";
          //  lblLicenseClass.Text = "[???]"; 

         
            btnDetain.Enabled = false;
            txtDetainfees.Enabled = false;
            linklblShowNewLicenseInfo.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;

           
            if (_SelectedLicenseId != -1)
            {
                ctrDriverLicenseInfoWithFilterscs1.LoadInfo(_SelectedLicenseId);
                ctrDriverLicenseInfoWithFilterscs1.FilterEnabled = false;
            }
            else
            {
                ctrDriverLicenseInfoWithFilterscs1.txtLicenseIdFocus();
            }
        }

        private void ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected(int licenseId)
        {
            _SelectedLicenseId = licenseId;

            if (_SelectedLicenseId == -1)
            {
                btnDetain.Enabled = false;
                txtDetainfees.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;
                //lblLicenseClass.Text = "[???]";
                return;
            }

            clsLicense selectedLicense = ctrDriverLicenseInfoWithFilterscs1.License;

          //  lblLicenseClass.Text = selectedLicense.LicenseDTO.LicenseID.ToString();
            linklblShowLicenseHistory.Enabled = true;

            if (!selectedLicense.LicenseDTO.IsActive)
            {
                MessageBox.Show("Selected license is not active. Only active licenses can be detained.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                txtDetainfees.Enabled = false;
                return;
            }

         
            if (selectedLicense.IsDetained)
            {
                MessageBox.Show("Selected license is already detained. You cannot detain it twice.",
                    "Already Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                txtDetainfees.Enabled = false;
                return;
            }

         
            txtDetainfees.Enabled = true;
            btnDetain.Enabled = true;
            txtDetainfees.Focus();
        }

    
        private void txtDetainfees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDetainfees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDetainfees, "Fine fees cannot be empty!");
            }
            else if (!decimal.TryParse(txtDetainfees.Text.Trim(), out decimal fees) || fees < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDetainfees, "Please enter a valid positive number for fine fees!");
            }
            else
            {
                errorProvider1.SetError(txtDetainfees, null);
            }
        }

        private void txtDetainfees_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

       
      

     
        private void gbDetainLicense_Enter(object sender, EventArgs e)
        {
        }

        private void linklblShowLicenseHistory_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int personId = ctrDriverLicenseInfoWithFilterscs1.License.DriverInfo.PersonInfo.PersonDTO.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personId);
            frm.ShowDialog();
        }

        private void linklblShowNewLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectedLicenseId);
            frm.ShowDialog();

        }

        private void btnDetain_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Hover over the red icon to see the error.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            decimal fineFees = Convert.ToDecimal(txtDetainfees.Text.Trim());


            _DetainId = ctrDriverLicenseInfoWithFilterscs1.License.Detain(
                fineFees, clsGlobal.CurrentUser.UserDTO.UserID
            );

            if (_DetainId == -1)
            {
                MessageBox.Show("Failed to detain the driving license.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblDetainId.Text = _DetainId.ToString();

            MessageBox.Show($"License Detained Successfully with Detain ID = {_DetainId}",
                "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnDetain.Enabled = false;
            txtDetainfees.Enabled = false;
            ctrDriverLicenseInfoWithFilterscs1.FilterEnabled = false;
            linklblShowNewLicenseInfo.Enabled = true;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}

