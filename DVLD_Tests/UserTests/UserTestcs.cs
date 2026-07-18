namespace DVLD_Tests_;
using DVLD_Business.Users;
[TestClass]
public class UserTestcs
{
    [TestMethod]
    public void Test1_FindUser()
    {

        clsUser user = clsUser.Find(1);
        Assert.IsNotNull(user, "The User Was not found");
        Console.WriteLine("The user was found  with the name " + user.UserDTO.UserName);



    }
    [TestMethod]
    public void Test2_AddNewUser()
    {
        clsUser user = new clsUser();
        user.UserDTO.UserName = "Amr";
        user.UserDTO.Password = "TestPassword";
        user.UserDTO.IsActive = true;
      user.PersonInfo.PersonDTO.PersonID = 1028;
        bool result = user.Save();
        Assert.IsTrue(result, user.LastValidationError);
        Console.WriteLine("User added successfully with UserID: " + user.UserDTO.UserID);
    }
    [TestMethod]
    public void Test3_UpdateUser()
    {
        clsUser user = clsUser.Find(1);
        Assert.IsNotNull(user, "The User Was not found");
        user.UserDTO.UserName = "UpdatedName";
        bool result = user.Save();
        Assert.IsTrue(result, user.LastValidationError);
        Console.WriteLine("User updated successfully with UserID: " + user.UserDTO.UserID);
    }
    [TestMethod]
    public void Test4_DeleteUser()
    {
        clsUser user = clsUser.Find(20);
        Assert.IsNotNull(user, "The User Was not found");
        bool result = clsUser.Delete(user.UserDTO.UserID);
        Assert.IsTrue(result, user.LastValidationError);
        Assert.IsTrue(result, user.LastValidationError);
        Console.WriteLine("User deleted successfully with UserID: " + user.UserDTO.UserID);
    }
    [TestMethod]

    public void Test5_IsUserNameExists()
    {
        string username = "user4";
        bool exists = clsUser.IsUserExists(username);
        Assert.IsTrue(exists, $"The username '{username}' does not exist.");
        Console.WriteLine($"The username '{username}' exists in the database.");
    }
    [TestMethod]
    public void Test6_IsUserExistByUserID()
    {
        int userId = 1;
        bool exists = clsUser.IsUserExists(userId);
        Assert.IsTrue(exists, $"The user with ID '{userId}' does not exist.");
        Console.WriteLine($"The user with ID '{userId}' exists in the database. With The Name ");
    }
    [TestMethod]
    public void Test7_GetAllUsers()
    {
        var usersTable = clsUser.GetAllUsers();
        Assert.IsNotNull(usersTable, "Failed to retrieve users.");
        Assert.IsTrue(usersTable.Rows.Count > 0, "No users found in the database.");
        Assert.IsTrue(usersTable.Columns.Contains("UserID"), "The 'UserID' column is missing in the users table.");
        Assert.IsTrue(usersTable.Columns.Contains("UserName"), "The 'UserName' column is missing in the users table.");
        Assert.IsTrue(usersTable.Columns.Contains("IsActive"), "The 'IsActive' column is missing in the users table.");
        Assert.IsTrue(usersTable.Columns.Contains("PersonID"), "The 'PersonID' column is missing in the users table.");

        Console.WriteLine($"Total users found: {usersTable.Rows.Count}");
        Console.WriteLine("An Example The User +" + usersTable.Rows[0]["UserName"]);
    }

}