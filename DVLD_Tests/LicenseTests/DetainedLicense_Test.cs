using DVLD_Business.Licenses;
using System.Data;

namespace DVLD_Tests_;

[TestClass]
public class DetainedLicense_Test
{
    [TestMethod]
    public void Test01_FindByDetainID_ExistingRecord_ShouldReturnValidEntity()
    {
      
        int detainId = 5;

       
        clsDetainedLicense detainRecord = clsDetainedLicense.FindByDetainID(detainId);


        Assert.IsNotNull(detainRecord, $"Test Setup Error: Detain ID {detainId} was not found in database.");
        Assert.AreEqual(14, detainRecord.DetainedLicenseDTO.LicenseID, "Mismatch in linked LicenseID.");
        Assert.AreEqual(56.00m, detainRecord.DetainedLicenseDTO.FineFees, "Mismatch in FineFees.");
        Assert.IsFalse(detainRecord.DetainedLicenseDTO.IsReleased, "Expected IsReleased to be false.");
        Assert.AreEqual(clsDetainedLicenseDTO.enMode.Update, detainRecord.DetainedLicenseDTO.Mode, "Expected Mode to be Update.");
        Console.WriteLine("The license with the id " + detainRecord.DetainedLicenseDTO.DetainID + " was found");
    }

    [TestMethod]
    public void Test02_FindByDetainID_NonExistentID_ShouldReturnNull()
    {
       
        clsDetainedLicense detainRecord = clsDetainedLicense.FindByDetainID(999999);

        Assert.IsNull(detainRecord, "Validation Violation: Non-existent DetainID returned an object.");
      
    }

    [TestMethod]
    public void Test03_FindDetainByLicenseID_ExistingActiveDetain_ShouldReturnValidEntity()
    {
       
        int licenseId = 19;

        // Act
        clsDetainedLicense detainRecord = clsDetainedLicense.FindDetainByLicenseID(licenseId);

        // Assert
        Assert.IsNotNull(detainRecord, $"Test Setup Error: Active detain record for License ID {licenseId} was not found.");
        Assert.AreEqual(7, detainRecord.DetainedLicenseDTO.DetainID, "Mismatch in DetainID.");
        Assert.AreEqual(120.00m, detainRecord.DetainedLicenseDTO.FineFees, "Mismatch in FineFees.");
        Assert.IsFalse(detainRecord.DetainedLicenseDTO.IsReleased, "Expected IsReleased to be false.");
    }

    

    [TestMethod]
    public void Test04_IsLicenseDetained_DetainedAndUndetainedLicenses_ShouldReturnCorrectStatus()
    {
        // Act 1: Check License 14 (Detained in DB)
        bool isDetainedTrue = clsDetainedLicense.IsLicenseDetained(14);

        // Act 2: Check License 17 (Not detained in DB)
        bool isDetainedFalse = clsDetainedLicense.IsLicenseDetained(17);

        
        Assert.IsTrue(isDetainedTrue, "Error: License ID 14 should be reported as detained.");
        Assert.IsFalse(isDetainedFalse, "Error: License ID 17 should NOT be reported as detained.");
    }

    

    [TestMethod]
    public void Test05_Save_MissingRequiredIDsOrNegativeFees_ShouldFail()
    {
        // Arrange: Invalid parameters
        clsDetainedLicense detain = new clsDetainedLicense();
        detain.DetainedLicenseDTO.LicenseID = 0;
        detain.DetainedLicenseDTO.CreatedByUserID = 0;
        detain.DetainedLicenseDTO.FineFees = -50.00m;

        // Act
        bool isSaved = detain.Save();

        // Assert
        Assert.IsFalse(isSaved, "Validation Violation: Save allowed zero IDs and negative fees.");
        Assert.IsTrue(detain.DetainedLicenseDTO.LastValidationError.Contains("reference is missing") ||
                      detain.DetainedLicenseDTO.LastValidationError.Contains("cannot be negative"));
        Console.WriteLine(detain.DetainedLicenseDTO.LastValidationError);
    }

    [TestMethod]
    public void Test06_Save_AlreadyDetainedLicense_ShouldFail()
    {
        // Arrange: Attempt to detain License 15 again (already detained under Detain ID 6)
        clsDetainedLicense duplicateDetain = new clsDetainedLicense();
        duplicateDetain.DetainedLicenseDTO.LicenseID = 15;
        duplicateDetain.DetainedLicenseDTO.FineFees = 75.00m;
        duplicateDetain.DetainedLicenseDTO.CreatedByUserID = 1;

        // Act
        bool isSaved = duplicateDetain.Save();

        // Assert
        Assert.IsFalse(isSaved, "Business Rule Violation: Allowed double-detaining an already detained license.");
        Assert.IsTrue(duplicateDetain.DetainedLicenseDTO.LastValidationError.Contains("already detained"),
            "Expected already detained error message.");
        Console.WriteLine(duplicateDetain.DetainedLicenseDTO.LastValidationError);
    }

    [TestMethod]
    public void Test07_Save_UpdateMode_ShouldBeProhibited()
    {
        // Arrange: Fetch existing record (Detain ID 5)
        clsDetainedLicense detainRecord = clsDetainedLicense.FindByDetainID(5);
        Assert.IsNotNull(detainRecord, "Test Setup Error: Detain ID 5 not found.");

        // Act: Direct call to Save() on an existing record
        bool isSaved = detainRecord.Save();

        // Assert
        Assert.IsFalse(isSaved, "Security Violation: Direct updates via Save() must be blocked on detain records.");
        Assert.IsTrue(detainRecord.DetainedLicenseDTO.LastValidationError.Contains("Direct updates to detain records are prohibited"),
            "Expected prohibited update error message.");
        Console.WriteLine(detainRecord.DetainedLicenseDTO.LastValidationError);
    }


    [TestMethod]
    public void Test08_Release_InvalidParameters_ShouldFail()
    {
        // Arrange: Fetch active detain record (Detain ID 6)
        clsDetainedLicense detainRecord = clsDetainedLicense.FindByDetainID(6);
        Assert.IsNotNull(detainRecord, "Test Setup Error: Detain ID 6 not found.");

        // Act: Pass invalid zero UserID and ApplicationID
        bool isReleased = detainRecord.Release(releasedByUserID: 0, releaseApplicationID: 0);

        // Assert
        Assert.IsFalse(isReleased, "Validation Violation: Release allowed zero foreign keys.");
        Assert.IsTrue(detainRecord.DetainedLicenseDTO.LastValidationError.Contains("required"),
            "Expected missing foreign key validation message.");
        Console.WriteLine(detainRecord.DetainedLicenseDTO.LastValidationError);
    }

    [TestMethod]
    public void Test09_Release_ValidActiveDetain_ShouldSucceed()
    {
        // Arrange: Fetch Detain ID 7 (License 19)
        clsDetainedLicense detainRecord = clsDetainedLicense.FindByDetainID(7);
        Assert.IsNotNull(detainRecord, "Test Setup Error: Detain ID 7 not found.");

        if (detainRecord.DetainedLicenseDTO.IsReleased)
        {
            Assert.Inconclusive("Test Skip: Detain ID 7 is already released.");
        }

        int validReleaseUserId = 1;
        int validReleaseApplicationId = 1076; // Valid release application ID from DB

        // Act
        bool isReleased = detainRecord.Release(validReleaseUserId, validReleaseApplicationId);

        // Assert
        Assert.IsTrue(isReleased, $"Release Failed. Error: {detainRecord.DetainedLicenseDTO.LastValidationError}");
        Assert.IsTrue(detainRecord.DetainedLicenseDTO.IsReleased, "DTO IsReleased flag was not updated.");
        Assert.IsNotNull(detainRecord.DetainedLicenseDTO.ReleaseDate, "DTO ReleaseDate was not populated.");

        // DB Verification: Re-fetch directly from database
        clsDetainedLicense reFetched = clsDetainedLicense.FindByDetainID(7);
        Assert.IsTrue(reFetched.DetainedLicenseDTO.IsReleased, "Database record was not updated to IsReleased = 1.");
        Assert.AreEqual(validReleaseUserId, reFetched.DetainedLicenseDTO.ReleasedByUserID, "Mismatch in ReleasedByUserID in DB.");
        Assert.AreEqual(validReleaseApplicationId, reFetched.DetainedLicenseDTO.ReleaseApplicationID, "Mismatch in ReleaseApplicationID in DB.");
    }

   
    [TestMethod]
    public void Test10_GetAllDetainedLicenses_ShouldReturnPopulatedDataTable()
    {
        // Act
        DataTable dt = clsDetainedLicense.GetAllDetainedLicenses();

        // Assert
        Assert.IsNotNull(dt, "GetAllDetainedLicenses returned null.");
        Assert.IsTrue(dt.Rows.Count >= 3, $"Expected at least 3 rows in sample database, found {dt.Rows.Count}.");
        Assert.IsTrue(dt.Columns.Contains("DetainID"), "DataTable missing DetainID column.");
        Assert.IsTrue(dt.Columns.Contains("FineFees"), "DataTable missing FineFees column.");
    }
}

