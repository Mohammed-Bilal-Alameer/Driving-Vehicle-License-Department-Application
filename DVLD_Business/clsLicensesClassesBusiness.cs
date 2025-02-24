using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;


namespace DVLD_Business
{
    public class clsLicensesClassesBusiness
    {

        public int LicensesClassID { get; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public float ClassFees { get; set;  }
        




        public static DataTable GetAllLicensesClasses()
        {
           return clsLicensesClasses.GetAllLicensesClassesName();
        }


       private clsLicensesClassesBusiness(int licensesClassID,string ClassName,string ClassDescription,int MinimumAllowedAge,int DefaultValidityLength,float ClassFees)
        {
            this.LicensesClassID = licensesClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;

            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

       public static clsLicensesClassesBusiness Find(int licensesClassID)
        {
            bool IsFound=false;
            string ClassName = "";
            string ClassDescription = "";
            int MinimumAllowedAge = 0;
            int DefaultValidityLength = 0;
                float ClassFees = 0;

            IsFound = clsLicensesClasses.GetLicensesClassByID(licensesClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees);
            if(IsFound) {
                return new clsLicensesClassesBusiness(licensesClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
                    }
            else
            {
                return null;
            }

        }


    }
}
