using System;
using System.Data;
using DVLD_DataAccess.Driver;
using DVLD_Business.People; // Assuming your person domain entity lives here

namespace DVLD_Business.Drivers
{


    public class clsDriverDTO
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; } = enMode.AddNew;

        public int DriverID { get; set; } = -1;
        public int PersonID { get; set; } = -1;
        public int CreatedByUserID { get; set; } = -1;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LastValidationError { get; set; } = "";
    }
    public class clsDriver
    {
        public clsDriverDTO DriverDTO { get; set; }

        // Object Composition: Provides direct rich-domain binding to the parent person's data folder
        public clsPerson PersonInfo { get; set; }

        public clsDriver()
        {
            this.DriverDTO = new clsDriverDTO();
            this.DriverDTO.Mode = clsDriverDTO.enMode.AddNew;
            this.PersonInfo = null;
        }

        private clsDriver(clsDriverDTO DTO)
        {
            this.DriverDTO = DTO;
            this.DriverDTO.Mode = clsDriverDTO.enMode.Update;

            // Automatically hydrate object composition on load
            this.PersonInfo = clsPerson.Find(DTO.PersonID);
        }

        public static clsDriver Find(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriverDataAccess.GetDriverInfoByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                clsDriverDTO dto = new clsDriverDTO
                {
                    DriverID = DriverID,
                    PersonID = PersonID,
                    CreatedByUserID = CreatedByUserID,
                    CreatedDate = CreatedDate
                };
                return new clsDriver(dto);
            }
            return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriverDataAccess.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
            {
                clsDriverDTO dto = new clsDriverDTO
                {
                    DriverID = DriverID,
                    PersonID = PersonID,
                    CreatedByUserID = CreatedByUserID,
                    CreatedDate = CreatedDate
                };
                return new clsDriver(dto);
            }
            return null;
        }

        private bool _AddNewDriver()
        {
            this.DriverDTO.DriverID = clsDriverDataAccess.AddNewDriver(
                this.DriverDTO.PersonID,
                this.DriverDTO.CreatedByUserID,
                this.DriverDTO.CreatedDate
            );

            return (this.DriverDTO.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriverDataAccess.UpdateDriver(
                this.DriverDTO.DriverID,
                this.DriverDTO.PersonID,
                this.DriverDTO.CreatedByUserID,
                this.DriverDTO.CreatedDate
            );
        }

        public bool Save()
        {
       
            if (this.PersonInfo != null && this.PersonInfo.PersonDTO.PersonID != this.DriverDTO.PersonID)
            {
               
                {
                    this.PersonInfo = clsPerson.Find(this.DriverDTO.PersonID);
                }
            }
            else if (this.PersonInfo != null)
            {
             
                this.DriverDTO.PersonID = this.PersonInfo.PersonDTO.PersonID;
            }

         
            if (this.DriverDTO.PersonID <= 0 || this.DriverDTO.CreatedByUserID <= 0)
            {
                this.DriverDTO.LastValidationError = "Validation Fail: Required structural Person or User reference values are missing.";
                return false;
            }

            switch (this.DriverDTO.Mode)
            {
                case clsDriverDTO.enMode.AddNew:
                    // Security guard rule: A person can only be registered as a driver exactly once in our system
                    if (clsDriverDataAccess.DoesDriverExistByPersonID(this.DriverDTO.PersonID))
                    {
                        this.DriverDTO.LastValidationError = "Record Already Exists! This person is already registered as a driver.";
                        return false;
                    }
                    return _AddNewDriver();

                case clsDriverDTO.enMode.Update:
                    // Security guard rule: PersonID identity properties are immutable once committed to storage histories
                    clsDriver originalRecord = clsDriver.Find(this.DriverDTO.DriverID);
                    if (originalRecord != null && originalRecord.DriverDTO.PersonID != this.DriverDTO.PersonID)
                    {
                        this.DriverDTO.LastValidationError = "Validation Fail: Modifying the base identity PersonID reference on an active Driver record is strictly prohibited.";
                        return false;
                    }
                    return _UpdateDriver();

                default:
                    return false;
            }
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverDataAccess.GetAllDrivers();
        }

        public static bool Delete(int DriverID)
        {
            return clsDriverDataAccess.DeleteDriver(DriverID);
        }
    }
}