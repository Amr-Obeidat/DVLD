using System;
using System.Data;
using System.Runtime.CompilerServices;
using DVLD_Business.Applications; // For composition with base application
using DVLD_Business.Licenses;     // For composition with license classes
using DVLD_DataAccess.Applications;

namespace DVLD_Business.Licenses
{
    public class clsLocalDrivingLicensecsDTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; } = -1;
        public int ApplicationID { get; set; } = -1;
        public int LicenseClassId { get; set; } = -1;

        public enum enMode { AddNew = 1, Update = 0 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public string LastValidationError { get; set; } = string.Empty;
    }

    public class clsLocalDrivingLicensecs
    {
        public clsLocalDrivingLicensecsDTO LocalDrivingLicensecsDTO { get; set; }

        // COMPOSITION HOOKS: Gives your UI direct access to base application records and metadata
        public clsApplication ApplicationInfo { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }

        public clsLocalDrivingLicensecs()
        {
            this.LocalDrivingLicensecsDTO = new clsLocalDrivingLicensecsDTO();
            this.LocalDrivingLicensecsDTO.Mode = clsLocalDrivingLicensecsDTO.enMode.AddNew;

            this.ApplicationInfo = null;
            this.LicenseClassInfo = null;
        }

        private clsLocalDrivingLicensecs(clsLocalDrivingLicensecsDTO FilledDTO)
        {
            this.LocalDrivingLicensecsDTO = FilledDTO;
            this.LocalDrivingLicensecsDTO.Mode = clsLocalDrivingLicensecsDTO.enMode.Update;

            // Hydrate complex compositions seamlessly upon retrieval
            this.ApplicationInfo = clsApplication.Find(FilledDTO.ApplicationID);
            this.LicenseClassInfo = clsLicenseClass.Find(FilledDTO.LicenseClassId);
        }

        private bool CheckIfBaseApplicationAlreadyLinked()
        {
           
            return clsLocalDrivingLicenseApplicationDataAccess.DoesLocalDrivingLicenseApplicationExist(this.LocalDrivingLicensecsDTO.ApplicationID);
        }

        public static clsLocalDrivingLicensecs Find(int LocalApplicationId)
        {
            int ApplicationId = -1;
            int LicenseClassId = -1;

            bool isFound = clsLocalDrivingLicenseApplicationDataAccess.GetLocalDrivingLicenseApplicationInfoByID(
                LocalApplicationId, ref ApplicationId, ref LicenseClassId
            );

            if (isFound)
            {
                // FIXED: Populate the safe DTO carrier instead of the wrapper class instance
                clsLocalDrivingLicensecsDTO FilledDto = new clsLocalDrivingLicensecsDTO
                {
                    LocalDrivingLicenseApplicationID = LocalApplicationId,
                    ApplicationID = ApplicationId, // FIXED: Correctly mapped foreign key tracking ID
                    LicenseClassId = LicenseClassId
                };

                return new clsLocalDrivingLicensecs(FilledDto);
            }

            return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            int NewId = -1;
            bool success = clsLocalDrivingLicenseApplicationDataAccess.AddNewLocalDrivingLicenseApplication(
                ref NewId,
                this.LocalDrivingLicensecsDTO.ApplicationID,
                this.LocalDrivingLicensecsDTO.LicenseClassId
            );

            if (success)
            {
                this.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID = NewId;
                this.LocalDrivingLicensecsDTO.Mode = clsLocalDrivingLicensecsDTO.enMode.Update;
                return true;
            }

            this.LocalDrivingLicensecsDTO.LastValidationError = "Database Error: Failed to insert new local application record.";
            return false;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            bool success = clsLocalDrivingLicenseApplicationDataAccess.UpdateLocalDrivingLicenseApplication(
                this.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID,
                this.LocalDrivingLicensecsDTO.ApplicationID,
                this.LocalDrivingLicensecsDTO.LicenseClassId
            );

            if (!success)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Database Error: Failed to update local application properties.";
            }
            return success;
        }

        public static bool Delete(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetAllLocalDrivingLicenseApplications();
        }

        public bool Save()
        {
            if (this.ApplicationInfo != null && this.ApplicationInfo.clsApplicationDTO.ApplicationID != this.LocalDrivingLicensecsDTO.ApplicationID)
            {
                // If they are in Update mode, this is a security violation! Let the code flow down to the Update guard clause to catch it.
                // If they are in AddNew mode, we synchronize the pointer to match the forced ID change.
                if (this.LocalDrivingLicensecsDTO.Mode == clsLocalDrivingLicensecsDTO.enMode.AddNew)
                {
                    this.ApplicationInfo = clsApplication.Find(this.LocalDrivingLicensecsDTO.ApplicationID);
                }
            }
            else if (this.ApplicationInfo != null)
            {
                // Smooth baseline assignment if they are perfectly in sync
                this.LocalDrivingLicensecsDTO.ApplicationID = this.ApplicationInfo.clsApplicationDTO.ApplicationID;
            }





            if (this.LicenseClassInfo != null && this.LicenseClassInfo.clsLicenseClassDTO.LicenseClassID != this.LocalDrivingLicensecsDTO.LicenseClassId)
            {
                // If the DTO ID was changed manually in code  update our composition pointer
                this.LicenseClassInfo = clsLicenseClass.Find(this.LocalDrivingLicensecsDTO.LicenseClassId);
            }

                if (this.LocalDrivingLicensecsDTO.ApplicationID <= 0 || this.LocalDrivingLicensecsDTO.LicenseClassId <= 0)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: Base Application ID or License Class ID references are missing.";
                return false;
            }

            switch (this.LocalDrivingLicensecsDTO.Mode)
            {
                case clsLocalDrivingLicensecsDTO.enMode.AddNew:
                    if (CheckIfBaseApplicationAlreadyLinked())
                    {
                        this.LocalDrivingLicensecsDTO.LastValidationError = "Record Already Exists! This base application is already linked to a local driving license application.";
                        return false;
                    }
                    return _AddNewLocalDrivingLicenseApplication();

                case clsLocalDrivingLicensecsDTO.enMode.Update:
                    clsLocalDrivingLicensecs originalRecord = clsLocalDrivingLicensecs.Find(this.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID);

                    if (originalRecord != null && originalRecord.LocalDrivingLicensecsDTO.ApplicationID != this.LocalDrivingLicensecsDTO.ApplicationID)
                    {
                        this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: Modifying the base ApplicationID link on an active record is strictly prohibited.";
                        return false;
                    }

                    return _UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
        }
    }

    }
