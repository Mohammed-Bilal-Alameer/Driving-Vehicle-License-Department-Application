using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicensesClasses
    {
        static public DataTable GetAllLicensesClassesName()
        {
            DataTable dt=new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select ClassName from LicensesClasses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetAllLicensesClassesName : " + ex.Message);
            }
            finally { connection.Close(); }
            return dt;

        }


        public static bool GetLicensesClassByID(int LicensesClassID, ref string ClassName,
        ref string ClassDescription, ref int MinimumAllowedAge, ref int DefaultValidityLength,
        ref float ClassFees)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicensesClasses WHERE LicensesClassID = @LicensesClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicensesClassID", LicensesClassID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge =(int) reader["MinimumAllowedAge"];
                    DefaultValidityLength = (int)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle( reader["ClassFees"]);
               


                }





            }
            catch (Exception ex)
            {
                Debug.Write("GetLicensesClassByID" + ex.ToString());
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return IsFound;
        }

      





    }
}
