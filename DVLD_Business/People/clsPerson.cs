using DVLD_DataAccess.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_Business.People
{
    // 1. DTO is outside the main class but in the same namespace for cleanliness
    public class clsPersonDTO
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enRecordState { Active = 1, Deleted = 0 };

        public enMode Mode { get; set; } = enMode.AddNew;
        public enRecordState State { get; set; } = enRecordState.Active;


        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public string LastValidationError { get;  set; }
    }

    public class clsPerson
    {

        public clsPersonDTO PersonDTO { get; set; }

        public clsPerson()
        {
            this.PersonDTO = new clsPersonDTO();
            this.PersonDTO.Mode = clsPersonDTO.enMode.AddNew;
        }

        private clsPerson(clsPersonDTO FilledDTO)
        {
            this.PersonDTO = FilledDTO;
        }

        public static clsPerson Find(int PersonId)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            string NationalNo = "", Email = "", Phone = "", ImagePath = "", Address = "";
            DateTime DateOfBirth = DateTime.Now;
            char Gender = 'M';
            int NationalityCountryID = -1;





            bool IsFound = clsPersonDataAccess.GetPersonInfoById(PersonId,
                ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref NationalNo, ref DateOfBirth, ref Gender,
                ref Email, ref NationalityCountryID, ref ImagePath, ref Phone, ref Address);
            if (IsFound)
            {
                clsPersonDTO FilledDTO = new clsPersonDTO();
                FilledDTO.PersonID = PersonId;
                FilledDTO.FirstName = FirstName;
                FilledDTO.SecondName = SecondName;
                FilledDTO.ThirdName = ThirdName;
                FilledDTO.LastName = LastName;
                FilledDTO.NationalNo = NationalNo;
                FilledDTO.DateOfBirth = DateOfBirth;
                FilledDTO.NationalityCountryID = NationalityCountryID;
                FilledDTO.Gender = Gender;
                FilledDTO.Email = Email;
                FilledDTO.Phone = Phone;
                FilledDTO.ImagePath = ImagePath;
                FilledDTO.Address = Address;
                FilledDTO.Mode = clsPersonDTO.enMode.Update;

                return new clsPerson(FilledDTO);



            }
            else
            {
                return null;
            }
        }
        public static clsPerson Find(string NationalNo)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            int PersonId = -1;
            string Email = "", Phone = "", ImagePath = "", Address = "";
            DateTime DateOfBirth = DateTime.Now;
            char Gender = 'M';
            int NationalityCountryID = -1;





            bool IsFound = clsPersonDataAccess.GetPersonInfoByNationalNo(NationalNo, ref PersonId,
                ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Email,
                ref NationalityCountryID, ref ImagePath, ref Phone, ref Address);
            if (IsFound)
            {
                clsPersonDTO FilledDTO = new clsPersonDTO();
                FilledDTO.PersonID = PersonId;
                FilledDTO.FirstName = FirstName;
                FilledDTO.SecondName = SecondName;
                FilledDTO.ThirdName = ThirdName;
                FilledDTO.LastName = LastName;
                FilledDTO.NationalNo = NationalNo;
                FilledDTO.DateOfBirth = DateOfBirth;
                FilledDTO.NationalityCountryID = NationalityCountryID;
                FilledDTO.Gender = Gender;
                FilledDTO.Email = Email;
                FilledDTO.Phone = Phone;
                FilledDTO.ImagePath = ImagePath;
                FilledDTO.Address = Address;
                FilledDTO.Mode = clsPersonDTO.enMode.Update;
                return new clsPerson(FilledDTO);



            }
            else
            {
                return null;
            }
        }


        private bool _AddNewPerson()
        {



            this.PersonDTO.PersonID = clsPersonDataAccess.AddNewPerson(this.PersonDTO.FirstName, this.PersonDTO.SecondName, this.PersonDTO.ThirdName, this.PersonDTO.LastName,
                this.PersonDTO.NationalNo, this.PersonDTO.DateOfBirth, this.PersonDTO.Gender, this.PersonDTO.Phone, this.PersonDTO.Email,
                this.PersonDTO.NationalityCountryID, this.PersonDTO.ImagePath, this.PersonDTO.Address);

            if (this.PersonDTO.PersonID > 0)
            {
                this.PersonDTO.Mode = clsPersonDTO.enMode.Update;
                return true;
            }
            else
            {
                return false;
            }


        }
        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePerson(this.PersonDTO.PersonID, this.PersonDTO.FirstName, this.PersonDTO.SecondName, this.PersonDTO.ThirdName, this.PersonDTO.LastName,
                this.PersonDTO.NationalNo, this.PersonDTO.DateOfBirth, this.PersonDTO.Gender, this.PersonDTO.Phone, this.PersonDTO.Email,
                this.PersonDTO.NationalityCountryID, this.PersonDTO.ImagePath, this.PersonDTO.Address);

        }

        public static  bool DeletePerson(int personID)
        {

            return clsPersonDataAccess.DeletePerson(personID);

        }
        public static  DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            dt=clsPersonDataAccess.GetAllPeople();
            return dt;

        }

        public static bool IsPersonExists(int PersonId)
        {
            return clsPersonDataAccess.IsPersonExists(PersonId);
        }
        public bool Save()
        {

            if (string.IsNullOrWhiteSpace(this.PersonDTO.FirstName))
            {
                this.PersonDTO.LastValidationError = "Validation Fail: First Name cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.PersonDTO.LastName))
            {
                this.PersonDTO.LastValidationError = "Validation Fail: Last Name cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.PersonDTO.NationalNo))
            {
                this.PersonDTO.LastValidationError = "Validation Fail: National Number cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.PersonDTO.Phone))
            {
                this.PersonDTO.LastValidationError = "Validation Fail: Phone Number cannot be empty.";
                return false;
            }

            if (this.PersonDTO.NationalityCountryID <= 0)
            {
                this.PersonDTO.LastValidationError = "Validation Fail: A valid Nationality Country must be selected.";
                return false;
            }
            switch (this.PersonDTO.Mode){

                case clsPersonDTO.enMode.Update:
                    clsPerson conflictingPerson = clsPerson.Find(this.PersonDTO.NationalNo);
                    if (conflictingPerson != null && conflictingPerson.PersonDTO.PersonID != this.PersonDTO.PersonID)
                    {
                        this.PersonDTO.LastValidationError = $"Validation Fail: National No [{this.PersonDTO.NationalNo}] belongs to another person (ID: {conflictingPerson.PersonDTO.PersonID}).";
                        return false;
                    }

                    return this._UpdatePerson();
                case clsPersonDTO.enMode.AddNew:
                    clsPerson existingPerson = clsPerson.Find(this.PersonDTO.NationalNo);
                    if (existingPerson != null)
                    {
                        this.PersonDTO.LastValidationError = $"Validation Fail: National No [{this.PersonDTO.NationalNo}] is already registered to another person.";
                        return false;
                    }
                    return this._AddNewPerson();  

                default:
                    return false;   




            }
           
        }
    }
}