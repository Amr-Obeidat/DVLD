using DVLD_DataAccess.System_Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess.Tests
{
    public class clsTestTypeDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private class clsTestTypeAttributes
        {
            public const string colTestTypeId = "TestTypeID";
            public const string colTestTypeTitle = "TestTypeTitle";
            public const string colTestTypeDescription = "TestTypeDescription";
            public const string colTestTypeFees = "TestTypeFees";
            public const string TableName = "DVLD.dbo.TestTypes";
        }

        public static bool GetTestTypeInfoById(int TestTypeId, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsTestTypeAttributes.TableName} WHERE {clsTestTypeAttributes.colTestTypeId} = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeId);
                    try
                    {
                        connection.Open();
                       
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                TestTypeTitle = reader[clsTestTypeAttributes.colTestTypeTitle].ToString();
                                TestTypeDescription = reader[clsTestTypeAttributes.colTestTypeDescription].ToString();
                                TestTypeFees = Convert.ToDecimal(reader[clsTestTypeAttributes.colTestTypeFees]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to get the TestType Information, " + ex.Message);
                    }
                }
            }
            return isFound;
        }

      
        public static bool UpdateTestfees(int TestTypeId, decimal TestTypeFees)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"UPDATE {clsTestTypeAttributes.TableName}  SET " +
                           $"{clsTestTypeAttributes.colTestTypeFees} = @Fees " +
                           $"WHERE {clsTestTypeAttributes.colTestTypeId} = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeId);
                    command.Parameters.AddWithValue("@Fees", TestTypeFees);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to update the TestType Information, " + ex.Message);
                    }
                }
            }
            return isUpdated;
        }

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
          
            string query = $"SELECT * FROM {clsTestTypeAttributes.TableName} ORDER BY {clsTestTypeAttributes.colTestTypeId} ASC";

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
                        Console.WriteLine("Failed to get all TestTypes, " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}