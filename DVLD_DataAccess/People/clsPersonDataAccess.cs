
using System;
using System.Data.SqlClient;
using System.Data;
using DVLD_DataAccess.System_Database;

namespace DVLD_DataAccess.People
{
    public class clsPersonDataAccess
    {
        readonly static string connectionstring =clsConnectionString.connectionString;

        private static class PersonColumns
        {
            public const string colPersonId = "PersonID";
            public const string colNationalId = "NationalNo";
            public const string colFirstName = "FirstName";
            public const string colSecondName = "SecondName";
            public const string colThirdName = "ThirdName";
            public const string colLastName = "LastName";
            public const string colBirthDate = "DateOfBirth";
            public const string colGender = "Gender";
            public const string colPhone = "Phone";
            public const string colEmail = "Email";
            public const string colCountryId = "NationalityCountryID";
            public const string colImagePath = "ImagePath";
            public const string colAddress = "Address";
            public const string TableName = "DVLD.dbo.People";
        }

        public static bool GetPersonInfoById(int PersonId, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime BirthDate, ref char Gendor, ref string Email, ref int CountryId, ref string ImagePath, ref string Phone, ref string Address)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {PersonColumns.TableName} WHERE {PersonColumns.colPersonId}=@PersonId";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@PersonId", PersonId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                FirstName = reader[PersonColumns.colFirstName].ToString();
                                SecondName = reader[PersonColumns.colSecondName].ToString();
                                ThirdName = reader[PersonColumns.colThirdName] != DBNull.Value ? reader[PersonColumns.colThirdName].ToString() : "";
                                LastName = reader[PersonColumns.colLastName].ToString();
                                NationalNo = reader[PersonColumns.colNationalId].ToString();
                                BirthDate = (DateTime)reader[PersonColumns.colBirthDate];
                                Gendor = Convert.ToChar(reader[PersonColumns.colGender]);
                                Email = reader[PersonColumns.colEmail] != DBNull.Value ? reader[PersonColumns.colEmail].ToString() : "";
                                CountryId = (int)reader[PersonColumns.colCountryId];
                                ImagePath = reader[PersonColumns.colImagePath] != DBNull.Value ? reader[PersonColumns.colImagePath].ToString() : "";
                                Phone = reader[PersonColumns.colPhone] != DBNull.Value ? reader[PersonColumns.colPhone].ToString() : "";
                                Address = reader[PersonColumns.colAddress] != DBNull.Value ? reader[PersonColumns.colAddress].ToString() : "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in GetPersonInfoById: " + ex.Message);
                        IsFound = false;
                    }
                }
            }
            return IsFound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonId, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime BirthDate, ref char Gender, ref string Email, ref int CountryId, ref string ImagePath, ref string Phone, ref string Address)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {PersonColumns.TableName} WHERE {PersonColumns.colNationalId}=@NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            bool IsFound = false;

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PersonId = (int)reader[PersonColumns.colPersonId];
                                FirstName = reader[PersonColumns.colFirstName].ToString();
                                SecondName = reader[PersonColumns.colSecondName].ToString();
                                ThirdName = reader[PersonColumns.colThirdName] != DBNull.Value ? reader[PersonColumns.colThirdName].ToString() : "";
                                LastName = reader[PersonColumns.colLastName].ToString();
                                BirthDate = (DateTime)reader[PersonColumns.colBirthDate];
                                Gender = Convert.ToChar(reader[PersonColumns.colGender]);
                                Email = reader[PersonColumns.colEmail] != DBNull.Value ? reader[PersonColumns.colEmail].ToString() : "";
                                CountryId = (int)reader[PersonColumns.colCountryId];
                                ImagePath = reader[PersonColumns.colImagePath] != DBNull.Value ? reader[PersonColumns.colImagePath].ToString() : "";
                                Phone = reader[PersonColumns.colPhone] != DBNull.Value ? reader[PersonColumns.colPhone].ToString() : "";
                                Address = reader[PersonColumns.colAddress] != DBNull.Value ? reader[PersonColumns.colAddress].ToString() : "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in GetPersonInfoByNationalNo: " + ex.Message);
                        IsFound = false;
                    }
                }
            }
            return IsFound;
        }

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth, char Gender, string Phone, string Email, int NationalityCountryID, string ImagePath, string Address)
        {
            int InsertedID = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $@"INSERT INTO {PersonColumns.TableName} 
                             ({PersonColumns.colFirstName}, {PersonColumns.colSecondName}, {PersonColumns.colThirdName}, {PersonColumns.colLastName}, {PersonColumns.colNationalId}, 
                              {PersonColumns.colBirthDate}, {PersonColumns.colGender}, {PersonColumns.colPhone}, {PersonColumns.colEmail}, {PersonColumns.colCountryId}, {PersonColumns.colImagePath}, {PersonColumns.colAddress}) 
                             VALUES 
                             (@FirstName, @SecondName, @ThirdName, @LastName, @NationalNo, 
                              @DateOfBirth, @Gender, @Phone, @Email, @NationalityCountryID, @ImagePath, @Address);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@Address", Address);

                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? DBNull.Value : (object)ThirdName);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int NewID))
                        {
                            InsertedID = NewID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in AddNewPerson: " + ex.Message);
                        InsertedID = -1;
                    }
                }
            }
            return InsertedID;
        }

        public static bool UpdatePerson(int PersonId, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth, char Gender, string Phone, string Email, int NationalityCountryId, string ImagePath, string Address)
        {
            int rowsAffected = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $@"UPDATE {PersonColumns.TableName} SET 
                               {PersonColumns.colFirstName}=@FirstName,
                               {PersonColumns.colSecondName}=@SecondName,
                               {PersonColumns.colThirdName}=@ThirdName,
                               {PersonColumns.colLastName}=@LastName,
                               {PersonColumns.colNationalId}=@NationalNo,
                               {PersonColumns.colBirthDate}=@DateOfBirth,
                               {PersonColumns.colGender}=@Gender,
                               {PersonColumns.colPhone}=@Phone,
                               {PersonColumns.colEmail}=@Email,
                               {PersonColumns.colCountryId}=@NationalityCountryId,
                               {PersonColumns.colImagePath}=@ImagePath,
                               {PersonColumns.colAddress}=@Address
                            WHERE {PersonColumns.colPersonId}=@PersonId";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@NationalityCountryId", NationalityCountryId);
                    command.Parameters.AddWithValue("@Address", Address);

                    command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? DBNull.Value : (object)ThirdName);
                    command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
                    command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in UpdatePerson: " + ex.Message);
                        return false;
                    }
                }
            }
            return rowsAffected > 0;
        }

        public static bool DeletePerson(int PersonId)
        {
            int rowsAffected = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"DELETE FROM {PersonColumns.TableName} WHERE {PersonColumns.colPersonId}=@PersonId";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in DeletePerson: " + ex.Message);
                        return false;
                    }
                }
            }
            return rowsAffected > 0;
        }

        public static DataTable GetAllPeople()
        {
            DataTable AllPeople = new DataTable();
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"SELECT * FROM {PersonColumns.TableName}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            using (connection)
            {
                using (command)
                {
                    try
                    {
                        connection.Open();
                        adapter.Fill(AllPeople);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in GetAllPeople: " + ex.Message);
                    }
                }
            }
            return AllPeople;
        }

        public static bool IsPersonExists(int PersonId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $@"SELECT 1 FROM {PersonColumns.TableName} WHERE {PersonColumns.colPersonId}=@PersonID";
            bool exists = false;
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@PersonID", PersonId);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        exists = (result != null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in IsPersonExists(ID): " + ex.Message);
                        exists = false;
                    }
                }
            }
            return exists;
        }

        public static bool IsPersonExists(string NationalNo)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $@"SELECT 1 FROM {PersonColumns.TableName} WHERE {PersonColumns.colNationalId}=@NationalNo";
            bool exists = false;
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        exists = (result != null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in IsPersonExists(NationalNo): " + ex.Message);
                        exists = false;
                    }
                }
            }
            return exists;
        }
    }
}