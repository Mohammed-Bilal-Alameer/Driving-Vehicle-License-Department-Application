using DVLD_DataAccess;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseBusniess
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason { FirstTime=1,Renew=2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public clsApplicationBusiness ApplicationInfo { set; get; }
        public int DriverID             { set; get; }
        public clsDriverBusiness DriverInfo { set; get; }
        public int LicenseClassID       { set; get; }
       public clsLicensesClassesBusiness LicenseClassInfo { set; get; }
        public DateTime IssueDate        { set; get; }
        public DateTime ExpirationDate           { set; get; }
        public string Notes               { set; get; }
        public float PaidFees                 { set; get; }
        public bool isActive            { set; get; }
        public enIssueReason IssueReason   { set; get; }
        public int CreatedByUserID        { set; get; }


        public string IssueReasonText
        {
            get {
                return GetIssueReasonText(this.IssueReason);
                }
        }
        private clsLicenseBusniess(int LicenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            Mode = enMode.Update;
            this.LicenseID = LicenseID;
            this.ApplicationID = applicationID;
            ApplicationInfo = clsApplicationBusiness.Find(this.ApplicationID);
            this.DriverID = driverID;
            this.DriverInfo =clsDriverBusiness.FindByDriverID(DriverID);
            this.LicenseClassID = licenseClassID;
            this.LicenseClassInfo = clsLicensesClassesBusiness.Find(LicenseClassID);
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.isActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;
        }


        public clsLicenseBusniess()
        {
            Mode = enMode.AddNew;
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            isActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;
        }

       static public clsLicenseBusniess GetLicenseInfoByLicenseID(int LicenseID)
        {
            int ApplicationID=-1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool isActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            bool IsFound = clsLicenseData.GetLicenseInfoByID(LicenseID,ref  ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref isActive, ref IssueReason, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsLicenseBusniess(LicenseID,ApplicationID,DriverID,LicenseClassID,IssueDate,ExpirationDate,Notes,PaidFees,isActive,(enIssueReason)IssueReason,CreatedByUserID);
            }
            else return null;



        }

        static public clsLicenseBusniess GetLicenseInfoByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool isActive = false;
            int IssueReason = 0;
            int CreatedByUserID = -1;

            bool IsFound = clsLicenseData.GetLicenseInfoByApplicationID(ref LicenseID,  ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref isActive, ref IssueReason, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsLicenseBusniess(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, isActive,(enIssueReason) IssueReason, CreatedByUserID);
            }
            else return null;



        }


        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, isActive, (int)IssueReason, CreatedByUserID);
            return this.LicenseID != -1;
        }

 


         public bool DeActivateLicense()
        {
            return clsLicenseData.DeActivateLicense(this.LicenseID);
        }

        public bool Save()
        {

            return _AddNewLicense();
        }

        public static string GetIssueReasonText(enIssueReason Reason)
        {
            switch(Reason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "ReNew";

                case enIssueReason.LostReplacement:
                    return "Replacement For Lost";
                case enIssueReason.DamagedReplacement:
                    return "Replacement For Damaged";

                default:
                    return "First Time";

            }
        }

        public bool IsLicenseExpired()
        {
            return this.ExpirationDate <DateTime.Now;
        }


        public bool IsLicenseIssued()
        {
            return GetActiveLicenseID() != -1;
        }

        public int GetActiveLicenseID()
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(this.DriverInfo.PersonID, this.LicenseClassID);
        }



        public clsLicenseBusniess ReplacementforDamagedOrLost(enIssueReason Reason,int UserID)
        {
            clsApplicationBusiness _NewApplication=new clsApplicationBusiness();
           

            _NewApplication.ApplicationPersonID = this.DriverInfo.PersonID;
            _NewApplication.ApplicationDate = DateTime.Now;
            if (Reason == enIssueReason.DamagedReplacement)
            {
                _NewApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.ReplaceDamagedDrivingLicense;

            }
            else 
            {
                _NewApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.ReplaceLostDrivingLicense;

            }
            _NewApplication.ApplicationStatus = clsApplicationBusiness.enApplicationStatus.Completed;
            _NewApplication.LastStatusDate = DateTime.Now;
            _NewApplication.PaidFees = clsApplicationTypes.Find(_NewApplication.ApplicationTypeID).Fees;
            _NewApplication.CreatedByUserID = UserID;

            if (!_NewApplication.Save())
            {
                return null;
            }

            clsLicenseBusniess ReplacementLicense=new clsLicenseBusniess();

            ReplacementLicense.ApplicationID = _NewApplication.ApplicationID;
            ReplacementLicense.DriverID = this.DriverID;
            ReplacementLicense.LicenseClassID = this.LicenseClassID;
            ReplacementLicense.IssueDate = DateTime.Now;
            ReplacementLicense.ExpirationDate = DateTime.Now.AddYears(clsLicensesClassesBusiness.Find(ReplacementLicense.LicenseClassID).DefaultValidityLength);
            ReplacementLicense.PaidFees = clsLicensesClassesBusiness.Find(ReplacementLicense.LicenseClassID).ClassFees;
            ReplacementLicense.isActive = true;
            ReplacementLicense.IssueReason = Reason;
            ReplacementLicense.CreatedByUserID = UserID;
            if (ReplacementLicense.Save())
            {
                DeActivateLicense();
                return ReplacementLicense;

            }

            else
            {
                return null;
            }


        }


        public clsDetainBusiness DetainLicense(int UserID,float FindFees)
        {

            clsDetainBusiness Detain=new clsDetainBusiness();
            Detain.LicenseID = this.LicenseID;
            Detain.DetainDate = DateTime.Now;
            Detain.FineFees = FindFees;
            Detain.CreatedByUserID=UserID;

            if(Detain.Save())
            {
                return Detain;
            }
            return null;


        }




      public bool ReleasLicense(int UserID,ref int ApplicationID)
        {
            clsApplicationBusiness _ReleasApplication= new clsApplicationBusiness();
            _ReleasApplication.ApplicationPersonID = this.DriverInfo.PersonID;
            _ReleasApplication.ApplicationDate=DateTime.Now;
            _ReleasApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.ReleaseDetainedDrivingLicsense;
            _ReleasApplication.ApplicationStatus = clsApplicationBusiness.enApplicationStatus.Completed;
            _ReleasApplication.LastStatusDate=DateTime.Now;
            _ReleasApplication.PaidFees = clsApplicationTypes.Find(_ReleasApplication.ApplicationTypeID).Fees;
            _ReleasApplication.CreatedByUserID = UserID;
            if (!_ReleasApplication.Save())
            {
                return false;
            }

            ApplicationID = _ReleasApplication.ApplicationID;

            clsDetainBusiness ReleaseLicense=clsDetainBusiness.GetInfoByLicenseID(this.LicenseID);

           clsDetainBusiness.ReleaseDetainedLicense(ReleaseLicense.DetainID, UserID, _ReleasApplication.ApplicationID);


            return true;

        }


    }
}
