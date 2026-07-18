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
        public clsApplicationDTO clsApplicationDTO { get; set; }

        // COMPOSITION HOOKS: Gives your UI instant access to full objects
        public clsPerson PersonInfo { get; set; }
        public clsUser CreatedByUserInfo { get; set; }

        private clsApplication(clsApplicationDTO FilledDTO)
        {
            this.clsApplicationDTO = FilledDTO;
            this.PersonInfo = clsPerson.Find(FilledDTO.ApplicantPersonID);
            this.CreatedByUserInfo = clsUser.Find(FilledDTO.CreatedByUserID);
          
        }

        public clsApplication()
        {
            this.clsApplicationDTO = new clsApplicationDTO();
            this.clsApplicationDTO.Mode = clsApplicationDTO.enMode.AddNew;
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
                this.clsApplicationDTO.ApplicantPersonID,
                this.clsApplicationDTO.ApplicationTypeID,
                this.clsApplicationDTO.ApplicationDate,
                this.clsApplicationDTO.ApplicationStatus,
                this.clsApplicationDTO.LastStatusDate,
                this.clsApplicationDTO.PaidFees,
                this.clsApplicationDTO.CreatedByUserID,
                ref NewId
            );

            if (success)
            {
                this.clsApplicationDTO.ApplicationID = NewId;
                this.clsApplicationDTO.Mode = clsApplicationDTO.enMode.Update;
                return true;
            }

            this.clsApplicationDTO.LastValidationError = "Database Error: Failed to insert new application record.";
            return false;
        }

        private bool _UpdateApplicationInfo()
        {
            bool success = clsApplicationsDataAccess.UpdateApplicationInfo(
                this.clsApplicationDTO.ApplicationID,
                this.clsApplicationDTO.ApplicantPersonID,
                this.clsApplicationDTO.ApplicationTypeID,
                this.clsApplicationDTO.ApplicationDate,
                this.clsApplicationDTO.ApplicationStatus,
                this.clsApplicationDTO.LastStatusDate,
                this.clsApplicationDTO.PaidFees,
                this.clsApplicationDTO.CreatedByUserID
            );

            if (!success)
            {
                this.clsApplicationDTO.LastValidationError = "Database Error: Failed to update application details.";
            }
            return success;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }

        public bool UpdateStatus(byte NewStatus)
        {
            // Fixed parameter count mismatch by passing DateTime.Now matching your DAL signature
            if (clsApplicationsDataAccess.UpdateApplicationStatus(this.clsApplicationDTO.ApplicationID, NewStatus)==true)
            {
                this.clsApplicationDTO.ApplicationStatus = NewStatus;
                this.clsApplicationDTO.LastStatusDate = DateTime.Now;
                this.clsApplicationDTO.Mode = clsApplicationDTO.enMode.Update;
                return true;
            }

            this.clsApplicationDTO.LastValidationError = "Database Error: Failed to switch application status pipeline.";
            return false;
        }

        public static bool Delete(int ApplicationId)
        {
            return clsApplicationsDataAccess.DeleteApplication(ApplicationId);
        }

        public bool Save()
        {
            // Before branching, verify relational components are synchronized
            if (this.PersonInfo != null)
                this.clsApplicationDTO.ApplicantPersonID = this.PersonInfo.PersonDTO.PersonID;

            if (this.CreatedByUserInfo != null)
                this.clsApplicationDTO.CreatedByUserID = this.CreatedByUserInfo.UserDTO.UserID;

            // Integrity Checks
            if (this.clsApplicationDTO.ApplicantPersonID <= 0 || this.clsApplicationDTO.CreatedByUserID <= 0)
            {
                this.clsApplicationDTO.LastValidationError = "Validation Fail: Applicant Person ID or Creator User ID is invalid.";
                return false;
            }

            switch (this.clsApplicationDTO.Mode)
            {
                case clsApplicationDTO.enMode.AddNew:
                    int ActualApplicationId = clsApplicationsDataAccess.GetActiveApplicationID(
                        this.clsApplicationDTO.ApplicantPersonID,
                        this.clsApplicationDTO.ApplicationTypeID
                    );

                    if (ActualApplicationId != -1)
                    {
                        this.clsApplicationDTO.LastValidationError = "Validation Fail: A pending application of this type already exists.";
                        return false;
                    }
                    return _AddNewApplication();

                case clsApplicationDTO.enMode.Update:
                    return _UpdateApplicationInfo();

                default:
                    return false;
            }
        }
    }
}
