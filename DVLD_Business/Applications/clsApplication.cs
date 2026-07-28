using DVLD_Business.People;
using DVLD_Business.Users;
using DVLD_DataAccess.Applications;
using System;
using System.Data;

namespace DVLD_Business.Applications
{
    public class clsApplicationDTO
    {
        public enum enMode { Update = 0, AddNew = 1 };
        public enMode Mode { get; set; } = enMode.AddNew;
        public enum enApplicationStatus : byte
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        };
        public int ApplicationID { get; set; } = 0;
        public int ApplicationTypeID { get; set; } = 0;
        public int ApplicantPersonID { get; set; } = 0;
        public byte ApplicationStatus { get; set; } = 1;
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public DateTime LastStatusDate { get; set; } = DateTime.Now;
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public string LastValidationError { get; set; } = string.Empty;
    }

    public class clsApplication
    {
        public clsApplicationDTO ApplicationDTO { get; set; }

        // COMPOSITION 
        public clsPerson PersonInfo { get; set; }
        public clsUser CreatedByUserInfo { get; set; }

        private clsApplication(clsApplicationDTO FilledDTO)
        {
            this.ApplicationDTO = FilledDTO;
            this.PersonInfo = clsPerson.Find(FilledDTO.ApplicantPersonID);
            this.CreatedByUserInfo = clsUser.Find(FilledDTO.CreatedByUserID);

        }

        public clsApplication()
        {
            this.ApplicationDTO = new clsApplicationDTO();
            this.ApplicationDTO.Mode = clsApplicationDTO.enMode.AddNew;
            this.PersonInfo = null;
            this.CreatedByUserInfo = null;
        }

        public static clsApplication Find(int ApplicationId)
        {
            int ApplicantPersonId = -1;
            int ApplicationTypeId = -1;
            DateTime ApplicationTime = DateTime.Now;
            byte ApplicationStatus = 1;
            DateTime LastTimeUpdate = DateTime.Now;
            decimal PaidFees = -1;
            int CreatedByUserId = -1;

            if (clsApplicationsDataAccess.GetApplicationInfoByID(
                ApplicationId, ref ApplicantPersonId, ref ApplicationTypeId,
                ref ApplicationTime, ref ApplicationStatus, ref LastTimeUpdate,
                ref PaidFees, ref CreatedByUserId))
            {
                clsApplicationDTO FilledDTO = new clsApplicationDTO
                {
                    ApplicationStatus = ApplicationStatus,
                    ApplicantPersonID = ApplicantPersonId,
                    ApplicationID = ApplicationId,
                    ApplicationTypeID = ApplicationTypeId,
                    ApplicationDate = ApplicationTime,
                    LastStatusDate = LastTimeUpdate,
                    PaidFees = PaidFees,
                    CreatedByUserID = CreatedByUserId,
                    Mode = clsApplicationDTO.enMode.Update
                };

                return new clsApplication(FilledDTO);
            }

            return null;
        }

        private bool _AddNewApplication()
        {
            int NewId = -1;
            bool success = clsApplicationsDataAccess.AddNewApplication(
                this.ApplicationDTO.ApplicantPersonID,
                this.ApplicationDTO.ApplicationTypeID,
                this.ApplicationDTO.ApplicationDate,
                this.ApplicationDTO.ApplicationStatus,
                this.ApplicationDTO.LastStatusDate,
                this.ApplicationDTO.PaidFees,
                this.ApplicationDTO.CreatedByUserID,
                ref NewId
            );

            if (success)
            {
                this.ApplicationDTO.ApplicationID = NewId;
                this.ApplicationDTO.Mode = clsApplicationDTO.enMode.Update;
                return true;
            }

            this.ApplicationDTO.LastValidationError = "Database Error: Failed to insert new application record.";
            return false;
        }

       

        public static DataTable GetAllApplications()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }

        private bool _UpdateStatus(byte newStatus)
        {
         
            if (this.ApplicationDTO.ApplicationID <= 0)
            {
                this.ApplicationDTO.LastValidationError = "Validation Fail: Cannot update status of an unsaved application.";
                return false;
            }

        
            if (clsApplicationsDataAccess.UpdateApplicationStatus(this.ApplicationDTO.ApplicationID, newStatus))
            {
                this.ApplicationDTO.ApplicationStatus = newStatus;
                this.ApplicationDTO.LastStatusDate = DateTime.Now;
                this.ApplicationDTO.Mode = clsApplicationDTO.enMode.Update;
                return true;
            }

            this.ApplicationDTO.LastValidationError = "Database Error: Failed to switch application status pipeline.";
            return false;
        }

        public bool Cancel()
        {
            if (this.ApplicationDTO.ApplicationStatus != 1) 
            {
                this.ApplicationDTO.LastValidationError = "Validation Fail: Only applications with 'New' status can be cancelled.";
                return false;
            }

            return _UpdateStatus(2); // 2 = Cancelled
        }

        public bool Complete()
        {
            if (this.ApplicationDTO.ApplicationStatus != 1) // 1 = New
            {
                this.ApplicationDTO.LastValidationError = "Validation Fail: Only 'New' applications can be marked as completed.";
                return false;
            }

            return _UpdateStatus(3); // 3 = Completed
        }

        public bool Save()
        {
            
            if (this.ApplicationDTO.Mode == clsApplicationDTO.enMode.Update || this.ApplicationDTO.ApplicationID > 0)
            {
                this.ApplicationDTO.LastValidationError = "System Restriction: Applications are immutable once created. Use Cancel(), Complete(), or UpdateStatus() to alter pipeline states.";
                return false;
            }

           
            if (this.PersonInfo != null)
                this.ApplicationDTO.ApplicantPersonID = this.PersonInfo.PersonDTO.PersonID;

            if (this.CreatedByUserInfo != null)
                this.ApplicationDTO.CreatedByUserID = this.CreatedByUserInfo.UserDTO.UserID;

           
            if ( this.ApplicationDTO.CreatedByUserID <= 0)
            {
                this.ApplicationDTO.LastValidationError = "Validation Fail:  Creator User ID is invalid.";
                return false;
            }

            if (this.ApplicationDTO.ApplicantPersonID <= 0 )
            {
                this.ApplicationDTO.LastValidationError = "Validation Fail: Applicant Person ID  is invalid.";
                return false;
            }


            int actualApplicationId = clsApplicationsDataAccess.GetActiveApplicationID(
                this.ApplicationDTO.ApplicantPersonID,
                this.ApplicationDTO.ApplicationTypeID
            );

            if (actualApplicationId != -1)
            {
                this.ApplicationDTO.LastValidationError = "Validation Fail: A pending application of this type already exists for this person.";
                return false;
            }

         
            return _AddNewApplication();
        }
    }
}