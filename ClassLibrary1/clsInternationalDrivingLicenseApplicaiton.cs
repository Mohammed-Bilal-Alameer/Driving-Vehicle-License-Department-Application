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
    public class clsInternationalDrivingLicenseApplicaiton
    {

        public static int AddNewInternationalLicense(int ApplicationID,
             int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
             DateTime ExpirationDate, bool IsActive, int CreatedByUserIDForLicense)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update  InternationalLicenses  
                            set IsActive = 0
                            where DriverID=@DriverID;


                            INSERT INTO InternationalLicenses( 
                             ApplicationID,
                            DriverID,
                             IssuedUsingLocalLicenseID,
                             IssueDate,
                             ExpirationDate,
                             IsActive,
                             CreatedByUserIDForLicense
                             )

                                VALUES(
                            
                             @ApplicationID,
                             @DriverID,
                             @IssuedUsingLocalLicenseID,
                             @IssueDate,
                             @ExpirationDate,
                             @IsActive,
                             @CreatedByUserIDForLicense
                           );
                             SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserIDForLicense", CreatedByUserIDForLicense);


            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    InternationalLicenseID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewInternationalLicense" + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }

            return InternationalLicenseID;






        }


        public static DataTable GetAllInternationaDrivingApplications()
        {
            DataTable dt = new DataTable();



            string query = "SELECT        InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive\r\nFROM            InternationalLicenses";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

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


        public static bool UpdateLocalDrivingApplications(int InternationalLicenseID, int ApplicationID, int DriverID,int IssuedUsingLocalLicenseID,DateTime IssueDate,DateTime ExpirationDate,bool IsActive,int CreatedByUserIDForLicense)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  InternationalLicenses  
                            set ApplicationID = @ApplicationID,
                                DriverID = @DriverID,
                                IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID,
                                IssueDate=@IssueDate,
                                ExpirationDate=@ExpirationDate,
                                IsActive=@IsActive,
                                CreatedByUserIDForLicense=@CreatedByUserIDForLicense
                            where InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserIDForLicense", CreatedByUserIDForLicense);



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateLocalDrivingApplications: " + ex.Message);

                return false;
            }

            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

        public static bool GetInternationalLicenseByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID,ref int IssuedUsingLocalLicenseID,ref DateTime IssueDate,
           ref  DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserIDForLicense)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
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
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserIDForLicense = (int)reader["CreatedByUserIDForLicense"];




                }





            }
            catch (Exception ex)
            {
                Debug.Write("GetInternationalLicenseByID" + ex.ToString());
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return IsFound;




        }




        public static bool DoesHaveAnActiveInternationalLicense(int IssuedUsingLocalLicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select Found=1 from InternationalLicenses \r\nwhere InternationalLicenses.IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID and InternationalLicenses.IsActive=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DoesHaveAnActiveInternationalLicense: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllInternationaDrivingApplicationsForDriver(int DriverID)
        {
            DataTable dt = new DataTable();



            string query = "SELECT        InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive\r\nFROM            InternationalLicenses\r\nwhere DriverID=@DriverID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

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





    }
}
