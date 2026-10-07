using DVLD.Applications.Detained_License;
using DVLD.Licenses;
using DVLD.People;
using DVLD_Business.Licenses;
using DVLD_Business.People;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Licenses.Detain_License
{
    public partial class frmListDetainLicenses : Form
    {
        public static class DetainedLicensesColumns
        {
            public const string FILTER_NONE = "None";
            public const string FILTER_DETAIN_ID = "Detain ID";
            public const string FILTER_IS_RELEASED = "Is Released";
            public const string FILTER_NATIONAL_NO = "National No.";
            public const string FILTER_FULL_NAME = "Full Name";
            public const string FILTER_RELEASE_APP_ID = "Release App ID";

            public const string colDetainId = "DetainID";
            public const string colLicenseId = "LicenseID";
            public const string colNationalNo = "NationalNo";
            public const string colFullName = "FullName";
            public const string colDetainDate = "DetainDate";
            public const string colFineFees = "FineFees";
            public const string colIsReleased = "IsReleased";
            public const string colReleaseDate = "ReleaseDate";
            public const string colReleaseApplicationId = "ReleaseApplicationID";
        }

        private DataTable _dtAllDetainedLicenses;

        public frmListDetainLicenses()
        {
            InitializeComponent();
            dgvDetainedLicenses.ContextMenuStrip = cmsDetainedLicense;
            cmsDetainedLicense.Opening += cmsDetainedLicense_Opening_1;
            dgvDetainedLicenses.ReadOnly = true;
        }

        private string GetSelectedColumnName(string filterColumnText)
        {
            switch (filterColumnText)
            {
                case DetainedLicensesColumns.FILTER_DETAIN_ID:
                    return DetainedLicensesColumns.colDetainId;

                case DetainedLicensesColumns.FILTER_IS_RELEASED:
                    return DetainedLicensesColumns.colIsReleased;

                case DetainedLicensesColumns.FILTER_NATIONAL_NO:
                    return DetainedLicensesColumns.colNationalNo;

                case DetainedLicensesColumns.FILTER_FULL_NAME:
                    return DetainedLicensesColumns.colFullName;

                case DetainedLicensesColumns.FILTER_RELEASE_APP_ID:
                    return DetainedLicensesColumns.colReleaseApplicationId;

                default:
                    return DetainedLicensesColumns.FILTER_NONE;
            }
        }

        private void _RefreshDetainedLicensesList()
        {
            _dtAllDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicenses.DataSource = _dtAllDetainedLicenses.DefaultView;
            lblNumOfRecords.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colDetainId].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colDetainId].Width = 80;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colLicenseId].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colLicenseId].Width = 80;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colDetainDate].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colDetainDate].DefaultCellStyle.Format = "dd/MMM/yyyy HH:mm";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colDetainDate].Width = 150;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colIsReleased].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colIsReleased].Width = 90;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colFineFees].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colFineFees].DefaultCellStyle.Format = "0.00";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colFineFees].Width = 90;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colReleaseDate].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colReleaseDate].DefaultCellStyle.Format = "dd/MMM/yyyy HH:mm";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colReleaseDate].Width = 150;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colNationalNo].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colNationalNo].Width = 90;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colFullName].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colFullName].Width = 280;

                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colReleaseApplicationId].HeaderText = "R.App.ID";
                dgvDetainedLicenses.Columns[DetainedLicensesColumns.colReleaseApplicationId].Width = 90;
            }
        }

        private void frmListDetainLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDetainedLicensesList();

            cbFilterList.Items.Clear();

            cbFilterList.Items.Add(DetainedLicensesColumns.FILTER_NONE);
            cbFilterList.Items.Add(DetainedLicensesColumns.FILTER_DETAIN_ID);
            cbFilterList.Items.Add(DetainedLicensesColumns.FILTER_IS_RELEASED);
            cbFilterList.Items.Add(DetainedLicensesColumns.FILTER_NATIONAL_NO);
            cbFilterList.Items.Add(DetainedLicensesColumns.FILTER_FULL_NAME);
            cbFilterList.Items.Add(DetainedLicensesColumns.FILTER_RELEASE_APP_ID);

            cbFilterList.SelectedIndex = 0;
        }

        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible =
                cbFilterList.Text != DetainedLicensesColumns.FILTER_NONE;

            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }
            else
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = "";

                lblNumOfRecords.Text =
                    _dtAllDetainedLicenses.DefaultView.Count.ToString();
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = cbFilterList.Text.Trim();
            string filterValue = txtFilterBy.Text.Trim();

            if (string.IsNullOrEmpty(filterValue) ||string.IsNullOrEmpty(filterColumn) ||filterColumn == DetainedLicensesColumns.FILTER_NONE)
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = "";

                dgvDetainedLicenses.DataSource =  _dtAllDetainedLicenses.DefaultView;

                lblNumOfRecords.Text =  _dtAllDetainedLicenses.DefaultView.Count.ToString();

                return;
            }

            string selectedColumn = GetSelectedColumnName(filterColumn);

            if (selectedColumn == DetainedLicensesColumns.colDetainId ||
                selectedColumn == DetainedLicensesColumns.colReleaseApplicationId)
            {
                if (int.TryParse(filterValue, out int numericVal))
                {  _dtAllDetainedLicenses.DefaultView.RowFilter = $"CONVERT([{selectedColumn}], 'System.String') LIKE '{filterValue}%'";
                }
                else
                {
                    _dtAllDetainedLicenses.DefaultView.RowFilter = "1 = 0";
                }
            }
            else if (selectedColumn == DetainedLicensesColumns.colIsReleased)
            {
                if (filterValue.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                    filterValue == "1")
                {
                    _dtAllDetainedLicenses.DefaultView.RowFilter = $"[{selectedColumn}] = 1";
                }
                else if (filterValue.Equals("no", StringComparison.OrdinalIgnoreCase) || filterValue == "0")
                {
                    _dtAllDetainedLicenses.DefaultView.RowFilter =
                        $"[{selectedColumn}] = 0";
                }
                else
                {
                    _dtAllDetainedLicenses.DefaultView.RowFilter = "1 = 0";
                }
            }
            else
            {
                string safeValue = filterValue.Replace("'", "''");

                _dtAllDetainedLicenses.DefaultView.RowFilter = $"[{selectedColumn}] LIKE '{safeValue}%'";
            }

            dgvDetainedLicenses.DataSource =   _dtAllDetainedLicenses.DefaultView;

            lblNumOfRecords.Text =
                _dtAllDetainedLicenses.DefaultView.Count.ToString();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterList.Text == DetainedLicensesColumns.FILTER_DETAIN_ID ||
                cbFilterList.Text == DetainedLicensesColumns.FILTER_RELEASE_APP_ID)
            {
                e.Handled =!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }


        private void dgvDetainedLicenses_CellMouseDown( object sender,  DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvDetainedLicenses.ClearSelection();
                dgvDetainedLicenses.Rows[e.RowIndex].Selected = true;
                dgvDetainedLicenses.CurrentCell =dgvDetainedLicenses.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void showPersonInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            string nationalNo =
                dgvDetainedLicenses.SelectedRows[0]
                    .Cells[DetainedLicensesColumns.colNationalNo]
                    .Value
                    .ToString();

            clsPerson person = clsPerson.Find(nationalNo);

            if (person != null)
            {
                frmShowPersonInfo frm =
                    new frmShowPersonInfo(person.PersonDTO.PersonID);

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Could not find person details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int licenseId = Convert.ToInt32(dgvDetainedLicenses.SelectedRows[0].Cells[DetainedLicensesColumns.colLicenseId] .Value);

            frmShowLicenseInfo frm =
                new frmShowLicenseInfo(licenseId);

            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string nationalNo = dgvDetainedLicenses.SelectedRows[0].Cells[DetainedLicensesColumns.colNationalNo].Value.ToString();
            clsPerson person = clsPerson.Find(nationalNo);

            if (person != null)
            {
                frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(person.PersonDTO.PersonID);
                frm.ShowDialog();
            }
        }
           
        

        private void cmsDetainedLicense_Opening_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvDetainedLicenses.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            object isReleasedVal = dgvDetainedLicenses.SelectedRows[0]  .Cells[DetainedLicensesColumns.colIsReleased].Value;

            bool isReleased = (isReleasedVal != null && isReleasedVal != DBNull.Value) && Convert.ToBoolean(isReleasedVal);

            releaseDetainedLicenseToolStripMenuItem.Enabled = !isReleased;
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int licenseId = Convert.ToInt32(dgvDetainedLicenses.SelectedRows[0] .Cells[DetainedLicensesColumns.colLicenseId].Value);

            frmReleaseDetainedLicenseApplication frm =  new frmReleaseDetainedLicenseApplication(licenseId);

            frm.ShowDialog();

            _RefreshDetainedLicensesList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}