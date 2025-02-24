using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUserData
    {
        public static bool IsUserNameExist(string UserName)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from Users where UserName = @UserName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("UserName", UserName);

            object obj = null;
            try
            {
                Connection.Open();
                obj = Command.ExecuteScalar();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("IsUserNameExist" + ex.Message) ;
            }

            finally
            {
                Connection.Close();
            }

            return obj != null;
            }


        public static bool IsUserIDExist(int PersonID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from Users where PersonID = @PersonID";
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
                Debug.WriteLine("IsUserIDExist" + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return obj != null;
        }

        public static bool IsPasswordExist(string Password)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from Users where Password = @Password";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("Password", Password);

            object obj = null;
            try
            {
                Connection.Open();
                obj = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("IsPasswordExist" + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return obj != null;
        }


        public static bool isActive(bool IsActive)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from Users where IsActive = @IsActive";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("IsActive", IsActive);

            object obj = null;
            try
            {
                Connection.Open();
                obj = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("isActive" + ex.Message);
            }

            finally
            {
                Connection.Close();
            }

            return obj != null;
        }
        public static bool Find(int UserID,ref int PersonID,ref string UserName,ref string Password,ref bool isAcvtive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    isAcvtive = (bool)reader["IsActive"];
                  

               
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
                Debug.Write("Find" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



            return isFound;
        }


        public static bool Find(ref int UserID, ref int PersonID, string UserName, ref string Password, ref bool isAcvtive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    isAcvtive = (bool)reader["IsActive"];



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
                Debug.Write("Find" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



            return isFound;
        }

        public static DataTable GetAllUsers()
        {


            DataTable UserData = new DataTable();
            string query = "Select * from Users";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    UserData.Load(reader);
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
            return UserData;


        }


        public static int AddNewUser(int PersonID,string UserName,string Password,bool isActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Users( PersonID,
                             UserName,
                            Password,
                             isActive)

                                VALUES(
                            
                             @PersonID,
                             @UserName,
                             @Password,
                             @isActive);
                             SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@isActive", isActive);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    UserID = InsertedID;

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



            return UserID;
        }



        public static bool UpdateUser(int UserID,string UserName,string Password,bool isActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Update  Users  
                            set UserName = @UserName, 
                                Password=@Password,
                                IsActive=@IsActive
                                where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@isActive", isActive);



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateUser" + ex.Message.ToString());
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }


        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Users 
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeleteUser" + ex.Message.ToString());
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }


    }
}
