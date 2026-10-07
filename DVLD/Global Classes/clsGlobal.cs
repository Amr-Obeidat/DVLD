using DVLD_Business.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.GlobalClasses
{
    public class clsGlobal
    {

        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string username, string password)
        {
            try
            {
                Properties.Settings.Default.UserName = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetStoredCredential(ref string username, ref string password)
        {
            try
            {
                username = Properties.Settings.Default.UserName;
                password = Properties.Settings.Default.Password;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}

