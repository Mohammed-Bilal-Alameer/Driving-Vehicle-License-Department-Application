using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsTestApplointmentsData
    {

        public static bool FindByApplointmentID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationsID, ref DateTime AppointmentDate, ref float PaidFees,ref int CreatedByUserID,ref bool isLocked,ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationsID = (int)reader["LocalDrivingLicenseApplicationsID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["isLocked"];


                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                    {
                        RetakeTestApplicationID = -1;
                    }
                    else
                    {
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    }



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


        static public DataTable GetAllApplointments(byte TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT        TestAppointments.TestAppointmentID, TestAppointments.PaidFees, TestAppointments.AppointmentDate, TestAppointments.isLocked\r\nFROM            LocalDrivingLicenseApplications INNER JOIN\r\n                         TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationsID\r\n\t\t\t\t\t\t where TestAppointments.TestTypeID=@TestTypeID and LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID"
                ;
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);




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
                Debug.WriteLine("GetAllApplointments", ex.ToString());

            }
            finally
            {
                connection.Close();

            }



            return dt;
        }



        static public bool UpdateApplointment(int TestApplointmentID, DateTime NewApplointmentDate)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  TestAppointments  
                            set AppointmentDate = @NewApplointmentDate
                             
                                where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestApplointmentID);
            command.Parameters.AddWithValue("@NewApplointmentDate", NewApplointmentDate);





            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("UpdateApplointment" + ex.Message.ToString());
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);






        }



        static public bool LockAppointment(int TestApplointmentID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  TestAppointments  
                            set isLocked = 1
                             
                                where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestApplointmentID);





            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("LockAppointment" + ex.Message.ToString());
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);






        }


        public static int AddNewApplointment(int TestTypeID, int LocalDrivingLicenseApplicationsID, DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool isLocked,int RetakeTestApplicationID)
        {
            int NewTestApplointmentID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TestAppointments( TestTypeID,
                             LocalDrivingLicenseApplicationsID,
                            AppointmentDate,
                             PaidFees,
                                CreatedByUserID,isLocked,RetakeTestApplicationID
)

                                VALUES(
                            
                             @TestTypeID,
                             @LocalDrivingLicenseApplicationsID,
                             @AppointmentDate,
                             @PaidFees,@CreatedByUserID,@isLocked,@RetakeTestApplicationID);
                             SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationsID", LocalDrivingLicenseApplicationsID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@isLocked", isLocked);
            command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    NewTestApplointmentID = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("AddNewApplointment: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                connection.Close();
            }



            return NewTestApplointmentID;
        }


        static public int GetPassedTests(int LocalDrivingLicenseApplicationsID, bool PassedTest)
        {
            int PassedTests = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "        SELECT COUNT(TestResult) AS PassedTests\r\n        FROM TestAppointments INNER JOIN\r\n                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppoimmentID\r\n                         where TestAppointments.LocalDrivingLicenseApplicationsID=@LocalDrivingLicenseApplicationsID and TestResult = @PassedTest";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationsID", LocalDrivingLicenseApplicationsID);
            Command.Parameters.AddWithValue("@PassedTest", PassedTest);


            SqlDataReader reader = null;

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    PassedTests = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetPassedTests: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                Connection.Close();
            }



            return PassedTests;


        }


        static public int GetCountTrail(int LocalDrivingLicenseApplicationsID, byte TestTypeID)
        {
            int PassedTests = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT     count(TestID)   \r\nFROM            TestAppointments INNER JOIN\r\n                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppoimmentID\r\n\t\t\t\t\t\t where TestAppointments.LocalDrivingLicenseApplicationsID=@LocalDrivingLicenseApplicationsID and TestAppointments.TestTypeID=@TestTypeID and Tests.TestResult=0";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationsID", LocalDrivingLicenseApplicationsID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            SqlDataReader reader = null;

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    PassedTests = InsertedID;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetCountTrail: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                Connection.Close();
            }



            return PassedTests;


        }



        static public bool DoesLocalApplicationHasAnActiveAppionment(int TestTypeID,int LocalID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select found=1 from TestAppointments \r\nwhere TestTypeID=@TestTypeID and LocalDrivingLicenseApplicationsID=@LocalID and isLocked=0  ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalID", LocalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DoesLocalApplicationHasAnActiveAppionment: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        static public bool DoesLocalApplicationPassedThisTest(int TestTypeID, int LocalID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT     Found=1   \r\nFROM            TestAppointments INNER JOIN\r\n                         Tests ON TestAppointments.TestAppointmentID = Tests.TestAppoimmentID\r\nwhere TestAppointments.LocalDrivingLicenseApplicationsID=@LocalID and   TestAppointments.TestTypeID=@TestTypeID and Tests.TestResult=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalID", LocalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DoesLocalApplicationPassedThisTest" + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




        ///////فنشكنات هدهود
        public static bool GetLastTestAppointment(int TestAppointmentID,  int TestTypeID, ref int LocalDrivingLicenseApplicationsID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID, ref bool isLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select top 1 * from TestAppointments   WHERE        (TestTypeID = @TestTypeID) \r\n                AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) \r\n                order by TestAppointmentID Desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationsID = (int)reader["LocalDrivingLicenseApplicationsID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["isLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                    {
                        RetakeTestApplicationID = -1;
                    }
                    else
                    {
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    }



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
                Debug.Write("GetLastTestAppointment" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }



            return isFound;




        }

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;
        }
    }
}
