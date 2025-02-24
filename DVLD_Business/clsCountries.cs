using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountriesData;

namespace DVLD_Business
{
    public class clsCountries
    {
        public static DataTable GetAllCountries()
        {
           return  clsCountriesData.ListOfCountries();
        }
    }
}
