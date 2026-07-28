using DVLD_DataAccess.System_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.Tests
{
    public class clsTestsDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private static class clsTestsAttributes
        {
            static public string colTestId = "TestID";
            static public string colTestAppointmentId = "TestAppointmentID";
            static public string colTestResult = "TestResult";
            static public string colNotes = "Notes";
            static public string colCreatedBy = "CreatedByUserID";
            static public string TableName = "DVLD.dbo.Tests";
        }

        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsTestsAttributes.TableName} WHERE {clsTestsAttributes.colTestId} = @TestID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestID", TestID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                TestAppointmentID = Convert.ToInt32(reader[clsTestsAttributes.colTestAppointmentId]);
                                TestResult = Convert.ToBoolean(reader[clsTestsAttributes.colTestResult]);

                                // Safely handle NULL values in database text columns
                                Notes = reader[clsTestsAttributes.colNotes] == DBNull.Value ? "" : reader[clsTestsAttributes.colNotes].ToString();

                                CreatedByUserID = Convert.ToInt32(reader[clsTestsAttributes.colCreatedBy]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving test evaluation records by ID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int NewTestID = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"INSERT INTO {clsTestsAttributes.TableName} ({clsTestsAttributes.colTestAppointmentId}, {clsTestsAttributes.colTestResult}, {clsTestsAttributes.colNotes}, {clsTestsAttributes.colCreatedBy}) " +
                           $"VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID); " +
                           $"SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);

                    // Force DBNull if the note block passed down from UI is empty/whitespace
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);

                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            NewTestID = newId;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error writing new test resolution record: " + ex.Message);
                    }
                }
            }
            return NewTestID;
        }

        public static bool UpdateTest(int TestID, bool TestResult, string Notes)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = $"UPDATE {clsTestsAttributes.TableName} SET " +
                     $"{clsTestsAttributes.colTestResult} = @TestResult, " +
                     $"{clsTestsAttributes.colNotes} = @Notes " +
                     $"WHERE {clsTestsAttributes.colTestId} = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestID", TestID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);
                  
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        IsUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        IsUpdated = false;
                        throw new Exception("Error updating historical test log information: " + ex.Message);
                    }
                }
            }
            return IsUpdated;
        }

        public static bool DoesTestExistForAppointment(int TestAppointmentID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT 1 FROM {clsTestsAttributes.TableName} WHERE {clsTestsAttributes.colTestAppointmentId} = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            IsFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                        throw new Exception("Error checking test status presence: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsTestsAttributes.TableName} ORDER BY {clsTestsAttributes.colTestId} DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            using (connection)
            {
                using (command)
                {
                    try
                    {
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error extracting historical data tables from index: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}