
using DVLD.GlobalClasses;
using DVLD.Licenses;
using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _SelectedLicenseId = -1;
        private int _ApplicationID = -1;

        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicenseApplication(int licenseId)
        {
            InitializeComponent();
            _SelectedLicenseId = licenseId;
        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
           lblDetainId.Text = "[???]";
            lblDetainDate.Text = "[??/??/????]";
            lblApplicationId.Text = "[???]";
            lblFinefees.Text = "[$$$]";
            lblTotalfees.Text = "[$$$]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserDTO.UserName;

         
            decimal appFees = clsApplicationTypes
                .Find((int)clsApplicationDTO.enApplicationType.ReleaseDetainedDrivingLicsense)
                .DTO.ApplicationFees;

            lblApplicationfees.Text = appFees.ToString("0.00");

           
            btnRelease.Enabled = false;
            linklblShowNewLicenseInfo.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;

         
            ctrDriverLicenseInfoWithFilterscs1.OnLicenseSelected += ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected;

          
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
                btnRelease.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;
                return;
            }

            clsLicense selectedLicense = ctrDriverLicenseInfoWithFilterscs1.License;

            
            linklblShowLicenseHistory.Enabled = true;

            if (!selectedLicense.IsDetained)
            {
                MessageBox.Show("Selected license is NOT detained. Please select a detained license.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRelease.Enabled = false;
                return;
            }

           
            lblDetainId.Text = selectedLicense.DetainedInfo.DetainedLicenseDTO.DetainID.ToString();
            lblDetainDate.Text = selectedLicense.DetainedInfo.DetainedLicenseDTO.DetainDate.ToString("dd/MMM/yyyy");
            lblFinefees.Text = selectedLicense.DetainedInfo.DetainedLicenseDTO.FineFees.ToString("0.00");

            decimal appFees = Convert.ToDecimal(lblApplicationfees.Text);
            decimal totalFees = appFees + selectedLicense.DetainedInfo.DetainedLicenseDTO.FineFees;
            lblTotalfees.Text = totalFees.ToString("0.00");

            btnRelease.Enabled = true;
        }

        

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained license?",
               "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            btnRelease.Enabled = false;


            bool isReleased = ctrDriverLicenseInfoWithFilterscs1.License.ReleaseDetainedLicense(
                clsGlobal.CurrentUser.UserDTO.UserID,
                ref _ApplicationID
            );

            if (!isReleased)
            {
                MessageBox.Show("Failed to release the detained license.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = true;
                return;
            }


            lblApplicationId.Text = _ApplicationID.ToString();

            MessageBox.Show($"Detained License released successfully with Application ID = {_ApplicationID}",
                "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ctrDriverLicenseInfoWithFilterscs1.FilterEnabled = false;
            linklblShowNewLicenseInfo.Enabled = true;
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
    }
}

