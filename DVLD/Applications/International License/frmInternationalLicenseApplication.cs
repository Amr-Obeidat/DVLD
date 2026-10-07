using DVLD.GlobalClasses;
using DVLD.Licenses;

using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.International_License
{
    public partial class frmInternationalLicenseApplication : Form
    {
        private int _InternationalLicenseID = -1;

        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
           
            ctrDriverLicenseInfoWithFilterscs1.OnLicenseSelected += ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected;

           
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
         
            lblExpierationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserDTO.UserName;

           
            decimal appFees = clsApplicationTypes
                .Find((int)clsApplicationDTO.enApplicationType.NewInternationalLicense)
                .DTO.ApplicationFees;

            lblApplicationfees.Text = appFees.ToString("0.00");

            lblApplicationId.Text = "[???]";
            
            lblDetainId.Text = "[???]";

        
            linklblShowNewLicenseInfo.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;

            ctrDriverLicenseInfoWithFilterscs1.txtLicenseIdFocus();
        }

        private void ctrDriverLicenseInfoWithFilterscs1_OnLicenseSelected(int licenseId)
        {
            int selectedLicenseId = licenseId;

            if (selectedLicenseId == -1)
            {
                btnIssue.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;
                return;
            }

            clsLicense selectedLicense = ctrDriverLicenseInfoWithFilterscs1.License;

         
            linklblShowLicenseHistory.Enabled = true;

            if (!selectedLicense.LicenseDTO.IsActive)
            {
                MessageBox.Show(
                    "Selected License is not active. You can only issue an international license for an active license.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssue.Enabled = false;
                return;
            }

          
            if (selectedLicense.LicenseDTO.LicenseClassID != 3)
            {
                MessageBox.Show(
                    "Selected License must be Class 3 (Ordinary driving license) to issue an International License.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssue.Enabled = false;
                return;
            }

           
            if (selectedLicense.IsDetained)
            {
                MessageBox.Show(
                    "Selected License is detained. You cannot issue an international license for a detained license.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssue.Enabled = false;
                return;
            }

            if (selectedLicense.LicenseDTO.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show(
                    "Selected License is expired. Please renew the local license first.",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssue.Enabled = false;
                return;
            }

            int activeInternationalLicenseID =
                clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(
                    selectedLicense.LicenseDTO.DriverID);

            if (activeInternationalLicenseID != -1)
            {
                MessageBox.Show(
                    $"Person already has an active International License with ID = {activeInternationalLicenseID}",
                    "Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                _InternationalLicenseID = activeInternationalLicenseID;
                lblDetainId.Text = _InternationalLicenseID.ToString();
                linklblShowNewLicenseInfo.Enabled = true;
                btnIssue.Enabled = false;
                return;
            }

          
            btnIssue.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to issue an International License for this driver?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            btnIssue.Enabled = false;

            clsLicense selectedLicense = ctrDriverLicenseInfoWithFilterscs1.License;

        
            clsInternationalLicense internationalLicense = new clsInternationalLicense();

           
            internationalLicense.InternationalLicenseDTO.DriverID =
                selectedLicense.LicenseDTO.DriverID;

            internationalLicense.InternationalLicenseDTO.IssuedUsingLocalLicenseID =
                selectedLicense.LicenseDTO.LicenseID;

            internationalLicense.InternationalLicenseDTO.IssueDate =
                DateTime.Now;

            internationalLicense.InternationalLicenseDTO.ExpirationDate =
                DateTime.Now.AddYears(1);

            internationalLicense.InternationalLicenseDTO.IsActive = true;

            internationalLicense.InternationalLicenseDTO.CreatedByUserID =
                clsGlobal.CurrentUser.UserDTO.UserID;

            // Pass the DriverInfo so the Base Application can resolve PersonID inside Save()
            internationalLicense.DriverInfo = selectedLicense.DriverInfo;

            if (!internationalLicense.Save())
            {
                MessageBox.Show(
                    string.IsNullOrEmpty(internationalLicense.InternationalLicenseDTO.LastValidationError)
                        ? "Failed to issue the international license."
                        : internationalLicense.InternationalLicenseDTO.LastValidationError,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssue.Enabled = true;
                return;
            }

         
            lblApplicationId.Text =
                internationalLicense.InternationalLicenseDTO.ApplicationID.ToString();

            _InternationalLicenseID =
                internationalLicense.InternationalLicenseDTO.InternationalLicenseID;

            lblDetainId.Text = _InternationalLicenseID.ToString();

            MessageBox.Show(
                $"International License Issued Successfully with ID = {_InternationalLicenseID}",
                "Succeeded",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ctrDriverLicenseInfoWithFilterscs1.FilterEnabled = false;
            linklblShowNewLicenseInfo.Enabled = true;
        }

        private void linklblShowNewLicenseInfo_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
        //    frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);

           //frm.ShowDialog();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblShowLicenseHistory_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personId =
               ctrDriverLicenseInfoWithFilterscs1
               .License
               .DriverInfo
               .PersonInfo
               .PersonDTO
               .PersonID;

            frmShowPersonLicenseHistory frm =
                new frmShowPersonLicenseHistory(personId);

            frm.ShowDialog();

        }
    }
}