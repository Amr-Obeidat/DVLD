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

        // Object Composition
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

      


        public bool Save()
        {
          
            if (this.DriverDTO.PersonID <= 0 || this.DriverDTO.CreatedByUserID <= 0)
            {
                this.DriverDTO.LastValidationError = "Validation Fail: Valid PersonID and CreatedByUserID are required to create a Driver record.";
                return false;
            }

            switch (this.DriverDTO.Mode)
            {
                case clsDriverDTO.enMode.AddNew:

                  
                    if (clsDriverDataAccess.DoesDriverExistByPersonID(this.DriverDTO.PersonID))
                    {
                        this.DriverDTO.LastValidationError = "Validation Fail: This person is already registered as a driver in the system.";
                        return false;
                    }

                    return _AddNewDriver();

                case clsDriverDTO.enMode.Update:

                 
                    this.DriverDTO.LastValidationError = "Validation Fail: Driver records are historical immutable entities and cannot be modified.";
                    return false;

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