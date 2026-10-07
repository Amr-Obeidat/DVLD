using DVLD.Licenses;
using DVLD.Tests;
using DVLD_Business.Drivers;
using DVLD_Business.Licenses;
using DVLD_Business.People;
using DVLD_Business.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmListLocalLicenseApp : Form
    {
        public frmListLocalLicenseApp()
        {
            InitializeComponent();
            _ConfigureDataGridView();
            this.txtFilterBy.TextChanged += new System.EventHandler(this.txtFilterBy_TextChanged);
            this.cbFilterList.SelectedIndexChanged += new System.EventHandler(this.cbFilterList_SelectedIndexChanged);
            this.txtFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterBy_KeyPress);
        }

        private DataTable _dtAllLocalApplications = clsLocalDrivingLicensecs.GetAllApplications();



        private void _ConfigureDataGridView()
        {
            dgvLocalApp.AllowUserToAddRows = false;
            dgvLocalApp.AllowUserToDeleteRows = false;
            dgvLocalApp.ReadOnly = true;
            dgvLocalApp.BackgroundColor = Color.White;
            dgvLocalApp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocalApp.MultiSelect = false;
        }

        private void _PopulateFilterComboBox()
        {
            cbFilterList.Items.Clear();

            cbFilterList.Items.Add(LocalAppColumns.FILTER_NONE);
            cbFilterList.Items.Add(LocalAppColumns.FILTER_LDL_APP_ID);
            cbFilterList.Items.Add(LocalAppColumns.FILTER_NATIONAL_NO);
            cbFilterList.Items.Add(LocalAppColumns.FILTER_FULL_NAME);
            cbFilterList.Items.Add(LocalAppColumns.FILTER_STATUS);

            cbFilterList.SelectedIndex = 0;
        }

        private void _ConfigureColumns()
        {
            if (dgvLocalApp.Columns.Count == 0)
            {
                return;
            }

            if (dgvLocalApp.Columns[LocalAppColumns.colLocalDrivingLicenseApplicationID] != null)
            {
                dgvLocalApp.Columns[LocalAppColumns.colLocalDrivingLicenseApplicationID].HeaderText = "L.D.L.App ID";
                dgvLocalApp.Columns[LocalAppColumns.colLocalDrivingLicenseApplicationID].Width = 70;
            }

            if (dgvLocalApp.Columns[LocalAppColumns.colClassName] != null)
            {
                dgvLocalApp.Columns[LocalAppColumns.colClassName].HeaderText = "Driving Class";
                dgvLocalApp.Columns[LocalAppColumns.colClassName].Width = 230;
            }

            if (dgvLocalApp.Columns[LocalAppColumns.colNationalNo] != null)
            {
                dgvLocalApp.Columns[LocalAppColumns.colNationalNo].HeaderText = "National No";
                dgvLocalApp.Columns[LocalAppColumns.colNationalNo].Width = 100;
            }

            if (dgvLocalApp.Columns[LocalAppColumns.colFullName] != null)
            {
                dgvLocalApp.Columns[LocalAppColumns.colFullName].HeaderText = "Full Name";
                dgvLocalApp.Columns[LocalAppColumns.colFullName].Width = 260;
            }

            if (dgvLocalApp.Columns[LocalAppColumns.colApplicationDate] != null)
            {
                dgvLocalApp.Columns[LocalAppColumns.colApplicationDate].HeaderText = "Application Date";
                dgvLocalApp.Columns[LocalAppColumns.colApplicationDate].Width = 130;
            }

            if (dgvLocalApp.Columns[LocalAppColumns.colPassedTestCount] != null)
            {
                dgvLocalApp.Columns[LocalAppColumns.colPassedTestCount].HeaderText = "Passed Tests";
                dgvLocalApp.Columns[LocalAppColumns.colPassedTestCount].Width = 90;
            }

            if (dgvLocalApp.Columns[LocalAppColumns.colStatus] != null)
            {
                dgvLocalApp.Columns[LocalAppColumns.colStatus].HeaderText = "Status";
                dgvLocalApp.Columns[LocalAppColumns.colStatus].Width = 100;
            }
        }
        private void frmListLocalLicenseApp_Load(object sender, EventArgs e)
        {
            _PopulateFilterComboBox();

            if (_dtAllLocalApplications != null && _dtAllLocalApplications.Rows.Count > 0)
            {
                dgvLocalApp.DataSource = _dtAllLocalApplications;
                cbFilterList.SelectedIndex = 0;
                lblNumOfRecords.Text = dgvLocalApp.Rows.Count.ToString();

                _ConfigureColumns();
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = cbFilterList.Text.Trim();
            string filterValue = txtFilterBy.Text.Trim();

            if (string.IsNullOrEmpty(filterValue) || string.IsNullOrEmpty(filterColumn) || filterColumn == LocalAppColumns.FILTER_NONE)
            {
                _dtAllLocalApplications.DefaultView.RowFilter = "";
                lblNumOfRecords.Text = _dtAllLocalApplications.DefaultView.Count.ToString();
                return;
            }

            string selectedColumn = GetSelectedColumnName(filterColumn);// should be the same as the column in the database

            if (selectedColumn == LocalAppColumns.colLocalDrivingLicenseApplicationID || selectedColumn == LocalAppColumns.colPassedTestCount)
            {
                if (int.TryParse(filterValue, out int numericVal))
                {
                    _dtAllLocalApplications.DefaultView.RowFilter = $"CONVERT([{selectedColumn}], 'System.String') LIKE '{filterValue}%'";
                }
                else
                {
                    _dtAllLocalApplications.DefaultView.RowFilter = "1 = 0";
                }
            }
            // For string columns, use LIKE for partial matching
            else
            {
                string safeValue = filterValue.Replace("'", "''");

                _dtAllLocalApplications.DefaultView.RowFilter = $"[{selectedColumn}] LIKE '{safeValue}%'";

            }
            dgvLocalApp.DataSource = _dtAllLocalApplications.DefaultView;
            lblNumOfRecords.Text = _dtAllLocalApplications.DefaultView.Count.ToString();
        }


        private string GetSelectedColumnName(string displayColumn)
        {
            switch (displayColumn)
            {
                case LocalAppColumns.FILTER_LDL_APP_ID:
                    return LocalAppColumns.colLocalDrivingLicenseApplicationID;
                case LocalAppColumns.FILTER_NATIONAL_NO:
                    return LocalAppColumns.colNationalNo;
                case LocalAppColumns.FILTER_FULL_NAME:
                    return LocalAppColumns.colFullName;
                case LocalAppColumns.FILTER_STATUS:
                    return LocalAppColumns.colStatus;
                default:
                    return displayColumn;
            }
        }

        private void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Visible = (cbFilterList.Text != LocalAppColumns.FILTER_NONE);

            if (txtFilterBy.Visible)
            {
                txtFilterBy.Text = "";
                txtFilterBy.Focus();
            }
        }

        private void dgvLocalApp_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvLocalApp.ClearSelection();
                dgvLocalApp.Rows[e.RowIndex].Selected = true;
                dgvLocalApp.CurrentCell = dgvLocalApp.Rows[e.RowIndex].Cells[e.ColumnIndex];

                cmsLocalApplications.Show(Cursor.Position);
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterList.Text == LocalAppColumns.FILTER_LDL_APP_ID)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmListLocalLicenseApp_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);

            frmShowLocalDrivingApplication frm = new frmShowLocalDrivingApplication(ApplicationId);
            frm.ShowDialog();

        }


        private void _RefreshApplications()
        {
            _dtAllLocalApplications = clsLocalDrivingLicensecs.GetAllApplications();

            dgvLocalApp.DataSource = _dtAllLocalApplications;

            lblNumOfRecords.Text = dgvLocalApp.Rows.Count.ToString();

            _ConfigureColumns();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);
            clsLocalDrivingLicensecs App = clsLocalDrivingLicensecs.Find(ApplicationId);
            if (App.Cancel())
            {
                MessageBox.Show("Application canceled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                _RefreshApplications();
            }
            else
            {
                MessageBox.Show("Failed to cancel the application.", $"Error + {App.LocalDrivingLicenseDTO.LastValidationError}", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static class LocalAppColumns
        {
            public const string colLocalDrivingLicenseApplicationID = "LocalDrivingLicenseApplicationID";
            public const string colClassName = "ClassName";
            public const string colNationalNo = "NationalNo";
            public const string colFullName = "FullName";
            public const string colApplicationDate = "ApplicationDate";
            public const string colPassedTestCount = "PassedTestCount";
            public const string colStatus = "Status";
            public const string TableName = "DVLD.dbo.LocalDrivingLicenseApplications_View";

            public const string FILTER_NONE = "None";
            public const string FILTER_LDL_APP_ID = "L.D.L.App ID";
            public const string FILTER_NATIONAL_NO = "National No";
            public const string FILTER_FULL_NAME = "Full Name";
            public const string FILTER_STATUS = "Status";
        }


        private void _SetIntialContextMenuState()
        {
            tmsscheduleVisionTest.Enabled = false;
            tmsscheduleWrittenTest.Enabled = false;
            tmsscheduleStreetTest.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            ShowLicenseHistorycms.Enabled = false;
        }
        private void cmsLocalApplications_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLocalApp.SelectedRows.Count == 0 || dgvLocalApp.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }

          
            int ApplicationId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);
            int PassedTestCount = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colPassedTestCount].Value);
            string ApplicationStatus = dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colStatus].Value.ToString();
            string Nationalnum = dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colNationalNo].Value.ToString();

            bool isCompleted = ApplicationStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase);
            bool isCancelled = ApplicationStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase);

           
            int personid = clsPerson.Find(Nationalnum).PersonDTO.PersonID;
            var driver = clsDriver.FindByPersonID(personid);

           
            _SetIntialContextMenuState();

            tsmScheduleTests.Enabled = (PassedTestCount < 3) && !isCompleted && !isCancelled;
            if (tsmScheduleTests.Enabled)
            {
                tmsscheduleVisionTest.Enabled = (PassedTestCount == 0);
                tmsscheduleWrittenTest.Enabled = (PassedTestCount == 1);
                tmsscheduleStreetTest.Enabled = (PassedTestCount == 2);
            }

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (PassedTestCount == 3 && !isCompleted && !isCancelled);

 
            showLicenseToolStripMenuItem.Enabled = isCompleted;

            
            ShowLicenseHistorycms.Enabled = (driver != null);
            cancelApplicationToolStripMenuItem.Enabled = (!isCompleted && !isCancelled);
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _LocalAppId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);
            frmListTestAppointments frm = new frmListTestAppointments(_LocalAppId, clsTestTypesDTO.enTestType.VisionTest);
            frm.ShowDialog();
            _RefreshApplications();
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _LocalAppId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);
            frmListTestAppointments frm = new frmListTestAppointments(_LocalAppId, clsTestTypesDTO.enTestType.WrittenTest);
            frm.ShowDialog();
            _RefreshApplications();
        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _LocalAppId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);
            frmListTestAppointments frm = new frmListTestAppointments(_LocalAppId, clsTestTypesDTO.enTestType.RoadTest);
            frm.ShowDialog();
            _RefreshApplications();

        }

        private void dgvLocalApp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int _LocalAppId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense(_LocalAppId);
            frm.ShowDialog();

          
            
                _RefreshApplications();
            
           

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalApp.SelectedRows.Count == 0 || dgvLocalApp.CurrentRow == null)
            {
                return;
            }

            int localAppId = Convert.ToInt32(dgvLocalApp.SelectedRows[0].Cells[LocalAppColumns.colLocalDrivingLicenseApplicationID].Value);

            clsLocalDrivingLicensecs localLicense = clsLocalDrivingLicensecs.Find(localAppId);

            if (localLicense == null)
            {
                MessageBox.Show("Could not find application with ID = " + localAppId,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            int personId = localLicense.ApplicationDTO.ApplicantPersonID;
            int licenseClassId = localLicense.LocalDrivingLicenseDTO.LicenseClassId;

           
            int licenseId = clsLicense.GetActiveLicenseForPerson(personId, licenseClassId);

            if (licenseId != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(licenseId);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No active license found for this applicant.",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}