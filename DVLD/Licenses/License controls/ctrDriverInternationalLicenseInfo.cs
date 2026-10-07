using DVLD.Properties;
using DVLD_Business.Licenses;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Licenses.License_controls
{
    public partial class ctrDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;

        public int InternationalLicenseID => _InternationalLicenseID;
        public clsInternationalLicense SelectedInternationalLicenseInfo => _InternationalLicense;

        public ctrDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            string imagePath = _InternationalLicense?.DriverInfo?.PersonInfo?.PersonDTO?.ImagePath;

           
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                pbPersonImage.ImageLocation = imagePath;
                return;
            }

         
            pbPersonImage.ImageLocation = null;

            var gender = _InternationalLicense?.DriverInfo?.PersonInfo?.PersonDTO?.Gender ?? 0;
            pbPersonImage.Image = (gender == 0)
                ?global::DVLD.Properties.Resources.Male_512
                : global::DVLD.Properties.Resources.Female_512;
        }

        public void LoadInfo(int internationalLicenseId)
        {
            _InternationalLicenseID = internationalLicenseId;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                ResetDefaultValues();
                MessageBox.Show($"Could not find International License with ID = {_InternationalLicenseID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            var person = _InternationalLicense.DriverInfo?.PersonInfo?.PersonDTO;

            lblName.Text = person?.FullName() ?? "[???]";
            lblNationalNo.Text = person?.NationalNo ?? "[???]";
            lblGender.Text = (person != null && person.Gender == 0) ? "Male" : "Female";
            lblDateOfBirth.Text = person?.DateOfBirth.ToString("dd/MMM/yyyy") ?? "[??/??/????]";
            lblDriverId.Text = _InternationalLicense.InternationalLicenseDTO.DriverID.ToString();

           
         
            lblLicenseID.Text = _InternationalLicense.InternationalLicenseDTO.InternationalLicenseID.ToString();

            lblIsActive.Text = _InternationalLicense.InternationalLicenseDTO.IsActive ? "Yes" : "No";
            lblIssueDate.Text = _InternationalLicense.InternationalLicenseDTO.IssueDate.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = _InternationalLicense.InternationalLicenseDTO.ExpirationDate.ToString("dd/MMM/yyyy");

            _LoadPersonImage();
        }

        public void ResetDefaultValues()
        {
            _InternationalLicenseID = -1;
            _InternationalLicense = null;

            lblName.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGender.Text = "[???]";
            lblIssueDate.Text = "[??/??/????]";
            lblIsActive.Text = "[???]";
            lblDateOfBirth.Text = "[??/??/????]";
            lblDriverId.Text = "[???]";
            lblExpirationDate.Text = "[??/??/????]";

            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = global::DVLD.Properties.Resources.Male_512;
        }

        private void ctrDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
        }

        private void gbDriverInfo_Enter(object sender, EventArgs e)
        {
        }
    }
}