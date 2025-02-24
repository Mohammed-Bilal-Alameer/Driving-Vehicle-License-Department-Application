using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsInternationalDrivingLicenseApplicaitonBusiness:clsApplicationBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        public int InternationalLicenseID { set; get; }
         public int DriverID { set; get; }
       public clsDriverBusiness DriverInfo { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }


        public clsInternationalDrivingLicenseApplicaitonBusiness()
        {
            this.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.NewInternationalLicense;
            InternationalLicenseID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate=DateTime.Now;
            IsActive = true;
            Mode = enMode.AddNew;
        }
        public clsInternationalDrivingLicenseApplicaitonBusiness(int InternationalLicenseID
            ,int ApplicationID,int DriverID,int IssuedUsingLocalLicenseID,
            DateTime IssueDate,DateTime ExpirationDate,bool isActive,
            int CreatedByUserIDForLicense,int ApplicationPersonID,DateTime ApplicationDate
            , enApplicationStatus ApplicationStatus,DateTime LastStatusDate,float PaidFees)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            DriverInfo=clsDriverBusiness.FindByDriverID(this.DriverID);
            this.IssuedUsingLocalLicenseID=IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = CreatedByUserIDForLicense;

            base.ApplicationID=ApplicationID;
            base.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.NewInternationalLicense;
            base.CreatedByUserID = CreatedByUserIDForLicense;
            base.ApplicationPersonID=ApplicationPersonID;
            base.ApplicationDate = ApplicationDate;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.ApplicationStatus=ApplicationStatus;
            Mode = enMode.Update;
        }



        private bool _AddNewInternationalDrivingLicense()
        {
            this.InternationalLicenseID =clsInternationalDrivingLicenseApplicaiton.AddNewInternationalLicense(this.ApplicationID, DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive, this.CreatedByUserID);

            return InternationalLicenseID != -1;


        }

        private bool _UpdateInternationalDrivingLicense()
        {
            return clsInternationalDrivingLicenseApplicaiton.UpdateLocalDrivingApplications(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public static DataTable GetAllInternationalApplications()
        {
            return clsInternationalDrivingLicenseApplicaiton.GetAllInternationaDrivingApplications();
        }

        public static DataTable GetAllInternationaDrivingApplicationsForDriver(int DriverID)
        {
            return clsInternationalDrivingLicenseApplicaiton.GetAllInternationaDrivingApplicationsForDriver(DriverID);
        }


        
        public bool Save()
        {
            base.Mode = (clsApplicationBusiness.enMode)Mode;
            if (!base.Save())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalDrivingLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateInternationalDrivingLicense();

            }

            return false;


        }

        public static clsInternationalDrivingLicenseApplicaitonBusiness FindByInternationalApplicationID(int InternationalApplicationID)
        {
            bool IsFound;
            int DriverID = -1;
            int ApplicationID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserIDForLicense = -1;


            IsFound = clsInternationalDrivingLicenseApplicaiton.GetInternationalLicenseByID(InternationalApplicationID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserIDForLicense);
            if (IsFound)
            {
                clsApplicationBusiness AppInfo = clsApplicationBusiness.Find(ApplicationID);


                return new clsInternationalDrivingLicenseApplicaitonBusiness(InternationalApplicationID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate,
                    ExpirationDate, IsActive, AppInfo.CreatedByUserID, AppInfo.ApplicationPersonID,AppInfo.ApplicationDate, AppInfo.ApplicationStatus, AppInfo.LastStatusDate,AppInfo.PaidFees);
            }
            else
            {
                return null;
            }


        }



       static public bool DoesHaveAnActiveInternationalLicense(int IssuedUsingLocalLicenseID)
        {
            return clsInternationalDrivingLicenseApplicaiton.DoesHaveAnActiveInternationalLicense(IssuedUsingLocalLicenseID);
        }



    }
}
