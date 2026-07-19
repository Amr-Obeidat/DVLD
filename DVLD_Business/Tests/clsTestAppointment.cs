using DVLD_DataAccess.TestAppointments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business.Tests
{

    public class clsTestAppointmentDTO
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int TestAppointmentID { get; set; } = -1;
        public int TestTypeID { get; set; } = -1;
        public int LocalDrivingLicenseApplicationID { get; set; } = -1;
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; } = -1;
        public bool IsLocked { get; set; } = false;
        public string LastValidationError { get; set; } = "";
    }

    public class clsTestAppointment
    {
        public clsTestAppointmentDTO AppointmentDTO { get; set; }

        public clsTestAppointment()
        {
            this.AppointmentDTO = new clsTestAppointmentDTO();
            this.AppointmentDTO.Mode = clsTestAppointmentDTO.enMode.AddNew;
        }

        private clsTestAppointment(clsTestAppointmentDTO DTO)
        {
            this.AppointmentDTO = DTO;
            this.AppointmentDTO.Mode = clsTestAppointmentDTO.enMode.Update;
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;

            if (clsTestAppointmentsDataAccess.GetAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked))
            {
                clsTestAppointmentDTO dto = new clsTestAppointmentDTO
                {
                    TestAppointmentID = TestAppointmentID,
                    TestTypeID = TestTypeID,
                    LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID,
                    AppointmentDate = AppointmentDate,
                    PaidFees = PaidFees,
                    CreatedByUserID = CreatedByUserID,
                    IsLocked = IsLocked
                };
                return new clsTestAppointment(dto);
            }
            return null;
        }

        private bool _AddNewAppointment()
        {
            this.AppointmentDTO.TestAppointmentID = clsTestAppointmentsDataAccess.AddNewAppointment(
                this.AppointmentDTO.TestTypeID,
                this.AppointmentDTO.LocalDrivingLicenseApplicationID,
                this.AppointmentDTO.AppointmentDate,
                this.AppointmentDTO.PaidFees,
                this.AppointmentDTO.CreatedByUserID,
                this.AppointmentDTO.IsLocked
            );

            return (this.AppointmentDTO.TestAppointmentID != -1);
        }

        private bool _UpdateAppointment()
        {
            return clsTestAppointmentsDataAccess.UpdateAppointment(
                this.AppointmentDTO.TestAppointmentID,
                this.AppointmentDTO.TestTypeID,
                this.AppointmentDTO.LocalDrivingLicenseApplicationID,
                this.AppointmentDTO.AppointmentDate,
                this.AppointmentDTO.PaidFees,
                this.AppointmentDTO.CreatedByUserID,
                this.AppointmentDTO.IsLocked
            );
        }

        public bool Save()
        {
            // 1. Structural Sanity Check
            if (this.AppointmentDTO.LocalDrivingLicenseApplicationID <= 0 || this.AppointmentDTO.TestTypeID <= 0 || this.AppointmentDTO.CreatedByUserID <= 0)
            {
                this.AppointmentDTO.LastValidationError = "Validation Fail: Required Application, Test Type, or User reference properties are missing.";
                return false;
            }

            // 2. State-Driven Validation Engine Pipeline
            switch (this.AppointmentDTO.Mode)
            {
                case clsTestAppointmentDTO.enMode.AddNew:
                    // Security rule: An applicant cannot book a new appointment if they have an active open/unlocked appointment for the same test type
                    if (clsTestAppointmentsDataAccess.CheckForActiveAppointment(this.AppointmentDTO.LocalDrivingLicenseApplicationID, this.AppointmentDTO.TestTypeID))
                    {
                        this.AppointmentDTO.LastValidationError = "Validation Fail: This application already has an active open appointment pending for this test type.";
                        return false;
                    }
                    return _AddNewAppointment();

                case clsTestAppointmentDTO.enMode.Update:
                    clsTestAppointment originalRecord = clsTestAppointment.Find(this.AppointmentDTO.TestAppointmentID);
                    if (originalRecord != null)
                    {
                        // Guard rule: Once a test record is locked (meaning the test was conducted), modifications are strictly prohibited
                        if (originalRecord.AppointmentDTO.IsLocked)
                        {
                            this.AppointmentDTO.LastValidationError = "Validation Fail: Modifications are strictly prohibited on locked test appointment histories.";
                            return false;
                        }

                        // Guard rule: Changing the underlying application tracking association is strictly prohibited
                        if (originalRecord.AppointmentDTO.LocalDrivingLicenseApplicationID != this.AppointmentDTO.LocalDrivingLicenseApplicationID)
                        {
                            this.AppointmentDTO.LastValidationError = "Validation Fail: Modifying the base LocalDrivingLicenseApplicationID link on active appointments is strictly prohibited.";
                            return false;
                        }
                    }
                    return _UpdateAppointment();

                default:
                    return false;
            }
        }

        public static DataTable GetApplicationAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsDataAccess.GetApplicationAppointmentsPerTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }
    }
}


