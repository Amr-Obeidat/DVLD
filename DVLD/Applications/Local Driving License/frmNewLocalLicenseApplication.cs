using DVLD.GlobalClasses;
using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmNewLocalLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, ShowInfo = 1 }

        private enMode _Mode = enMode.AddNew;
        private int _LocalDrivingLicenseApplicationId = -1;
        private int _SelectedPersonId = -1;
        private clsLocalDrivingLicensecs _LocalDrivingLicenseApplication;

        public frmNewLocalLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            ctrPersonCardWithFiltercs1.EnableEditPerson = false;
        }

        public frmNewLocalLicenseApplication(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            _Mode = enMode.ShowInfo;
        }

        private void _FillLicenseClassesInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            cbLicenseClass.DataSource = dtLicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicensecs();
                tbAppInfo.Enabled = false;
                btnSave.Enabled = false;

                cbLicenseClass.SelectedIndex = 2; // Default to Ordinary Driving License (Class 3)
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplicationDTO.enApplicationType.NewDrivingLicense).DTO.ApplicationFees.ToString("0.00");
                lblAppDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserDTO.UserName;
                lblL_D_App_ID.Text = "[????]";
            }
            else
            {
                lblTitle.Text = "Local Driving License Application Info";
                this.Text = "Local Driving License Application Info";

                tbAppInfo.Enabled = true;
                btnSave.Enabled = false;
                btnSave.Visible = false;
                cbLicenseClass.Enabled = false;
            }
        }

        private void _LoadData()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicensecs.Find(_LocalDrivingLicenseApplicationId);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Application with ID = {_LocalDrivingLicenseApplicationId} was found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            // Lock person card to view-only
            _SelectedPersonId = _LocalDrivingLicenseApplication.ApplicationDTO.ApplicantPersonID;
            ctrPersonCardWithFiltercs1.LoadPersonInfo(_SelectedPersonId);
            ctrPersonCardWithFiltercs1.FilterEnabled = false;
            
            ctrPersonCardWithFiltercs1.ShowAddPerson = false;
            ctrPersonCardWithFiltercs1.EnableEditPerson = false;
        

            // Load Application Details
            lblL_D_App_ID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID.ToString();
            lblAppDate.Text = _LocalDrivingLicenseApplication.ApplicationDTO.ApplicationDate.ToString("dd/MMM/yyyy");
            cbLicenseClass.SelectedValue = _LocalDrivingLicenseApplication.LocalDrivingLicenseDTO.LicenseClassId;
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.ApplicationDTO.PaidFees.ToString("0.00");
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo?.UserDTO?.UserName ?? "[Unknown]";
        }

        private void frmNewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.ShowInfo)
            {
                _LoadData();
            }
            _UpdateNavigationButtons();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.ShowInfo)
            {
                tbAppInfo.Enabled = true;
                tcAppInfo.SelectedTab = tbAppInfo;
                return;
            }

            if (ctrPersonCardWithFiltercs1.PersonId != -1)
            {
                btnSave.Enabled = true;
                tbAppInfo.Enabled = true;
                tcAppInfo.SelectedTab = tbAppInfo;
            }
            else
            {
                MessageBox.Show("Please select a person first.", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonCardWithFiltercs1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int licenseClassId = (int)cbLicenseClass.SelectedValue;

            int activeApplicationId = clsLocalDrivingLicensecs.GetActiveApplicationForLicenseClass(
                ctrPersonCardWithFiltercs1.PersonId,
                (int)clsApplicationDTO.enApplicationType.NewDrivingLicense,
                licenseClassId
            );

            if (activeApplicationId != -1)
            {
                MessageBox.Show($"This person already has an active application for this license class with ID = {activeApplicationId}!",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Populate base application DTO
            _LocalDrivingLicenseApplication.ApplicationDTO.ApplicantPersonID = ctrPersonCardWithFiltercs1.PersonId;
            _LocalDrivingLicenseApplication.ApplicationDTO.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationDTO.ApplicationTypeID = (int)clsApplicationDTO.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationDTO.ApplicationStatus = (byte)clsApplicationDTO.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.ApplicationDTO.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationDTO.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.ApplicationDTO.CreatedByUserID = clsGlobal.CurrentUser.UserDTO.UserID;

            // Populate derived local application DTO
            _LocalDrivingLicenseApplication.LocalDrivingLicenseDTO.LicenseClassId = licenseClassId;

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblL_D_App_ID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID.ToString();

                // Transition mode from AddNew to ShowInfo
                _Mode = enMode.ShowInfo;
                lblTitle.Text = "Local Driving License Application Info";
                this.Text = "Local Driving License Application Info";

                btnSave.Enabled = false;
                btnSave.Visible = false;
                cbLicenseClass.Enabled = false;
                ctrPersonCardWithFiltercs1.FilterEnabled = false;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string errorMessage = !string.IsNullOrEmpty(_LocalDrivingLicenseApplication.LocalDrivingLicenseDTO.LastValidationError)
                    ? _LocalDrivingLicenseApplication.LocalDrivingLicenseDTO.LastValidationError
                    : "Data was not saved successfully.";

                MessageBox.Show($"Error: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewLocalLicenseApplication_Activated(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                ctrPersonCardWithFiltercs1.FilterFocus();
            }
        }
        private void _UpdateNavigationButtons()
        {
          
            if (tcAppInfo.SelectedIndex == 0)
            {
                btnBack.Enabled = false;
                btnBack.Visible = false; 

                btnNext.Enabled = true;
                btnNext.Visible = true;
            }
            else if (tcAppInfo.SelectedIndex == 1)
            {
                btnBack.Enabled = true;
                btnBack.Visible = true;

                btnNext.Enabled = false;
                btnNext.Visible = false; 
            }
        }
        private void tcAppInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
             if(tcAppInfo.SelectedIndex == 1 && _Mode == enMode.AddNew && ctrPersonCardWithFiltercs1.PersonId == -1)
            {
                MessageBox.Show("Please select a person first.", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonCardWithFiltercs1.FilterFocus();
                tcAppInfo.SelectedIndex = 0;
            }
            _UpdateNavigationButtons();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAppInfo.SelectedIndex = 0;    
        }
    }
}