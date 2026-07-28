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
             
                clsLocalDrivingLicensecsDTO FilledDto = new clsLocalDrivingLicensecsDTO
                {
                    LocalDrivingLicenseApplicationID = LocalApplicationId,
                    ApplicationID = ApplicationId, 
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
          
            clsLicenseClass licenseClass = clsLicenseClass.Find(this.LocalDrivingLicensecsDTO.LicenseClassId);
            if (licenseClass == null)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Error: Target license class was not found.";
                return false;
            }

         
            clsApplication baseApp = clsApplication.Find(this.LocalDrivingLicensecsDTO.ApplicationID);
            if (baseApp == null)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Error: Linked base application record was not found.";
                return false;
            }


            clsApplicationTypes appType = clsApplicationTypes.Find(baseApp.ApplicationDTO.ApplicationTypeID);
            if (appType == null)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Error: Linked application type was not found.";
                return false;
            }

           
            decimal applicationTypeFee = appType.DTO.ApplicationFees;
            decimal newClassFee = licenseClass.clsLicenseClassDTO.ClassFees;

            baseApp.ApplicationDTO.PaidFees = applicationTypeFee + newClassFee;

          
            if (!baseApp.Save())
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Error: Failed to update base application fees for the new license class.";
                return false;
            }


            return clsLocalDrivingLicenseApplicationDataAccess.UpdateLocalDrivingLicenseApplication(
                this.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID,
                this.LocalDrivingLicensecsDTO.LicenseClassId
            );
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
          // Sync Lazy-Loaded Composition Objects (Pointers)
            if (this.LocalDrivingLicensecsDTO.ApplicationID > 0)
            {
                if (this.ApplicationInfo == null || this.ApplicationInfo.ApplicationDTO.ApplicationID != this.LocalDrivingLicensecsDTO.ApplicationID)
                {
                    this.ApplicationInfo = clsApplication.Find(this.LocalDrivingLicensecsDTO.ApplicationID);
                }
            }

            if (this.LocalDrivingLicensecsDTO.LicenseClassId > 0)
            {
                if (this.LicenseClassInfo == null || this.LicenseClassInfo.clsLicenseClassDTO.LicenseClassID != this.LocalDrivingLicensecsDTO.LicenseClassId)
                {
                    this.LicenseClassInfo = clsLicenseClass.Find(this.LocalDrivingLicensecsDTO.LicenseClassId);
                }
            }

        
            if (this.LocalDrivingLicensecsDTO.ApplicationID <= 0)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: Linked Base Application ID is missing or invalid.";
                return false;
            }

            if (this.LocalDrivingLicensecsDTO.LicenseClassId <= 0 || this.LicenseClassInfo == null)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: Target License Class is invalid or does not exist.";
                return false;
            }

            if (this.ApplicationInfo == null)
            {
                this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: Linked Base Application record was not found.";
                return false;
            }

           
            switch (this.LocalDrivingLicensecsDTO.Mode)
            {
                case clsLocalDrivingLicensecsDTO.enMode.AddNew:


                    if (CheckIfBaseApplicationAlreadyLinked())
                    {
                        this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: This base application is already linked to another local application.";
                        return false;
                    }

                    return _AddNewLocalDrivingLicenseApplication();

                case clsLocalDrivingLicensecsDTO.enMode.Update:

                    // Fetch original state to protect immutable relations
                    clsLocalDrivingLicensecs originalRecord = clsLocalDrivingLicensecs.Find(this.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID);

                    if (originalRecord == null)
                    {
                        this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: The local driving license application record being updated no longer exists.";
                        return false;
                    }

                    // Guard Rail: Prohibit re-linking to a different base ApplicationID
                    if (originalRecord.LocalDrivingLicensecsDTO.ApplicationID != this.LocalDrivingLicensecsDTO.ApplicationID)
                    {
                        this.LocalDrivingLicensecsDTO.LastValidationError = "Validation Fail: Modifying the base ApplicationID link on an existing record is strictly prohibited.";
                        return false;
                    }

                    return _UpdateLocalDrivingLicenseApplication();

                default:
                    return false;
            }
        }
    }

    }
