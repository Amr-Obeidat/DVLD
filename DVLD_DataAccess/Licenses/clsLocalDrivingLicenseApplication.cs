using DVLD_DataAccess.System_Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess.Applications
{
    public class clsLocalDrivingLicenseApplicationDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private static class clsLocalAppAttributes
        {
            public const string colLocalDrivingLicenseApplicationId = "LocalDrivingLicenseApplicationID";
            public const string colApplicationId = "ApplicationID";
            public const string colLicenseClassId = "LicenseClassID";
            public const string TableName = "LocalDrivingLicenseApplications";
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID,
            ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsLocalAppAttributes.TableName} " +
                           $"WHERE {clsLocalAppAttributes.colLocalDrivingLicenseApplicationId} = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ApplicationID = Convert.ToInt32(reader[clsLocalAppAttributes.colApplicationId]);
                                LicenseClassID = Convert.ToInt32(reader[clsLocalAppAttributes.colLicenseClassId]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine("Failed to get LocalDrivingLicenseApplication Info: " + ex.Message);
                    }
                }
            }
            return isFound;
        }


        public static bool DoesLocalDrivingLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);


            string query = $"SELECT 1 FROM {clsLocalAppAttributes.TableName} " +
                           $"WHERE {clsLocalAppAttributes.colLocalDrivingLicenseApplicationId} = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine(" this is the local license data access" + ex.Message);
                    }
                }
            }
            return isFound;
        }
        public static bool AddNewLocalDrivingLicenseApplication(ref int LocalDrivingLicenseApplicationID,
            int ApplicationID, int LicenseClassID)
        {
            bool isAdded = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"INSERT INTO {clsLocalAppAttributes.TableName} " +
                           $"({clsLocalAppAttributes.colApplicationId}, {clsLocalAppAttributes.colLicenseClassId}) " +
                           $"VALUES (@ApplicationID, @LicenseClassID); " +
                           $"SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedId))
                        {
                            LocalDrivingLicenseApplicationID = insertedId;
                            isAdded = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        isAdded = false;
                        Console.WriteLine("Failed to add LocalDrivingLicenseApplication: " + ex.Message);
                    }
                }
            }
            return isAdded;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            // ONLY update the LicenseClassID! ApplicationID is strictly immutable.
            string query = $"UPDATE {clsLocalAppAttributes.TableName} " +
                           $"SET {clsLocalAppAttributes.colLicenseClassId} = @LicenseClassID " +
                           $"WHERE {clsLocalAppAttributes.colLocalDrivingLicenseApplicationId} = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        isUpdated = false;
                        Console.WriteLine("Failed to update LocalDrivingLicenseApplication: " + ex.Message);
                    }
                }
            }
            return isUpdated;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            bool isDeleted = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"DELETE FROM {clsLocalAppAttributes.TableName} " +
                           $"WHERE {clsLocalAppAttributes.colLocalDrivingLicenseApplicationId} = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isDeleted = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        isDeleted = false;
                        Console.WriteLine("Failed to delete LocalDrivingLicenseApplication: " + ex.Message);
                    }
                }
            }
            return isDeleted;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);

            // Note: In the view layer later, you'll probably want a complex JOIN view, 
            // but the base DAL table pull remains direct and clean.


            string query = $"SELECT * FROM LocalDrivingLicenseApplications_View " +
                           $" ORDER BY ApplicationDate DESC";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to get all LocalDrivingLicenseApplications: " + ex.Message);
                    }
                }
            }
            return dt;
        }



        public static bool DoesPassTestType(int localDrivingLicenseApplicationId, short testTypeId)
        {
            bool isFound = false;

            string query = $@"SELECT TOP 1 Found = 1
                      FROM {clsLocalAppAttributes.TableName} L
                      INNER JOIN TestAppointments A 
                          ON L.LocalDrivingLicenseApplicationID = A.LocalDrivingLicenseApplicationID
                      INNER JOIN Tests T 
                          ON A.TestAppointmentID = T.TestAppointmentID
                      WHERE L.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                        AND A.TestTypeID = @TestTypeID
                        AND T.TestResult = 1";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return isFound;
        }
        public static byte TotalTrialsPerTest(int localDrivingLicenseApplicationId, short testTypeId)
        {
            byte totalTrials = 0;

            string query = $@"SELECT COUNT(T.TestID)
                      FROM {clsLocalAppAttributes.TableName} L
                      INNER JOIN TestAppointments A 
                          ON L.LocalDrivingLicenseApplicationID = A.LocalDrivingLicenseApplicationID
                      INNER JOIN Tests T 
                          ON A.TestAppointmentID = T.TestAppointmentID
                      WHERE L.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                        AND A.TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte trialsCount))
                        {
                            totalTrials = trialsCount;
                        }
                    }
                    catch (Exception ex)
                    {
                     
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return totalTrials;
        }

        // this query is called on testappointment tables
        public static bool IsThereAnActiveScheduledTest(int localDrivingLicenseApplicationId, short testTypeId)
        {
            bool isFound = false;

           
            string query = $@"SELECT TOP 1 Found = 1
                      FROM TestAppointments
                      WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                        AND TestTypeID = @TestTypeID
                        AND IsLocked = 0";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return isFound;
        }
        public static bool DoesAttendTestType(int localDrivingLicenseApplicationId, short testTypeId)
        {
            bool isFound = false;

            string query = $@"SELECT TOP 1 Found = 1
                      FROM {clsLocalAppAttributes.TableName} L
                      INNER JOIN TestAppointments A 
                          ON L.LocalDrivingLicenseApplicationID = A.LocalDrivingLicenseApplicationID
                      INNER JOIN Tests T 
                          ON A.TestAppointmentID = T.TestAppointmentID
                      WHERE L.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                        AND A.TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeId);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static byte GetPassedTestCount(int localDrivingLicenseApplicationId)
        {
            byte passedTestCount = 0;

            
            string query = @"SELECT COUNT(Tests.TestID)
                     FROM Tests 
                     INNER JOIN TestAppointments 
                         ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                     WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                       AND Tests.TestResult = 1";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && byte.TryParse(result.ToString(), out byte count))
                    {
                        passedTestCount = count;
                    }
                }
                catch (Exception ex)
                {
                    passedTestCount = 0;
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return passedTestCount;
        }
    }
}