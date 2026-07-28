using DVLD_DataAccess.System_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.Applications
{
    public class clsApplicationsDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;
        private static class clsApplicationsAttributes
        {
            static public string colApplicationId = "ApplicationID";
            static public string colPersonId = "ApplicantPersonID";
            static public string colApplicationType = "ApplicationTypeID";
            static public string colApplicationDate = "ApplicationDate";
            static public string colApplicationStatus = "ApplicationStatus";
            static public string colLastUpdatedDate = "LastStatusDate";
            static public string colPaidFees = "PaidFees";
            static public string colCreatedBy = "CreatedByUserID";
            static public string TableName = "DVLD.dbo.Applications";
        }

        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref int ApplicationTypeID, ref DateTime ApplicationDate, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select * from {clsApplicationsAttributes.TableName} where {clsApplicationsAttributes.colApplicationId} = @ApplicationID"
                ;
            SqlCommand command = new SqlCommand(query, connection);
            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                ApplicantPersonID = Convert.ToInt32(reader[clsApplicationsAttributes.colPersonId]);
                                ApplicationTypeID = Convert.ToInt32(reader[clsApplicationsAttributes.colApplicationType]);
                                ApplicationDate = Convert.ToDateTime(reader[clsApplicationsAttributes.colApplicationDate]);
                                ApplicationStatus = Convert.ToByte(reader[clsApplicationsAttributes.colApplicationStatus]);
                                LastStatusDate = Convert.ToDateTime(reader[clsApplicationsAttributes.colLastUpdatedDate]);
                                PaidFees = Convert.ToDecimal(reader[clsApplicationsAttributes.colPaidFees]);
                                CreatedByUserID = Convert.ToInt32(reader[clsApplicationsAttributes.colCreatedBy]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                       // IsFound = false;
                        throw new Exception("Error retrieving application information: " + ex.Message);
                    }
                }
            }
            return IsFound;
        }
        public static int GetActiveApplicationID(int ApplicantPersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;
            SqlConnection connection = new SqlConnection(connectionstring);

            // Status 1 means 'New/Pending'. We look for an open application of this specific type.
            string query = $"SELECT {clsApplicationsAttributes.colApplicationId} FROM {clsApplicationsAttributes.TableName} " +
                           $"WHERE {clsApplicationsAttributes.colPersonId} = @ApplicantPersonID " +
                           $"AND {clsApplicationsAttributes.colApplicationType} = @ApplicationTypeID " +
                           $"AND {clsApplicationsAttributes.colApplicationStatus} = 1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            using (connection)
            {
                using (command)
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            ActiveApplicationID = id;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving active application ID: " + ex.Message);
                    }
                }
            }
            return ActiveApplicationID;
        }
        public static bool AddNewApplication(int ApplicantPersonID, int ApplicationTypeID,
            DateTime ApplicationDate, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID, ref int NewApplicationID)
        {
            bool IsAdded = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"insert into {clsApplicationsAttributes.TableName} ({clsApplicationsAttributes.colPersonId}, {clsApplicationsAttributes.colApplicationType}, {clsApplicationsAttributes.colApplicationDate}, {clsApplicationsAttributes.colApplicationStatus}, {clsApplicationsAttributes.colLastUpdatedDate}, {clsApplicationsAttributes.colPaidFees}, {clsApplicationsAttributes.colCreatedBy}) " +
                $"values (@ApplicantPersonID, @ApplicationTypeID, @ApplicationDate, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID); " +
                $"select SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            NewApplicationID = newId;
                            IsAdded = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        IsAdded = false;
                        throw new Exception("Error adding new application: " + ex.Message);
                    }
                }
            }
            return IsAdded;
        }

     
        public static bool UpdateApplicationStatus(int ApplicationId, byte NewStatues)
        {

            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"update {clsApplicationsAttributes.TableName} " +
                $" set {clsApplicationsAttributes.colApplicationStatus}=@ApplicationStatus," +
                $"{clsApplicationsAttributes.colLastUpdatedDate}=@LastStatusDate where " +
                $" {clsApplicationsAttributes.colApplicationId}=@ApplicationId";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {

                using (command)
                {

                    command.Parameters.AddWithValue("@ApplicationStatus", NewStatues);
                    command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
                    command.Parameters.AddWithValue("@ApplicationId", ApplicationId);


                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        IsUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        IsUpdated = false;
                        throw new Exception("Error updating application status: " + ex.Message);
                    }
                }
            }
            return IsUpdated;
        }


        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {clsApplicationsAttributes.TableName} ORDER BY {clsApplicationsAttributes.colApplicationId} DESC";
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
                        Console.WriteLine("Error retrieving All applications: " + ex.Message);
                    }
                }
            }
            return dt;
        }

       
    }
}

