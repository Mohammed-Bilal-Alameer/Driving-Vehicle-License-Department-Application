using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDriverBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int DriverID { set; get; }
        public int PersonID { set; get; }
       public clsPerson PersonInfo { set; get; }
        public int CreatedByUserID { set; get; }   
        public DateTime CreatedDate { set; get; }



       private clsDriverBusiness(int DriverID,int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.Find(this.PersonID);
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            Mode= enMode.Update;
        }


        public clsDriverBusiness()
        {
            this.DriverID = -1;
            this.PersonID =-1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;

        }



        private bool AddNewDriver()
        {
            this.DriverID=clsDriverData.AddNewDriver(PersonID,CreatedByUserID,CreatedDate);

            return this.DriverID!=-1;
        }

        public bool Save()
        {
            return AddNewDriver();
        }

        public static clsDriverBusiness FindByPersonID(int PersonID)
        {
            int DriverID = -1;
         int CreatedByUserID = -1;
         DateTime CreatedDate=DateTime.Now;
            bool IsFound = false;
            IsFound = clsDriverData.GetDriverInfoByPersonID(PersonID,ref DriverID, ref CreatedByUserID, ref CreatedDate);
            if(IsFound)
            {
                return new clsDriverBusiness(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }
        public static clsDriverBusiness FindByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            bool IsFound = false;
            IsFound = clsDriverData.GetDriverInfoByDriverID(ref PersonID,  DriverID, ref CreatedByUserID, ref CreatedDate);
            if (IsFound)
            {
                return new clsDriverBusiness(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }



        public static bool IsThePersonDriver(int PersonID)
        {
            return clsDriverData.DoesPersonHasADriver(PersonID);
        }
    }
}
