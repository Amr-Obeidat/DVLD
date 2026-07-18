namespace DVLD_Tests_;

using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DVLD_Business.Drivers;

[TestClass]
public class DriverTest
{
    [TestMethod]
    public void Test1_FindDriverByID()
    {
        // Use a known existing Driver ID from your database (e.g., 8 or 9)
        int driverId = 8;
        clsDriver driver = clsDriver.Find(driverId);

        Assert.IsNotNull(driver, $"Driver with ID {driverId} was not found.");
        Console.WriteLine($"Driver {driverId} found successfully. Linked to Person ID: {driver.DriverDTO.PersonID}");
    }

    [TestMethod]
    public void Test2_FindDriverByPersonID()
    {
        // Use a known Person ID that is already a driver (e.g., 1 or 1025)
        int personId = 1025;
        clsDriver driver = clsDriver.FindByPersonID(personId);

        Assert.IsNotNull(driver, $"Driver linked to Person ID {personId} was not found.");
        Console.WriteLine($"Driver record fetched via Person ID {personId}. Assigned Driver ID: {driver.DriverDTO.DriverID}");
    }

    [TestMethod]
    public void Test3_AddNewDriver_Success()
    {
        // IMPORTANT: Change this to a valid Person ID in your DB that is NOT YET a driver!
        int unlinkedPersonId = 1023;

        clsDriver newDriver = new clsDriver();
        newDriver.DriverDTO.PersonID = unlinkedPersonId;
        newDriver.DriverDTO.CreatedByUserID = 1;
        newDriver.DriverDTO.CreatedDate = DateTime.Now;

        bool isSaved = newDriver.Save();

        Assert.IsTrue(isSaved, "Failed to create a new driver. Error: " + newDriver.DriverDTO.LastValidationError);
        Assert.IsTrue(newDriver.DriverDTO.DriverID > 0, "Expected a valid generated DriverID primary key.");

        Console.WriteLine($"Successfully registered Person {unlinkedPersonId} as a new Driver.");
        Console.WriteLine($"Generated Driver ID: {newDriver.DriverDTO.DriverID}");
    }

    [TestMethod]
    public void Test4_AddNewDriver_ShouldFailOnDuplicatePerson()
    {
        // Use a Person ID that already has a driver record (e.g., 1025)
        int alreadyDriverPersonId = 1023;

        clsDriver duplicateAttempt = new clsDriver();
        duplicateAttempt.DriverDTO.PersonID = alreadyDriverPersonId;
        duplicateAttempt.DriverDTO.CreatedByUserID = 1;

        bool result = duplicateAttempt.Save();

        // Assert that the domain rule caught the duplicate and BLOCKED it
        Assert.IsFalse(result, "Security vulnerability! The system allowed a person to register as a driver twice.");
        Assert.IsTrue(duplicateAttempt.DriverDTO.LastValidationError.Contains("Already Exists"), "Duplicate validation reason was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully blocked duplicate registration: " + duplicateAttempt.DriverDTO.LastValidationError);
    }

    [TestMethod]
    public void Test5_UpdateDriver_ValidChange()
    {
        // Fetch an existing target record
        int targetDriverId = 10;
        clsDriver driver = clsDriver.Find(targetDriverId);
        Assert.IsNotNull(driver, "Target driver not found.");

        // Change an allowed mutable property
        int newUserId = 15; // Assuming User 15 exists
        driver.DriverDTO.CreatedByUserID = newUserId;

        // Commit update pipeline
        bool isUpdated = driver.Save();

        // Assert success and verify persistence
        Assert.IsTrue(isUpdated, "Failed to update driver properties. Error: " + driver.DriverDTO.LastValidationError);

        // Refetch clean from database to prove it committed
        clsDriver updatedSnapshot = clsDriver.Find(targetDriverId);
        Assert.AreEqual(newUserId, updatedSnapshot.DriverDTO.CreatedByUserID, "CreatedByUserID did not properly save changes to SQL Server.");
        Console.WriteLine($"Successfully updated Driver {targetDriverId} to track CreatedByUserID {newUserId}");
    }

    [TestMethod]
    public void Test6_UpdateDriver_ShouldFailOnImmutableFieldChange()
    {
        // This tests that your Gate 3 explicitly kills identity hijack attempts
        int targetDriverId = 9;
        clsDriver driver = clsDriver.Find(targetDriverId);
        Assert.IsNotNull(driver, "Target driver not found.");

        // Force an invalid change: attempt to switch the static base PersonID link
        int illegalPersonId = 9999;
        driver.DriverDTO.PersonID = illegalPersonId;

        // Commit update pipeline
        bool result = driver.Save();

        // Assert that the domain rule caught it and BLOCKED it
        Assert.IsFalse(result, "Security vulnerability! The business layer allowed changing an immutable PersonID relation.");
        Assert.IsTrue(driver.DriverDTO.LastValidationError.Contains("strictly prohibited"), "Validation failure reason was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully blocked identity tamper attempt: " + driver.DriverDTO.LastValidationError);
    }

    [TestMethod]
    public void Test7_GetAllDrivers()
    {
        DataTable dt = clsDriver.GetAllDrivers();

        Assert.IsNotNull(dt, "Data access returned a null reference datatable.");
        Console.WriteLine($"Total active drivers tracked: {dt.Rows.Count}");

        if (dt.Rows.Count > 0)
        {
            Console.WriteLine($"Top Row Sample Driver ID: {dt.Rows[0]["DriverID"]}");
        }
    }

    [TestMethod]
    public void Test8_DeleteDriver()
    {
        // 1. Create a sacrificial driver to test deletion safely
        int testPersonId = 1027; // Must be a valid Person without a driver record yet
        clsDriver tempDriver = new clsDriver();
        tempDriver.DriverDTO.PersonID = testPersonId;
        tempDriver.DriverDTO.CreatedByUserID = 1;
        tempDriver.Save();

        int targetDeleteId = tempDriver.DriverDTO.DriverID;
        Assert.IsTrue(targetDeleteId > 0, "Failed to instantiate dummy entity tracking target.");

        // 2. Execute static deletion call
        bool isDeleted = clsDriver.Delete(targetDeleteId);

        // 3. Assert record is wiped completely out of memory/storage pipelines
        Assert.IsTrue(isDeleted, $"Failed to remove record referencing key target {targetDeleteId}");
        Assert.IsNull(clsDriver.Find(targetDeleteId), "Verification step failed: record still fetched via Find pipeline after deletion.");
        Console.WriteLine($"Driver Record ID {targetDeleteId} purged safely from tracking index.");
    }
}