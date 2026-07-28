using DVLD_DataAccess.System_Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess.Licenses
{
    public class clsLicenseDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private static class clsLicensesAttributes
        {
            static public string colLicenseId = "LicenseID";
            static public string colApplicationId = "ApplicationID";
            static public string colDriverId = "DriverID";
            static public string colLicenseClass = "LicenseClass";
            static public string colIssueDate = "IssueDate";
            static public string colExpirationDate = "ExpirationDate";
            static public string colNotes = "Notes";
            static public string colPaidFees = "PaidFees";
            static public string colIsActive = "IsActive";
            static public string colIssueReason = "IssueReason";
            static public string colCreatedBy = "CreatedByUserID";
            static public string TableName = "DVLD.dbo.Licenses";
        }

        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsLicensesAttributes.TableName} WHERE {clsLicensesAttributes.colLicenseId} = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                ApplicationID = Convert.ToInt32(reader[clsLicensesAttributes.colApplicationId]);
                                DriverID = Convert.ToInt32(reader[clsLicensesAttributes.colDriverId]);
                                LicenseClass = Convert.ToInt32(reader[clsLicensesAttributes.colLicenseClass]);
                                IssueDate = Convert.ToDateTime(reader[clsLicensesAttributes.colIssueDate]);
                                ExpirationDate = Convert.ToDateTime(reader[clsLicensesAttributes.colExpirationDate]);
                                Notes = reader[clsLicensesAttributes.colNotes] == DBNull.Value ? "" : reader[clsLicensesAttributes.colNotes].ToString();
                                PaidFees = Convert.ToDecimal(reader[clsLicensesAttributes.colPaidFees]);
                                IsActive = Convert.ToBoolean(reader[clsLicensesAttributes.colIsActive]);
                                IssueReason = Convert.ToByte(reader[clsLicensesAttributes.colIssueReason]);
                                CreatedByUserID = Convert.ToInt32(reader[clsLicensesAttributes.colCreatedBy]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving license details by ID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int NewLicenseID = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"INSERT INTO {clsLicensesAttributes.TableName} " +
                           $"({clsLicensesAttributes.colApplicationId}, {clsLicensesAttributes.colDriverId}, {clsLicensesAttributes.colLicenseClass}, {clsLicensesAttributes.colIssueDate}, {clsLicensesAttributes.colExpirationDate}, {clsLicensesAttributes.colNotes}, {clsLicensesAttributes.colPaidFees}, {clsLicensesAttributes.colIsActive}, {clsLicensesAttributes.colIssueReason}, {clsLicensesAttributes.colCreatedBy}) " +
                           $"VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID); " +
                           $"SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            NewLicenseID = newId;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error issuing new local license: " + ex.Message);
                    }
                }
            }
            return NewLicenseID;
        }

        public static bool UpdateLicense(int LicenseID, string Notes, bool IsActive)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"UPDATE {clsLicensesAttributes.TableName} SET " +
                           $"{clsLicensesAttributes.colNotes} = @Notes, " +
                           $"{clsLicensesAttributes.colIsActive} = @IsActive " +
                           $"WHERE {clsLicensesAttributes.colLicenseId} = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    if (string.IsNullOrWhiteSpace(Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);

                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        isUpdated = false;
                        throw new Exception("Error updating license status/notes: " + ex.Message);
                    }
                }
            }
            return isUpdated;
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsLicensesAttributes.TableName} WHERE {clsLicensesAttributes.colDriverId} = @DriverID ORDER BY {clsLicensesAttributes.colLicenseId} DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error retrieving driver licenses: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}