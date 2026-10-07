using DVLD.GlobalClasses;
using DVLD_Business.Tests;
using DVLD_Business.Tests.DVLD_Business.Tests;
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
    public partial class frmTakeTest : Form
    {

        int _AppointmentId;
        clsTestTypesDTO.enTestType _TestTypeId;
        clsTest _Test;
        private int _TestId;

        public frmTakeTest(int AppointmentId,clsTestTypesDTO.enTestType TestTypeID)
        {
            InitializeComponent();
            _AppointmentId = AppointmentId;
            _TestTypeId = TestTypeID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrScheduledTests1.TestTypeID = _TestTypeId;
            ctrScheduledTests1.LoadInfo(_AppointmentId);

            if (ctrScheduledTests1.TestAppointmentID == -1)
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled=true;
            }

           _TestId= ctrScheduledTests1.TestID;


            if (_TestId != -1)// the edit mode 
            {
                _Test = clsTest.Find(_TestId);
                if (_Test.TestDTO.TestResult)
                {
                    btnPass.Checked = true;
                }
                else
                {
                    btnFail.Checked = true;
                }
                txtNotes.Text = _Test.TestDTO.Notes;
                lblUserMessage.Visible = true;
                btnFail.Enabled = false;
                btnPass.Enabled = false;
                btnSave.Enabled =(btnPass.Checked);


            }
            else
            {
                _Test=new clsTest();
            }
           

           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to save ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _Test.TestAppointment = clsTestAppointment.Find(_AppointmentId);

            _Test.TestDTO.TestAppointmentID = _AppointmentId;
            _Test.TestDTO.TestResult=btnPass.Checked;
            _Test.TestDTO.Notes=txtNotes.Text.Trim();
            _Test.TestDTO.CreatedByUserID = clsGlobal.CurrentUser.UserDTO.UserID;
            if (_Test.TestAppointment.AppointmentDTO.AppointmentDate.Date > DateTime.Today)
            {
                MessageBox.Show("Cannot enter results for a test scheduled in the future.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Succesfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show(" Error :Data was not  Saved Succesfully"+ _Test.TestDTO.LastValidationError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
               

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrScheduledTests1_Load(object sender, EventArgs e)
        {

        }
    }
}
