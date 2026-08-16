using DVLD_DataAccess.System_Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess.Users
{
    public class clsUserDataAccess
    {
        readonly static string connectionstring = clsConnectionString.connectionString;



        private class UserAttributes
        {

            public const string colUserId = "UserID";
            public const string colUserName = "UserName";
            public const string colPersonId = "PersonID";
            public const string colPassword = "Password";
            public const string colIsActive = "IsActive";
            public const string TableName = "DVLD.dbo.Users";

        }



        public static bool FindUserById(int UserId, ref string UserName, ref int PersonId, ref string Password, ref bool IsActive)
        {



            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select *  from {UserAttributes.TableName} where {UserAttributes.colUserId}=@UserId";

            SqlCommand command = new SqlCommand(query, connection);

            bool IsFound = false;


            command.Parameters.AddWithValue("@UserId", UserId);
            using (connection)
            {

                using (command)
                {

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        using (reader)
                        {


                            if (reader.Read())
                            {

                                IsFound = true;
                                UserName = reader[UserAttributes.colUserName].ToString();
                                PersonId = Convert.ToInt32(reader[UserAttributes.colPersonId]);
                                Password = reader[UserAttributes.colPassword].ToString();
                                IsActive = Convert.ToBoolean(reader[UserAttributes.colIsActive]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Iam The Find In the UserDataAccess " + ex.Message);
                    }
                }
            }
            return IsFound;


        }
        public static bool FindUserByPersonId( int PersonId, ref string UserName, ref int UserId, ref string Password, ref bool IsActive)
        {



            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select *  from {UserAttributes.TableName} where {UserAttributes.colUserId}=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            bool IsFound = false;


            command.Parameters.AddWithValue("@PersonID", PersonId);
            using (connection)
            {

                using (command)
                {

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        using (reader)
                        {


                            if (reader.Read())
                            {

                                IsFound = true;
                                UserName = reader[UserAttributes.colUserName].ToString();
                                Password = reader[UserAttributes.colPassword].ToString();
                                UserId = Convert.ToInt32( reader[UserAttributes.colUserId]);
                                IsActive = Convert.ToBoolean(reader[UserAttributes.colIsActive]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Iam The Find In the UserDataAccess " + ex.Message);
                    }
                }
            }
            return IsFound;


        }
        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $@"
    SELECT 
        {UserAttributes.colUserId}, 
        {UserAttributes.TableName}.{UserAttributes.colPersonId}, 
        FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName, 
        {UserAttributes.colUserName}, 
        {UserAttributes.colIsActive} 
    FROM {UserAttributes.TableName}
    INNER JOIN People ON {UserAttributes.TableName}.{UserAttributes.colPersonId} = People.PersonID;";
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
                        Console.WriteLine("Iam The GetAllUsers In the UserDataAccess " + ex.Message);
                    }
                }
            }

            return dt;
        }

        public static int AddNewUser(string UserName, int PersonId, string Password, bool IsActive)
        {
            int NewUserId = -1;



            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"insert into {UserAttributes.TableName} ({UserAttributes.colUserName}, {UserAttributes.colPersonId}, {UserAttributes.colPassword}, {UserAttributes.colIsActive}) " +
                "values (@UserName, @PersonId, @Password, @IsActive);" +
                " SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);


                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int GivenUserId))
                        {
                            NewUserId = GivenUserId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Iam The AddNewUser In the UserDataAccess " + ex.Message);

                    }

                }
            }
            return NewUserId;
        }

        public static bool DeleteUser(int UserID)
        {
            int RowsAffectd = -1;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = $"Delete From {UserAttributes.TableName} Where {UserAttributes.colUserId} = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {

                using (command)
                {

                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        connection.Open();
                        RowsAffectd = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Iam the Delete User " + ex.Message);
                    }











                }
            }
            return RowsAffectd > 0;
        }

        public static bool IsUserExistByPersonID(int PersonId)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = $"SELECT COUNT(*) FROM {UserAttributes.TableName} WHERE {UserAttributes.colPersonId} = @PersonId";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonId);

            using (connection)
            {
                using (command)
                {
                    try
                    {
                        connection.Open();

                     
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        IsExist = count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DAL Error in IsUserExistForPersonID: " + ex.Message);
                    }
                }
            }
            return IsExist;
        }
        public static bool IsUserExistByUserId(int UserId)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select count(*) from {UserAttributes.TableName} where {UserAttributes.colUserId}=@UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", UserId);
            using (connection)
            {
                using (command)
                {
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        IsExist = count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Iam The IsUserExist In the UserDataAccess " + ex.Message);
                    }
                }
            }
            return IsExist;
        }

        public static bool IsUserNameExist(string UserName)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select count(*) from {UserAttributes.TableName} where {UserAttributes.colUserName}=@UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            using (connection)
            {
                using (command)
                {
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        IsExist = count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Iam The IsUserNameExist In the UserDataAccess " + ex.Message);
                    }
                }
            }
            return IsExist;
        }
        public static bool UpdateUser(int UserId, string UserName, int PersonId, string Password, bool IsActive)
        {

            int RowsAffected = -1;
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"update {UserAttributes.TableName} set {UserAttributes.colUserName}=@UserName, {UserAttributes.colPersonId}=@PersonId, {UserAttributes.colPassword}=@Password, {UserAttributes.colIsActive}=@IsActive where {UserAttributes.colUserId}=@UserId";
            SqlCommand command = new SqlCommand(query, connection);
            using (connection)
            {
                using (command)
                {
                    command.Parameters.AddWithValue("@UserID", UserId);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@PersonId", PersonId);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    try
                    {
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Iam the Update User " + ex.Message);
                    }
                }
            }
            return RowsAffected > 0;
        }

        public static bool GetUserByUserNameAndPassword(string UserName, string Password, ref int UserId, ref int PersonId, ref bool IsActive)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(connectionstring);
            string query = $"select * from {UserAttributes.TableName} where {UserAttributes.colUserName} = @UserName and {UserAttributes.colPassword} = @Password";

            SqlCommand command = new SqlCommand(query, connection);
            using (connection)
            {
                using (command)
                {


                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                UserId = Convert.ToInt32(reader[UserAttributes.colUserId]);
                                PersonId = Convert.ToInt32(reader[UserAttributes.colPersonId]);
                                IsActive = Convert.ToBoolean(reader[UserAttributes.colIsActive]);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Iam The GetUserByUserNameAndPassword In the UserDataAccess " + ex.Message);
                    }
                }
            }
            return IsFound;
        }
    }
}