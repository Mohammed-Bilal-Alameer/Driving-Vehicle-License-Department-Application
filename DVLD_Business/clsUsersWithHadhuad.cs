using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUsersWithHadhuad
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        public int PersonID { set; get; }

        clsPerson PersonInfo;
        public clsUsersWithHadhuad()
        {
            UserID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            PersonID = -1;
            Mode = enMode.AddNew;
        }

        private clsUsersWithHadhuad(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }


        private bool _AddNewUser()
        {
            this.UserID = clsUserDataWithHadhoud.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return this.UserID != -1;
        }


        private bool _UpdateUser()
        {

            return clsUserDataWithHadhoud.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }


        public static clsUsersWithHadhuad FindByUserID(int UserID)
        {
            string UserName = string.Empty;
            string Password = string.Empty;
            int PersonID = -1;
            bool isActive = false;


            bool IsFound = clsUserDataWithHadhoud.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref isActive);
            if (IsFound)
            {
                return new clsUsersWithHadhuad(UserID, PersonID, UserName, Password, isActive);
            }
            else return null;

        }


        public static clsUsersWithHadhuad FindByPersonID(int PersonID)
        {
            string UserName = string.Empty;
            string Password = string.Empty;
            int UserID = -1;
            bool isActive = false;


            bool IsFound = clsUserDataWithHadhoud.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref isActive);
            if (IsFound)
            {
                return new clsUsersWithHadhuad(UserID, PersonID, UserName, Password, isActive);
            }
            else return null;


        }



        public static clsUsersWithHadhuad FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = clsUserDataWithHadhoud.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUsersWithHadhuad(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }

        public static bool ChangePassword(int UserID,string Password)
        {
            return clsUserDataWithHadhoud.ChangePassword(UserID, Password);
        }
        public static bool DeleteUser(int ID)
        {
            return clsUserDataWithHadhoud.DeleteUser(ID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsUserDataWithHadhoud.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUserDataWithHadhoud.IsUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserDataWithHadhoud.IsUserExistFroPersonID(PersonID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserDataWithHadhoud.GetAllUsers();
        }




    }
}
