using DVLD.Licenses;
using DVLD.People;
using DVLD_Business.Drivers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();

            _ConfigureDataGridView();

            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.cbFilterList.SelectedIndexChanged += new System.EventHandler(this.cbFilterList_SelectedIndexChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
        }

        private DataTable _dtAllDrivers = clsDriver.GetAllDrivers();


        private void _ConfigureDataGridView()
        {
            dgvDrivers.AllowUserToAddRows = false;
            dgvDrivers.AllowUserToDeleteRows = false;
            dgvDrivers.ReadOnly = true;
            dgvDrivers.BackgroundColor = Color.White;
            dgvDrivers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrivers.MultiSelect = false;
        }

        private void _PopulateFilterComboBox()
        {
            cbFilterList.Items.Clear();

            cbFilterList.Items.Add(DriversColumns.FILTER_NONE);
            cbFilterList.Items.Add(DriversColumns.FILTER_DRIVER_ID);
            cbFilterList.Items.Add(DriversColumns.FILTER_PERSON_ID);
            cbFilterList.Items.Add(DriversColumns.FILTER_NATIONAL_NO);
            cbFilterList.Items.Add(DriversColumns.FILTER_FULL_NAME);

            cbFilterList.SelectedIndex = 0;
        }

        private void _ConfigureColumns()
        {
            if (dgvDrivers.Columns.Count == 0)
            {
                return;
            }

            if (dgvDrivers.Columns[DriversColumns.colDriverId] != null)
            {
                dgvDrivers.Columns[DriversColumns.colDriverId].HeaderText = "Driver ID";
                dgvDrivers.Columns[DriversColumns.colDriverId].Width = 100;
            }

            if (dgvDrivers.Columns[DriversColumns.colPersonId] != null)
            {
                dgvDrivers.Columns[DriversColumns.colPersonId].HeaderText = "Person ID";
                dgvDrivers.Columns[DriversColumns.colPersonId].Width = 100;
            }

            if (dgvDrivers.Columns[DriversColumns.colNationalNo] != null)
            {
                dgvDrivers.Columns[DriversColumns.colNationalNo].HeaderText = "National No.";
                dgvDrivers.Columns[DriversColumns.colNationalNo].Width = 120;
            }

            if (dgvDrivers.Columns[DriversColumns.colFullName] != null)
            {
                dgvDrivers.Columns[DriversColumns.colFullName].HeaderText = "Full Name";
                dgvDrivers.Columns[DriversColumns.colFullName].Width = 300;
            }

            if (dgvDrivers.Columns[DriversColumns.colCreatedDate] != null)
            {
                dgvDrivers.Columns[DriversColumns.colCreatedDate].HeaderText = "Date";
                dgvDrivers.Columns[DriversColumns.colCreatedDate].DefaultCellStyle.Format = "dd/MMM/yyyy HH:mm";
                dgvDrivers.Columns[DriversColumns.colCreatedDate].Width = 170;
            }

            if (dgvDrivers.Columns[DriversColumns.colNumberOfActiveLicenses] != null)
            {
                dgvDrivers.Columns[DriversColumns.colNumberOfActiveLicenses].HeaderText = "Active Licenses";
                dgvDrivers.Columns[DriversColumns.colNumberOfActiveLicenses].Width = 120;
            }
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _PopulateFilterComboBox();

            if (_dtAllDrivers != null && _dtAllDrivers.Rows.Count > 0)
            {
                dgvDrivers.DataSource = _dtAllDrivers;

                cbFilterList.SelectedIndex = 0;

                lblNumOfRecords.Text = dgvDrivers.Rows.Count.ToString();

                _ConfigureColumns();
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = cbFilterList.Text.Trim();
            string filterValue = txtFilterBy.Text.Trim();

            if (string.IsNullOrEmpty(filterValue) ||
                string.IsNullOrEmpty(filterColumn) ||
                filterColumn == DriversColumns.FILTER_NONE)
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                dgvDrivers.DataSource = _dtAllDrivers.DefaultView;
                lblNumOfRecords.Text = _dtAllDrivers.DefaultView.Count.ToString();

                return;
            }

            string selectedColumn = GetSelectedColumnName(filterColumn);

            if (selectedColumn == DriversColumns.colDriverId ||
                selectedColumn == DriversColumns.colPersonId)
            {
                if (int.TryParse(filterValue, out int numericVal))
                {
                    _dtAllDrivers.DefaultView.RowFilter =
                        $"CONVERT([{selectedColumn}], 'System.String') LIKE '{filterValue}%'";
                }
                else
                {
                    _dtAllDrivers.DefaultView.RowFilter = "1 = 0";
                }
            }
            else
            {
                string safeValue = filterValue.Replace("'", "''");

                _dtAllDrivers.DefaultView.RowFilter =
                    $"[{selectedColumn}] LIKE '{safeValue}%'";
            }

            dgvDrivers.DataSource = _dtAllDrivers.DefaultView;

            lblNumOfRecords.Text = _dtAllDrivers.DefaultView.Count.ToString();
        }

        private string GetSelectedColumnName(string displayColumn)
        {
            switch (displayColumn)
            {
                case DriversColumns.FILTER_DRIVER_ID:
                    return DriversColumns.colDriverId;

                case DriversColumns.FILTER_PERSON_ID:
                    return DriversColumns.colPersonId;

                case DriversColumns.FILTER_NATIONAL_NO:
                    return DriversColumns.colNationalNo;

                case DriversColumns.FILTER_FULL_NAME:
                    return DriversColumns.colFullName;

                default:
                    return displayColumn;
            }
        }

        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cbFilterList.Text != DriversColumns.FILTER_NONE);

            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterList.Text == DriversColumns.FILTER_DRIVER_ID ||
                cbFilterList.Text == DriversColumns.FILTER_PERSON_ID)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _RefreshDrivers()
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();

            dgvDrivers.DataSource = _dtAllDrivers;

            lblNumOfRecords.Text = dgvDrivers.Rows.Count.ToString();

            _ConfigureColumns();
        }


        public static class DriversColumns
        {
            public const string colDriverId = "DriverID";
            public const string colPersonId = "PersonID";
            public const string colNationalNo = "NationalNo";
            public const string colFullName = "FullName";
            public const string colCreatedDate = "CreatedDate";
            public const string colNumberOfActiveLicenses = "NumberOfActiveLicenses";

            public const string TableName = "DVLD.dbo.Drivers_View";

            public const string FILTER_NONE = "None";
            public const string FILTER_DRIVER_ID = "Driver ID";
            public const string FILTER_PERSON_ID = "Person ID";
            public const string FILTER_NATIONAL_NO = "National No";
            public const string FILTER_FULL_NAME = "Full Name";
        }

        private void showPeronInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _PersonId = Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells["PersonID"].Value);
            frmShowPersonInfo frm = new frmShowPersonInfo(_PersonId);
            frm.ShowDialog();   
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _PersonId = Convert.ToInt32(dgvDrivers.SelectedRows[0].Cells["PersonID"].Value);
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_PersonId);
            


            frm.ShowDialog();

        }
    }
}