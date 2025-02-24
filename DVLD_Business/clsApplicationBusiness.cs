using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static DVLD_Business.clsApplicationBusiness;

namespace DVLD_Business
{
    public class clsApplicationBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
       public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };


        public int ApplicationID { get; set; }
       
        public int ApplicationPersonID { get; set; }

        public string ApplicantFullName
        {
            get { return clsPerson.Find(ApplicationPersonID).FullName(); }
        }
        public clsPerson PersonInfo { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }



       public clsApplicationTypes ApplicationTypeInfo { set; get; }
        public string ApplicationTitle
        {
            get { return clsApplicationTypes.Find(ApplicationTypeID).Title; }
        }
        public enApplicationStatus ApplicationStatus { set; get; }
            
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        {
                            return "New";
                        }
                        case enApplicationStatus.Cancelled:
                        {
                            return "Cancelled";
                        }
                        case enApplicationStatus.Completed:
                        {
                            return "Completed";
                        }
                    default:
                        return "Unknown";
                }

            }
        }


        public DateTime LastStatusDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public clsUsersWithHadhuad CreatedByUserInfo { set; get; }
        public string ApplicationCreater
        {
            get { return clsUsersWithHadhuad.FindByUserID(CreatedByUserID).UserName; }
        }
        //By This you can bring the person info too

       public clsApplicationBusiness()
        {
            this.ApplicationID = -1;
            this.ApplicationPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }



        public clsApplicationBusiness(int ApplicationID, int ApplicantPersonID,
          DateTime ApplicationDate, int ApplicationTypeID,
           enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
           float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID=ApplicationID;
            this.ApplicationPersonID=ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate=ApplicationDate;
            this.ApplicationTypeID=ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypes.Find(ApplicationTypeID);

            this.ApplicationStatus=ApplicationStatus;
            this.LastStatusDate=LastStatusDate;
            this.PaidFees=PaidFees;
            this.CreatedByUserID=CreatedByUserID;
            this.CreatedByUserInfo = clsUsersWithHadhuad.FindByUserID(CreatedByUserID);
            Mode= enMode.Update;


        }


        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.ApplicationID = clsApplication.AddNewApplication(
                this.ApplicationPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        public static bool DoesPersonHaveActiveApplication(int ApplicationPersonID, int ApplicationTypeID,int LicensID)
        {
            return clsApplication.DoesPersonHaveActiveApplication(ApplicationPersonID, ApplicationTypeID, LicensID);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplication.UpdateApplication(this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }


       public static  clsApplicationBusiness Find(int ApplicationID)
        {
            int ApplicantPersonID=-1;
          DateTime ApplicationDate=DateTime.Now;
          int ApplicationTypeI=-1;
          byte ApplicationStatus=1;
          DateTime LastStatusDate=DateTime.Now;
          float PaidFees=-1;
          int CreatedByUserID=-1;
            bool IsFound;
            IsFound = clsApplication.GetApplicationInfoByID(ApplicationID,ref ApplicantPersonID, ref ApplicationDate
                , ref ApplicationTypeI, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);
            if(IsFound)
            {
                return new clsApplicationBusiness(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeI,
                    (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }



        public static bool CancelApplication(int ApplicationID,byte NewStatus)
        {
            return clsApplication.CancelApplication(ApplicationID,NewStatus);
        }

        public static bool CompletApplication(int ApplicationID, byte NewStatus)
        {
            return clsApplication.CompletApplication(ApplicationID, NewStatus);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;
        }



    }
}
