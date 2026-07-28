using DVLD_Business.Applications;
using DVLD_Business.Drivers;
using DVLD_DataAccess.Licenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_Business.Licenses
{

    public class clsLicenseDTO
    {



        
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int LicenseID { get; set; } = -1;
        public int ApplicationID { get; set; } = -1;
        public int DriverID { get; set; } = -1;
        public int LicenseClassID { get; set; } = -1;
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = "";
        public decimal PaidFees { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public byte IssueReason { get; set; } = 1; // 1 = FirstTime, 2 = Renew, 3 = ReplacementForDamaged, 4 = ReplacementForLost
        public int CreatedByUserID { get; set; } = -1;
        public string LastValidationError { get; set; } = "";
    }
    public class clsLicense
    {
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }

        public clsLicenseDTO LicenseDTO { get; set; }

        public clsLicense()
        {
            this.LicenseDTO = new clsLicenseDTO();
            this.LicenseDTO.Mode = clsLicenseDTO.enMode.AddNew;
        }

        private clsLicense(clsLicenseDTO DTO)
        {
            this.LicenseDTO = DTO;
            this.LicenseDTO.Mode = clsLicenseDTO.enMode.Update;
        }

        public int LicenseID => this.LicenseDTO.LicenseID;
        public int LicenseClassID => this.LicenseDTO.LicenseClassID;
        public DateTime ExpirationDate => this.LicenseDTO.ExpirationDate;
        public bool IsActive => this.LicenseDTO.IsActive;

      
        public bool IsDetained { get; set; } = false;

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 1;
            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.GetLicenseInfoByID(
                LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                clsLicenseDTO dto = new clsLicenseDTO
                {
                    LicenseID = LicenseID,
                    ApplicationID = ApplicationID,
                    DriverID = DriverID,
                    LicenseClassID = LicenseClass,
                    IssueDate = IssueDate,
                    ExpirationDate = ExpirationDate,
                    Notes = Notes,
                    PaidFees = PaidFees,
                    IsActive = IsActive,
                    IssueReason = IssueReason,
                    CreatedByUserID = CreatedByUserID
                };
                return new clsLicense(dto);
            }
            return null;
        }

        private bool _AddNewLicense()
        {
            this.LicenseDTO.LicenseID = clsLicenseDataAccess.AddNewLicense(
                this.LicenseDTO.ApplicationID,
                this.LicenseDTO.DriverID,
                this.LicenseDTO.LicenseClassID,
                this.LicenseDTO.IssueDate,
                this.LicenseDTO.ExpirationDate,
                this.LicenseDTO.Notes,
                this.LicenseDTO.PaidFees,
                this.LicenseDTO.IsActive,
                this.LicenseDTO.IssueReason,
                this.LicenseDTO.CreatedByUserID
            );

            return (this.LicenseDTO.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseDataAccess.UpdateLicense(
               this.LicenseDTO.LicenseID,this.LicenseDTO.Notes,this.LicenseDTO.IsActive
            );
        }

        public bool Save()
        {
          

            if (this.LicenseDTO.ApplicationID <= 0)
            {
                this.LicenseDTO.LastValidationError = "Validation Fail: Application ID reference is missing or invalid.";
                return false;
            }

            if (this.LicenseDTO.DriverID <= 0)
            {
                this.LicenseDTO.LastValidationError = "Validation Fail: Driver ID reference is missing or invalid.";
                return false;
            }

            if (this.LicenseDTO.LicenseClassID <= 0)
            {
                this.LicenseDTO.LastValidationError = "Validation Fail: License Class reference is missing or invalid.";
                return false;
            }

            if (this.LicenseDTO.CreatedByUserID <= 0)
            {
                this.LicenseDTO.LastValidationError = "Validation Fail: Created By User ID reference is missing or invalid.";
                return false;
            }

          

            if (clsApplication.Find(this.LicenseDTO.ApplicationID) == null)
            {
                this.LicenseDTO.LastValidationError = $"Validation Fail: Foreign Key Error - Linked Application ID [{this.LicenseDTO.ApplicationID}] does not exist in the database.";
                return false;
            }

            if (clsDriver.Find(this.LicenseDTO.DriverID) == null)
            {
                this.LicenseDTO.LastValidationError = $"Validation Fail: Foreign Key Error - Linked Driver ID [{this.LicenseDTO.DriverID}] does not exist in the database.";
                return false;
            }

            if (clsLicenseClass.Find(this.LicenseDTO.LicenseClassID) == null)
            {
                this.LicenseDTO.LastValidationError = $"Validation Fail: Foreign Key Error - Linked License Class ID [{this.LicenseDTO.LicenseClassID}] does not exist in the database.";
                return false;
            }

         

            switch (this.LicenseDTO.Mode)
            {
                case clsLicenseDTO.enMode.AddNew:
                    return _AddNewLicense();

                case clsLicenseDTO.enMode.Update:

                    clsLicense originalLicense = clsLicense.Find(this.LicenseDTO.LicenseID);

                    if (originalLicense == null)
                    {
                        this.LicenseDTO.LastValidationError = $"Validation Fail: The license record with ID [{this.LicenseDTO.LicenseID}] does not exist.";
                        return false;
                    }

                 

                    if (originalLicense.LicenseDTO.ApplicationID != this.LicenseDTO.ApplicationID)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Modifying the linked Application ID on an existing license record is prohibited.";
                        return false;
                    }

                    if (originalLicense.LicenseDTO.DriverID != this.LicenseDTO.DriverID)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Modifying the linked Driver ID on an existing license record is prohibited.";
                        return false;
                    }

                    if (originalLicense.LicenseDTO.LicenseClassID != this.LicenseDTO.LicenseClassID)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Modifying the License Class on an issued card is prohibited.";
                        return false;
                    }

                    if (originalLicense.LicenseDTO.IssueDate != this.LicenseDTO.IssueDate)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Modifying the original Issue Date of an issued license card is prohibited.";
                        return false;
                    }

                    if (originalLicense.LicenseDTO.ExpirationDate != this.LicenseDTO.ExpirationDate)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Expiration date cannot be modified directly. Use the 'Renew License' service to extend license validity.";
                        return false;
                    }

                    if (originalLicense.LicenseDTO.IssueReason != this.LicenseDTO.IssueReason)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Modifying the Issue Reason on an existing license card is prohibited.";
                        return false;
                    }

                    if (originalLicense.LicenseDTO.PaidFees != this.LicenseDTO.PaidFees)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Modifying historical Paid Fees on an issued license record is prohibited.";
                        return false;
                    }

                    if (originalLicense.LicenseDTO.CreatedByUserID != this.LicenseDTO.CreatedByUserID)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Modifying the issuer User ID audit trail is prohibited.";
                        return false;
                    }

                 

                    if (!originalLicense.LicenseDTO.IsActive && this.LicenseDTO.IsActive)
                    {
                        this.LicenseDTO.LastValidationError = "Validation Fail: Reactivating a deactivated license card is prohibited.";
                        return false;
                    }

                    return _UpdateLicense();

                default:
                    return false;
            }
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseDataAccess.GetDriverLicenses(DriverID);
        }
    }
}

