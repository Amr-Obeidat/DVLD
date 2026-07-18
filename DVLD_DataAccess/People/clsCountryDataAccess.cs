using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_DataAccess.System_Database;
namespace DVLD_DataAccess.People
{
    public class clsCountryDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;
         
        private class Countrycolumns
        {
            public const string colCountryID = "CountryID";
            public const string colCountryName = "CountryName";
            public const string TableName = "Countries";
        }

        public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT {Countrycolumns.colCountryName} FROM {Countrycolumns.TableName} WHERE {Countrycolumns.colCountryID} = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@CountryID", CountryID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isFound = true;
                            CountryName = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error: " + ex.Message);
                    }
                }
            }
            return isFound;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dtCountries = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {Countrycolumns.TableName} ORDER BY {Countrycolumns.colCountryName} ASC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            using (connection)
            {
                using (command)
                {
                    try
                    {
                        connection.Open();
                        adapter.Fill(dtCountries);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error: " + ex.Message);
                    }
                }
            }
            return dtCountries;
        }
    }
}