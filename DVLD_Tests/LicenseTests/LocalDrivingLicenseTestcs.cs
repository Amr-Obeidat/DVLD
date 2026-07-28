namespace DVLD_Tests_;

using DVLD_Business.Applications;
using DVLD_Business.Licenses;
using System.Data;

[TestClass]
public class LocalDrivingLicenseTestcs
{
    [TestMethod]
    public void Test1_Find_localLicenseApplication()
    {

        int appId = 30;
        clsLocalDrivingLicensecs Local = clsLocalDrivingLicensecs.Find(appId);
        Assert.IsNotNull(Local, "The Licenses with the Application Id " + appId + " was not found");
        Console.WriteLine("The license with the id " + appId + " was found succesfully");

        Console.WriteLine((clsApplicationDTO.enApplicationStatus)Local.ApplicationInfo.ApplicationDTO.ApplicationStatus);


    }
    [TestMethod]

    public void Test2_AddnewRecord()
    {

        clsApplication baseApp = new clsApplication();
        baseApp.ApplicationDTO.ApplicantPersonID = 1; // Must be a valid Person ID in your DB
        baseApp.ApplicationDTO.ApplicationTypeID = 2; // renew
        baseApp.ApplicationDTO.CreatedByUserID = 1;   // Must be a valid User ID in your DB
        baseApp.ApplicationDTO.PaidFees = 15.00m;     // Match the fee for this application type


        bool baseSaved = baseApp.Save();
        Assert.IsTrue(baseSaved, "Failed to create the required base application. Error: " + baseApp.ApplicationDTO.LastValidationError);

        // 2. Instantiate the Local Driving License Application
        clsLocalDrivingLicensecs localApp = new clsLocalDrivingLicensecs();

        // 3. Harness the power of Object Composition! Bind the rich baseApp object directly
        localApp.ApplicationInfo = baseApp;


        // 4. Bind the License Class ID (e.g., Class 3 = Ordinary driving license)
        localApp.LocalDrivingLicensecsDTO.LicenseClassId = 3;

        // 5. Fire the Save pipeline
        bool localSaved = localApp.Save();

        // 6. Assertions & Console Outputs
        Assert.IsTrue(localSaved, "Failed to save the Local Driving License Application. Error: " + localApp.LocalDrivingLicensecsDTO.LastValidationError);
        Assert.IsTrue(localApp.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID > 0, "Expected a valid generated identity primary key.");

        Console.WriteLine($"Successfully linked Base App ID: {localApp.LocalDrivingLicensecsDTO.ApplicationID}");
        Console.WriteLine($"Generated Local Application ID: {localApp.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID}");


    }



    [TestMethod]
    public void Test3_UpdateRecord_ValidChange()
    {
        // 1. Fetch an existing target record (using 33 per your query)
        int appid = 33;
        clsLocalDrivingLicensecs app = clsLocalDrivingLicensecs.Find(appid);
        Assert.IsNotNull(app, "The application with the id " + appid + " was not found");

        // 2. Change the only allowed mutable property (e.g., update from Class 3 to Class 4)
        int targetLicenseClass = 4;
        app.LocalDrivingLicensecsDTO.LicenseClassId = targetLicenseClass;

        // 3. Commit update pipeline
        bool isUpdated = app.Save();

        // 4. Assert success and verify persistence
        Assert.IsTrue(isUpdated, "Failed to update record properties. Error: " + app.LocalDrivingLicensecsDTO.LastValidationError);

        // Refetch clean from database to prove it committed
        clsLocalDrivingLicensecs updatedSnapshot = clsLocalDrivingLicensecs.Find(appid);
        Assert.AreEqual(targetLicenseClass, updatedSnapshot.LocalDrivingLicensecsDTO.LicenseClassId, "LicenseClassId did not properly save changes to SQL Server.");
        Console.WriteLine($"Successfully updated Application {appid} to License Class {targetLicenseClass}");
    }

    [TestMethod]
    public void Test4_UpdateRecord_ShouldFailOnImmutableFieldChange()
    {
        // This explicitly tests that your guard clause kills unsafe field changes
        int appid = 33;
        clsLocalDrivingLicensecs app = clsLocalDrivingLicensecs.Find(appid);
        Assert.IsNotNull(app, "Target application not found.");

        // Force an invalid change: attempt to switch the static base application link
        int illegalBaseAppId = 9999;
        app.LocalDrivingLicensecsDTO.ApplicationID = illegalBaseAppId;

        // Commit update pipeline
        bool result = app.Save();

        // Assert that the domain rule caught it and BLOCKED it
        Assert.IsFalse(result, "Security vulnerability! The business layer allowed changing an immutable foreign key relation.");
        Assert.IsTrue(app.LocalDrivingLicensecsDTO.LastValidationError.Contains("prohibited"), "Validation failure reason was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully blocked data corruption attempt: " + app.LocalDrivingLicensecsDTO.LastValidationError);
    }

    [TestMethod]
    public void Test_UpdateLocalDrivingLicenseApplication_ShouldUpdateClassAndRecalculateTotalFees()
    {
       
        int localAppId = 30; // Existing Local Application ID
        int newLicenseClassId = 7; // Target new class ID (e.g., Heavy Vehicle)

        // 1. Fetch existing local application record
        clsLocalDrivingLicensecs localApp = clsLocalDrivingLicensecs.Find(localAppId);
        Assert.IsNotNull(localApp, "Test Setup Fail: Local Driving License Application record not found.");

        int baseAppId = localApp.LocalDrivingLicensecsDTO.ApplicationID;

        // 2. Look up target class fee and base application type fee for expectation calculation
        clsLicenseClass targetClass = clsLicenseClass.Find(newLicenseClassId);
        Assert.IsNotNull(targetClass, "Test Setup Fail: Target license class not found.");

        clsApplication OriginalApplicationBeforeTheUpdate = clsApplication.Find(baseAppId);
        Assert.IsNotNull(OriginalApplicationBeforeTheUpdate, "Test Setup Fail: Base application record not found.");

        clsApplicationTypes appType = clsApplicationTypes.Find(OriginalApplicationBeforeTheUpdate.ApplicationDTO.ApplicationTypeID);
        Assert.IsNotNull(appType, "Test Setup Fail: Application type record not found.");

        decimal expectedTotalFee = appType.DTO.ApplicationFees + targetClass.clsLicenseClassDTO.ClassFees;

        // Act
        localApp.LocalDrivingLicensecsDTO.LicenseClassId = newLicenseClassId;
        bool isSaved = localApp.Save(); // Calls _UpdateLocalDrivingLicenseApplication internally

        // Assert
        Assert.IsTrue(isSaved, "Failed to save updated local driving license application. Error: " + localApp.LocalDrivingLicensecsDTO.LastValidationError);

        // Verify Local Driving License Application record was updated in DB
        clsLocalDrivingLicensecs updatedLocalApp = clsLocalDrivingLicensecs.Find(localAppId);
        Assert.IsNotNull(updatedLocalApp, "Failed to fetch updated local application record.");
        Assert.AreEqual(newLicenseClassId, updatedLocalApp.LocalDrivingLicensecsDTO.LicenseClassId, "LicenseClassID was not updated in the database.");

        // Verify Base Application PaidFees was synchronized with sum of fees
        clsApplication updatedBaseApp = clsApplication.Find(baseAppId);
        Assert.IsNotNull(updatedBaseApp, "Failed to fetch updated base application record.");
        Assert.AreEqual(expectedTotalFee, updatedBaseApp.ApplicationDTO.PaidFees, "PaidFees was not accurately updated to match ApplicationTypeFee + NewClassFee.");

        Console.WriteLine($"Success: Local App ID {localAppId} updated to LicenseClassID {newLicenseClassId}.");
        Console.WriteLine($"Success: Base App ID {baseAppId} PaidFees synchronized to {updatedBaseApp.ApplicationDTO.PaidFees:C}.");
    }
    [TestMethod]
    public void Test5_GetAllRecords()
    {
        DataTable dt = clsLocalDrivingLicensecs.GetAllLocalDrivingLicenseApplications();

        Assert.IsNotNull(dt, "Data access returned a null reference datatable.");
        Console.WriteLine($"Total active data entries tracked: {dt.Rows.Count}");

        if (dt.Rows.Count > 0)
        {
            Console.WriteLine($"Top Row Sample ID: {dt.Rows[0]["LocalDrivingLicenseApplicationID"]}");
        }
    }


    [TestMethod]
    public void Test6_DeleteRecord()
    {
        clsLocalDrivingLicensecs cll = clsLocalDrivingLicensecs.Find(33);

        Assert.IsNotNull(cll, " Record was not found ");

        Console.WriteLine("Record was found ");

        bool IsDeleted = clsLocalDrivingLicensecs.Delete(cll.LocalDrivingLicensecsDTO.LocalDrivingLicenseApplicationID);

        Assert.IsTrue(IsDeleted, "Record was not deleted ");
        Console.WriteLine("The record was deleted");

    }
}

