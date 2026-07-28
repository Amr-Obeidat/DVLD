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
    public class clsApplicationTypeDataAccess
    {

       readonly static string connectionstring = clsConnectionString.connectionString;
        private static class clsApplicationTypeAttributes
        {
            public static string colApplicationTypeId = "ApplicationTypeID";
            public static string colApplicationTypeName = "ApplicationTypeTitle";
            public static string colApplicationFees = "ApplicationFees";
            public static string TableName = "DVLD.dbo.ApplicationTypes";
        }

        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, ref string ApplicationTypeName, ref decimal ApplicationFees)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select {clsApplicationTypeAttributes.colApplicationTypeName}, {clsApplicationTypeAttributes.colApplicationFees} from {clsApplicationTypeAttributes.TableName} " +
                $"where {clsApplicationTypeAttributes.colApplicationTypeId} = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {

                using (command)
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        using (reader)
                        {
                            if (reader.Read())
                            {
                                ApplicationTypeName = reader[clsApplicationTypeAttributes.colApplicationTypeName].ToString();
                                ApplicationFees = Convert.ToDecimal(reader[clsApplicationTypeAttributes.colApplicationFees]);
                                IsFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IsFound = false;
                        throw new Exception("Error retrieving application type information: " + ex.Message);
                    }
                }
            }

            return IsFound;
        }

        public static bool UpdateApplicationTypeInfo(int ApplicationTypeID, decimal ApplicationFees)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"update {clsApplicationTypeAttributes.TableName} set " +
                 
                $"{clsApplicationTypeAttributes.colApplicationFees} = @ApplicationFees " +
                $"where {clsApplicationTypeAttributes.colApplicationTypeId} = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                  
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        IsUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        IsUpdated = false;
                        throw new Exception("Error updating application type information: " + ex.Message);
                    }
                }
            }
            return IsUpdated;
        }
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select * from {clsApplicationTypeAttributes.TableName}" +
                $" order by {clsApplicationTypeAttributes.colApplicationTypeId} asc";
            SqlCommand command = new SqlCommand(query, connection);
            using (connection)
            {


                using (command)
                {

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error retrieving all application types: " + ex.Message);
                    }
                }
            }
            return dt;  

        }
    }
}