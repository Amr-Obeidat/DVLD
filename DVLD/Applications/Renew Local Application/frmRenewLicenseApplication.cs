
using DVLD.GlobalClasses;
using DVLD.Licenses;
using DVLD.Licenses.Local_Driving_License;
using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_Driving_License
{
    public partial class frmRenewLicenseApplication : Form
    {
        private int _NewLicenseId = -1;

        public frmRenewLicenseApplication()
        {
           
          
            InitializeComponent();
            this.VerticalScroll.Visible = true;

        }

        private void _InitilizeComponents()
        {
           

            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserDTO.UserName;


            decimal applicationFees = clsApplicationTypes
                .Find((int)clsApplicationDTO.enApplicationType.RenewDrivingLicense)
                .DTO.ApplicationFees;

            lblApplicationFees.Text = applicationFees.ToString("0.00");


            btnSave.Enabled = false;
            linklblShowNewLicenseInfo.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;

        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilterscs1.OnLicenseSelected += ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected;
            ctrDriverLicenseInfoWithFilterscs1.txtLicenseIdFocus();
            _InitilizeComponents();
        }

        private void ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected(int licenseId)
        {
            int selectedLicenseId = licenseId;

            
            if (selectedLicenseId == -1)
            {
                btnSave.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;
                return;
            }

            clsLicense selectedLicense = ctrDriverLicenseInfoWithFilterscs1.License;

            
            linklblShowLicenseHistory.Enabled = true;

          
            lblOldLicenseId.Text = selectedLicense.LicenseDTO.LicenseID.ToString();

            int validityYears =clsLicenseClass.Find(selectedLicense.LicenseDTO.LicenseClassID)?.clsLicenseClassDTO?.DefaultValidityLength ?? 10;
            lblExpDate.Text = DateTime.Now.AddYears(validityYears).ToString("dd/MMM/yyyy");

            decimal licenseFees = clsLicenseClass.Find(selectedLicense.LicenseDTO.LicenseClassID)?.clsLicenseClassDTO?.ClassFees ?? 0;
            lblLicensefees.Text = licenseFees.ToString("0.00");

            decimal applicationFees = Convert.ToDecimal(lblApplicationFees.Text);
            lblTotalfees.Text = (applicationFees + licenseFees).ToString("0.00");

           

           
            if (!selectedLicense.LicenseDTO.IsActive)
            {
                MessageBox.Show("Selected License is not active. You can only renew an active license.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

           
            if (selectedLicense.LicenseDTO.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"Selected License has not expired yet. It will expire on: {selectedLicense.LicenseDTO.ExpirationDate:dd/MMM/yyyy}",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

           
            if (selectedLicense.IsDetained)
            {
                MessageBox.Show("Selected License is detained. You must release the detention before renewal.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

         
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this license?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            btnSave.Enabled = false;

           
            clsLicense newLicense = ctrDriverLicenseInfoWithFilterscs1.License.RenewLicense(
                txtNotes.Text.Trim(),
                clsGlobal.CurrentUser.UserDTO.UserID
            );

            if (newLicense == null)
            {
                MessageBox.Show("Failed to renew the license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                return;
            }

            
            lblRenewAppId.Text = newLicense.LicenseDTO.ApplicationID.ToString();
            _NewLicenseId = newLicense.LicenseDTO.LicenseID;
            lblRenewLicenseid.Text = _NewLicenseId.ToString();

            MessageBox.Show($"License Renewed Successfully with License ID = {_NewLicenseId}",
                "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

    
            ctrDriverLicenseInfoWithFilterscs1.FilterEnabled = false;
            linklblShowNewLicenseInfo.Enabled = true;
        }

        private void linklblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseId);
            frm.ShowDialog();
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personId = ctrDriverLicenseInfoWithFilterscs1.License.DriverInfo.PersonInfo.PersonDTO.PersonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personId);
             frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

