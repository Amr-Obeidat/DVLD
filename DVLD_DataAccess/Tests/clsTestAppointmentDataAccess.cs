using DVLD_DataAccess.System_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.TestAppointments
{
    public class clsTestAppointmentsDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private static class clsAppointmentsAttributes
        {
            static public string colTestAppointmentId = "TestAppointmentID";
            static public string colTestTypeId = "TestTypeID";
            static public string colLocalDrivingLicenseApplicationId = "LocalDrivingLicenseApplicationID";
            static public string colAppointmentDate = "AppointmentDate";
            static public string colPaidFees = "PaidFees";
            static public string colCreatedBy = "CreatedByUserID";
            static public string colIsLocked = "IsLocked";
            static public string TableName = "DVLD.dbo.TestAppointments";
        }

        public static bool GetAppointmentInfoByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsAppointmentsAttributes.TableName} WHERE {clsAppointmentsAttributes.colTestAppointmentId} = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                TestTypeID = Convert.ToInt32(reader[clsAppointmentsAttributes.colTestTypeId]);
                                LocalDrivingLicenseApplicationID = Convert.ToInt32(reader[clsAppointmentsAttributes.colLocalDrivingLicenseApplicationId]);
                                AppointmentDate = Convert.ToDateTime(reader[clsAppointmentsAttributes.colAppointmentDate]);
                                PaidFees = Convert.ToDecimal(reader[clsAppointmentsAttributes.colPaidFees]);
                                CreatedByUserID = Convert.ToInt32(reader[clsAppointmentsAttributes.colCreatedBy]);
                                IsLocked = Convert.ToBoolean(reader[clsAppointmentsAttributes.colIsLocked]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving test appointment information by ID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static int AddNewAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int NewAppointmentID = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"INSERT INTO {clsAppointmentsAttributes.TableName} ({clsAppointmentsAttributes.colTestTypeId}, {clsAppointmentsAttributes.colLocalDrivingLicenseApplicationId}, {clsAppointmentsAttributes.colAppointmentDate}, {clsAppointmentsAttributes.colPaidFees}, {clsAppointmentsAttributes.colCreatedBy}, {clsAppointmentsAttributes.colIsLocked}) " +
                           $"VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked); " +
                           $"SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            NewAppointmentID = newId;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error adding new test appointment: " + ex.Message);
                    }
                }
            }
            return NewAppointmentID;
        }

        public static bool UpdateAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"UPDATE {clsAppointmentsAttributes.TableName} SET {clsAppointmentsAttributes.colTestTypeId} = @TestTypeID, " +
                           $"{clsAppointmentsAttributes.colLocalDrivingLicenseApplicationId} = @LocalDrivingLicenseApplicationID, " +
                           $"{clsAppointmentsAttributes.colAppointmentDate} = @AppointmentDate, " +
                           $"{clsAppointmentsAttributes.colPaidFees} = @PaidFees, " +
                           $"{clsAppointmentsAttributes.colCreatedBy} = @CreatedByUserID, " +
                           $"{clsAppointmentsAttributes.colIsLocked} = @IsLocked " +
                           $"WHERE {clsAppointmentsAttributes.colTestAppointmentId} = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        IsUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        IsUpdated = false;
                        throw new Exception("Error updating test appointment information: " + ex.Message);
                    }
                }
            }
            return IsUpdated;
        }

        public static bool CheckForActiveAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool HasActive = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            // Checks if there's an active appointment that is NOT locked yet (meaning the test hasn't been taken/failed/passed)
            string query = $"SELECT 1 FROM {clsAppointmentsAttributes.TableName} " +
                           $"WHERE {clsAppointmentsAttributes.colLocalDrivingLicenseApplicationId} = @LocalDrivingLicenseApplicationID " +
                           $"AND {clsAppointmentsAttributes.colTestTypeId} = @TestTypeID " +
                           $"AND {clsAppointmentsAttributes.colIsLocked} = 0";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null) HasActive = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error checking for active un-locked appointment: " + ex.Message);
                    }
                }
            }
            return HasActive;
        }

        public static DataTable GetApplicationAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsAppointmentsAttributes.TableName} " +
                           $"WHERE {clsAppointmentsAttributes.colLocalDrivingLicenseApplicationId} = @LocalDrivingLicenseApplicationID " +
                           $"AND {clsAppointmentsAttributes.colTestTypeId} = @TestTypeID " +
                           $"ORDER BY {clsAppointmentsAttributes.colTestAppointmentId} DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error retrieving application appointments: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}