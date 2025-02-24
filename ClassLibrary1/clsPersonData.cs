using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT        People.PersonID, People.TheIDNumber, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth,    \r\n\t\t\t\t  CASE\r\n                  WHEN People.Gendor = 0 THEN 'Female'\r\n\r\n                  ELSE 'Male'\r\n\r\n                  END as Gendor , People.Address, People.PhoneNumber, People.Email, \r\n                         Countries.CountryName\r\nFROM            Countries INNER JOIN\r\n                         People ON Countries.CountryID = People.CountryID";
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
                Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                connection.Close();

            }
            return dt;

        }



        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string TheIDNumber, DateTime DateOfBirth, string PhoneNumber, bool Gendor, string Address, string Email, int CountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People( FirstName,
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
                             ImagePath)

                                VALUES(
                            
                             @FirstName,
                             @SecondName,
                             @ThirdName,
                             @LastName,
                             @TheIDNumber,
                             @DateOfBirth,
                             @PhoneNumber,
                             @Gendor,
                             @Address,
                             @Email,
                             @CountryID,
                             @ImagePath);
                             SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TheIDNumber", TheIDNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            {

                if (string.IsNullOrEmpty(ThirdName))
                    command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);

                if (string.IsNullOrEmpty(ImagePath))
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    PersonID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewPerson: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return PersonID;
        }

        public static bool GetPersonInfoByID(int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string TheIDNumber, ref DateTime DateOfBirth, ref string PhoneNumber, ref bool Gendor, ref string Address, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                 reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    LastName = (string)reader["LastName"];
                    TheIDNumber = (string)reader["TheIDNumber"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Gendor = (bool)reader["Gendor"];
                    Address = (string)reader["Address"];
                   
                    CountryID = (int)reader["CountryID"];


                    if (reader["Email"] == DBNull.Value)
                        Email = "";
                    else
                        Email = (string)reader["Email"];


                    if (reader["ThirdName"] == DBNull.Value)
                        ThirdName = "";
                    else
                        ThirdName = reader["ThirdName"].ToString();
                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] == DBNull.Value )
                    {
                        ImagePath = string.Empty;
                    }
                    else
                    {
                        ImagePath = (string)reader["ImagePath"].ToString();

                    }
                    //: 'Unable to cast object of type 'System.DBNull' to type 'System.String'.'

                }
              

               


            }
            catch (Exception ex)
            {
                Debug.Write("GetPersonInfoByID" + ex.ToString());
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return IsFound;
        }



        public static bool GetPersonInfoByNationalNo(ref int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, string TheIDNumber, ref DateTime DateOfBirth, ref string PhoneNumber, ref bool Gendor, ref string Address, ref string Email, ref int CountryID, ref string ImagePath)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE TheIDNumber = @TheIDNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TheIDNumber", TheIDNumber);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;
                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    LastName = (string)reader["LastName"];
                   
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    PhoneNumber = (string)reader["PhoneNumber"];
                    Gendor = (bool)reader["Gendor"];
                    Address = (string)reader["Address"];

                    CountryID = (int)reader["CountryID"];


                    if (reader["Email"] == DBNull.Value)
                        Email = "";
                    else
                        Email = (string)reader["Email"];


                    if (reader["ThirdName"] == DBNull.Value)
                        ThirdName = "";
                    else
                        ThirdName = reader["ThirdName"].ToString();
                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] == DBNull.Value)
                    {
                        ImagePath = string.Empty;
                    }
                    else
                    {
                        ImagePath = (string)reader["ImagePath"].ToString();

                    }
                    //: 'Unable to cast object of type 'System.DBNull' to type 'System.String'.'

                }





            }
            catch (Exception ex)
            {
                Debug.Write("GetPersonInfoByNationalNo" + ex.ToString());
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return IsFound;
        }


        public static bool UpdatePerson(int ID, string FirstName, string SecondName, string ThirdName, string LastName, string TheIDNumber, DateTime DateOfBirth, string PhoneNumber, bool Gendor, string Address, string Email, int CountryID, string ImagePath)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  People  
                            set FirstName = @FirstName, 
                                SecondName=@SecondName,
                                ThirdName=@ThirdName,
                                LastName = @LastName, 
                                TheIDNumber=@TheIDNumber,
                                DateOfBirth = @DateOfBirth,
                                PhoneNumber = @PhoneNumber, 
                                Gendor=@Gendor,
                                Address = @Address, 
                                Email = @Email, 
                                CountryID = @CountryID,
                                ImagePath =@ImagePath
                                where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@TheIDNumber", TheIDNumber);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdatePerson" + ex.Message.ToString());
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeletePerson(int PersonID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete People 
                                where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeletePerson" + ex.Message.ToString());
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);


        }


        public static bool IsNationalNoExist(string TheIDNumber )
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from People where TheIDNumber = @TheIDNumber";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("TheIDNumber", TheIDNumber);

            object obj = null;
            try
            {
                Connection.Open();
                obj = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("IsNationalNoExist" + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return obj != null;



        }

    }
}
