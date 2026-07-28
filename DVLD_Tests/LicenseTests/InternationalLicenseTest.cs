using DVLD_Business.Licenses;
using DVLD_DataAccess.Licenses;
using System.Data;

namespace DVLD_Tests_;

[TestClass]
public class InternationalLicenseTest
{


    [TestMethod]
    public void Test01_AddNew_MissingRequiredIDs_ShouldFail()
    {
        // Arrange: Invalid zero/negative IDs
        clsInternationalLicense license = new clsInternationalLicense();
        license.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.AddNew;
        license.InternationalLicenseDTO.ApplicationID = 0;
        license.InternationalLicenseDTO.DriverID = 0;
        license.InternationalLicenseDTO.IssuedUsingLocalLicenseID = 0;
        license.InternationalLicenseDTO.CreatedByUserID = 0;

        // Act
        bool isSaved = license.Save();

        // Assert
        Assert.IsFalse(isSaved, "Validation Violation: Save allowed zero/negative foreign key IDs.");
        Assert.IsTrue(license.InternationalLicenseDTO.LastValidationError.Contains("reference is missing"),
            "Expected missing reference error message was not set.");
    }

    [TestMethod]
    public void Test02_AddNew_NonExistentBaseApplication_ShouldFail()
    {
        // Arrange: Non-existent Application ID
        clsInternationalLicense license = new clsInternationalLicense();

        license.InternationalLicenseDTO.ApplicationID = 999999;
        license.InternationalLicenseDTO.DriverID = 9;
        license.InternationalLicenseDTO.IssuedUsingLocalLicenseID = 15;
        license.InternationalLicenseDTO.CreatedByUserID = 1;

        // Act
        bool isSaved = license.Save();

        // Assert
        Assert.IsFalse(isSaved, "Validation Violation: Foreign key check failed to catch non-existent ApplicationID.");
        Assert.IsTrue(license.InternationalLicenseDTO.LastValidationError.Contains("Linked Application ID"),
            "Expected non-existent ApplicationID error message.");
    }

    [TestMethod]
    public void Test03_AddNew_NonExistentDriver_ShouldFail()
    {
        // Arrange: Non-existent Driver ID
        clsInternationalLicense license = new clsInternationalLicense();
        license.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.AddNew;
        license.InternationalLicenseDTO.ApplicationID = 69;
        license.InternationalLicenseDTO.DriverID = 999999;
        license.InternationalLicenseDTO.IssuedUsingLocalLicenseID = 15;
        license.InternationalLicenseDTO.CreatedByUserID = 1;

        // Act
        bool isSaved = license.Save();

        // Assert
        Assert.IsFalse(isSaved, "Validation Violation: Foreign key check failed to catch non-existent DriverID.");
        Assert.IsTrue(license.InternationalLicenseDTO.LastValidationError.Contains("Linked Driver ID"),
            "Expected non-existent DriverID error message.");
        Console.WriteLine(license.InternationalLicenseDTO.LastValidationError);
    }



    [TestMethod]
    public void Test04_AddNew_InvalidLicenseClass_ShouldFail()
    {

        int nonClass3LicenseId = 10;

        clsInternationalLicense license = new clsInternationalLicense();
        license.InternationalLicenseDTO.Mode = clsInternationalLicenseDTO.enMode.AddNew;
        license.InternationalLicenseDTO.ApplicationID = 69;
        license.InternationalLicenseDTO.DriverID = 8;
        license.InternationalLicenseDTO.IssuedUsingLocalLicenseID = nonClass3LicenseId;
        license.InternationalLicenseDTO.CreatedByUserID = 1;

        // Act
        bool isSaved = license.Save();

        // Assert
        Assert.IsFalse(isSaved, "Business Rule Violation: International license issued for non-Class 3 local license.");

        Console.WriteLine(license.InternationalLicenseDTO.LastValidationError);
    }

    [TestMethod]
    public void Test05_AddNew_DriverWithActiveLicense_ShouldAutoDeactivateAndSucceed()
    {

        int driverId = 9;
        int previousActiveLicenseId = -1;
        clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(driverId, ref previousActiveLicenseId);

        clsInternationalLicense newLicense = new clsInternationalLicense();
        newLicense.InternationalLicenseDTO.ApplicationID = 47;
        newLicense.InternationalLicenseDTO.DriverID = driverId;
        newLicense.InternationalLicenseDTO.IssuedUsingLocalLicenseID = 15;
        newLicense.InternationalLicenseDTO.CreatedByUserID = 1;


        bool isSaved = newLicense.Save();


        Assert.IsTrue(isSaved, "Failed to issue new international license. Error: " + newLicense.InternationalLicenseDTO.LastValidationError);


        if (previousActiveLicenseId > 0)
        {
            clsInternationalLicense oldLicense = clsInternationalLicense.Find(previousActiveLicenseId);
            Assert.IsNotNull(oldLicense, "Previous active license record was not found.");
            Assert.IsFalse(oldLicense.InternationalLicenseDTO.IsActive, "Previous active license was not auto-deactivated!");
        }
    }


    [TestMethod]
    public void Test06_SaveInUpdateMode_ShouldFail()
    {

        clsInternationalLicense license = clsInternationalLicense.Find(12);
        Assert.IsNotNull(license, "Test Setup Fail: International License ID 12 not found.");


        bool isSaved = license.Save();

        // Assert
        Assert.IsFalse(isSaved, "Security Violation: Direct updates via Save() must be blocked.");
        Console.WriteLine(license.InternationalLicenseDTO.LastValidationError);
    }


    [TestMethod]
    public void Test07_Deactivate_ActiveLicense_ShouldSucceed()
    {

        int activeLicenseId = 14;
        clsInternationalLicense license = clsInternationalLicense.Find(activeLicenseId);
        Assert.IsNotNull(license, "Test Setup Fail: Record not found.");

        if (!license.InternationalLicenseDTO.IsActive)
        {
            Assert.Inconclusive("Test Setup Skip: Target record is already inactive.");
        }


        bool isDeactivated = license.Deactivate();


        Assert.IsTrue(isDeactivated, "Failed to deactivate active international license.");
        Assert.IsFalse(license.InternationalLicenseDTO.IsActive, "IsActive flag was not updated on DTO.");


        clsInternationalLicense reFetchedLicense = clsInternationalLicense.Find(activeLicenseId);
        Assert.IsFalse(reFetchedLicense.InternationalLicenseDTO.IsActive, "IsActive was not updated in database.");
    }

    [TestMethod]
    public void Test08_Deactivate_AlreadyInactiveLicense_ShouldFail()
    {

        clsInternationalLicense license = clsInternationalLicense.Find(13);
        Assert.IsNotNull(license, "Test Setup Fail: Record not found.");


        bool isDeactivated = license.Deactivate();

        Assert.IsFalse(isDeactivated, "Validation Violation: Deactivating an already inactive license returned true.");

        Console.WriteLine(license.InternationalLicenseDTO.LastValidationError);

    }
    [TestMethod]
    public void Test09_Save_TransactionRollback_WhenInsertFails_OldLicenseRemainsActive()
    {
        // --- ARRANGE ---
        // Target Driver 9 who holds active International License ID 14 in your DB
        int driverId = 9;

        // 1. Get the active international license ID for Driver 9
        int initialActiveIntlLicenseId = -1;
        clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(driverId, ref initialActiveIntlLicenseId);

        Assert.IsTrue(initialActiveIntlLicenseId > 0,
            $"Test Setup Error: Driver {driverId} must have an active international license for this rollback test.");

        // Fetch the target active license from DB
        clsInternationalLicense initialLicenseObj = clsInternationalLicense.Find(initialActiveIntlLicenseId);
        Assert.IsNotNull(initialLicenseObj, "Test Setup Error: Active international license record not found.");
        Assert.IsTrue(initialLicenseObj.InternationalLicenseDTO.IsActive, "Test Setup Error: Target international license is not currently active.");

        // 2. Prepare a new International License issuance request
        clsInternationalLicense newIntlLicense = new clsInternationalLicense();

        // Populate valid foreign keys from existing records
        newIntlLicense.InternationalLicenseDTO.ApplicationID = 69;
        newIntlLicense.InternationalLicenseDTO.DriverID = driverId;
        newIntlLicense.InternationalLicenseDTO.IssuedUsingLocalLicenseID = initialLicenseObj.InternationalLicenseDTO.IssuedUsingLocalLicenseID;

        // ?? SABOTAGE STEP: Use an invalid UserID (999999) to force a SQL Foreign Key constraint exception during INSERT
        newIntlLicense.InternationalLicenseDTO.CreatedByUserID = 999999;

        // --- ACT ---
        // Save() will deactivate License 14 inside TransactionScope, 
        // then attempt _AddNewInternationalLicense(), which will throw a SQL exception and fail.
        bool isSaved = newIntlLicense.Save();

        // --- ASSERT ---
        // 1. Save must return false due to SQL failure
        Assert.IsFalse(isSaved, "Validation Violation: Save should have returned false due to invalid CreatedByUserID.");

        // 2. Re-fetch the old license directly from the DB to verify Transaction Rollback
        clsInternationalLicense licenseAfterRollback = clsInternationalLicense.Find(initialActiveIntlLicenseId);
        Assert.IsNotNull(licenseAfterRollback, "Error: Original license missing from DB.");

        // 3. CRITICAL CHECK: Did TransactionScope roll back and restore IsActive = true?
        Assert.IsTrue(licenseAfterRollback.InternationalLicenseDTO.IsActive,
            $"TRANSACTION ROLLBACK FAILURE: License ID [{initialActiveIntlLicenseId}] was deactivated and NOT restored after the insertion failed!");

        Console.WriteLine($"[Passed] Transaction Rollback Verified: License ID {initialActiveIntlLicenseId} remained Active after failed insert.");
    }
    [TestMethod]
    public void Test10_Save_AutoDeactivatesOldLicense_AndIssuesNewOneSuccessfully()
    {
        // --- ARRANGE ---
        // Target Driver 1016 who holds Active International License ID 1013 and Active Local License ID 20
        int driverId = 1016;
        int activeLocalLicenseId = 20;

        // 1. Get the current active international license ID for Driver 1016 (ID 1013)
        int oldActiveIntlLicenseId = -1;
        clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(driverId, ref oldActiveIntlLicenseId);

        Assert.IsTrue(oldActiveIntlLicenseId > 0,
            $"Test Setup Error: Driver {driverId} must have an active international license prior to running this test.");

        clsInternationalLicense oldLicenseBefore = clsInternationalLicense.Find(oldActiveIntlLicenseId);
        Assert.IsNotNull(oldLicenseBefore, "Test Setup Error: Active international license record not found.");
        Assert.IsTrue(oldLicenseBefore.InternationalLicenseDTO.IsActive, "Test Setup Error: Target license is not active.");

        // 2. Setup the new international license entity
        clsInternationalLicense newIntlLicense = new clsInternationalLicense();
        newIntlLicense.InternationalLicenseDTO.ApplicationID = 1111; // Valid Application ID
        newIntlLicense.InternationalLicenseDTO.DriverID = driverId;
        newIntlLicense.InternationalLicenseDTO.IssuedUsingLocalLicenseID = activeLocalLicenseId; // Active Local License 20
        newIntlLicense.InternationalLicenseDTO.CreatedByUserID = 2019; // Valid User ID

        // --- ACT ---
        bool isSaved = newIntlLicense.Save();

        // --- ASSERT ---
        // 1. Save must succeed
        Assert.IsTrue(isSaved,
            $"Issuance Failed: Save() returned false. Error: {newIntlLicense.InternationalLicenseDTO.LastValidationError}");

        // 2. Verify NEW international license ID was generated
        int newLicenseId = newIntlLicense.InternationalLicenseDTO.InternationalLicenseID;
        Assert.IsTrue(newLicenseId > 0, "Error: New International License ID was not generated.");

        // 3. Re-fetch OLD international license from DB and verify auto-deactivation (IsActive = false)
        clsInternationalLicense oldLicenseAfter = clsInternationalLicense.Find(oldActiveIntlLicenseId);
        Assert.IsNotNull(oldLicenseAfter, "Error: Old international license record missing from database.");
        Assert.IsFalse(oldLicenseAfter.InternationalLicenseDTO.IsActive,
            $"BUSINESS RULE VIOLATION: Old International License ID [{oldActiveIntlLicenseId}] was NOT deactivated!");

        // 4. Re-fetch NEW international license from DB and verify active status (IsActive = true)
        clsInternationalLicense newLicenseFromDb = clsInternationalLicense.Find(newLicenseId);
        Assert.IsNotNull(newLicenseFromDb, "Error: Newly issued license was not found in database.");
        Assert.IsTrue(newLicenseFromDb.InternationalLicenseDTO.IsActive,
            "Error: The newly issued international license is not set to Active!");

        Console.WriteLine($"[Passed] Deactivation & Re-issuance Verified:");
        Console.WriteLine($"   - Old International License ID [{oldActiveIntlLicenseId}] -> IsActive: {oldLicenseAfter.InternationalLicenseDTO.IsActive}");
        Console.WriteLine($"   - New International License ID [{newLicenseId}] -> IsActive: {newLicenseFromDb.InternationalLicenseDTO.IsActive}");
    }
}


