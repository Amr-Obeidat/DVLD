using DVLD_DataAccess.System_Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess.Licenses
{
    public class clsLicenseClassDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;

        private static class clsLicenseClassAttributes
        {
            public const string colLicenseClassId = "LicenseClassID";
            public const string colClassName = "ClassName";
            public const string colClassDescription = "ClassDescription";
            public const string colMinimumAllowedAge = "MinimumAllowedAge";
            public const string colDefaultValidityLength = "DefaultValidityLength";
            public const string colClassFees = "ClassFees";
            public const string TableName = "LicenseClasses";
        }

        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
            ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsLicenseClassAttributes.TableName} " +
                           $"WHERE {clsLicenseClassAttributes.colLicenseClassId} = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                ClassName = reader[clsLicenseClassAttributes.colClassName].ToString();
                                ClassDescription = reader[clsLicenseClassAttributes.colClassDescription].ToString();
                                MinimumAllowedAge = Convert.ToByte(reader[clsLicenseClassAttributes.colMinimumAllowedAge]);
                                DefaultValidityLength = Convert.ToByte(reader[clsLicenseClassAttributes.colDefaultValidityLength]);
                                ClassFees = Convert.ToDecimal(reader[clsLicenseClassAttributes.colClassFees]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine("Failed to get LicenseClass Info: " + ex.Message);
                    }
                }
            }
            return isFound;
        }

        public static bool UpdateLicenseClass(int LicenseClassID,
            byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"UPDATE {clsLicenseClassAttributes.TableName} " +
                           $"SET "+
                           $"{clsLicenseClassAttributes.colMinimumAllowedAge} = @MinimumAllowedAge, " +
                           $"{clsLicenseClassAttributes.colDefaultValidityLength} = @DefaultValidityLength, " +
                           $"{clsLicenseClassAttributes.colClassFees} = @ClassFees " +
                           $"WHERE {clsLicenseClassAttributes.colLicenseClassId} = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@ClassFees", ClassFees);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        isUpdated = false;
                        Console.WriteLine("Failed to update LicenseClass Info: " + ex.Message);
                    }
                }
            }
            return isUpdated;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsLicenseClassAttributes.TableName} " +
                           $"ORDER BY {clsLicenseClassAttributes.colLicenseClassId} ASC";

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
                        Console.WriteLine("Failed to get all LicenseClasses: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}