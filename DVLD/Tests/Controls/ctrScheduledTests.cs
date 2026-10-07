using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using DVLD_Business.Tests;
using System;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrScheduledTests : UserControl
    {
        public ctrScheduledTests()
        {
            InitializeComponent();
        }

        private clsTestTypesDTO.enTestType _TestTypeID = clsTestTypesDTO.enTestType.VisionTest;
        private int _TestAppointmentId = -1;
        private int _TestID = -1;
        private int _LocalDrivingLicenseApplicationId = -1;

        private clsTestAppointment _TestAppointment;
        private clsLocalDrivingLicensecs _LocalLicenseApplication;

        public clsTestTypesDTO.enTestType TestTypeID
        {
            get => _TestTypeID;
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestTypesDTO.enTestType.VisionTest:
                        pbTestType.Image = Properties.Resources.Vision_512;
                        gbTestType.Text = "Vision Test";
                        break;

                    case clsTestTypesDTO.enTestType.WrittenTest:
                        pbTestType.Image = Properties.Resources.Written_Test_512;
                        gbTestType.Text = "Written Test";
                        break;

                    case clsTestTypesDTO.enTestType.RoadTest:
                        pbTestType.Image = Properties.Resources.driving_test_512;
                        gbTestType.Text = "Road Test";
                        break;
                }
            }
        }

       
        public int TestAppointmentID => _TestAppointmentId;
        public int TestID => _TestID;
        public int LocalDrivingLicenseApplicationID => _LocalDrivingLicenseApplicationId;
        public clsTestAppointment SelectedTestAppointment => _TestAppointment;
        public clsLocalDrivingLicensecs LocalDrivingLicenseApplication => _LocalLicenseApplication;

        public bool LoadInfo(int testAppointmentId)
        {
            _TestAppointmentId = testAppointmentId;
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentId);

            if (_TestAppointment == null)
            {
                MessageBox.Show($"Error: No Appointment was found with ID = {_TestAppointmentId}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

          
            TestTypeID = _TestAppointment.AppointmentDTO.TestTypeID;

            
            _LocalDrivingLicenseApplicationId = _TestAppointment.AppointmentDTO.LocalDrivingLicenseApplicationID;
            _LocalLicenseApplication = clsLocalDrivingLicensecs.Find(_LocalDrivingLicenseApplicationId);

            if (_LocalLicenseApplication == null)
            {
                MessageBox.Show($"Error: No Local Application was found with ID = {_LocalDrivingLicenseApplicationId}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

           
            lblL_D_App_ID.Text = _LocalDrivingLicenseApplicationId.ToString();
            lblLicenseClass.Text = _LocalLicenseApplication.LicenseClassInfo?.clsLicenseClassDTO?.ClassName ?? "[Unknown]";
            lblApplicant.Text = _LocalLicenseApplication.PersonInfo?.PersonDTO?.FullName() ?? "[Unknown]";
            lblTrial.Text = _LocalLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblApplicationFees.Text = _TestAppointment.AppointmentDTO.PaidFees.ToString("0.00");

            _TestID = _TestAppointment.TestID;

            if (_TestID == -1)
            {
                lblTestID.Text = "Not Taken Yet";
            }
            else
            {
                lblTestID.Text = _TestID.ToString();
            }

    
            dtpTests.MinDate = DateTime.MinValue;
            dtpTests.Value = _TestAppointment.AppointmentDTO.AppointmentDate;
            dtpTests.Enabled = false;

            return true;
        }

        private void ctrScheduledTests_Load(object sender, EventArgs e)
        {
        }
    }
}