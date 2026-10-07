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
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }
        public enIssueReason IssueReason { get; set; } = enIssueReason.FirstTime;  
        public int CreatedByUserID { get; set; } = -1;

        
        public string LastValidationError { get; set; } = "";
    }
    public class clsLicense
    {
     

        public clsLicenseDTO LicenseDTO { get; set; }
        public clsDriver DriverInfo {  get; set; }
        public clsDetainedLicense DetainedInfo {  get; set; }
        public bool IsDetained
        {
            get { return DetainedInfo != null; }
        }



        public clsLicense()
        {
            this.LicenseDTO = new clsLicenseDTO();
            this.LicenseDTO.Mode = clsLicenseDTO.enMode.AddNew;
            DriverInfo = new clsDriver();
            DetainedInfo = null;
        }
       
        private clsLicense(clsLicenseDTO DTO)
        {
            this.LicenseDTO = DTO;
            this.LicenseDTO.Mode = clsLicenseDTO.enMode.Update;
            this.DriverInfo=clsDriver.Find(LicenseDTO.DriverID);
            this.DetainedInfo =
         clsDetainedLicense.FindDetainByLicenseID(LicenseID);
        }

        public int LicenseID => this.LicenseDTO.LicenseID;
        public int LicenseClassID => this.LicenseDTO.LicenseClassID;
        public DateTime ExpirationDate => this.LicenseDTO.ExpirationDate;
        public bool IsActive => this.LicenseDTO.IsActive;

      
        

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
                    IssueReason  = (clsLicenseDTO.enIssueReason)IssueReason,
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
                (byte)this.LicenseDTO.IssueReason,
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
            return clsLicenseDataAccess.GetDriverLicensesByDriverId(DriverID);
        }
        public static int GetActiveLicenseForPerson(int PersonID, int LicenseClassType)
        {

            return clsLicenseDataAccess.GetActiveLicenseIDByPersonID(PersonID, LicenseClassType);
        }

        public bool IsLicenseExpired()
        {
            return (this.LicenseDTO.ExpirationDate < DateTime.Now);
        }
        public static bool DeactivateLicense(int LicenseID)
        {

            return clsLicenseDataAccess.DeactivateLicense(LicenseID);   
        }

        public static string GetIssueReasonString(clsLicenseDTO.enIssueReason IssueReason)
        {

            switch (IssueReason)
            {

                case clsLicenseDTO.enIssueReason.FirstTime:
                    return "First Time";
                
                case clsLicenseDTO.enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damage";
                    ;
                case clsLicenseDTO.enIssueReason.Renew:
                    return "Renew";
                  
                case clsLicenseDTO.enIssueReason.ReplacementForLost:
                    return "Replacement For Lost ";

                default:
                    return "First Time";

            }
        }

        public int Detain(decimal finefees, int CreatedByUser)
        {

            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.DetainedLicenseDTO.LicenseID=this.LicenseID;    
            detainedLicense.DetainedLicenseDTO.FineFees=finefees;
            detainedLicense.DetainedLicenseDTO.CreatedByUserID = CreatedByUser;
            detainedLicense.DetainedLicenseDTO.DetainDate = DateTime.Now;
            detainedLicense.DetainedLicenseDTO.IsReleased = false;


            if (!detainedLicense.Save())
            {
                return -1;
            }
            else
            {
                return detainedLicense.DetainedLicenseDTO.DetainID;
            }
        }
        public bool ReleaseDetainedLicense(int ReleasedByUserId, ref  int ApplicationID) {
             

            clsApplication application =new clsApplication();
            application.ApplicationDTO.ApplicantPersonID = this.DriverInfo.PersonInfo.PersonDTO.PersonID;
            application.ApplicationDTO.ApplicationDate = DateTime.Now;
            application.ApplicationDTO.ApplicationTypeID = (int)clsApplicationDTO.enApplicationType.ReleaseDetainedDrivingLicsense;
            application.ApplicationDTO.ApplicationStatus = (int)clsApplicationDTO.enApplicationStatus.Completed;
            application.ApplicationDTO.LastStatusDate = DateTime.Now;


            int ApplicationTypeId = (int)clsApplicationDTO.enApplicationType.ReleaseDetainedDrivingLicsense;
            application.ApplicationDTO.PaidFees = clsApplicationTypes.Find(ApplicationTypeId).DTO.ApplicationFees;
            application.ApplicationDTO.CreatedByUserID = ReleasedByUserId;

            if (!application.Save())
            {
                return false;
            }
            ApplicationID = application.ApplicationDTO.ApplicationID;


            return this.DetainedInfo.Release(ReleasedByUserId, ApplicationID);




        }


        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            
            clsApplication Application = new clsApplication();
            Application.ApplicationDTO.ApplicantPersonID = this.DriverInfo.PersonInfo.PersonDTO.PersonID;
            Application.ApplicationDTO.ApplicationDate = DateTime.Now;
            Application.ApplicationDTO.ApplicationTypeID = (int)clsApplicationDTO.enApplicationType.RenewDrivingLicense;
            Application.ApplicationDTO.ApplicationStatus = (int)clsApplicationDTO.enApplicationStatus.Completed;
            Application.ApplicationDTO.LastStatusDate = DateTime.Now;

          
            Application.ApplicationDTO.PaidFees = clsApplicationTypes.Find((int)clsApplicationDTO.enApplicationType.RenewDrivingLicense).DTO.ApplicationFees;
            Application.ApplicationDTO.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

         
            if (!DeactivateLicense(this.LicenseID))
            {
                return null;
            }

         
            clsLicense NewLicense = new clsLicense();
            NewLicense.LicenseDTO.ApplicationID = Application.ApplicationDTO.ApplicationID;
            NewLicense.LicenseDTO.DriverID = this.LicenseDTO.DriverID;
            NewLicense.LicenseDTO.LicenseClassID = this.LicenseDTO.LicenseClassID;
            NewLicense.LicenseDTO.IssueDate = DateTime.Now;

            clsLicenseClass LicenseClassInfo = clsLicenseClass.Find(this.LicenseDTO.LicenseClassID);
            NewLicense.LicenseDTO.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.clsLicenseClassDTO.DefaultValidityLength);

            NewLicense.LicenseDTO.Notes = Notes;
            NewLicense.LicenseDTO.PaidFees = LicenseClassInfo.clsLicenseClassDTO.ClassFees; 
            NewLicense.LicenseDTO.IsActive = true;
            NewLicense.LicenseDTO.IssueReason = clsLicenseDTO.enIssueReason.Renew;
            NewLicense.LicenseDTO.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            return NewLicense;
        }

        public clsLicense Replace(clsLicenseDTO.enIssueReason IssueReason, int CreatedByUserID)
        {
          
            int ApplicationTypeID = (IssueReason == clsLicenseDTO.enIssueReason.ReplacementForDamaged) ?
                (int)clsApplicationDTO.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplicationDTO.enApplicationType.ReplaceLostDrivingLicense;

           
            clsApplication Application = new clsApplication();
            Application.ApplicationDTO.ApplicantPersonID = this.DriverInfo.PersonInfo.PersonDTO.PersonID;
            Application.ApplicationDTO.ApplicationDate = DateTime.Now;
            Application.ApplicationDTO.ApplicationTypeID = ApplicationTypeID;
            Application.ApplicationDTO.ApplicationStatus = (int)clsApplicationDTO.enApplicationStatus.Completed;
            Application.ApplicationDTO.LastStatusDate = DateTime.Now;

          
            Application.ApplicationDTO.PaidFees = clsApplicationTypes.Find(ApplicationTypeID).DTO.ApplicationFees;
            Application.ApplicationDTO.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

         
            if (!DeactivateLicense(this.LicenseID))
            {
                return null;
            }

           
            clsLicense NewLicense = new clsLicense();
            NewLicense.LicenseDTO.ApplicationID = Application.ApplicationDTO.ApplicationID;
            NewLicense.LicenseDTO.DriverID = this.LicenseDTO.DriverID;
            NewLicense.LicenseDTO.LicenseClassID = this.LicenseDTO.LicenseClassID;
            NewLicense.LicenseDTO.IssueDate = DateTime.Now;

         
            NewLicense.LicenseDTO.ExpirationDate = this.LicenseDTO.ExpirationDate;

            NewLicense.LicenseDTO.Notes = this.LicenseDTO.Notes;
            NewLicense.LicenseDTO.PaidFees = 0; 
            NewLicense.LicenseDTO.IsActive = true;
            NewLicense.LicenseDTO.IssueReason = IssueReason;
            NewLicense.LicenseDTO.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            return NewLicense;
        }
    }
}

