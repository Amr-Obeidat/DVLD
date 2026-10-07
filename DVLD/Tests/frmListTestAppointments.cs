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

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {


      private  DataTable _dtAppointments;

        private int _LocalApplicationID;
        private clsTestTypesDTO.enTestType _TestTypeId = clsTestTypesDTO.enTestType.VisionTest;

        public frmListTestAppointments(int LocalApplicationInfo, clsTestTypesDTO.enTestType TestTypeId)
        {
            InitializeComponent();
            _LocalApplicationID = LocalApplicationInfo;
            _TestTypeId = TestTypeId;
        }


        public void _ConfigureDataColumns()
        {

            if (dgvLicenseTestAppointments.Columns.Count == 0)
            {
                return;
            }

            if (dgvLicenseTestAppointments.Columns["TestAppointmentID"] != null)
            {
                dgvLicenseTestAppointments.Columns["TestAppointmentID"].Visible = true;
                dgvLicenseTestAppointments.Columns["TestAppointmentID"].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns["TestAppointmentID"].Width = 150;
            }
            if (dgvLicenseTestAppointments.Columns["AppointmentDate"] != null)
            {
                dgvLicenseTestAppointments.Columns["AppointmentDate"].Visible = true;
                dgvLicenseTestAppointments.Columns["AppointmentDate"].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns["AppointmentDate"].Width = 200;
            }

            if (dgvLicenseTestAppointments.Columns["PaidFees"] != null)
            {
                dgvLicenseTestAppointments.Columns["PaidFees"].Visible = true;
                dgvLicenseTestAppointments.Columns["PaidFees"].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns["PaidFees"].Width = 150;
            }

            if (dgvLicenseTestAppointments.Columns["IsLocked"] != null)
            {
                dgvLicenseTestAppointments.Columns["IsLocked"].Visible = true;
                dgvLicenseTestAppointments.Columns["IsLocked"].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns["IsLocked"].Width = 100;
            }


        }

        public void _ResetDataGridViewSettings()
        {
         dgvLicenseTestAppointments.AllowUserToAddRows = false;
         dgvLicenseTestAppointments.AllowUserToDeleteRows = false;
         dgvLicenseTestAppointments.ReadOnly = true;
         dgvLicenseTestAppointments.BackgroundColor = Color.White;
         dgvLicenseTestAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         dgvLicenseTestAppointments.MultiSelect = false;
        }

        private void _RefreshAppointments()
        {
            DataTable dt = clsTestAppointment.GetApplicationAppointmentsPerTestType(
         _LocalApplicationID,
         _TestTypeId);


            _dtAppointments = dt.DefaultView.ToTable(
          true,
          "TestAppointmentID",
          "AppointmentDate",
          "PaidFees",
          "IsLocked"
          );

            dgvLicenseTestAppointments.DataSource = _dtAppointments;

            _ConfigureDataColumns();
            _ResetDataGridViewSettings();

            lblNumOfRecords.Text =   _dtAppointments.Rows.Count.ToString();
        }
        private void frmListTestAppointmentscs_Load(object sender, EventArgs e)
        {
            ctrLocalDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_LocalApplicationID);
            _RefreshAppointments();

        }


       
        private void btnAddAppointmnet_Click(object sender, EventArgs e)
        {
            using (frmScheduleTests frm = new frmScheduleTests())
            {
                if (!frm.LoadInfo(_LocalApplicationID, _TestTypeId))
                    return;


                frm.ShowDialog();
                _RefreshAppointments();
            }
            
              
                
            }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLicenseTestAppointments.CurrentRow == null)
                return;

            int testAppointmentId = (int)dgvLicenseTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value;

            frmTakeTest frm = new frmTakeTest(testAppointmentId,  _TestTypeId);
            frm.ShowDialog();


            _RefreshAppointments();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLicenseTestAppointments.CurrentRow == null)
                return;

            int testAppointmentId = (int)dgvLicenseTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value;

            frmScheduleTests frm = new frmScheduleTests();
            frm.LoadInfo(_LocalApplicationID, _TestTypeId, testAppointmentId);
            frm.ShowDialog();

           
            _RefreshAppointments();
        }
    }
}
