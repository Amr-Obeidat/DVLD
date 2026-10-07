using DVLD_Business.Applications;
using DVLD_Business.Drivers;
using DVLD_Business.Tests;
using DVLD_DataAccess.Applications;
using System;
using System.Data;

namespace DVLD_Business.Licenses
{
    public class clsLocalDrivingLicensecsDTO
    {
        public enum enMode
        {
            Update = 0,
            AddNew = 1
        }

        public int LocalDrivingLicenseApplicationID { get; set; } = -1;
        public int LicenseClassId { get; set; } = -1;
        public enMode Mode { get; set; } = enMode.AddNew;
        public string LastValidationError { get; set; } = string.Empty;
    }

    public class clsLocalDrivingLicensecs : clsApplication
    {
        public clsLocalDrivingLicensecsDTO LocalDrivingLicenseDTO { get; set; }

        public clsLicenseClass LicenseClassInfo { get; set; }

        public clsLocalDrivingLicensecs() : base()
        {
            LocalDrivingLicenseDTO = new clsLocalDrivingLicensecsDTO();
            LicenseClassInfo = null;

        }

        private clsLocalDrivingLicensecs(clsLocalDrivingLicensecsDTO FilledDTO) : base()
        {
            LocalDrivingLicenseDTO = FilledDTO;
            ApplicationDTO.Mode = clsApplicationDTO.enMode.Update;
            LicenseClassInfo = clsLicenseClass.Find(FilledDTO.LicenseClassId);
        }

        public static new clsLocalDrivingLicensecs Find(int localApplicationId)
        {
            int applicationId = -1;
            int licenseClassId = -1;

            bool isFound =
                clsLocalDrivingLicenseApplicationDataAccess
                .GetLocalDrivingLicenseApplicationInfoByID(
                    localApplicationId,
                    ref applicationId,
                    ref licenseClassId);

            if (!isFound)
                return null;

            clsApplication application = clsApplication.Find(applicationId);// Fetch the base application details

            if (application == null)
                return null;

            clsLocalDrivingLicensecsDTO FilledDTO =
                new clsLocalDrivingLicensecsDTO
                {
                    LocalDrivingLicenseApplicationID = localApplicationId,
                    LicenseClassId = licenseClassId,
                    Mode = clsLocalDrivingLicensecsDTO.enMode.Update
                };



            clsLocalDrivingLicensecs localApplication = new clsLocalDrivingLicensecs(FilledDTO);
            //rhis is the whole class instance with the filled DTO


            // fill the base class properties from the found application
            localApplication.ApplicationDTO.ApplicationID =
                application.ApplicationDTO.ApplicationID;

            localApplication.ApplicationDTO.ApplicantPersonID =
                application.ApplicationDTO.ApplicantPersonID;

            localApplication.ApplicationDTO.ApplicationTypeID =
                application.ApplicationDTO.ApplicationTypeID;

            localApplication.ApplicationDTO.ApplicationDate =
                application.ApplicationDTO.ApplicationDate;

            localApplication.ApplicationDTO.ApplicationStatus =
                application.ApplicationDTO.ApplicationStatus;

            localApplication.ApplicationDTO.LastStatusDate =
                application.ApplicationDTO.LastStatusDate;

            localApplication.ApplicationDTO.PaidFees =
                application.ApplicationDTO.PaidFees;

            localApplication.ApplicationDTO.CreatedByUserID =
                application.ApplicationDTO.CreatedByUserID;

            // Fill the composition properties from the found application
            localApplication.PersonInfo = application.PersonInfo;
            localApplication.CreatedByUserInfo = application.CreatedByUserInfo;
            localApplication.ApplicationTypeInfo = application.ApplicationTypeInfo;

            return localApplication;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            int newId = -1;

            bool success =
                clsLocalDrivingLicenseApplicationDataAccess
                .AddNewLocalDrivingLicenseApplication(
                    ref newId,
                    ApplicationDTO.ApplicationID,// Original Application ID from the base class
                    LocalDrivingLicenseDTO.LicenseClassId);

            if (!success)
            {
                LocalDrivingLicenseDTO.LastValidationError =
                    "Database Error: Failed to insert new local driving license application.";

                return false;
            }

            LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID = newId;
            LocalDrivingLicenseDTO.Mode =
                clsLocalDrivingLicensecsDTO.enMode.Update;

            return true;
        }

        public new bool Save()
        {
            if (LocalDrivingLicenseDTO.Mode == clsLocalDrivingLicensecsDTO.enMode.Update ||
                ApplicationDTO.Mode == clsApplicationDTO.enMode.Update)
            {
                LocalDrivingLicenseDTO.LastValidationError =
                    "System Restriction: Applications are immutable once created. Use the appropriate operation to change application state.";

                return false;
            }

            // Add new application logic

            if (LocalDrivingLicenseDTO.LicenseClassId <= 0)
            {
                LocalDrivingLicenseDTO.LastValidationError =
                    "Validation Fail: A valid license class is required.";

                return false;
            }

            LicenseClassInfo = clsLicenseClass.Find(LocalDrivingLicenseDTO.LicenseClassId);

            if (LicenseClassInfo == null)
            {
                LocalDrivingLicenseDTO.LastValidationError =
                    "Validation Fail: The selected license class does not exist.";

                return false;
            }

            if (ApplicationTypeInfo == null) // 
            {
                ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationDTO.ApplicationTypeID);
            }

            if (ApplicationTypeInfo == null)
            {
                LocalDrivingLicenseDTO.LastValidationError =
                    "Validation Fail: The application type was not found.";

                return false;
            }





            if (!base.Save())
            {
                LocalDrivingLicenseDTO.LastValidationError = ApplicationDTO.LastValidationError;

                return false;
            }

            return _AddNewLocalDrivingLicenseApplication();
        }

        public static bool Delete(int localApplicationId)
        {
            return clsLocalDrivingLicenseApplicationDataAccess
                .DeleteLocalDrivingLicenseApplication(localApplicationId);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationDataAccess
                .GetAllLocalDrivingLicenseApplications();
        }
        public static byte GetPassedTestCount(int localDrivingLicenseApplicationId)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetPassedTestCount(localDrivingLicenseApplicationId);
        }

        public byte GetPassedTestCount()
        {
            return clsLocalDrivingLicensecs.GetPassedTestCount(this.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID);
        }
        public bool DoesPassTestType(clsTestTypesDTO.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassTestType(this.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID, (short)TestTypeID);
        }

        public bool DoesPassTestType(int localDrivingLicenseApplicationId, clsTestTypesDTO.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassTestType(localDrivingLicenseApplicationId, (short)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestTypesDTO.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesAttendTestType(this.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID, (short)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestTypesDTO.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(this.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID, (short)TestTypeID);
        }


        public static byte TotalTrialsPerTest(int localDrivingLicenseApplicationId, clsTestTypesDTO.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(localDrivingLicenseApplicationId, (short)TestTypeID);
        }


        /////////////////////
        public bool IsThereAnActiveScheduledTest(clsTestTypesDTO.enTestType TestTypeID)
        {
            return clsLocalDrivingLicensecs.IsThereAnActiveScheduledTest(
                this.LocalDrivingLicenseDTO.LocalDrivingLicenseApplicationID, TestTypeID

            );
        }


        public static bool IsThereAnActiveScheduledTest(int localDrivingLicenseApplicationId, clsTestTypesDTO.enTestType TestTypeId)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.IsThereAnActiveScheduledTest(localDrivingLicenseApplicationId, (short)TestTypeId);
        }
    


        public bool SetCompleted()
        {
            bool isUpdated = clsApplicationsDataAccess.UpdateApplicationStatus(
        this.ApplicationDTO.ApplicationID,
        (byte)clsApplicationDTO.enApplicationStatus.Completed
    );

            if (isUpdated)
            {
                this.ApplicationDTO.ApplicationStatus = (byte)clsApplicationDTO.enApplicationStatus.Completed;
                this.ApplicationDTO.LastStatusDate = DateTime.Now;
            }

            return isUpdated;
        }
        public int IssueLicenseForFirstTime(string notes, int createdByUserId)
        {
           
            if (this.LicenseClassInfo == null)
            {
                this.LicenseClassInfo = clsLicenseClass.Find(this.LocalDrivingLicenseDTO.LicenseClassId);
                if (this.LicenseClassInfo == null)
                    return -1;
            }

           
            int driverId = -1;
            clsDriver driver = clsDriver.FindByPersonID(this.ApplicationDTO.ApplicantPersonID);

            if (driver == null)
            {
                driver = new clsDriver();
                driver.DriverDTO.PersonID = this.ApplicationDTO.ApplicantPersonID;
                driver.DriverDTO.CreatedByUserID = createdByUserId;
                driver.DriverDTO.CreatedDate = DateTime.Now;

                if (driver.Save())
                {
                    driverId = driver.DriverDTO.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                driverId = driver.DriverDTO.DriverID;
            }

           
            clsLicense newLicense = new clsLicense();
            newLicense.LicenseDTO.ApplicationID = this.ApplicationDTO.ApplicationID;
            newLicense.LicenseDTO.DriverID = driverId;
            newLicense.LicenseDTO.LicenseClassID = this.LocalDrivingLicenseDTO.LicenseClassId;
            newLicense.LicenseDTO.IssueDate = DateTime.Now;
            newLicense.LicenseDTO.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.clsLicenseClassDTO.DefaultValidityLength);
            newLicense.LicenseDTO.Notes = string.IsNullOrWhiteSpace(notes) ? "No Notes" : notes.Trim();
            newLicense.LicenseDTO.PaidFees = this.LicenseClassInfo.clsLicenseClassDTO.ClassFees;
            newLicense.LicenseDTO.IsActive = true;
            newLicense.LicenseDTO.IssueReason = clsLicenseDTO.enIssueReason.FirstTime;
            newLicense.LicenseDTO.CreatedByUserID = createdByUserId;

            if (newLicense.Save())
            {
               
                this.SetCompleted();

               
                return newLicense.LicenseDTO.LicenseID;
            }

            return -1;
        }
    }
}