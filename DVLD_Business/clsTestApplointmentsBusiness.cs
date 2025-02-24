using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsTestType;

namespace DVLD_Business
{
    public class clsTestApplointmentsBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

      public  int TestApplointmentID { get; set; }
        public int TestTypeID { get; set; }
        public clsTestType testTypeInfo;
        public int LocalDrivingLicenseApplicationsID { get; set; }
        public DateTime ApplointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isLocked { get; set; }
        public int RetakeTestApplicationID { set; get; }
       public clsApplicationBusiness RetakeTestAppInfo { set; get; }

        public clsTestApplointmentsBusiness()
        {
            this.TestApplointmentID = -1;

            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationsID = -1;
            this.isLocked = false;
            this.CreatedByUserID = -1;
            this.PaidFees = 0;
            this.ApplointmentDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsTestApplointmentsBusiness(int TestApplointmentID, int TestTypeID, int LocalDrivingLicenseApplicationsID, DateTime ApplointmentDate, float PaidFees,
          int CreatedByUserID, bool isLocked,int RetakeTestApplicationID)
        {
            this.TestApplointmentID = TestApplointmentID;

            this.TestTypeID = TestTypeID;
            testTypeInfo = clsTestType.Find((enTestType)TestTypeID);
            this.LocalDrivingLicenseApplicationsID = LocalDrivingLicenseApplicationsID;
            this.isLocked = isLocked;
            this.CreatedByUserID = CreatedByUserID;
            this.PaidFees = PaidFees;
            this.ApplointmentDate = ApplointmentDate;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            RetakeTestAppInfo = clsApplicationBusiness.Find(RetakeTestApplicationID);
            Mode = enMode.Update;

        }



        public static DataTable GetAllApplointments(byte TestType,int LocalDrivingLicenseApplicationID)
        {
            return clsTestApplointmentsData.GetAllApplointments(TestType, LocalDrivingLicenseApplicationID);
        }
   

       


        public static bool DoesLocalApplicationHasAnActiveAppionment(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            return clsTestApplointmentsData.DoesLocalApplicationHasAnActiveAppionment(TestTypeID, LocalDrivingLicenseApplicationID);
        }
        public static bool DoesLocalApplicationPassedTest(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return clsTestApplointmentsData.DoesLocalApplicationPassedThisTest(TestTypeID, LocalDrivingLicenseApplicationID);
        }



        public static clsTestApplointmentsBusiness Find(int TestApplointmentID)
        {
            bool IsFound = false;

            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationsI = -1;
            DateTime ApplointmentDate = DateTime.Now;
            float PaidFee = 0;
            int RetakeTestApplicationID = -1;
            int CreatedByUserID = -1;
            bool isLocked = false;
            IsFound = clsTestApplointmentsData.FindByApplointmentID(TestApplointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationsI,
               ref ApplointmentDate, ref PaidFee, ref CreatedByUserID, ref isLocked,ref RetakeTestApplicationID);
            if (IsFound)
            {
                return new clsTestApplointmentsBusiness(TestApplointmentID, TestTypeID, LocalDrivingLicenseApplicationsI,
                ApplointmentDate, PaidFee, CreatedByUserID, isLocked, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }

        }

        public static clsTestApplointmentsBusiness GetLastTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (clsTestApplointmentsData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsTestApplointmentsBusiness(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }

        private bool _AddNewApplointment()
        {
            this.TestApplointmentID = clsTestApplointmentsData.AddNewApplointment(TestTypeID, LocalDrivingLicenseApplicationsID, ApplointmentDate, PaidFees, CreatedByUserID, isLocked, RetakeTestApplicationID);
            return TestApplointmentID != -1;
        }


        private bool _UpdateApplointment()
        {
            return clsTestApplointmentsData.UpdateApplointment(TestApplointmentID, ApplointmentDate);
        }

        public static int GetPassedTests(int LocalDrivingLicenseApplicationID,bool PassedTest)
        {
            return clsTestApplointmentsData.GetPassedTests(LocalDrivingLicenseApplicationID, PassedTest);
        }
        public static int GetCountTrail(int LocalDrivingLicenseApplicationID, byte TestTypeID)
        {
            return clsTestApplointmentsData.GetCountTrail(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool LockAppointment(int TestApplointmentID)
        {
            return clsTestApplointmentsData.LockAppointment(TestApplointmentID);
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplointment();

            }

            return false;


        }

        private int _GetTestID()
        {
            return clsTestApplointmentsData.GetTestID(TestApplointmentID);
        }
    }
}
