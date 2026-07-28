using DVLD_Business.Applications;
using DVLD_Business.Drivers;
using DVLD_DataAccess.Licenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public clsInternationalLicense()
        {
            this.InternationalLicenseDTO = new clsInternationalLicenseDTO();
            this.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.AddNew;
        }

        private clsInternationalLicense(clsInternationalLicenseDTO DTO)
        {
            this.InternationalLicenseDTO = DTO;
            this.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.Update;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsInternationalLicensesDataAccess.GetInternationalLicenseInfoByID(
                InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID,
                ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                clsInternationalLicenseDTO dto = new clsInternationalLicenseDTO
                {
                    InternationalLicenseID = InternationalLicenseID,
                    ApplicationID = ApplicationID,
                    DriverID = DriverID,
                    IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID,
                    IssueDate = IssueDate,
                    ExpirationDate = ExpirationDate,
                    IsActive = IsActive,
                    CreatedByUserID = CreatedByUserID
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

            if (this.InternationalLicenseDTO.InternationalLicenseID != -1 || this.InternationalLicenseDTO.Mode == clsInternationalLicenseDTO.enMode.Update)
            {
                this.InternationalLicenseDTO.LastValidationError = "System Error: International licenses are immutable. Updates are prohibited. Use Deactivate() to invalidate an active card.";
                return false;
            }


            //  (1 )Check for foriegn keys

            if (this.InternationalLicenseDTO.ApplicationID <= 0 )
            
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: Required Application ID is missing.";
                return false;
            }


            if(this.InternationalLicenseDTO.DriverID <= 0 )
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: Required  Driver ID is missing.";
                return false;
            }

            if (this.InternationalLicenseDTO.CreatedByUserID<=0)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: Required  User ID is missing.";
                return false;
            }



            // (2) check for  local license existant and activation

            clsLicense localLicense = clsLicense.Find(this.InternationalLicenseDTO.IssuedUsingLocalLicenseID);

            if (localLicense == null)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: The specified local license does not exist.";
                return false;
            }

          
            if (localLicense.LicenseDTO.LicenseClassID != 3)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: International licenses can only be issued for Class 3 (Ordinary Driving License).";
                return false;
            }

            if (!localLicense.LicenseDTO.IsActive)
            {
                this.InternationalLicenseDTO.LastValidationError = "Validation Fail: The linked local license is inactive .";
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
                // AUTO-DEACTIVATE PREVIOUS ACTIVE LICENSES
                if (activeInternationalLicenseID > 0)
                {
                    clsInternationalLicense oldLicense = clsInternationalLicense.Find(activeInternationalLicenseID);
                    if (oldLicense != null && !oldLicense.Deactivate())
                    {
                        this.InternationalLicenseDTO.LastValidationError = "Validation Fail: Failed to deactivate the driver's existing active international license.";
                        return false;
                       
                    }
                }

                //  ISSUE NEW LICENSE
                this.InternationalLicenseDTO.IsActive = true;
                bool isSaved = _AddNewInternationalLicense();

                if (isSaved)
                {
                    // Update mode only serves to prevent future re-saves of this instance in memory
                    this.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.Update;

                    // IF WE REACH HERE, EVERYTHING WORKED! COMMIT THE CHANGES!
                    scope.Complete();
                    return true;
                }
                else
                {
                    this.InternationalLicenseDTO.LastValidationError = "Database Error: Failed to issue the new license. Any deactivations have been safely rolled back.";
                    return false;
                    //  scope.Complete() was NOT called. 
                    // The database will automatically RESTORE the old license to IsActive = 1!
                }
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

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicensesDataAccess.GetDriverInternationalLicenses(DriverID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicenses();
        }
    }
}






