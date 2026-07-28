using System;
using System.Data;
using DVLD_DataAccess.Licenses;

namespace DVLD_Business.Licenses
{
    public class clsLicenseClassDTO
    {
        public int LicenseClassID { get; set; } = 0;
        public string ClassName { get; set; } = string.Empty;
        public string ClassDescription { get; set; } = string.Empty;
        public byte MinimumAllowedAge { get; set; } = 18;
        public byte DefaultValidityLength { get; set; } = 10;
        public decimal ClassFees { get; set; } = 0;
        public string LastValidationError { get; set; } = string.Empty;
    }

    public class clsLicenseClass
    {
        public clsLicenseClassDTO clsLicenseClassDTO { get; set; }

        private clsLicenseClass(clsLicenseClassDTO FilledDTO)
        {
            this.clsLicenseClassDTO = FilledDTO;
        }

        public clsLicenseClass()
        {
            this.clsLicenseClassDTO = new clsLicenseClassDTO();
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            byte MinimumAllowedAge = 18;
            byte DefaultValidityLength = 10;
            decimal ClassFees = -1;

            if (clsLicenseClassDataAccess.GetLicenseClassInfoByID(
                LicenseClassID, ref ClassName, ref ClassDescription,
                ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                clsLicenseClassDTO FilledDTO = new clsLicenseClassDTO
                {
                    LicenseClassID = LicenseClassID,
                    ClassName = ClassName,
                    ClassDescription = ClassDescription,
                    MinimumAllowedAge = MinimumAllowedAge,
                    DefaultValidityLength = DefaultValidityLength,
                    ClassFees = ClassFees
                };

                return new clsLicenseClass(FilledDTO);
            }

            return null;
        }

        private bool _UpdateLicenseClass()
        {
            bool success = clsLicenseClassDataAccess.UpdateLicenseClass(
                this.clsLicenseClassDTO.LicenseClassID,
                this.clsLicenseClassDTO.MinimumAllowedAge,
                this.clsLicenseClassDTO.DefaultValidityLength,
                this.clsLicenseClassDTO.ClassFees
            );

            if (!success)
            {
                this.clsLicenseClassDTO.LastValidationError = "Database Error: Failed to update license class details.";
            }
            return success;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassDataAccess.GetAllLicenseClasses();
        }

        public bool Save()
        {
      
            if (this.clsLicenseClassDTO.LicenseClassID <= 0)
            {
                this.clsLicenseClassDTO.LastValidationError = "Validation Fail: Invalid or non-existent License Class ID.";
                return false;
            }

          
            clsLicenseClass originalClass = clsLicenseClass.Find(this.clsLicenseClassDTO.LicenseClassID);

            if (originalClass == null)
            {
                this.clsLicenseClassDTO.LastValidationError = $"Validation Fail: License Class with ID [{this.clsLicenseClassDTO.LicenseClassID}] does not exist.";
                return false;
            }

            if (originalClass.clsLicenseClassDTO.ClassName != this.clsLicenseClassDTO.ClassName)
            {
                this.clsLicenseClassDTO.LastValidationError = "Validation Fail: Modifying the License Class Name is prohibited.";
                return false;
            }

         
            if (originalClass.clsLicenseClassDTO.ClassDescription != this.clsLicenseClassDTO.ClassDescription)
            {
                this.clsLicenseClassDTO.LastValidationError = "Validation Fail: Modifying the License Class Description is prohibited.";
                return false;
            }

          
            if (this.clsLicenseClassDTO.MinimumAllowedAge < 16)
            {
                this.clsLicenseClassDTO.LastValidationError = "Validation Fail: Minimum Allowed Age cannot be less than 16 years.";
                return false;
            }

            if (this.clsLicenseClassDTO.DefaultValidityLength <= 0)
            {
                this.clsLicenseClassDTO.LastValidationError = "Validation Fail: Default Validity Length must be at least 1 year.";
                return false;
            }

           
            if (this.clsLicenseClassDTO.ClassFees < 0)
            {
                this.clsLicenseClassDTO.LastValidationError = "Validation Fail: Class Fees cannot be negative.";
                return false;
            }

         
            return _UpdateLicenseClass();
        }
    }
}