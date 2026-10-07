using DVLD.GlobalClasses;
using DVLD_Business.Applications;
using DVLD_Business.Licenses;
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

namespace DVLD.Tests.Controls
{
    public partial class ctrScheduleTests : UserControl
    {
        public ctrScheduleTests()
        {
            InitializeComponent();
        }

        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;


        public enum enCreationMode { FirstTimeSchoedule = 0, RetakeTest = 1 }
        enCreationMode _CreationMode = enCreationMode.FirstTimeSchoedule;



        private clsTestTypesDTO.enTestType _TestTypeID = clsTestTypesDTO.enTestType.VisionTest;


        private int _LocalDrivingLicenseApplicationId = 0;
        private clsLocalDrivingLicensecs _LocalLicenseApplication;

        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentId = 0;

        public clsTestTypesDTO.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {


                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestTypesDTO.enTestType.VisionTest:
                        pbTestType.Image = Properties.Resources.Vision_512;
                        gbTestType.Text = "Vision Test";
                        lblScheduleTests.Text = "Vision Test";
                        break;

                    case clsTestTypesDTO.enTestType.WrittenTest:
                        pbTestType.Image = Properties.Resources.Written_Test_512;
                        gbTestType.Text = "Written Test";
                        lblScheduleTests.Text = "Written Test";
                        break;

                    case clsTestTypesDTO.enTestType.RoadTest:

                        pbTestType.Image = Properties.Resources.driving_test_512;
                        gbTestType.Text = "Road Test";
                        lblScheduleTests.Text = "Road Test";
                        break;


                }

            }
        }


public bool LoadInfo(int LocalDrivingLicenseApplicationId, int TestAppointmentId = -1)
        {
            _InitializeMode(TestAppointmentId);

            _LocalDrivingLicenseApplicationId = LocalDrivingLicenseApplicationId;

            if (!_LoadLocalApplicationAndValidateItExistant())
                return false;

            if (!_ValidateLocalApplication())
                return false;

            _LoadCommonInfo();

            if (_Mode == enMode.AddNew)
                return _LoadAddNewMode();

            return _LoadUpdateMode();
        }


        

        private void _InitializeMode(int TestAppointmentId)
        {// used in take test mode 
            if (TestAppointmentId == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
                _TestAppointmentId = TestAppointmentId;
            }
        }


      
        private bool _LoadLocalApplicationAndValidateItExistant()
        {
            _LocalLicenseApplication =
                clsLocalDrivingLicensecs.Find(_LocalDrivingLicenseApplicationId);

            if (_LocalLicenseApplication != null)
                return true;

            MessageBox.Show(
                $"No Local Application was found with ID = {_LocalDrivingLicenseApplicationId}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }


       
        private bool _ValidateLocalApplication()
        {
            // make sure if Person already passed this test
            if (_LocalLicenseApplication.DoesPassTestType(_TestTypeID))
            {
                MessageBox.Show(
                    "Person already passed this test before.",
                    "Cannot Schedule Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }


        
        private void _LoadCommonInfo()
        {
            // Local Driving License Application ID
            lblL_D_App_ID.Text =
                _LocalLicenseApplication
                .LocalDrivingLicenseDTO
                .LocalDrivingLicenseApplicationID
                .ToString();

            // License Class
            lblLicenseClass.Text =
                _LocalLicenseApplication
                .LicenseClassInfo?
                .clsLicenseClassDTO?
                .ClassName
                ?? "[Unknown]";

         
            lblApplicant.Text =
                _LocalLicenseApplication
                .PersonInfo?
                .PersonDTO?
                .FullName()
                ?? "[Unknown]";

          
                _LocalLicenseApplication.TotalTrialsPerTest(_TestTypeID) .ToString();

        
            decimal testFees = _GetTestFees();

            lblApplicationFees.Text = testFees.ToString("0.00");
        }


      
        private decimal _GetTestFees()
        {
            return clsTestTypes
                .Find(_TestTypeID)
                .clsTestTypesDTO
                .TestTypeFees;
        }


        private bool _LoadAddNewMode()
        {
            // Check if there is already an active appointment
            if (!_ValidateNewAppointment())
                return false;

            decimal testFees = _GetTestFees();

            lblRetakeTestAppID.Text = "N/A";

            // Configure Retake / First Time (fees + titles)
            _ConfigureNewTestFees(testFees);

            // Date constraint logic:
            DateTime minDate = DateTime.Now;

            if (_CreationMode == enCreationMode.RetakeTest)
            {
                // Get the date of the last appointment attended
                DateTime lastAppointmentDate = clsTestAppointment.GetLastTestAppointmentDate(
                    _LocalDrivingLicenseApplicationId,
                    _TestTypeID
                );

                if (lastAppointmentDate != DateTime.MinValue)
                {
                    // Must be at least 1 day after the previous attempt
                    DateTime nextAllowedDate = lastAppointmentDate.Date.AddDays(1);

                    // If nextAllowedDate is in the future (e.g. they failed today), force tomorrow or later
                    if (nextAllowedDate > DateTime.Now)
                    {
                        minDate = nextAllowedDate;
                    }
                }
            }

           


            dtpTests.MinDate = DateTime.MinValue;
            dtpTests.Value = minDate;
            dtpTests.MinDate = minDate;

            // Create new appointment object
            _TestAppointment = new clsTestAppointment();

            return true;
        }



        private bool _ValidateNewAppointment()
        {
            // Person already has an active appointment
            if (_LocalLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show(
                    "Person already has an active appointment for this test.",
                    "Cannot Schedule Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }




        private void _ConfigureNewTestFees(decimal testFees)
        {
            // Person attended this test before -> Retake
            if (_LocalLicenseApplication.DoesAttendTestType(_TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTest;

                decimal retakeAppFees = clsApplicationTypes
                    .Find((int)clsApplicationDTO.enApplicationType.RetakeTest)
                    .DTO.ApplicationFees;

                gbRetakeTest.Enabled = true;
                lblReFees.Text = retakeAppFees.ToString("0.00");
                lblTotalFees.Text = (testFees + retakeAppFees).ToString("0.00");

              
                lblScheduleTests.Text = "Schedule Retake Test";
                gbTestType.Text = "Schedule Retake Test";
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeSchoedule;

                gbRetakeTest.Enabled = false;
                lblReFees.Text = "0.00";
                lblTotalFees.Text = testFees.ToString("0.00");

                
                lblScheduleTests.Text = "Schedule Test";
                gbTestType.Text = "Schedule Test";
            }
        }




        private bool _LoadUpdateMode()
        {
            // Load existing appointment
            if (!_LoadTestAppointment())
                return false;

            decimal testFees = _GetTestFees();

            // Configure locked / unlocked state
            _ConfigureAppointmentState();

            // Configure appointment date
            _ConfigureAppointmentDate();

            // Configure retake information and fees
            _ConfigureExistingAppointmentFees(testFees);

            return true;
        }


        private bool _LoadTestAppointment()
        {
            _TestAppointment =  clsTestAppointment.Find(_TestAppointmentId);

            if (_TestAppointment != null)
                return true;

            MessageBox.Show(
                $"No Appointment was found with ID = {_TestAppointmentId}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }


        private void _ConfigureAppointmentState()
        {
            // Appointment already taken
            if (_TestAppointment.AppointmentDTO.IsLocked)
            {
                lblUserMessage.Text =
                    "Person already sat for the test, appointment locked.";

                lblUserMessage.Visible = true;

                MessageBox.Show(
                    "Person already sat for the test. This appointment is locked.",
                    "Appointment Locked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpTests.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                lblUserMessage.Visible = false;

                dtpTests.Enabled = true;
                btnSave.Enabled = true;
            }
        }


     

        private void _ConfigureAppointmentDate()
        {
            DateTime currentAppointmentDate = _TestAppointment.AppointmentDTO.AppointmentDate;
         // The rescheduled date cannot be in the past
            DateTime minimumAllowedDate = DateTime.Now;

            // If this appointment is a retake, ensure it cannot be placed before or on the previous attempt's day
            if (_TestAppointment.AppointmentDTO.RetakeTestApplicationID != -1)
            {
                DateTime previousAttemptDate = clsTestAppointment.GetPreviousTestAppointmentDateExcludingCurrentOne(
                    _LocalDrivingLicenseApplicationId,
                    _TestTypeID,
                    _TestAppointmentId
                );

                if (previousAttemptDate != DateTime.MinValue)
                {
                    DateTime nextDayAfterPrevAttempt = previousAttemptDate.Date.AddDays(1);

                    // Take whichever date is further in the future
                    if (nextDayAfterPrevAttempt > minimumAllowedDate)
                    {
                        minimumAllowedDate = nextDayAfterPrevAttempt;
                    }
                }
            }

         
            dtpTests.MinDate = DateTime.MinValue;

            if (currentAppointmentDate < minimumAllowedDate)
            {
                // If the original date was somehow earlier than the minimum allowed,
                // clamp Value to minimumAllowedDate first
                dtpTests.Value = minimumAllowedDate;
            }
            else
            {
                dtpTests.Value = currentAppointmentDate;
            }

            dtpTests.MinDate = minimumAllowedDate;
        }


       
        private void _ConfigureExistingAppointmentFees(decimal testFees)
        {
            int retakeApplicationID = _TestAppointment.AppointmentDTO.RetakeTestApplicationID;

            // No retake (First time appointment being edited)
            if (retakeApplicationID == -1)
            {
                gbRetakeTest.Enabled = false;
                lblReFees.Text = "0.00";
                lblRetakeTestAppID.Text = "N/A";
                lblTotalFees.Text = testFees.ToString("0.00");

                lblScheduleTests.Text = "Schedule Test";
                gbTestType.Text = "Schedule Test";
                return;
            }

            // Retake appointment being edited
            gbRetakeTest.Enabled = true;

            decimal retakeFees = _TestAppointment.RetakeTestAppInfo.ApplicationDTO.PaidFees;

            lblReFees.Text = retakeFees.ToString("0.00");
            lblRetakeTestAppID.Text = retakeApplicationID.ToString();
            lblTotalFees.Text = (testFees + retakeFees).ToString("0.00");

            lblScheduleTests.Text = "Schedule Retake Test";
            gbTestType.Text = "Schedule Retake Test";
        }


        private bool _HandleRetakeApplication()
        {
            // Retake sub-applications are only created on brand new appointments
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTest)
            {
                clsApplication retakeApp = new clsApplication();

                // 1. Populate base application details for the Retake Test
                retakeApp.ApplicationDTO.ApplicantPersonID = _LocalLicenseApplication.ApplicationDTO.ApplicantPersonID;
                retakeApp.ApplicationDTO.ApplicationDate = DateTime.Now;
                retakeApp.ApplicationDTO.ApplicationTypeID = (int)clsApplicationDTO.enApplicationType.RetakeTest;
                retakeApp.ApplicationDTO.ApplicationStatus = (byte)clsApplicationDTO.enApplicationStatus.Completed;
                retakeApp.ApplicationDTO.LastStatusDate = DateTime.Now;
                retakeApp.ApplicationDTO.PaidFees = clsApplicationTypes.Find((int)clsApplicationDTO.enApplicationType.RetakeTest).DTO.ApplicationFees;
                retakeApp.ApplicationDTO.CreatedByUserID = clsGlobal.CurrentUser.UserDTO.UserID;

                // 2. Persist to database to generate the ApplicationID
                if (!retakeApp.Save())
                {
                    _TestAppointment.AppointmentDTO.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed to create Retake Test base application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // 3. Link the generated ApplicationID to the appointment DTO
                _TestAppointment.AppointmentDTO.RetakeTestApplicationID = retakeApp.ApplicationDTO.ApplicationID;
            }

            return true;
        }
        private void ctrScheduleTests_Load(object sender, EventArgs e)
        {

        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. If this is a Retake Test, generate and save the base application first
            if (!_HandleRetakeApplication())
                return;

            // 2. Populate Test Appointment details
            _TestAppointment.AppointmentDTO.TestTypeID = _TestTypeID;
            _TestAppointment.AppointmentDTO.LocalDrivingLicenseApplicationID = _LocalLicenseApplication.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDTO.AppointmentDate = dtpTests.Value;
            _TestAppointment.AppointmentDTO.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            _TestAppointment.AppointmentDTO.CreatedByUserID = clsGlobal.CurrentUser.UserDTO.UserID;

            if (dtpTests.Value.Date < dtpTests.MinDate.Date)
            {
                MessageBox.Show("Appointment date cannot be set before " + dtpTests.MinDate.ToString("dd/MMM/yyyy"),
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 3. Save Appointment Record
            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                _TestAppointmentId = _TestAppointment.AppointmentDTO.TestAppointmentID;

                // Display generated Retake Application ID in the UI if applicable
                if (_CreationMode == enCreationMode.RetakeTest)
                {
                    lblRetakeTestAppID.Text = _TestAppointment.AppointmentDTO.RetakeTestApplicationID.ToString();
                }

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data was not saved successfully.\n" + _TestAppointment.AppointmentDTO.LastValidationError,
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
