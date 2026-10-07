using DVLD.Drivers;

using DVLD.People;
using DVLD_Business.Drivers;
using DVLD_Business.Licenses;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Licenses.International_Licenses
{
    public partial class frmListInternationalLicenses : Form
    {
        private DataTable _dtAllInternationalLicenses;

        public static class InternationalLicensesColumns
        {
            public const string FILTER_NONE = "None";
            public const string FILTER_INT_LICENSE_ID = "International License ID";
            public const string FILTER_APPLICATION_ID = "Application ID";
            public const string FILTER_DRIVER_ID = "Driver ID";
            public const string FILTER_LOCAL_LICENSE_ID = "Local License ID";
            public const string FILTER_IS_ACTIVE = "Is Active";

            public const string colInternationalLicenseId = "InternationalLicenseID";
            public const string colApplicationId = "ApplicationID";
            public const string colDriverId = "DriverID";
            public const string colIssuedUsingLocalLicenseId = "IssuedUsingLocalLicenseID";
            public const string colIssueDate = "IssueDate";
            public const string colExpirationDate = "ExpirationDate";
            public const string colIsActive = "IsActive";
        }

        public frmListInternationalLicenses()
        {
            InitializeComponent();
        }

        private string GetSelectedColumnName(string filterColumnText)
        {
            switch (filterColumnText)
            {
                case InternationalLicensesColumns.FILTER_INT_LICENSE_ID:
                    return InternationalLicensesColumns.colInternationalLicenseId;

                case InternationalLicensesColumns.FILTER_APPLICATION_ID:
                    return InternationalLicensesColumns.colApplicationId;

                case InternationalLicensesColumns.FILTER_DRIVER_ID:
                    return InternationalLicensesColumns.colDriverId;

                case InternationalLicensesColumns.FILTER_LOCAL_LICENSE_ID:
                    return InternationalLicensesColumns.colIssuedUsingLocalLicenseId;

                case InternationalLicensesColumns.FILTER_IS_ACTIVE:
                    return InternationalLicensesColumns.colIsActive;

                default:
                    return InternationalLicensesColumns.FILTER_NONE;
            }
        }

        private void _RefreshInternationalLicensesList()
        {
            _dtAllInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();

            dgvInternational.DataSource = _dtAllInternationalLicenses.DefaultView;
            lblNumOfRecords.Text = _dtAllInternationalLicenses.DefaultView.Count.ToString();

            if (dgvInternational.Rows.Count > 0)
            {
                dgvInternational.Columns[InternationalLicensesColumns.colInternationalLicenseId].HeaderText = "Int.License ID";
                dgvInternational.Columns[InternationalLicensesColumns.colInternationalLicenseId].Width = 120;

                dgvInternational.Columns[InternationalLicensesColumns.colApplicationId].HeaderText = "Application ID";
                dgvInternational.Columns[InternationalLicensesColumns.colApplicationId].Width = 110;

                dgvInternational.Columns[InternationalLicensesColumns.colDriverId].HeaderText = "Driver ID";
                dgvInternational.Columns[InternationalLicensesColumns.colDriverId].Width = 100;

                dgvInternational.Columns[InternationalLicensesColumns.colIssuedUsingLocalLicenseId].HeaderText = "L.License ID";
                dgvInternational.Columns[InternationalLicensesColumns.colIssuedUsingLocalLicenseId].Width = 110;

                dgvInternational.Columns[InternationalLicensesColumns.colIssueDate].HeaderText = "Issue Date";
                dgvInternational.Columns[InternationalLicensesColumns.colIssueDate].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvInternational.Columns[InternationalLicensesColumns.colIssueDate].Width = 160;

                dgvInternational.Columns[InternationalLicensesColumns.colExpirationDate].HeaderText = "Expiration Date";
                dgvInternational.Columns[InternationalLicensesColumns.colExpirationDate].DefaultCellStyle.Format = "dd/MMM/yyyy";
                dgvInternational.Columns[InternationalLicensesColumns.colExpirationDate].Width = 160;

                dgvInternational.Columns[InternationalLicensesColumns.colIsActive].HeaderText = "Is Active";
                dgvInternational.Columns[InternationalLicensesColumns.colIsActive].Width = 90;
            }
        }

        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshInternationalLicensesList();

            cbFilterList.Items.Clear();
            cbFilterList.Items.Add(InternationalLicensesColumns.FILTER_NONE);
            cbFilterList.Items.Add(InternationalLicensesColumns.FILTER_INT_LICENSE_ID);
            cbFilterList.Items.Add(InternationalLicensesColumns.FILTER_APPLICATION_ID);
            cbFilterList.Items.Add(InternationalLicensesColumns.FILTER_DRIVER_ID);
            cbFilterList.Items.Add(InternationalLicensesColumns.FILTER_LOCAL_LICENSE_ID);
            cbFilterList.Items.Add(InternationalLicensesColumns.FILTER_IS_ACTIVE);

            cbFilterList.SelectedIndex = 0;
        }

        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible =
                (cbFilterList.Text != InternationalLicensesColumns.FILTER_NONE);

            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }
            else
            {
                _dtAllInternationalLicenses.DefaultView.RowFilter = "";
                dgvInternational.DataSource = _dtAllInternationalLicenses.DefaultView;
                lblNumOfRecords.Text =
                    _dtAllInternationalLicenses.DefaultView.Count.ToString();
            }
        }

     

        private void dgvInternational_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvInternational.ClearSelection();
                dgvInternational.Rows[e.RowIndex].Selected = true;
            }
        }

        private void cmsInternationalInfo_Opening(object sender, CancelEventArgs e)
        {
            if (dgvInternational.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void showPeronInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverId = Convert.ToInt32(
                dgvInternational.SelectedRows[0]
                .Cells[InternationalLicensesColumns.colDriverId]
                .Value);

            clsDriver driver = clsDriver.Find(driverId);

            if (driver != null)
            {
                frmShowPersonInfo frm =
                    new frmShowPersonInfo(driver.DriverDTO.PersonID);

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Could not find the driver associated with this license.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int internationalLicenseId = Convert.ToInt32(
                dgvInternational.SelectedRows[0]
                .Cells[InternationalLicensesColumns.colInternationalLicenseId]
                .Value);

            frmShowInternationalLicenseInfo frm =  new frmShowInternationalLicenseInfo(internationalLicenseId);

            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverId = Convert.ToInt32(
                dgvInternational.SelectedRows[0]
                .Cells[InternationalLicensesColumns.colDriverId]
                .Value);

            clsDriver driver = clsDriver.Find(driverId);

            if (driver != null)
            {
                frmShowPersonLicenseHistory frm =
                    new frmShowPersonLicenseHistory(driver.DriverDTO.PersonID);

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Could not find driver license history.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterBy_TextChanged_1(object sender, EventArgs e)
        {
            string filterColumn = cbFilterList.Text.Trim();
            string filterValue = txtFilterBy.Text.Trim();

            if (string.IsNullOrEmpty(filterValue) ||
                string.IsNullOrEmpty(filterColumn) ||
                filterColumn == InternationalLicensesColumns.FILTER_NONE)
            {
                _dtAllInternationalLicenses.DefaultView.RowFilter = "";
                dgvInternational.DataSource = _dtAllInternationalLicenses.DefaultView;
                lblNumOfRecords.Text =
                    _dtAllInternationalLicenses.DefaultView.Count.ToString();

                return;
            }

            string selectedColumn = GetSelectedColumnName(filterColumn);

            if (selectedColumn == InternationalLicensesColumns.colInternationalLicenseId ||
                selectedColumn == InternationalLicensesColumns.colApplicationId ||
                selectedColumn == InternationalLicensesColumns.colDriverId ||
                selectedColumn == InternationalLicensesColumns.colIssuedUsingLocalLicenseId)
            {
                if (int.TryParse(filterValue, out int numericVal))
                {
                    _dtAllInternationalLicenses.DefaultView.RowFilter =
                        $"CONVERT([{selectedColumn}], 'System.String') LIKE '{filterValue}%'";
                }
                else
                {
                    _dtAllInternationalLicenses.DefaultView.RowFilter = "1 = 0";
                }
            }
            else if (selectedColumn == InternationalLicensesColumns.colIsActive)
            {
                if (filterValue.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                    filterValue == "1")
                {
                    _dtAllInternationalLicenses.DefaultView.RowFilter =
                        $"[{selectedColumn}] = 1";
                }
                else if (filterValue.Equals("no", StringComparison.OrdinalIgnoreCase) ||
                         filterValue == "0")
                {
                    _dtAllInternationalLicenses.DefaultView.RowFilter =
                        $"[{selectedColumn}] = 0";
                }
                else
                {
                    _dtAllInternationalLicenses.DefaultView.RowFilter = "1 = 0";
                }
            }
            else
            {
                string safeValue = filterValue.Replace("'", "''");

                _dtAllInternationalLicenses.DefaultView.RowFilter =
                    $"[{selectedColumn}] LIKE '{safeValue}%'";
            }

            dgvInternational.DataSource = _dtAllInternationalLicenses.DefaultView;
            lblNumOfRecords.Text =
                _dtAllInternationalLicenses.DefaultView.Count.ToString();
        }

        private void txtFilterBy_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cbFilterList.Text == InternationalLicensesColumns.FILTER_INT_LICENSE_ID ||
               cbFilterList.Text == InternationalLicensesColumns.FILTER_APPLICATION_ID ||
               cbFilterList.Text == InternationalLicensesColumns.FILTER_DRIVER_ID ||
               cbFilterList.Text == InternationalLicensesColumns.FILTER_LOCAL_LICENSE_ID)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}