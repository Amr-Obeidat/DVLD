namespace DVLD_Tests_;
using DVLD_Business.Applications;
using System.Data;

[TestClass]
public class ApplicationTypesTestcs
{
    [TestMethod]
    public void Test1_FindApplicationType()
    {

        clsApplicationTypes applicationTypes = new clsApplicationTypes();
        applicationTypes = clsApplicationTypes.Find(5);
        Assert.IsNotNull(applicationTypes,"Application type not found.");
        Console.WriteLine($"Application Type ID: {applicationTypes.DTO.ApplicationTypeID}");
        Console.WriteLine($"Application Type Title: {applicationTypes.DTO.ApplicationTypeTitle}");
        Console.WriteLine($"Application Fees: {applicationTypes.DTO.ApplicationFees}");
      
    }
    [TestMethod]
    public void Test2_GetAllApplicationTypes()
    {
        var dt = clsApplicationTypes.GetAllApplicationTypes();
        Assert.IsNotNull(dt, "No application types found.");
        Assert.IsTrue(dt.Columns.Contains("ApplicationTypeID"), "ApplicationTypeID column not found.");
        Assert.IsTrue(dt.Columns.Contains("ApplicationTypeTitle"), "ApplicationTypeTitle column not found.");
        Assert.IsTrue(dt.Columns.Contains("ApplicationFees"), "ApplicationFees column not found.");
        Console.WriteLine($"Total Application Types: {dt.Rows.Count}");
        Console.WriteLine($"Total Application Types: {dt.Rows.Count}");

        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine(
                $"ID: {row["ApplicationTypeID"]}, " +
                $"Title: {row["ApplicationTypeTitle"]}, " +
                $"Fees: {row["ApplicationFees"]}"
            );
        }

    }
}
