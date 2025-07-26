using DVLD.Applications.Local_Driving_Application;
using DVLD.Applications.Test_Types;
using DVLD.Login;
using DVLD.NewFolder1;
using DVLD.People;
using DVLD.User;
using DVLD_Business;
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
            //Application.Run(new AddUpdateUser(-1));
           //Application.Run(new frmDVLDMain());
            Application.Run(new frmLoginScreen());
            //Application.Run(new frmListPeople());
            //Application.Run(new UsersList());
            // Application.Run(new frmApplicationTypes());
            //Application.Run(new frmNewLocalDrivingApplication());


        }
    }
}
