using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsPerson
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string TheIDNumber { set; get; }
        public string FullName()
        {
            return FirstName+ " "+SecondName + " "+ ThirdName + " "+ LastName;

        }
        public static bool IsNationalNoExist(string nationalNo)
        {
            return clsPersonData.IsNationalNoExist(nationalNo);
        }
        public DateTime DateOfBirth { set; get; }

        public string ImagePath { set; get; }

        public bool Gendor { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }

        public int CountryID { set; get; }

        public clsPerson()
        {
            PersonID = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gendor = true;
            TheIDNumber = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            CountryID = -1;
            ImagePath = string.Empty;
            Mode = enMode.AddNew;
        }

        private clsPerson( int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string TheIDNumber, DateTime DateOfBirth,string PhoneNumber, bool Gendor, string Address, string Email, int CountryID,string ImagePath)
        {
          
            this.PersonID = PersonID;
           this.FirstName = FirstName;
           this.SecondName = SecondName;
           this.ThirdName = ThirdName;
           this.LastName = LastName;
           this.TheIDNumber = TheIDNumber;
           this.DateOfBirth = DateOfBirth;
            this.PhoneNumber = PhoneNumber;
           this.ImagePath = ImagePath;
           this.Gendor = Gendor;
           this.Address = Address;
           this.Email = Email;
            this.CountryID = CountryID;
            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID=clsPersonData.AddNewPerson(this.FirstName,this.SecondName,this.ThirdName, this.LastName,this.TheIDNumber,this.DateOfBirth,this.PhoneNumber,this.Gendor,this.Address,this.Email,this.CountryID,this.ImagePath);
            return this.PersonID !=-1;
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID,this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.TheIDNumber,this.DateOfBirth,this.PhoneNumber,this.Gendor,this.Address,this.Email,this.CountryID,this.ImagePath);
        }

        public static clsPerson Find(int ID)
        {
            string FirstName   = "";
            string SecondName  = "";
            string ThirdName   = "";
            string LastName    = "";
            string TheIDNumber = "";
          DateTime DateOfBirth = DateTime.Now;
            string PhoneNumber = "";
            bool   Gendor      = true ;
            string Address     = "";
            string Email       = "";
            int    CountryID   = -1;
            string ImagePath   = "";

            if (clsPersonData.GetPersonInfoByID(ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref TheIDNumber, ref DateOfBirth, ref PhoneNumber, ref Gendor, ref Address, ref Email, ref CountryID, ref ImagePath))
            {
                return new clsPerson(ID, FirstName,
                                 SecondName,
                                 ThirdName,
                                 LastName,
                                 TheIDNumber,
                                 DateOfBirth,
                                 PhoneNumber,
                                 Gendor,
                                 Address,
                                 Email,
                                 CountryID,
                                 ImagePath);

            }
            else return null;


        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            string PhoneNumber = "";
            bool Gendor = true;
            string Address = "";
            string Email = "";
            int CountryID = -1;
            string ImagePath = "";

            if (clsPersonData.GetPersonInfoByNationalNo(ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,  NationalNo, ref DateOfBirth, ref PhoneNumber, ref Gendor, ref Address, ref Email, ref CountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, FirstName,
                                 SecondName,
                                 ThirdName,
                                 LastName,
                                 NationalNo,
                                 DateOfBirth,
                                 PhoneNumber,
                                 Gendor,
                                 Address,
                                 Email,
                                 CountryID,
                                 ImagePath);

            }
            else return null;


        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }


        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }



    }
}
