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
      
        public bool TestResults { get; set; }   
        public int CreatedByUserID { get; set; } = -1;
        public string LastValidationError { get; set; } = "";
    }
  
namespace DVLD_Business.Tests
    {
        public class clsTest
        {
            public clsTestAppointment TestAppointment { get; set; }
            public clsTestDTO TestDTO { get; set; }

            public clsTest()
            {
                this.TestDTO = new clsTestDTO();
                this.TestDTO.Mode = clsTestDTO.enMode.AddNew;
                this.TestAppointment = null;
            }

            private clsTest(clsTestDTO DTO)
            {
                this.TestDTO = DTO;
                this.TestDTO.Mode = clsTestDTO.enMode.Update;
                TestAppointment = clsTestAppointment.Find(TestDTO.TestAppointmentID);
                
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
                if (TestAppointment == null)
                {
                    TestDTO.LastValidationError = "Validation Fail: Test Appointment does not exist.";
                    return false;
                }

                TestDTO.TestAppointmentID = TestAppointment.AppointmentDTO.TestAppointmentID;

                // 1. Insert test result into Tests table
                TestDTO.TestID = clsTestsDataAccess.AddNewTest(
                    TestDTO.TestAppointmentID,
                    TestDTO.TestResult,
                    TestDTO.Notes,
                    TestDTO.CreatedByUserID
                );

                if (TestDTO.TestID == -1)
                    return false;

                // 2. Lock the appointment directly without triggering the Save validation pipeline
                if (!TestAppointment.Lock())
                {
                    TestDTO.LastValidationError = "Test was created, but the appointment could not be locked in the database.";
                    return false;
                }

                // Keep in-memory DTO in sync
                TestAppointment.AppointmentDTO.IsLocked = true;

                return true;
            }

            private bool _UpdateTest()
            {

                return clsTestsDataAccess.UpdateTest(this.TestDTO.TestID, this.TestDTO.TestResult, this.TestDTO.Notes);

            }

            public bool Save()
            {
                if (this.TestDTO.CreatedByUserID <= 0)
                {
                    this.TestDTO.LastValidationError =
                        "Validation Fail: CreatedByUserID is required.";

                    return false;
                }


                switch (this.TestDTO.Mode)
                {
                    case clsTestDTO.enMode.AddNew:

                        // The appointment object is required when creating a new test
                        if (this.TestAppointment == null)
                        {
                            this.TestDTO.LastValidationError =
                                "Validation Fail: Test Appointment is required.";

                            return false;
                        }

                        // Get the ID from the composed appointment
                        this.TestDTO.TestAppointmentID =
                            this.TestAppointment.AppointmentDTO.TestAppointmentID;

                        if (this.TestDTO.TestAppointmentID <= 0)
                        {
                            this.TestDTO.LastValidationError =
                                "Validation Fail: Invalid Test Appointment.";

                            return false;
                        }


                        // An appointment can have only one test
                        if (clsTestsDataAccess.DoesTestExistForAppointment(
                            this.TestDTO.TestAppointmentID))
                        {
                            this.TestDTO.LastValidationError =
                                "Validation Fail: A test already exists for this appointment.";

                            return false;
                        }

                        return _AddNewTest();


                    case clsTestDTO.enMode.Update:

                        clsTest originalRecord =  clsTest.Find(this.TestDTO.TestID);

                        if (originalRecord == null)
                        {
                            this.TestDTO.LastValidationError =
                                "Validation Fail: Test record was not found.";

                            return false;
                        }


                        // Appointment relationship cannot be changed
                        if (originalRecord.TestDTO.TestAppointmentID !=
                            this.TestDTO.TestAppointmentID)
                        {
                            this.TestDTO.LastValidationError =
                                "Validation Fail: Test Appointment cannot be changed.";

                            return false;
                        }


                        // Creator cannot be changed
                        if (originalRecord.TestDTO.CreatedByUserID !=
                            this.TestDTO.CreatedByUserID)
                        {
                            this.TestDTO.LastValidationError =
                                "Validation Fail: CreatedByUserID cannot be changed.";

                            return false;
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