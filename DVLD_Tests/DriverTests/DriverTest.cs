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

     
        Assert.IsFalse(result, "Security vulnerability! The system allowed a person to register as a driver twice.");
        Assert.IsTrue(duplicateAttempt.DriverDTO.LastValidationError.Contains("Already Exists"), "Duplicate validation reason was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully blocked duplicate registration: " + duplicateAttempt.DriverDTO.LastValidationError);
    }


    [TestMethod]
    public void Test5_TryToUpdateDriverRecord_ShouldFailRecordsCantBeUpdated()
    {

       
        clsDriver driver = clsDriver.Find(8);
        Assert.IsNotNull(driver, "Test Setup Fail: Driver record with ID 8 was not found.");

       
        driver.DriverDTO.CreatedByUserID = 4;

      
        bool isSaved = driver.Save();

      
        Assert.IsFalse(isSaved, "Security Violation: Driver update was allowed, but Driver records must be strictly immutable!");

    
        string expectedError = "Validation Fail: Driver records are historical immutable entities and cannot be modified.";
        Assert.AreEqual(expectedError, driver.DriverDTO.LastValidationError, "The expected immutability error message was not set on the DTO.");

        Console.WriteLine("Success: Guardrail cleanly blocked Driver record modification.");
        Console.WriteLine($"Logged Validation Error: \"{driver.DriverDTO.LastValidationError}\"");


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