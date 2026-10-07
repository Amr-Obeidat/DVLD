using DVLD.Controls;
using DVLD.Licenses;
using DVLD.Licenses.International_Licenses;
using DVLD_Business.Drivers;
using DVLD_Business.Licenses;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Drivers.Driver_Controls
{
    public partial class ctrDrivingLicense : UserControl
    {
        private int _DriverID = -1;
        private clsDriver _Driver;
        private DataTable _dtLocalDrivingLicenses;
        private DataTable _dtInternationalDrivingLicenses;

        public int DriverID => _DriverID;
        public clsDriver SelectedDriverInfo => _Driver;

        public ctrDrivingLicense()
        {
            InitializeComponent();
            
        }

        private void _LoadLocalLicenseInfo()
        {
           
            _dtLocalDrivingLicenses = clsLicense.GetDriverLicenses(_DriverID);
            dgvLocal.DataSource = _dtLocalDrivingLicenses;
            lblLocalnumcnt.Text = dgvLocal.Rows.Count.ToString();

            if (dgvLocal.Rows.Count > 0)
            {
                
                dgvLocal.Columns["LicenseID"].HeaderText = "Lic.ID";
                dgvLocal.Columns["LicenseID"].Width = 90;

                dgvLocal.Columns["ApplicationID"].HeaderText = "App.ID";
                dgvLocal.Columns["ApplicationID"].Width = 90;

                dgvLocal.Columns["ClassName"].HeaderText = "Class Name";
                dgvLocal.Columns["ClassName"].Width = 220;

                dgvLocal.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvLocal.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvLocal.Columns["IssueDate"].Width = 140;

                dgvLocal.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dgvLocal.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvLocal.Columns["ExpirationDate"].Width = 140;

                dgvLocal.Columns["IsActive"].HeaderText = "Is Active";
                dgvLocal.Columns["IsActive"].Width = 80;
            }
            
        }

        private void _LoadInternationalLicenseInfo()
        {
            
            _dtInternationalDrivingLicenses = clsInternationalLicense.GetDriverInternationalLicenses(_DriverID);
            dgvInternationalLicense.DataSource = _dtInternationalDrivingLicenses;
            lblInternationalnumcnt.Text = dgvInternationalLicense.Rows.Count.ToString();

            if (dgvInternationalLicense.Rows.Count > 0)
            {
                dgvInternationalLicense.Columns["InternationalLicenseID"].HeaderText = "Int.License ID";
                dgvInternationalLicense.Columns["InternationalLicenseID"].Width = 110;

                dgvInternationalLicense.Columns["ApplicationID"].HeaderText = "Application ID";
                dgvInternationalLicense.Columns["ApplicationID"].Width = 100;

                dgvInternationalLicense.Columns["IssuedUsingLocalLicenseID"].HeaderText = "Local Lic.ID";
                dgvInternationalLicense.Columns["IssuedUsingLocalLicenseID"].Width = 100;

                dgvInternationalLicense.Columns["IssueDate"].HeaderText = "Issue Date";
                dgvInternationalLicense.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvInternationalLicense.Columns["IssueDate"].Width = 140;

                dgvInternationalLicense.Columns["ExpirationDate"].HeaderText = "Expiration Date";
                dgvInternationalLicense.Columns["ExpirationDate"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvInternationalLicense.Columns["ExpirationDate"].Width = 140;

                dgvInternationalLicense.Columns["IsActive"].HeaderText = "Is Active";
                dgvInternationalLicense.Columns["IsActive"].Width = 80;
            }
        }

        public void LoadInfo(int driverId)
        {
            _DriverID = driverId;
            _Driver = clsDriver.Find(_DriverID);

            if (_Driver == null)
            {
                MessageBox.Show(
                    $"Could not find Driver with ID = {_DriverID}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Clear();
                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void LoadInfoByPersonID(int personId)
        {
            _Driver = clsDriver.FindByPersonID(personId);

            if (_Driver == null)
            {
                MessageBox.Show(
                    $"There is no driver record associated with Person ID = {personId}",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Clear();
                return;
            }

            _DriverID = _Driver.DriverDTO.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void Clear()
        {
            _dtLocalDrivingLicenses?.Clear();
            _dtInternationalDrivingLicenses?.Clear();

            lblLocalnumcnt.Text = "0";
            lblInternationalnumcnt.Text = "0";
        }

        private void gbDriver_Enter(object sender, EventArgs e)
        {
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (dgvLocal.CurrentRow == null || dgvLocal.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a license first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object cellValue = dgvLocal.CurrentRow.Cells["LicenseID"].Value;

            if (cellValue == null || cellValue == DBNull.Value)
            {
                MessageBox.Show("Invalid License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseId = Convert.ToInt32(cellValue);

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseId);
            frm.ShowDialog();

        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (dgvInternationalLicense.CurrentRow == null || dgvInternationalLicense.CurrentRow.Index < 0)
            {
                MessageBox.Show("Please select a license first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object cellValue = dgvInternationalLicense.CurrentRow.Cells["InternationalLicenseID"].Value;

            if (cellValue == null || cellValue == DBNull.Value)
            {
                MessageBox.Show("Invalid License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int InternationalLicenseId = Convert.ToInt32(cellValue);

            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseId);
            frm.ShowDialog();
        }
    }
}