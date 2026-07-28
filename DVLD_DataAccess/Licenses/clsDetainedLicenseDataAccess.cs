using DVLD_DataAccess.System_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.Licenses
{
    public static class clsDetainedLicensesAttributes
    {
        public const string TableName = "DetainedLicenses";

        public const string colDetainId = "DetainID";
        public const string colLicenseId = "LicenseID";
        public const string colDetainDate = "DetainDate";
        public const string colFineFees = "FineFees";
        public const string colCreatedByUserId = "CreatedByUserID";
        public const string colIsReleased = "IsReleased";
        public const string colReleaseDate = "ReleaseDate";
        public const string colReleasedByUserId = "ReleasedByUserID";
        public const string colReleaseApplicationId = "ReleaseApplicationID";
    }
    public class clsDetainedLicenseDataAccess
    {
        private static string connectionString = clsConnectionString.connectionString;

        public static bool GetDetainedLicenseInfoByID(int detainID, ref int licenseID, ref DateTime detainDate,
         ref decimal fineFees, ref int createdByUserID,
           ref bool isReleased, ref DateTime? releaseDate, ref int? releasedByUserID, ref int? releaseApplicationID)
        {
            bool isFound = false;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $@"SELECT * FROM {clsDetainedLicensesAttributes.TableName} 
                             WHERE {clsDetainedLicensesAttributes.colDetainId} = @DetainID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", detainID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                licenseID = Convert.ToInt32(reader[clsDetainedLicensesAttributes.colLicenseId]);
                                detainDate = Convert.ToDateTime(reader[clsDetainedLicensesAttributes.colDetainDate]);
                                fineFees = Convert.ToDecimal(reader[clsDetainedLicensesAttributes.colFineFees]);
                                createdByUserID = Convert.ToInt32(reader[clsDetainedLicensesAttributes.colCreatedByUserId]);
                                isReleased = Convert.ToBoolean(reader[clsDetainedLicensesAttributes.colIsReleased]);

                                releaseDate = reader[clsDetainedLicensesAttributes.colReleaseDate] != DBNull.Value
                                    ? Convert.ToDateTime(reader[clsDetainedLicensesAttributes.colReleaseDate]) : (DateTime?)null;

                                releasedByUserID = reader[clsDetainedLicensesAttributes.colReleasedByUserId] != DBNull.Value
                                    ? Convert.ToInt32(reader[clsDetainedLicensesAttributes.colReleasedByUserId]) : (int?)null;

                                releaseApplicationID = reader[clsDetainedLicensesAttributes.colReleaseApplicationId] != DBNull.Value
                                    ? Convert.ToInt32(reader[clsDetainedLicensesAttributes.colReleaseApplicationId]) : (int?)null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving detained license by ID: " + ex.Message);
                    }
                }
            }

            return isFound;
        }


        public static bool GetDetainedLicenseInfoByLicenseID(
            int licenseID,
            ref int detainID,
            ref DateTime detainDate,
            ref decimal fineFees,
            ref int createdByUserID,
            ref bool isReleased,
            ref DateTime? releaseDate,
            ref int? releasedByUserID,
            ref int? releaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $@"SELECT * FROM {clsDetainedLicensesAttributes.TableName} 
                             WHERE {clsDetainedLicensesAttributes.colLicenseId} = @LicenseID 
                               AND {clsDetainedLicensesAttributes.colIsReleased} = 0;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                detainID = Convert.ToInt32(reader[clsDetainedLicensesAttributes.colDetainId]);
                                detainDate = Convert.ToDateTime(reader[clsDetainedLicensesAttributes.colDetainDate]);
                                fineFees = Convert.ToDecimal(reader[clsDetainedLicensesAttributes.colFineFees]);
                                createdByUserID = Convert.ToInt32(reader[clsDetainedLicensesAttributes.colCreatedByUserId]);
                                isReleased = Convert.ToBoolean(reader[clsDetainedLicensesAttributes.colIsReleased]);

                                releaseDate = reader[clsDetainedLicensesAttributes.colReleaseDate] != DBNull.Value
                                    ? Convert.ToDateTime(reader[clsDetainedLicensesAttributes.colReleaseDate]) : (DateTime?)null;

                                releasedByUserID = reader[clsDetainedLicensesAttributes.colReleasedByUserId] != DBNull.Value
                                    ? Convert.ToInt32(reader[clsDetainedLicensesAttributes.colReleasedByUserId]) : (int?)null;

                                releaseApplicationID = reader[clsDetainedLicensesAttributes.colReleaseApplicationId] != DBNull.Value
                                    ? Convert.ToInt32(reader[clsDetainedLicensesAttributes.colReleaseApplicationId]) : (int?)null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving active detained license by License ID: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        // --- 3. CHECK IF LICENSE IS DETAINED ---
        public static bool IsLicenseDetained(int licenseID)
        {
            bool isDetained = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $@"SELECT 1 FROM {clsDetainedLicensesAttributes.TableName} 
                             WHERE {clsDetainedLicensesAttributes.colLicenseId} = @LicenseID 
                               AND {clsDetainedLicensesAttributes.colIsReleased} = 0;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isDetained = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error checking detain status for license: " + ex.Message);
                    }
                }
            }

            return isDetained;
        }

        public static int AddNewDetainedLicense(
            int licenseID,
            DateTime detainDate,
            decimal fineFees,
            int createdByUserID)
        {
            int insertedID = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $@"INSERT INTO {clsDetainedLicensesAttributes.TableName} 
                             (
                                 {clsDetainedLicensesAttributes.colLicenseId},
                                 {clsDetainedLicensesAttributes.colDetainDate},
                                 {clsDetainedLicensesAttributes.colFineFees},
                                 {clsDetainedLicensesAttributes.colCreatedByUserId},
                                 {clsDetainedLicensesAttributes.colIsReleased}
                             )
                             VALUES 
                             (
                                 @LicenseID, 
                                 @DetainDate, 
                                 @FineFees, 
                                 @CreatedByUserID, 
                                 0
                             );
                             SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", licenseID);
                    command.Parameters.AddWithValue("@DetainDate", detainDate);
                    command.Parameters.AddWithValue("@FineFees", fineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            insertedID = id;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error inserting new detained license record: " + ex.Message);
                    }
                }
            }

            return insertedID;
        }


        public static bool ReleaseDetainedLicense(int detainID, int releasedByUserID, int releaseApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $@"UPDATE {clsDetainedLicensesAttributes.TableName}
                             SET {clsDetainedLicensesAttributes.colIsReleased} = 1,
                                 {clsDetainedLicensesAttributes.colReleaseDate} = @ReleaseDate,
                                 {clsDetainedLicensesAttributes.colReleasedByUserId} = @ReleasedByUserID,
                                 {clsDetainedLicensesAttributes.colReleaseApplicationId} = @ReleaseApplicationID
                             WHERE {clsDetainedLicensesAttributes.colDetainId} = @DetainID 
                               AND {clsDetainedLicensesAttributes.colIsReleased} = 0;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", detainID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                    command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error releasing detained license record: " + ex.Message);
                    }
                }
            }

            return rowsAffected > 0;
        }


        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"Select * from {clsDetainedLicensesAttributes.TableName} Order by {clsDetainedLicensesAttributes.colDetainId} DEsc";

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
                        throw new Exception("Failed to retrieve detained licenses: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}



          
    
