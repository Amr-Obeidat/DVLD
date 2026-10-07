using DVLD.Properties;
using DVLD_Business.Drivers;
using DVLD_Business.Licenses;
using DVLD_Business.People;
using System;
using System.IO;
using System.Windows.Forms;
using DVLD.Properties;
using System.Web.UI.WebControls;
namespace DVLD.Licenses.License_controls
{
    public partial class ctrDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        private clsLicense _License;

        public int LicenseID => _LicenseID;
        public clsLicense SelectedLicenseInfo => _License;

        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void ResetDefaultValues()
        {
            _LicenseID = -1;
            _License = null;

            lblclass.Text = "[???]";
            lblName.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGender.Text = "[???]";
            lblIssueDate.Text = "[??/??/????]";
            lblIssueReason.Text = "[???]";
            lblNotes.Text = "[???]";

            lblIsActive.Text = "[???]";
            lblDateOfBirth.Text = "[??/??/????]";
            lblDriverId.Text = "[???]";
            lblExpirationDate.Text = "[??/??/????]";
            lblIsDetained.Text = "[???]";

            pbPersonImage.Image = global::DVLD.Properties.Resources.Male_512;
        }

        public void LoadInfo(int licenseID)
        {
            _LicenseID = licenseID;
            _License = clsLicense.Find(_LicenseID);

            if (_License == null)
            {
                ResetDefaultValues();
                MessageBox.Show($"Could not find License with ID = {licenseID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLicenseInfo();
        }

        private string _GetIssueReasonText(clsLicenseDTO.enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case clsLicenseDTO.enIssueReason.FirstTime:
                    return "First Time";

                case clsLicenseDTO.enIssueReason.Renew:
                    return "Renew";

                case clsLicenseDTO.enIssueReason.ReplacementForDamaged:
                    return "Replacement for Damaged";

                case clsLicenseDTO.enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";

                default:
                    return "Unknown";
            }
        }

      
        private void _LoadPersonImage() { 

    string imagePath = _License?.DriverInfo?.PersonInfo?.PersonDTO?.ImagePath;

    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
    {
        pbPersonImage.ImageLocation = imagePath;
        return;
    }

    
    pbPersonImage.ImageLocation = null;

   
    var gender = _License?.DriverInfo?.PersonInfo?.PersonDTO?.Gender ?? 0;

    pbPersonImage.Image = (gender == 0)
        ? global::DVLD.Properties.Resources.Male_512
        : global::DVLD.Properties.Resources.Female_512;
}

        private void _FillLicenseInfo()
        {

            lblclass.Text = clsLicenseClass.Find(_License.LicenseDTO.LicenseClassID)?.clsLicenseClassDTO?.ClassName ?? "[Unknown]";
            lblName.Text = _License.DriverInfo?.PersonInfo?.PersonDTO?.FullName() ?? "[Unknown]";
            lblLicenseID.Text = _License.LicenseDTO.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo?.PersonInfo?.PersonDTO?.NationalNo ?? "[Unknown]";
            lblGender.Text = (_License.DriverInfo?.PersonInfo?.PersonDTO?.Gender == 0)? "Male": "Female";

            lblIssueDate.Text = _License.LicenseDTO.IssueDate.ToString("dd/MMM/yyyy");
            lblIssueReason.Text = _GetIssueReasonText(_License.LicenseDTO.IssueReason);
            lblNotes.Text = string.IsNullOrWhiteSpace(_License.LicenseDTO.Notes)? "No Notes": _License.LicenseDTO.Notes;
       
            lblIsActive.Text = _License.LicenseDTO.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.DriverInfo?.PersonInfo?.PersonDTO?.DateOfBirth.ToString("dd/MMM/yyyy") ?? "[??/??/????]";
            lblDriverId.Text = _License.LicenseDTO.DriverID.ToString();
            lblExpirationDate.Text = _License.LicenseDTO.ExpirationDate.ToString("dd/MMM/yyyy");            
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";

            
            _LoadPersonImage();
        }

        private void ctrDriverLicenseInfo_Load(object sender, EventArgs e)
        {
        }

        private void pbClassDescription_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}