using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestsBusniess
    {
        public int TestID { get; set; }
        public int AppoientmentID { get; set; }
        public bool TestResult { get; set; }
        public int CreatedByUserID { get; set; }


        public clsTestsBusniess()
        {
            this.TestID = -1;
            this.AppoientmentID = -1;
            this.TestResult = false;
            this.CreatedByUserID = -1;
        }

        private clsTestsBusniess(int TestID,int AppoientmentID,bool TestResult, int CreatedByUserID)
        {
            this.TestID=TestID;
            this.AppoientmentID=AppoientmentID;
            this.TestResult = TestResult;
            this.CreatedByUserID=CreatedByUserID;
        }


        private bool _AddNewTest()
        {
            this.TestID = clsTests.AddNewTest(AppoientmentID, TestResult, CreatedByUserID);
            return TestID != -1;
        }


     static  public clsTestsBusniess FindByAppoientmentID(int appoientmentID)
        {
            bool IsFound = false;
            int TestID = -1;
            bool TestResult = false;
           int CreatedByUserID = -1;

            IsFound = clsTests.FindByTestAppoimmentID(appoientmentID, ref TestID, ref TestResult, ref CreatedByUserID);
            if(IsFound)
            {
                return new clsTestsBusniess(TestID, appoientmentID, TestResult, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        public bool Save()
        {

            return _AddNewTest();




         }

         


        }
    
}
