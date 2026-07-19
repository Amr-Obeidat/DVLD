namespace DVLD_Tests_;
using DVLD_Business.Tests;
using DVLD_DataAccess.Tests;
using System.Data;

[TestClass]
public class TestTypesTest
{
    [TestMethod]
    public void Test1_FindTestTypeInfo()
    {

        clsTestTypes testTypes = new clsTestTypes();
        testTypes = clsTestTypes.Find(1);
        Assert.IsNotNull(testTypes,"Test Was not found");
        Console.WriteLine("Test Title is "+testTypes.clsTestTypesDTO.TestTypeTitle);

    }
    [TestMethod]
    public void Test2_GetAllTests()
    {

        var dt=clsTestTypeDataAccess.GetAllTestTypes();

        Assert.IsNotNull(dt, "No Tests Records Were Found");


        foreach(DataRow row in dt.Rows)
        {
            Console.WriteLine("Application ID  "+row["TestTypeID"]+ "Application Title" + row["TestTypeTitle"]);
        }

    }
}
