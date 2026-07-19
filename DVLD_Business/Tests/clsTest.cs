using DVLD_DataAccess.Tests;
using System;
using System.Data;

namespace DVLD_Business.Tests
{
    public class clsTestDTO
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int TestID { get; set; } = -1;
        public int TestAppointmentID { get; set; } = -1;
        public bool TestResult { get; set; } = false;
        public string Notes { get; set; } = "";
        public int CreatedByUserID { get; set; } = -1;
        public string LastValidationError { get; set; } = "";
    }
  
namespace DVLD_Business.Tests
    {
        public class clsTest
        {
            public clsTestDTO TestDTO { get; set; }

            public clsTest()
            {
                this.TestDTO = new clsTestDTO();
                this.TestDTO.Mode = clsTestDTO.enMode.AddNew;
            }

            private clsTest(clsTestDTO DTO)
            {
                this.TestDTO = DTO;
                this.TestDTO.Mode = clsTestDTO.enMode.Update;
            }

            public static clsTest Find(int TestID)
            {
                int TestAppointmentID = -1;
                bool TestResult = false;
                string Notes = "";
                int CreatedByUserID = -1;

                if (clsTestsDataAccess.GetTestInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                {
                    clsTestDTO dto = new clsTestDTO
                    {
                        TestID = TestID,
                        TestAppointmentID = TestAppointmentID,
                        TestResult = TestResult,
                        Notes = Notes,
                        CreatedByUserID = CreatedByUserID
                    };
                    return new clsTest(dto);
                }
                return null;
            }

            private bool _AddNewTest()
            {
                this.TestDTO.TestID = clsTestsDataAccess.AddNewTest(
                    this.TestDTO.TestAppointmentID,
                    this.TestDTO.TestResult,
                    this.TestDTO.Notes,
                    this.TestDTO.CreatedByUserID
                );

                if (this.TestDTO.TestID != -1)
                {
                    // SIDE EFFECT CONSTRAINTS: Once a test is written, the underlying appointment must be locked permanently.
                    clsTestAppointment appointment = clsTestAppointment.Find(this.TestDTO.TestAppointmentID);
                    if (appointment != null)
                    {
                        appointment.AppointmentDTO.IsLocked = true;
                        return appointment.Save(); // Updates database configuration status to IsLocked = 1
                    }
                }
                return false;
            }

            private bool _UpdateTest()
            {
                return clsTestsDataAccess.UpdateTest(
                    this.TestDTO.TestID,
                    this.TestDTO.TestAppointmentID,
                    this.TestDTO.TestResult,
                    this.TestDTO.Notes,
                    this.TestDTO.CreatedByUserID
                );
            }

            public bool Save()
            {
                // 1. Sanity Security Gate
                if (this.TestDTO.TestAppointmentID <= 0 || this.TestDTO.CreatedByUserID <= 0)
                {
                    this.TestDTO.LastValidationError = "Validation Fail: Required Test Appointment or User tracking associations are completely missing.";
                    return false;
                }

                // 2. Execution State Pipeline Control
                switch (this.TestDTO.Mode)
                {
                    case clsTestDTO.enMode.AddNew:
                        // Guard Rule: An appointment can hold exactly ONE evaluation record. No duplicate entries allowed.
                        if (clsTestsDataAccess.DoesTestExistForAppointment(this.TestDTO.TestAppointmentID))
                        {
                            this.TestDTO.LastValidationError = "Validation Fail: A finalized test evaluation record has already been submitted for this specific appointment index.";
                            return false;
                        }
                        return _AddNewTest();

                    case clsTestDTO.enMode.Update:
                        clsTest originalRecord = clsTest.Find(this.TestDTO.TestID);
                        if (originalRecord != null)
                        {
                            // Guard Rule: The appointment relationship index pointer cannot be modified after compilation
                            if (originalRecord.TestDTO.TestAppointmentID != this.TestDTO.TestAppointmentID)
                            {
                                this.TestDTO.LastValidationError = "Validation Fail: Structural alterations to the historical TestAppointmentID reference are strictly prohibited.";
                                return false;
                            }
                        }
                        return _UpdateTest();

                    default:
                        return false;
                }
            }

            public static DataTable GetAllTests()
            {
                return clsTestsDataAccess.GetAllTests();
            }
        }
    }
}