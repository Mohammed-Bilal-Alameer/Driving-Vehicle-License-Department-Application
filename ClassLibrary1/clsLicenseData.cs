using DVLD_DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseData
    {

        public static int AddNewLicense( int ApplicationID, int DriverID, int LicenseClassID ,DateTime IssueDate,DateTime ExpirationDate,string Notes,float PaidFees,bool isActive,int IssueReason,int CreatedByUserID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Licenses( ApplicationID,
                             DriverID,
                            LicenseClassID,
                             IssueDate,ExpirationDate,Notes,PaidFees,isActive,IssueReason,CreatedByUserID)

                                VALUES(
                            
                             @ApplicationID,
                             @DriverID,
                             @LicenseClassID,
                             @IssueDate,@ExpirationDate,@Notes,@PaidFees,@isActive,@IssueReason,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            if (string.IsNullOrEmpty(Notes))
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);



            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    LicenseID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewLicense: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return LicenseID;
        }

        public static bool GetLicenseInfoByID(int LicenseID,ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool isActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees =Convert.ToSingle( reader["PaidFees"]);
                    isActive = (bool)reader["isActive"];
                    IssueReason = (byte)reader["IssueReason"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];


                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];


                  
                }





            }
            catch (Exception ex)
            {
                Debug.Write("GetLicenseInfoByID" + ex.ToString());
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return IsFound;
        }

        public static bool GetLicenseInfoByApplicationID(ref int LicenseID,  int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool isActive, ref int IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = (bool)reader["isActive"];
                    IssueReason = (int)reader["IssueReason"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];


                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];



                }





            }
            catch (Exception ex)
            {
                Debug.Write("GetLicenseInfoByApplicationID" + ex.ToString());
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return IsFound;
        }

        public static bool DeActivateLicense(int LicenseID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Licenses  
                            set isActive = 0
                            where LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
         



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeActivateLicense: " + ex.Message);

                return false;
            }

            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            string Query = "SELECT        Licenses.LicenseID\r\nFROM            Drivers INNER JOIN\r\n                         Licenses ON Drivers.DriverID = Licenses.DriverID\r\n\t\t\t\t\t\t where Licenses.LicenseClassID=@LicenseClassID\r\n\t\t\t\t\t\t and Drivers.PersonID=@PersonID\r\n\t\t\t\t\t\t and Licenses.isActive=1";


                 SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;




        }


    }
}
