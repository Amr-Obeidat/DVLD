using DVLD_DataAccess.System_Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess.Licenses
{
    public class clsInternationalLicensesDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private static class clsInternationalLicensesAttributes
        {
            static public string colInternationalLicenseId = "InternationalLicenseID";
            static public string colApplicationId = "ApplicationID";
            static public string colDriverId = "DriverID";
            static public string colIssuedUsingLocalLicenseId = "IssuedUsingLocalLicenseID";
            static public string colIssueDate = "IssueDate";
            static public string colExpirationDate = "ExpirationDate";
            static public string colIsActive = "IsActive";
            static public string colCreatedBy = "CreatedByUserID";
            static public string TableName = "DVLD.dbo.InternationalLicenses";
        }

        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsInternationalLicensesAttributes.TableName} WHERE {clsInternationalLicensesAttributes.colInternationalLicenseId} = @InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                ApplicationID = Convert.ToInt32(reader[clsInternationalLicensesAttributes.colApplicationId]);
                                DriverID = Convert.ToInt32(reader[clsInternationalLicensesAttributes.colDriverId]);
                                IssuedUsingLocalLicenseID = Convert.ToInt32(reader[clsInternationalLicensesAttributes.colIssuedUsingLocalLicenseId]);
                                IssueDate = Convert.ToDateTime(reader[clsInternationalLicensesAttributes.colIssueDate]);
                                ExpirationDate = Convert.ToDateTime(reader[clsInternationalLicensesAttributes.colExpirationDate]);
                                IsActive = Convert.ToBoolean(reader[clsInternationalLicensesAttributes.colIsActive]);
                                CreatedByUserID = Convert.ToInt32(reader[clsInternationalLicensesAttributes.colCreatedBy]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving international license details by ID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int NewInternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"INSERT INTO {clsInternationalLicensesAttributes.TableName} " +
                           $"({clsInternationalLicensesAttributes.colApplicationId}, {clsInternationalLicensesAttributes.colDriverId}, {clsInternationalLicensesAttributes.colIssuedUsingLocalLicenseId}, {clsInternationalLicensesAttributes.colIssueDate}, {clsInternationalLicensesAttributes.colExpirationDate}, {clsInternationalLicensesAttributes.colIsActive}, {clsInternationalLicensesAttributes.colCreatedBy}) " +
                           $"VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID); " +
                           $"SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            NewInternationalLicenseID = newId;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error issuing new international license: " + ex.Message);
                    }
                }
            }
            return NewInternationalLicenseID;
        }

        public static bool DeactivateInternationalLicense(int InternationalLicenseID)
        {
            bool isDeactivated = false;
            SqlConnection connection = new SqlConnection(connectionstring);

       
            string query = $"UPDATE {clsInternationalLicensesAttributes.TableName} SET " +
                           $"{clsInternationalLicensesAttributes.colIsActive} = 0 " +
                           $"WHERE {clsInternationalLicensesAttributes.colInternationalLicenseId} = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isDeactivated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        isDeactivated = false;
                        throw new Exception("Error deactivating international license: " + ex.Message);
                    }
                }
            }
            return isDeactivated;
        }
        public static bool GetActiveInternationalLicenseIDByDriverID(int DriverID, ref int ActiveInternationalLicenseID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
         
            string query = $"SELECT {clsInternationalLicensesAttributes.colInternationalLicenseId} FROM {clsInternationalLicensesAttributes.TableName} " +
                           $"WHERE {clsInternationalLicensesAttributes.colDriverId} = @DriverID " +
                           $"AND {clsInternationalLicensesAttributes.colIsActive} = 1 " +
                           $"AND {clsInternationalLicensesAttributes.colExpirationDate} > GETDATE()";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int licenseId))
                        {
                            ActiveInternationalLicenseID = licenseId;
                            IsFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error checking active international license state by driver ID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsInternationalLicensesAttributes.TableName} " +
                           $"WHERE {clsInternationalLicensesAttributes.colDriverId} = @DriverID " +
                           $"ORDER BY {clsInternationalLicensesAttributes.colInternationalLicenseId} DESC";
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
                        Console.WriteLine("Error retrieving driver international licenses: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsInternationalLicensesAttributes.TableName} ORDER BY {clsInternationalLicensesAttributes.colInternationalLicenseId} DESC";
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
                        Console.WriteLine("Error retrieving all international licenses: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}