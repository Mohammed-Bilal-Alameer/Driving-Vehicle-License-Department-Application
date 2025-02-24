using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsLicenseBusniess;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsDetainBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enReasonMode { Detain = 1, Release = 2 };
       static public enReasonMode Reason = enReasonMode.Detain;

        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public float FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleasedByUserID { set; get; }
        public int ReleaseApplicationID{set;get;}

        public clsDetainBusiness()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            ReleaseApplicationID = -1;
            ReleasedByUserID = -1;
            FineFees = 0;
            DetainDate= DateTime.Now;
            Mode= enMode.AddNew;
            
        }

        private clsDetainBusiness(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
            DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID= DetainID;
            this.LicenseID= LicenseID;
            this.DetainDate= DetainDate;
            this.FineFees= FineFees;
            this.CreatedByUserID= CreatedByUserID;
            this.IsReleased= IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID= ReleaseApplicationID;
            Mode= enMode.Update;
        }
        private bool _AddNewDetain()
        {
            this.DetainID = clsDetainData.AddNewDetain(LicenseID, DetainDate, FineFees, CreatedByUserID);
            return this.DetainID != -1;
        }

       static public bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainData.IsLicenseDetained(LicenseID);
        }


      static  public bool ReleaseDetainedLicense(int DetainID,
                 int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainData.ReleaseDetainedLicense(DetainID, ReleasedByUserID, ReleaseApplicationID);
        }


        static public clsDetainBusiness GetInfoByLicenseID(int LicenseID)
        {
            int DetainID = -1;
            float FineFees = 0;
            int CreatedByUserID = -1;
            DateTime DetainDate = DateTime.Now;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            bool IsFound = clsDetainData.GetInfoByLicenseID(ref DetainID,  LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);

            if (IsFound)
            {
                return new clsDetainBusiness(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else return null;



        }
        static public clsDetainBusiness GetInfoByDetainID(int DetainID)
        {
            int LicenseID = -1;
            float FineFees = 0;
            int CreatedByUserID = -1;
            DateTime DetainDate = DateTime.Now;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            bool IsFound = clsDetainData.GetInfoByDetainID( DetainID,ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);

            if (IsFound)
            {
                return new clsDetainBusiness(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else return null;



        }

        public bool Save()
        {
            return _AddNewDetain();
        }

    }
}
