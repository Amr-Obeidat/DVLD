using DVLD_DataAccess.System_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.Driver
{
    public class clsDriverDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private static class clsDriversAttributes
        {
            static public string colDriverId = "DriverID";
            static public string colPersonId = "PersonID";
            static public string colCreatedBy = "CreatedByUserID";
            static public string colCreatedDate = "CreatedDate";
            static public string colFullName = "FullName";
            static public string TableName = "DVLD.dbo.Drivers";
            static public string ViewTable = "Drivers_View";
        }

        public static bool GetDriverInfoByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsDriversAttributes.TableName} WHERE {clsDriversAttributes.colDriverId} = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                PersonID = Convert.ToInt32(reader[clsDriversAttributes.colPersonId]);
                                CreatedByUserID = Convert.ToInt32(reader[clsDriversAttributes.colCreatedBy]);
                                CreatedDate = Convert.ToDateTime(reader[clsDriversAttributes.colCreatedDate]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving driver information by ID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsDriversAttributes.TableName} WHERE {clsDriversAttributes.colPersonId} = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                DriverID = Convert.ToInt32(reader[clsDriversAttributes.colDriverId]);
                                CreatedByUserID = Convert.ToInt32(reader[clsDriversAttributes.colCreatedBy]);
                                CreatedDate = Convert.ToDateTime(reader[clsDriversAttributes.colCreatedDate]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving driver information by PersonID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int NewDriverID = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"INSERT INTO {clsDriversAttributes.TableName} ({clsDriversAttributes.colPersonId}, {clsDriversAttributes.colCreatedBy}, {clsDriversAttributes.colCreatedDate}) " +
                           $"VALUES (@PersonID, @CreatedByUserID, @CreatedDate); " +
                           $"SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            { 

                using (command)
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            NewDriverID = newId;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error adding new driver: " + ex.Message);
                    }
                }
            }
            return NewDriverID;
        }

      

        public static bool DoesDriverExist(int DriverID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT 1 FROM {clsDriversAttributes.TableName} WHERE {clsDriversAttributes.colDriverId} = @DriverID";
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
                        if (result != null)
                        {
                            IsFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                        throw new Exception("Error checking if driver exists: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static bool DoesDriverExistByPersonID(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT 1 FROM {clsDriversAttributes.TableName} WHERE {clsDriversAttributes.colPersonId} = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
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
                        throw new Exception("Error checking if driver exists by PersonID: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsDriversAttributes.ViewTable} ORDER BY {clsDriversAttributes.colFullName}";
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
                        Console.WriteLine("Error retrieving all drivers: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public static bool DeleteDriver(int DriverID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"DELETE FROM {clsDriversAttributes.TableName} WHERE {clsDriversAttributes.colDriverId} = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        IsDeleted = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        IsDeleted = false;
                        throw new Exception("Error deleting driver: " + ex.Message);
                    }
                }
            }
            return IsDeleted;
        }
    }
}