using DVLD.Controls;
using DVLD.FormTests.User_control_tests;
using DVLD.FromTests;
using DVLD.FromTests.User_control_tests;
using DVLD.LogIn;
using DVLD.People;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());


        

          
            
            Application.Run(new frmLogin());
        }
    }
}
