using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTests
    {

        public static bool FindByTestID(int TestID, ref int TestAppoimmentID, ref bool TestResult, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    TestAppoimmentID = (int)reader["TestAppoimmentID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];





                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Debug.Write("FindByTestID" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



            return isFound;

        }


        public static bool FindByTestAppoimmentID(int TestAppoimmentID, ref int TestID, ref bool TestResult, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests WHERE TestAppoimmentID = @TestAppoimmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppoimmentID", TestAppoimmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];





                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Debug.Write("FindByTestAppoimmentID" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



            return isFound;
        }


        static public DataTable GetAllTests()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT  * from Tests";
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
                Debug.WriteLine("FindByTestID", ex.ToString());

            }
            finally
            {
                connection.Close();

            }



            return dt;
        }

   

        public static int AddNewTest(int TestAppoimmentID, bool TestResult, int CreatedByUserID)
        {
            int NewTest = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Tests(
                             TestAppoimmentID,
                             TestResult,                       
                             CreatedByUserID
)

                                VALUES(
                             @TestAppoimmentID,
                             @TestResult,
                             @CreatedByUserID);
                             SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestAppoimmentID", TestAppoimmentID);


            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    NewTest = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewTest: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return NewTest;
        }





    }
}
