using DVLD_DataAccess.Licenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business.Licenses
{
    public class clsDetainedLicenseDTO
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int DetainID { get; set; } = -1;
        public int LicenseID { get; set; } = -1;
        public DateTime DetainDate { get; set; } = DateTime.Now;
        public decimal FineFees { get; set; } = 0m;
        public int CreatedByUserID { get; set; } = -1;
        public bool IsReleased { get; set; } = false;
        public DateTime? ReleaseDate { get; set; } = null;
        public int? ReleasedByUserID { get; set; } = null;
        public int? ReleaseApplicationID { get; set; } = null;

        public string LastValidationError { get; set; } = string.Empty;
    }
    public class clsDetainedLicense
    {
        public clsDetainedLicenseDTO DetainedLicenseDTO { get; set; }

        public clsDetainedLicense()
        {
            this.DetainedLicenseDTO = new clsDetainedLicenseDTO();
            this.DetainedLicenseDTO.Mode = clsDetainedLicenseDTO.enMode.AddNew;
        }

        private clsDetainedLicense(clsDetainedLicenseDTO dto)
        {
            this.DetainedLicenseDTO = dto;
            this.DetainedLicenseDTO.Mode = clsDetainedLicenseDTO.enMode.Update;
        }

 
        public static clsDetainedLicense FindByDetainID(int detainID)
        {
            if (detainID <= 0) return null;

            int licenseID = -1;
            DateTime detainDate = DateTime.Now;
            decimal fineFees = 0m;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime? releaseDate = null;
            int? releasedByUserID = null;
            int? releaseApplicationID = null;
            
            bool isFound = clsDetainedLicenseDataAccess.GetDetainedLicenseInfoByID(
                detainID,
                ref licenseID,
                ref detainDate,
                ref fineFees,
                ref createdByUserID,
                ref isReleased,
                ref releaseDate,
                ref releasedByUserID,
                ref releaseApplicationID
            );

            if (isFound)
            {
                clsDetainedLicenseDTO dto = new clsDetainedLicenseDTO
                {
                    DetainID = detainID,
                    LicenseID = licenseID,
                    DetainDate = detainDate,
                    FineFees = fineFees,
                    CreatedByUserID = createdByUserID,
                    IsReleased = isReleased,
                    ReleaseDate = releaseDate,
                    ReleasedByUserID = releasedByUserID,
                    ReleaseApplicationID = releaseApplicationID,
                    Mode = clsDetainedLicenseDTO.enMode.Update
                };

                return new clsDetainedLicense(dto);
            }

            return null;
        }

        public static clsDetainedLicense FindDetainByLicenseID(int licenseID)
        {
            if (licenseID <= 0) return null;

            int detainID = -1;
            DateTime detainDate = DateTime.Now;
            decimal fineFees = 0m;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime? releaseDate = null;
            int? releasedByUserID = null;
            int? releaseApplicationID = null;

            bool isFound = clsDetainedLicenseDataAccess.GetDetainedLicenseInfoByLicenseID(
                licenseID,
                ref detainID,
                ref detainDate,
                ref fineFees,
                ref createdByUserID,
                ref isReleased,
                ref releaseDate,
                ref releasedByUserID,
                ref releaseApplicationID
            );

            if (isFound)
            {
                clsDetainedLicenseDTO dto = new clsDetainedLicenseDTO
                {
                    DetainID = detainID,
                    LicenseID = licenseID,
                    DetainDate = detainDate,
                    FineFees = fineFees,
                    CreatedByUserID = createdByUserID,
                    IsReleased = isReleased,
                    ReleaseDate = releaseDate,
                    ReleasedByUserID = releasedByUserID,
                    ReleaseApplicationID = releaseApplicationID,
                    Mode = clsDetainedLicenseDTO.enMode.Update
                };

                return new clsDetainedLicense(dto);
            }

            return null;
        }

        
        public static bool IsLicenseDetained(int licenseID)
        {
            if (licenseID <= 0) return false;
            return clsDetainedLicenseDataAccess.IsLicenseDetained(licenseID);
        }

       
        private bool _AddNewDetainedLicense()
        {
            this.DetainedLicenseDTO.DetainID = clsDetainedLicenseDataAccess.AddNewDetainedLicense(
                this.DetainedLicenseDTO.LicenseID,
                this.DetainedLicenseDTO.DetainDate,
                this.DetainedLicenseDTO.FineFees,
                this.DetainedLicenseDTO.CreatedByUserID
            );

            return (this.DetainedLicenseDTO.DetainID > 0);
        }

  
        public bool Save()
        {
           
            if (this.DetainedLicenseDTO.Mode == clsDetainedLicenseDTO.enMode.Update || this.DetainedLicenseDTO.DetainID > 0)
            {
                this.DetainedLicenseDTO.LastValidationError = "System Restriction: Direct updates to detain records are prohibited. Use Release() to unlock a license.";
                return false;
            }

           
            if (this.DetainedLicenseDTO.LicenseID <= 0)
            {
                this.DetainedLicenseDTO.LastValidationError = "Validation Fail: Linked License ID reference is missing.";
                return false;
            }

            if (this.DetainedLicenseDTO.CreatedByUserID <= 0)
            {
                this.DetainedLicenseDTO.LastValidationError = "Validation Fail: Created By User ID reference is missing.";
                return false;
            }

            if (this.DetainedLicenseDTO.FineFees < 0)
            {
                this.DetainedLicenseDTO.LastValidationError = "Validation Fail: Fine fees cannot be negative.";
                return false;
            }

         
            clsLicense localLicense = clsLicense.Find(this.DetainedLicenseDTO.LicenseID);
            if (localLicense == null)
            {
                this.DetainedLicenseDTO.LastValidationError = $"Validation Fail: Foreign Key Error - Linked License ID [{this.DetainedLicenseDTO.LicenseID}] does not exist.";
                return false;
            }

           
            if (IsLicenseDetained(this.DetainedLicenseDTO.LicenseID))
            {
                this.DetainedLicenseDTO.LastValidationError = $"Validation Fail: License ID [{this.DetainedLicenseDTO.LicenseID}] is already detained.";
                return false;
            }

        
            bool isSaved = _AddNewDetainedLicense();

            if (isSaved)
            {
                this.DetainedLicenseDTO.Mode = clsDetainedLicenseDTO.enMode.Update;
            }

            return isSaved;
        }

       
        public bool Release(int releasedByUserID, int releaseApplicationID)
        {
          
            if (this.DetainedLicenseDTO.DetainID <= 0)
            {
                this.DetainedLicenseDTO.LastValidationError = "Validation Fail: Cannot release an unsaved or non-existent detain record.";
                return false;
            }

         
            if (this.DetainedLicenseDTO.IsReleased)
            {
                this.DetainedLicenseDTO.LastValidationError = "Validation Fail: License is already released.";
                return false;
            }

           
            if (releasedByUserID <= 0 || releaseApplicationID <= 0)
            {
                this.DetainedLicenseDTO.LastValidationError = "Validation Fail: Valid ReleasedByUserID and ReleaseApplicationID are required.";
                return false;
            }

          
            bool isReleased = clsDetainedLicenseDataAccess.ReleaseDetainedLicense(
                this.DetainedLicenseDTO.DetainID,
                releasedByUserID,
                releaseApplicationID
            );

            if (isReleased)
            {
                this.DetainedLicenseDTO.IsReleased = true;
                this.DetainedLicenseDTO.ReleaseDate = DateTime.Now;
                this.DetainedLicenseDTO.ReleasedByUserID = releasedByUserID;
                this.DetainedLicenseDTO.ReleaseApplicationID = releaseApplicationID;
                return true;
            }

            this.DetainedLicenseDTO.LastValidationError = "Database Error: Failed to release the detained license record.";
            return false;
        }

       
        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseDataAccess.GetAllDetainedLicenses();
        }
    }
}
