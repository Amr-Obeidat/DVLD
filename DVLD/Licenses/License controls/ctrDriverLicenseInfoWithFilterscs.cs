using DVLD_Business.Licenses;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Licenses.License_controls
{
    public partial class ctrDriverLicenseInfoWithFilterscs : UserControl
    {
        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int licenseId)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(licenseId);
            }
        }

        private bool _FilterEnabled = true;

        public int LicenseId => ctrDriverLicenseInfo1.LicenseID;

        public clsLicense License => ctrDriverLicenseInfo1.SelectedLicenseInfo;

        public bool FilterEnabled
        {
            get => _FilterEnabled;
            set
            {
                _FilterEnabled = value;
                gbDriverLicenseFilter.Enabled = _FilterEnabled;
            }
        }

        public ctrDriverLicenseInfoWithFilterscs()
        {
            InitializeComponent();
        }

        public void LoadInfo(int licenseId)
        {
            txtLicenseId.Text = licenseId.ToString();
            ctrDriverLicenseInfo1.LoadInfo(licenseId);

            if (OnLicenseSelected != null && FilterEnabled)
            {
                OnLicenseSelected(ctrDriverLicenseInfo1.LicenseID);
            }
        }

        public void txtLicenseIdFocus()
        {
            txtLicenseId.Focus();
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Hover over the red icon to see the error.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int enteredLicenseId = int.Parse(txtLicenseId.Text.Trim());
            LoadInfo(enteredLicenseId);
        }

        private void txtLicenseId_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseId.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseId, "License ID cannot be empty!");
            }
            else if (!int.TryParse(txtLicenseId.Text.Trim(), out _))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseId, "License ID should only contain numbers!");
            }
            else
            {
                errorProvider1.SetError(txtLicenseId, null);
            }
        }

        private void txtLicenseId_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

           
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnFindLicense.PerformClick();
            }
        }

        private void txtLicenseId_TextChanged(object sender, EventArgs e)
        {
        }

        private void ctrDriverLicenseInfo1_Load(object sender, EventArgs e)
        {
        }
    }
}