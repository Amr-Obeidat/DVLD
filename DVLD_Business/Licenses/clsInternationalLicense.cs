using DVLD_Business.Applications;
using DVLD_Business.Drivers;
using DVLD_DataAccess.Licenses;
using System;
using System.Data;
using System.Transactions;

namespace DVLD_Business.Licenses
{
    public class clsInternationalLicenseDTO
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int InternationalLicenseID { get; set; } = -1;
        public int ApplicationID { get; set; } = -1;
        public int DriverID { get; set; } = -1;
        public int IssuedUsingLocalLicenseID { get; set; } = -1;
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddYears(1);
        public bool IsActive { get; set; } = true;
        public int CreatedByUserID { get; set; } = -1;
        public string LastValidationError { get; set; } = "";
    }

    public class clsInternationalLicense
    {
        public clsInternationalLicenseDTO InternationalLicenseDTO { get; set; }

       
        public clsApplication ApplicationInfo { get; set; }
        public clsDriver DriverInfo { get; set; }

       
        public clsDriver Driver => DriverInfo;

        public clsInternationalLicense()
        {
            this.InternationalLicenseDTO = new clsInternationalLicenseDTO();
            this.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.AddNew;

            this.ApplicationInfo = new clsApplication();
            this.DriverInfo = new clsDriver();
        }

        private clsInternationalLicense(clsInternationalLicenseDTO dto)
        {
            this.InternationalLicenseDTO = dto;
            this.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.Update;

          
            this.ApplicationInfo = clsApplication.Find(dto.ApplicationID);
            this.DriverInfo = clsDriver.Find(dto.DriverID);
        }

        public static clsInternationalLicense Find(int internationalLicenseID)
        {
            int applicationID = -1;
            int driverID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUserID = -1;

            if (clsInternationalLicensesDataAccess.GetInternationalLicenseInfoByID(
                internationalLicenseID, ref applicationID, ref driverID, ref issuedUsingLocalLicenseID,
                ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
            {
                clsInternationalLicenseDTO dto = new clsInternationalLicenseDTO
                {
                    InternationalLicenseID = internationalLicenseID,
                    ApplicationID = applicationID,
                    DriverID = driverID,
                    IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID,
                    IssueDate = issueDate,
                    ExpirationDate = expirationDate,
                    IsActive = isActive,
                    CreatedByUserID = createdByUserID
                };

                return new clsInternationalLicense(dto);
            }

            return null;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseDTO.InternationalLicenseID = clsInternationalLicensesDataAccess.AddNewInternationalLicense(
                this.InternationalLicenseDTO.ApplicationID,
                this.InternationalLicenseDTO.DriverID,
                this.InternationalLicenseDTO.IssuedUsingLocalLicenseID,
                this.InternationalLicenseDTO.IssueDate,
                this.InternationalLicenseDTO.ExpirationDate,
                this.InternationalLicenseDTO.IsActive,
                this.InternationalLicenseDTO.CreatedByUserID
            );

            return (this.InternationalLicenseDTO.InternationalLicenseID != -1);
        }

        public bool Save()
        {
           
            if (this.InternationalLicenseDTO.InternationalLicenseID != -1 ||
                this.InternationalLicenseDTO.Mode == clsInternationalLicenseDTO.enMode.Update)
            {
                this.InternationalLicenseDTO.LastValidationError =
                    "System Error: International licenses are immutable. Updates are prohibited. Use Deactivate() to invalidate an active card.";
                return false;
            }

       
            if (this.InternationalLicenseDTO.DriverID <= 0)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: Required Driver ID is missing.";
                return false;
            }

            if (this.InternationalLicenseDTO.CreatedByUserID <= 0)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: Required User ID is missing.";
                return false;
            }

          
            clsLicense localLicense = clsLicense.Find(this.InternationalLicenseDTO.IssuedUsingLocalLicenseID);

            if (localLicense == null)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: The specified local license does not exist.";
                return false;
            }

            if (localLicense.LicenseDTO.LicenseClassID != 3)
            {
                this.InternationalLicenseDTO.LastValidationError =
                    "Validation Fail: International licenses can only be issued for Class 3 (Ordinary Driving License).";
                return false;
            }

            if (!localLicense.LicenseDTO.IsActive)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: The linked local license is inactive.";
                return false;
            }

            if (localLicense.LicenseDTO.ExpirationDate < DateTime.Now)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: The linked local license is expired.";
                return false;
            }

           
            int activeInternationalLicenseID = -1;
            clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(
                this.InternationalLicenseDTO.DriverID,
                ref activeInternationalLicenseID
            );

            
            using (TransactionScope scope = new TransactionScope())
            {
                
                if (this.InternationalLicenseDTO.ApplicationID <= 0)
                {
                    if (this.DriverInfo == null || this.DriverInfo.DriverDTO.DriverID == -1)
                    {
                        this.DriverInfo = clsDriver.Find(this.InternationalLicenseDTO.DriverID);
                    }

                    this.ApplicationInfo.ApplicationDTO.ApplicantPersonID = this.DriverInfo.PersonInfo.PersonDTO.PersonID;
                    this.ApplicationInfo.ApplicationDTO.ApplicationDate = DateTime.Now;
                    this.ApplicationInfo.ApplicationDTO.ApplicationTypeID = (int)clsApplicationDTO.enApplicationType.NewInternationalLicense;
                    this.ApplicationInfo.ApplicationDTO.ApplicationStatus = (byte)clsApplicationDTO.enApplicationStatus.Completed;
                    this.ApplicationInfo.ApplicationDTO.LastStatusDate = DateTime.Now;
                    this.ApplicationInfo.ApplicationDTO.PaidFees = clsApplicationTypes
                        .Find((int)clsApplicationDTO.enApplicationType.NewInternationalLicense)
                        .DTO.ApplicationFees;
                    this.ApplicationInfo.ApplicationDTO.CreatedByUserID = this.InternationalLicenseDTO.CreatedByUserID;

                    if (!this.ApplicationInfo.Save())
                    {
                        this.InternationalLicenseDTO.LastValidationError = "Database Error: Failed to create base application record.";
                        return false;
                    }

                    this.InternationalLicenseDTO.ApplicationID = this.ApplicationInfo.ApplicationDTO.ApplicationID;
                }

                
                if (activeInternationalLicenseID > 0)
                {
                    clsInternationalLicense oldLicense = clsInternationalLicense.Find(activeInternationalLicenseID);
                    if (oldLicense != null && !oldLicense.Deactivate())
                    {
                        this.InternationalLicenseDTO.LastValidationError =
                            "Validation Fail: Failed to deactivate the driver's existing active international license.";
                        return false;
                    }
                }

               
                this.InternationalLicenseDTO.IsActive = true;
                bool isSaved = _AddNewInternationalLicense();

                if (!isSaved)
                {
                    this.InternationalLicenseDTO.LastValidationError =
                        "Database Error: Failed to issue the new license. Any changes have been safely rolled back.";
                    return false;
                }

                this.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.Update;
                scope.Complete();
                return true;
            }
        }

        public bool Deactivate()
        {
            if (this.InternationalLicenseDTO.Mode != clsInternationalLicenseDTO.enMode.Update)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: Cannot deactivate an unsaved or new International License entity.";
                return false;
            }

            if (!this.InternationalLicenseDTO.IsActive)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: This International License is already deactivated.";
                return false;
            }

            bool isDeactivated = clsInternationalLicensesDataAccess.DeactivateInternationalLicense(
                this.InternationalLicenseDTO.InternationalLicenseID
            );

            if (isDeactivated)
            {
                this.InternationalLicenseDTO.IsActive = false;
                return true;
            }

            this.InternationalLicenseDTO.LastValidationError = "Database Error: Failed to deactivate international license record.";
            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int driverID)
        {
            int activeID = -1;
            clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(driverID, ref activeID);
            return activeID;
        }

        public static DataTable GetDriverInternationalLicenses(int driverID)
        {
            return clsInternationalLicensesDataAccess.GetDriverInternationalLicenses(driverID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicenses();
        }
    }
}