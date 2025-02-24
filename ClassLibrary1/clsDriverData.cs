using DVLD_DataAccess;
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
    public class clsDriverData
    {
       static public bool GetDriverInfoByPersonID( int PersonID,ref int DriverID, ref int CreatedByUserID,ref DateTime CreatedDate)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];



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
                Debug.Write("GetDriverInfoByPersonID" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



            return isFound;
        }

        static public bool GetDriverInfoByDriverID(ref int PersonID,  int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];



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
                Debug.Write("GetDriverInfoByDriverID" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



            return isFound;
        }


        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Drivers( PersonID,
                             CreatedByUserID,
                            CreatedDate
                             )

                                VALUES(
                            
                             @PersonID,
                             @CreatedByUserID,
                             @CreatedDate
                            );
                             SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    DriverID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewUser: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return DriverID;
        }


        public static DataTable GetAllDrivers()
        {


            DataTable DriversData = new DataTable();
            string query = @"SELECT        Drivers.DriverID, People.PersonID, People.TheIDNumber,FullName=People.FirstName+' '+People.SecondName+' '+People.LastName, Drivers.CreatedDate
FROM            Drivers INNER JOIN
                         People ON Drivers.PersonID = People.PersonID CROSS JOIN
                         LicensesClasses";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    DriversData.Load(reader);
                }

                reader.Close();

            }



            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                connection.Close();

            }
            return DriversData;


        }


        public static bool DoesPersonHasADriver(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from Drivers where PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("PersonID", PersonID);

            object obj = null;
            try
            {
                Connection.Open();
                obj = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DoesPersonHasADriver" + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return obj != null;
        }


    }
}
