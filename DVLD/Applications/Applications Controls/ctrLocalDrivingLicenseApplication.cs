using DVLD.Licenses;
using DVLD.Licenses.License_controls;
using DVLD.People;
using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.Applications_Controls
{
    public partial class ctrLocalDrivingLicenseApplication : UserControl
    {
        private clsLocalDrivingLicensecs _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _LicenseID = -1;

        public int LocalDrivingLicenseApplicationID => _LocalDrivingLicenseApplicationID;// get method
        public int ApplicationID => _LocalDrivingLicenseApplication?.ApplicationDTO?.ApplicationID ?? -1; // get method
        public clsLocalDrivingLicensecs SelectedLocalDrivingLicenseAppInfo => _LocalDrivingLicenseApplication;

        public ctrLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        public void ResetDefaultValues()
        {
            _LocalDrivingLicenseApplicationID = -1;
            _LocalDrivingLicenseApplication = null;
            _LicenseID = -1;

            // Driving License Application Info
            lblL_D_App_ID.Text = "[???]";
            lblLicenseClass.Text = "[???]";
            lblPassedTests.Text = "0/3";
            linklblLicenseInfo.Enabled = false;

            // Application Basic Info
            lblAppID.Text = "[???]";
            lblStatues.Text = "[???]";
            lblApplicationFees.Text = "[$$$]";
            lblType.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblAppDate.Text = "[??/??/????]";
            lblLastStatuesDate.Text = "[??/??/????]";
            lblCreatedBy.Text = "[???]";
            LinklblPersonInfo.Enabled = false;
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int localDrivingLicenseApplicationId)
        {
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationId;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicensecs.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetDefaultValues();
                MessageBox.Show($"No Local Driving License Application found with ID = {localDrivingLicenseApplicationId}",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _FillApplicationInfo();
        }

        private string _GetStatusString(byte status)
        {
            switch ((clsApplicationDTO.enApplicationStatus)status)
            {
                case clsApplicationDTO.enApplicationStatus.New:
                    return "New";
                case clsApplicationDTO.enApplicationStatus.Cancelled:
                    return "Cancelled";
                case clsApplicationDTO.enApplicationStatus.Completed:
                    return "Completed";
                default:
                    return "Unknown";
            }
        }

        private void _FillApplicationInfo()
        {
            // 1. Top Section: Local Driving License Application Info
            lblL_D_App_ID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo?.clsLicenseClassDTO?.ClassName ?? "[Unknown]";

            // Passed tests count (Vision, Written, Street -> Out of 3)
            //  int passedTests = clsLocalDrivingLicensecs.GetPassedTestCount(_LocalDrivingLicenseApplicationID);// not implemented yet
            // lblPassedTests.Text = $"{passedTests}/3";

            // License Link (enabled only if the license was issued)
            //  _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID(); not implemented yet
            // llShowLicenseInfo.Enabled = (_LicenseID != -1);

            // 2. Bottom Section: Base Application Info
            byte passedTests = _LocalDrivingLicenseApplication.GetPassedTestCount();
            lblPassedTests.Text = $"{passedTests}/3";
            lblAppID.Text = _LocalDrivingLicenseApplication.ApplicationDTO.ApplicationID.ToString();
            lblStatues.Text = _GetStatusString(_LocalDrivingLicenseApplication.ApplicationDTO.ApplicationStatus);
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.ApplicationDTO.PaidFees.ToString("0.00");
            lblType.Text = _LocalDrivingLicenseApplication.ApplicationTypeInfo?.DTO?.ApplicationTypeTitle ?? "New Driving License";
            lblApplicant.Text = _LocalDrivingLicenseApplication.PersonInfo?.PersonDTO?.FullName() ?? "[Unknown]";
            lblAppDate.Text = _LocalDrivingLicenseApplication.ApplicationDTO.ApplicationDate.ToString("dd/MMM/yyyy");
            lblLastStatuesDate.Text = _LocalDrivingLicenseApplication.ApplicationDTO.LastStatusDate.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo?.UserDTO?.UserName ?? "[Unknown]";
            

            LinklblPersonInfo.Enabled = (_LocalDrivingLicenseApplication.ApplicationDTO.ApplicantPersonID > 0);
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LocalDrivingLicenseApplication?.ApplicationDTO?.ApplicantPersonID > 0)
            {
                frmShowPersonInfo frm = new frmShowPersonInfo(_LocalDrivingLicenseApplication.ApplicationDTO.ApplicantPersonID);
                frm.ShowDialog();

                // Refresh control data in case person info changed

                     if(frm.ShowDialog() == DialogResult.OK)
                {
                    LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
                }
                   
            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LicenseID != -1)
            {
                // Hook up your license card dialog once implemented:
                // frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
                // frm.ShowDialog();
                MessageBox.Show($"Opening License ID: {_LicenseID}", "License Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gbDrivingLicenseAppInfo_Enter(object sender, EventArgs e)
        {

        }

        private void linklblLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseClassInfo frm = new frmShowLicenseClassInfo(_LocalDrivingLicenseApplication.LicenseClassInfo?.clsLicenseClassDTO?.LicenseClassID ?? -1);
            frm.ShowDialog();
        }

        private void LinklblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_LocalDrivingLicenseApplication.ApplicationDTO.ApplicantPersonID);    
            frm.ShowDialog();   
        }

        private void gbAppBasicInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}