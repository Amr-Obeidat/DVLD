using DVLD_Business.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess.Users;
using DVLD_DataAccess.People;
using System.Runtime.CompilerServices;
using System.Data;
namespace DVLD_Business.Users
{

    public class clsUserDTO
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode { get; set; } = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

    }
    public class clsUser
    {

        public clsUserDTO UserDTO { get; set; }

        public clsPerson PersonInfo { get; set; }
        public string LastValidationError { get; private set; }


        public clsUser()
        {
            this.UserDTO = new clsUserDTO();
            this.PersonInfo = new clsPerson();
            this.UserDTO.Mode = clsUserDTO.enMode.AddNew;

        }
        private clsUser(clsUserDTO UserInfo, clsPerson PersonInfo)
        {
            this.UserDTO = UserInfo;
            this.PersonInfo = PersonInfo;
            this.UserDTO.Mode = clsUserDTO.enMode.Update;
        }
        public static clsUser Find(int UserId)
        {

            bool IsFound = false;
            string Username = "";
            int PersonId = -1;
            string Password = "";
            bool IsActive = false;

           
            IsFound = clsUserDataAccess.FindUserById(UserId, ref Username, ref PersonId, ref Password, ref IsActive);

            if (IsFound)
            {
                clsUser UserInfo = new clsUser();
                UserInfo.UserDTO.Mode = clsUserDTO.enMode.Update;
                UserInfo.UserDTO.UserID = UserId;
                UserInfo.UserDTO.PersonID = PersonId;
                UserInfo.UserDTO.UserName = Username;
                UserInfo.UserDTO.Password = Password;
                UserInfo.UserDTO.IsActive = IsActive;

                clsPerson PersonInfo = clsPerson.Find(PersonId);

                if (PersonInfo != null)
                {

                    return new clsUser(UserInfo.UserDTO, PersonInfo);

                }
                else
                {
                    return new clsUser(UserInfo.UserDTO, null);
                }



            }
            else
            {
                return null;
            }




        }

        private bool _AddNewUser()
        {

            this.UserDTO.UserID = clsUserDataAccess.AddNewUser(this.UserDTO.UserName, this.UserDTO.PersonID, this.UserDTO.Password, this.UserDTO.IsActive);

            if (this.UserDTO.UserID > 0)
            {
                this.UserDTO.Mode = clsUserDTO.enMode.Update;

                return true;
            }
            else
            {
                return false;

            }
        }


        private bool _UpdateUser()
        {

            bool IsUpdated = false;

            IsUpdated = clsUserDataAccess.UpdateUser(this.UserDTO.UserID, this.UserDTO.UserName, this.UserDTO.PersonID, this.UserDTO.Password
                 , this.UserDTO.IsActive);

            if (IsUpdated)
            {
                this.UserDTO.Mode = clsUserDTO.enMode.Update;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserExists(int UserID)
        {
            return clsUserDataAccess.IsUserExist(UserID);
        }

        public static bool IsUserExists(string UserName)
        {
            return clsUserDataAccess.IsUserNameExist(UserName);
        }
        public static bool IsUserExistsByPersonID(int PersonID)
        {
            return clsUserDataAccess.IsUserExistForPersonID(PersonID);
        }


        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }
        public static bool Delete(int UserID)
        {
           
            return clsUserDataAccess.DeleteUser(UserID);
        }
        public bool Save()
        {
            if (this.PersonInfo != null)
            {
                this.UserDTO.PersonID = this.PersonInfo.PersonDTO.PersonID;
            }

            if (!clsPerson.IsPersonExists(this.UserDTO.PersonID))
            {
                this.LastValidationError = "Validation Fail: Assigned Person does not exist.";
                return false;
            }

            switch (this.UserDTO.Mode)
            {
                case clsUserDTO.enMode.Update:
                    return _UpdateUser();

                case clsUserDTO.enMode.AddNew:
                 
                    if (clsUser.IsUserExistsByPersonID(this.UserDTO.PersonID))
                    {
                        this.LastValidationError = "Validation Fail: A user account already exists for this PersonID.";
                        return false;
                    }

                  
                    if (clsUser.IsUserExists(this.UserDTO.UserName))
                    {
                        this.LastValidationError = "Validation Fail: This Username is already taken.";
                        return false;
                    }

                    return _AddNewUser();

                default:
                    return false;
            }
        }
    }

    }


