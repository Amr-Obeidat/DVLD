using DVLD.GlobalClasses;
using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssueDrivingLicense : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicensecs _LocalDrivingLicenseApplication;
        private bool _IsLoaded = false;
        public frmIssueDrivingLicense(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            if (_IsLoaded)
                return;

            _IsLoaded = true;

            txtNotes.Focus();

           
            ctrLocalDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            _LocalDrivingLicenseApplication = ctrLocalDrivingLicenseApplication1.SelectedLocalDrivingLicenseAppInfo;

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No application found with ID = {_LocalDrivingLicenseApplicationID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

           
            if (_LocalDrivingLicenseApplication.GetPassedTestCount() < 3)
            {
                MessageBox.Show("Applicant must pass all 3 tests before issuing a license.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnIssue.Enabled = false;
                return;
            }

          
            if (_LocalDrivingLicenseApplication.ApplicationDTO.ApplicationStatus == (byte)clsApplicationDTO.enApplicationStatus.Completed)
            {
                MessageBox.Show("This application has already been completed and a license is issued.",
                    "Already Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                return;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license for this application?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            
            int licenseID = _LocalDrivingLicenseApplication.IssueLicenseForFirstTime(
                txtNotes.Text.Trim(),
                clsGlobal.CurrentUser.UserDTO.UserID
            );

            if (licenseID != -1)
            {
                MessageBox.Show($"License Issued Successfully with License ID = {licenseID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnIssue.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to issue driving license.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrLocalDrivingLicenseApplication1_Load(object sender, EventArgs e)
        {
        }
    }
}
