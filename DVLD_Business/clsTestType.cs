using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestType
    {

        public enum enTestType {VisionTest=1,WrittenTest=2,StreetTest=3 };
        


        public clsTestType.enTestType ID { set; get; }
        public string TestTitle { set; get; }
        public float TestTypeFees { set; get; }
        public string TestDescription { set; get; }
     

        static public DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

       private clsTestType(clsTestType.enTestType ID, string TestTitle, string TestDescription, float TestTypeFees)
        {
            this.ID = ID;
            this.TestTitle = TestTitle;
            this.TestDescription = TestDescription;
            this.TestTypeFees = TestTypeFees;
        }


        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string TestTitle = "";
            float TestTypeFees = 0;
            string TestDescription = "";
            if (clsTestTypeData.Find((int)TestTypeID, ref TestTitle,ref TestDescription, ref TestTypeFees))
            {
                return new clsTestType(TestTypeID, TestTitle, TestDescription, TestTypeFees);
            }
            else
            {
                return null;
            }
        }


        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateApplicationTypes((int)this.ID, this.TestTitle,this.TestDescription,this.TestTypeFees);
        }


        public bool Save()
        {
            return _UpdateTestType();
        }
    }
}
