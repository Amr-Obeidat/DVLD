using DVLD_Business.Applications;
using System.Data;

namespace DVLD_Tests_;

[TestClass]
public class ApplicationsTest
{


    [TestMethod]
    public void Test01_Cancel_NewApplication_ShouldUpdateStatusAndTimestamp()
    {
        
        int appId = 46;
        clsApplication app = clsApplication.Find(appId);
        Assert.IsNotNull(app, $"Test Setup Error: Application {appId} was not found.");

        if (app.ApplicationDTO.ApplicationStatus != 1)
        {
            Assert.Inconclusive($"Test Skip: Application {appId} is not in 'New' status.");
        }

        DateTime timeBeforeUpdate = DateTime.Now.AddSeconds(-2);

     
        bool isCancelled = app.Cancel();


        Assert.IsTrue(isCancelled, $"Cancel Failed. Error: {app.ApplicationDTO.LastValidationError}");
        Assert.AreEqual((byte)2, app.ApplicationDTO.ApplicationStatus, "DTO ApplicationStatus was not updated to 2 (Cancelled).");


        clsApplication reFetchedApp = clsApplication.Find(appId);
        Assert.AreEqual((byte)2, reFetchedApp.ApplicationDTO.ApplicationStatus, "Database record ApplicationStatus was not updated.");
        Assert.IsTrue(reFetchedApp.ApplicationDTO.LastStatusDate >= timeBeforeUpdate, "LastStatusDate was not automatically stamped with current timestamp.");

        Console.WriteLine($"[Passed] Application {appId} successfully cancelled at {reFetchedApp.ApplicationDTO.LastStatusDate}.");
    }

    [TestMethod]
    public void Test02_Complete_NewApplication_ShouldUpdateStatusAndTimestamp()
    {
        // Arrange: Target Application ID 1070 (New application in sample DB)
        int appId = 1070;
        clsApplication app = clsApplication.Find(appId);
        Assert.IsNotNull(app, $"Test Setup Error: Application {appId} was not found.");

        if (app.ApplicationDTO.ApplicationStatus != 1)
        {
            Assert.Inconclusive($"Test Skip: Application {appId} is not in 'New' status.");
        }

        DateTime timeBeforeUpdate = DateTime.Now.AddSeconds(-2);

        // Act
        bool isCompleted = app.Complete();

        // Assert
        Assert.IsTrue(isCompleted, $"Complete Failed. Error: {app.ApplicationDTO.LastValidationError}");
        Assert.AreEqual((byte)3, app.ApplicationDTO.ApplicationStatus, "DTO ApplicationStatus was not updated to 3 (Completed).");

        
        clsApplication reFetchedApp = clsApplication.Find(appId);
        Assert.AreEqual((byte)3, reFetchedApp.ApplicationDTO.ApplicationStatus, "Database ApplicationStatus was not updated.");
        Assert.IsTrue(reFetchedApp.ApplicationDTO.LastStatusDate >= timeBeforeUpdate, "LastStatusDate was not automatically stamped.");

        Console.WriteLine($"[Passed] Application {appId} successfully completed at {reFetchedApp.ApplicationDTO.LastStatusDate}.");
    }

    [TestMethod]
    public void Test03_CancelOrComplete_NonNewApplication_ShouldFail()
    {
        // Arrange: Application ID 45 is already in "3-Completed" status in DB
        int completedAppId = 45;
        clsApplication app = clsApplication.Find(completedAppId);
        Assert.IsNotNull(app, $"Test Setup Error: Application {completedAppId} not found.");

        // Act
        bool isCancelled = app.Cancel();

        // Assert
        Assert.IsFalse(isCancelled, "Validation Violation: Allowed cancelling an already completed application.");
        Assert.IsTrue(app.ApplicationDTO.LastValidationError.Contains("Only applications with 'New' status"),
            "Expected status restriction error message.");
    }

   

    [TestMethod]
    public void Test04_Save_DuplicatePendingApplication_ShouldFail()
    {
        // Arrange: Person 1027 already has an active pending Application (ID 1070, Type 1)
        clsApplication duplicateApp = new clsApplication();
        duplicateApp.ApplicationDTO.ApplicantPersonID = 1027;
        duplicateApp.ApplicationDTO.ApplicationTypeID = 1; // New Local Driving License
        duplicateApp.ApplicationDTO.ApplicationDate = DateTime.Now;
        duplicateApp.ApplicationDTO.ApplicationStatus = 1;
        duplicateApp.ApplicationDTO.LastStatusDate = DateTime.Now;
        duplicateApp.ApplicationDTO.PaidFees = 15.00m;
        duplicateApp.ApplicationDTO.CreatedByUserID = 1;

        // Act
        bool isSaved = duplicateApp.Save();

        // Assert
        Assert.IsFalse(isSaved, "Business Rule Violation: Allowed creating a duplicate pending application for the same person and type.");
        Assert.IsTrue(duplicateApp.ApplicationDTO.LastValidationError.Contains("already exists"),
            "Expected active pending application error message.");
    }

    [TestMethod]
    public void Test05_Save_UpdateExistingApplication_ShouldBeProhibited()
    {
        // Arrange: Fetch existing record (Application ID 45)
        clsApplication existingApp = clsApplication.Find(45);
        Assert.IsNotNull(existingApp, "Test Setup Error: Application 45 not found.");

        // Act: Attempt to execute Save() on an existing record (Update mode)
        existingApp.ApplicationDTO.PaidFees = 1;
        bool isSaved = existingApp.Save();

        // Assert
        Assert.IsFalse(isSaved, "Security Violation: Applications are immutable and direct updates via Save() must be blocked.");
        Assert.IsTrue(existingApp.ApplicationDTO.LastValidationError.Contains("Applications are immutable once created"),
            "Expected immutability error message.");
    }

    [TestMethod]
    public void Test06_Save_InvalidForeignKeys_ShouldFail()
    {
        // Arrange: Application missing required Person ID and Creator User ID
        clsApplication invalidApp = new clsApplication();
        invalidApp.ApplicationDTO.ApplicantPersonID = 0;
        invalidApp.ApplicationDTO.CreatedByUserID = 0;

        // Act
        bool isSaved = invalidApp.Save();

        // Assert
        Assert.IsFalse(isSaved, "Validation Violation: Save allowed invalid zero foreign key references.");
        Assert.IsTrue(invalidApp.ApplicationDTO.LastValidationError.Contains("invalid"),
            "Expected missing reference error message.");
        Console.WriteLine(invalidApp.ApplicationDTO.LastValidationError);
    }
}

