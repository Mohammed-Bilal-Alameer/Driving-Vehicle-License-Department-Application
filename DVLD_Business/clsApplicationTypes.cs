using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;


namespace DVLD_Business
{
    public class clsApplicationTypes
    {


      public  int IDType { set; get; }
      public  string Title { set; get; }
        public float Fees { set; get; }


        static public DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        private clsApplicationTypes(int IDType, string Title, float Fees)
        {
            this.IDType = IDType;
            this.Title = Title;
            this.Fees = Fees;
        }

        public static clsApplicationTypes Find(int IDType)
        {
            string Title = "";
            float Fees = 0;
            if(clsApplicationTypesData.GetApplicationTypeByID(IDType,ref Title,ref Fees))
            {
                return new clsApplicationTypes(IDType, Title, Fees);
            }
            else
            {
                return null;
            }
        }
        private  bool _UpdateApplicationTypes()
        {
            return clsApplicationTypesData.UpdateApplicationTypes(this.IDType, this.Title, this.Fees);
        }

        public  bool Save()
        {
           return _UpdateApplicationTypes();
        }
    }
}
