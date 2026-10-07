using DVLD_Business.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD.Licenses.License_controls
{
    public partial class ctrlLicenseClassInfo : UserControl
    {
        private int _LicenseClassID = -1;
        private clsLicenseClass _LicenseClassInfo;

        public int LicenseClassID => _LicenseClassID;
        public clsLicenseClass SelectedLicenseClassInfo => _LicenseClassInfo;

        public ctrlLicenseClassInfo()
        {
            InitializeComponent();
        }

        public void ResetDefaultValues()
        {
            _LicenseClassID = -1;
            _LicenseClassInfo = null;

            lblLicenseClassName.Text = "[???]";
            lblMinimumAllowedAge.Text = "[???]";
            lblDefaultValidityLength.Text = "[???]";
            lblClassFees.Text = "[???]";
         
        }

        private void _FillLicenseClassInfo()
        {
            _LicenseClassID = _LicenseClassInfo.clsLicenseClassDTO.LicenseClassID;

            
            lblLicenseClassName.Text = _LicenseClassInfo.clsLicenseClassDTO?.ClassName ?? _LicenseClassInfo.clsLicenseClassDTO.ClassName;
            lblMinimumAllowedAge.Text = (_LicenseClassInfo.clsLicenseClassDTO?.MinimumAllowedAge ?? _LicenseClassInfo.clsLicenseClassDTO.MinimumAllowedAge).ToString();
            lblDefaultValidityLength.Text = $"{_LicenseClassInfo.clsLicenseClassDTO?.DefaultValidityLength ?? _LicenseClassInfo.clsLicenseClassDTO.DefaultValidityLength} Years";
            lblClassFees.Text = (_LicenseClassInfo.clsLicenseClassDTO?.ClassFees ?? _LicenseClassInfo.clsLicenseClassDTO.ClassFees).ToString("0.00");
            txtLicenseClassDescription.Text = _LicenseClassInfo.clsLicenseClassDTO?.ClassDescription ?? _LicenseClassInfo.clsLicenseClassDTO.ClassDescription;
        }

        public void LoadLicenseClassInfo(int licenseClassId)
        {
            _LicenseClassID = licenseClassId;
            _LicenseClassInfo = clsLicenseClass.Find(_LicenseClassID);

            if (_LicenseClassInfo == null)
            {
                ResetDefaultValues();
                MessageBox.Show($"License Class with ID = {licenseClassId} was not found.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _FillLicenseClassInfo();
        }

      

       
        private void ctrlLicenseClassInfo_Load(object sender, EventArgs e) { }
        private void lblMinimumAllowedAgetag_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void lblClassFeestag_Click(object sender, EventArgs e) { }
        private void lblClassDescription_Click(object sender, EventArgs e) { }
    }
}