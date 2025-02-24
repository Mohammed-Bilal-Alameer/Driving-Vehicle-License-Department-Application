using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        public int PersonID { set; get; }

        clsPerson PersonInfo;
        public clsUser()
        {
            UserID = -1;
           UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            PersonID = -1;
            Mode = enMode.AddNew;
        }

        private clsUser(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive= IsActive;
            
            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return this.UserID!=-1;
        }
      

        private bool _UpdateUser()
        {

            return clsUserData.UpdateUser(this.UserID,this.UserName,this.Password,this.IsActive);
        }

       public static clsUser Find(int UserID)
        {
            string UserName = string.Empty;
            string Password = string.Empty;
            int PersonID = -1;
            bool isActive = false;

            if (clsUserData.Find(UserID, ref PersonID, ref UserName, ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else return null;

        }

        public static clsUser Find(string UserName)
        {
            int UserID = -1;
            string Password = string.Empty;
            int PersonID = -1;
            bool isActive = false;

            if (clsUserData.Find(ref UserID, ref PersonID, UserName, ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else return null;

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


        public static bool DeleteUser(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static bool IsUserNameExist(string UserName)
        {
            return clsUserData.IsUserNameExist(UserName);
        }
        public static bool IsUserIDExist(int ID)
        {
            return clsUserData.IsUserIDExist(ID);
        }
        public static bool IsPasswordExist(string Password)
        {
           return clsUserData.IsPasswordExist(Password);
        }

    public static bool isActive(bool IsActive)
        {
            return clsUserData.isActive(IsActive);
        }
        public static DataTable GetAllUsers()
        {
           return clsUserData.GetAllUsers();
        }

    }
}
