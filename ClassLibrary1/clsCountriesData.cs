using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace CountriesData

{
    public class clsCountriesData
    {

        public static DataTable ListOfCountries()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Countries";
            SqlCommand command=new SqlCommand(query, connection);

            try
            {
            connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ListOfCountries : " + ex.Message);
            }
            finally { connection.Close(); }
            return dataTable;

        }


    }
}
