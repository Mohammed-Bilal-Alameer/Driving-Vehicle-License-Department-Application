using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLocalDrivingApplicationsBusiness : clsApplicationBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

      public  int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

      public clsLicensesClassesBusiness LicensInfo { set; get; }
        public string PersonFullName
        {
            get {return base.PersonInfo.FullName(); }
        }
        
      public  clsUsersWithHadhuad UserInfo;
       
        
        public clsLocalDrivingApplicationsBusiness()

        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
      

            Mode = enMode.AddNew;

        }

        public clsLocalDrivingApplicationsBusiness(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID,int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.ApplicationID= ApplicationID;
            this.ApplicationPersonID= ApplicantPersonID;
            this.ApplicationDate= ApplicationDate;
            this.ApplicationTypeID= ApplicationTypeID;
            this.ApplicationStatus= ApplicationStatus;
            this.LastStatusDate= LastStatusDate;
            this.PaidFees= PaidFees;
            this.CreatedByUserID= CreatedByUserID;
            this.UserInfo = clsUsersWithHadhuad.FindByUserID(CreatedByUserID);
            this.LicenseClassID= LicenseClassID;
            LicensInfo = clsLicensesClassesBusiness.Find(LicenseClassID);
            

            Mode = enMode.Update;



        }


        public static bool DeleteLocalDrivingApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingApplications.DeleteLocalDrivingapplications(LocalDrivingLicenseApplicationID);
        }

       public static clsLocalDrivingApplicationsBusiness Find(int LDA)
        {
            bool IsFound;
            int LicenseClassID = -1; 
            int ApplicationID = -1;
           
            IsFound = clsLocalDrivingApplications.GetLocalDrivingApplicationsByID(LDA, ref ApplicationID, ref LicenseClassID);
        if (IsFound)
            {
                clsApplicationBusiness AppInfo = clsApplicationBusiness.Find(ApplicationID);

                return new clsLocalDrivingApplicationsBusiness(LDA, ApplicationID, AppInfo.ApplicationPersonID, AppInfo.ApplicationDate, AppInfo.ApplicationTypeID,
                    AppInfo.ApplicationStatus, AppInfo.LastStatusDate, AppInfo.PaidFees, AppInfo.CreatedByUserID, LicenseClassID);
            }
        else
            {
                return null;
            }


        }


        public static clsLocalDrivingApplicationsBusiness FindByApplicationID(int ApplicationID)
        {
            bool IsFound;
            int LicenseClassID = -1;
            int LocalID = -1;

            IsFound = clsLocalDrivingApplications.GetLocalDrivingApplicationsByApplicationID( ApplicationID, ref LocalID, ref LicenseClassID);
            if (IsFound)
            {
                clsApplicationBusiness AppInfo = clsApplicationBusiness.Find(ApplicationID);

                return new clsLocalDrivingApplicationsBusiness(LocalID, ApplicationID, AppInfo.ApplicationPersonID, AppInfo.ApplicationDate, AppInfo.ApplicationTypeID,
                    AppInfo.ApplicationStatus, AppInfo.LastStatusDate, AppInfo.PaidFees, AppInfo.CreatedByUserID, LicenseClassID);
            }
            else
            {
                return null;
            }


        }


        private bool _AddNewLocalDrivingLicense()
        {
        this.LocalDrivingLicenseApplicationID=clsLocalDrivingApplications.AddNewLocalDrivingApplications(ApplicationID,LicenseClassID);

            return LocalDrivingLicenseApplicationID != -1;


        }


    

        public static DataTable GetAllLocalApplications()
        {
            return clsLocalDrivingApplications.GetAllLocalDrivingApplications();
        }

        public static DataTable GetAllLocalApplicationsForDriver(int DriverID)
        {
            return clsLocalDrivingApplications.GetAllLocalDrivingApplicationsForDriver(DriverID);
        }


        private bool _UpdateLocalDrivingLicense()
        {
            return clsLocalDrivingApplications.UpdateLocalDrivingApplications(LocalDrivingLicenseApplicationID,ApplicationID,LicenseClassID);    
        }

       public bool Save()
        {
            base.Mode = (clsApplicationBusiness.enMode)Mode;
            if(!base.Save())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicense();

            }

            return false;


        }



        public  bool DoesAttendTestType( clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingApplications.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
      

        public int IssueLicenseForTheFirstTime(string Notes,int CreatedByUserID)
        {
            int DriverID = -1;
            clsDriverBusiness Driver = clsDriverBusiness.FindByPersonID(this.ApplicationPersonID);
            if (Driver == null)
            {
                Driver = new clsDriverBusiness();
                Driver.PersonID = this.ApplicationPersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                Driver.CreatedDate = DateTime.Now;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID=Driver.DriverID;

            }

            clsLicenseBusniess _NewLicense = new clsLicenseBusniess();

            _NewLicense.ApplicationID = this.ApplicationID;
            _NewLicense.DriverID = DriverID;
            _NewLicense.LicenseClassID = this.LicenseClassID;
            _NewLicense.IssueDate = DateTime.Now;
            _NewLicense.ExpirationDate = _NewLicense.IssueDate.AddYears(this.LicensInfo.DefaultValidityLength);
            _NewLicense.Notes = Notes;
            _NewLicense.PaidFees = this.LicensInfo.ClassFees;
            _NewLicense.isActive = true;
            _NewLicense.IssueReason = clsLicenseBusniess.enIssueReason.FirstTime;
            _NewLicense.CreatedByUserID = CreatedByUserID;


            if(_NewLicense.Save())
            {
                return _NewLicense.LicenseID;
               

            }
            else
            {
                return -1;
            }

        }

        public bool IsLicenseIssued()
        {
            return GetActiveLicenseID() != -1;
        }

        public int GetActiveLicenseID()
        {
          return  clsLicenseData.GetActiveLicenseIDByPersonID(this.ApplicationPersonID, this.LicenseClassID);
        }



        }





    }




    

