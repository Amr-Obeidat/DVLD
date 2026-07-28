namespace DVLD_Tests_;
using DVLD_Business.Licenses;
using System.Data;

[TestClass]
public class LicenseClassTest
{

    private static void PrintLicenseClassInfo(clsLicenseClass licenseClass)
    {
        if (licenseClass == null)
        {
            Console.WriteLine("License class is null.");
            return;
        }

        Console.WriteLine("License Class Information");
        Console.WriteLine("-------------------------");
        Console.WriteLine($"ID                : {licenseClass.clsLicenseClassDTO.LicenseClassID}");
        Console.WriteLine($"Name              : {licenseClass.clsLicenseClassDTO.ClassName}");
        Console.WriteLine($"Description       : {licenseClass.clsLicenseClassDTO.ClassDescription}");
        Console.WriteLine($"Minimum Age       : {licenseClass.clsLicenseClassDTO.MinimumAllowedAge}");
        Console.WriteLine($"Validity (Years)  : {licenseClass.clsLicenseClassDTO.DefaultValidityLength}");
        Console.WriteLine($"Fees              : {licenseClass.clsLicenseClassDTO.ClassFees:C}");
        Console.WriteLine();
    }
    [TestMethod]
    public void Find_WithValidLicenseClassId_ShouldReturnLicenseClass()
    {
        // Arrange
        const int licenseClassId = 1;

        // Act
        clsLicenseClass? licenseClass = clsLicenseClass.Find(licenseClassId);

        // Assert
        Assert.IsNotNull(
            licenseClass,
            $"License class with ID {licenseClassId} was not found."
        );

        PrintLicenseClassInfo(licenseClass);
    }
    [TestMethod]
    public void Test2_GetAllLicenseClasses()
    {
        // Act
        DataTable licenseClasses = clsLicenseClass.GetAllLicenseClasses();

        // Assert
        Assert.IsNotNull(licenseClasses, "GetAllLicenseClasses() returned null.");
        Assert.IsTrue(licenseClasses.Rows.Count > 0, "No license classes were found.");

        Console.WriteLine($"Total License Classes: {licenseClasses.Rows.Count}");
        Console.WriteLine(new string('-', 80));

        foreach (DataRow row in licenseClasses.Rows)
        {
            Console.WriteLine($"ID                : {row["LicenseClassID"]}");
            Console.WriteLine($"Name              : {row["ClassName"]}");
            Console.WriteLine($"Description       : {row["ClassDescription"]}");
            Console.WriteLine($"Minimum Age       : {row["MinimumAllowedAge"]}");
            Console.WriteLine($"Validity (Years)  : {row["DefaultValidityLength"]}");
            Console.WriteLine($"Fees              : {row["ClassFees"]}");
            Console.WriteLine(new string('-', 80));
        }
    }



    [TestMethod]
    public void Test3_UpdateLicesnseClassInfo()
    {

        clsLicenseClass License = clsLicenseClass.Find(1);


        License.clsLicenseClassDTO.ClassFees = 15;
        License.clsLicenseClassDTO.MinimumAllowedAge = 18;
      
       bool IsSaved= License.Save();

        Assert.IsTrue(IsSaved, "The Last Updation Was not save " + License.clsLicenseClassDTO.LastValidationError);

    }
}

