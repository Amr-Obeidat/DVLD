namespace DVLD_Tests_;


using DVLD_Business.Tests;
using DVLD_Business.Tests.DVLD_Business.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

[TestClass]
public class TestsEvaluationTest
{
    [TestMethod]
    public void Test1_FindTestByID()
    {
        
        int testId = 32;
        clsTest evaluation = clsTest.Find(testId);

        Assert.IsNotNull(evaluation, $"Test evaluation record with ID {testId} was not found.");
        Console.WriteLine($"Test {testId} fetched successfully.");
        Console.WriteLine($"Linked to Appointment ID: {evaluation.TestDTO.TestAppointmentID}, Result: {(evaluation.TestDTO.TestResult ? "Pass" : "Fail")}, Notes: {evaluation.TestDTO.Notes}");
    }

    [TestMethod]
    public void Test2_AddNewTestResult_ShouldSucceedAndLockAppointment()
    {
        // IMPORTANT SETUP: For this test to pass, create or use an existing TestAppointment 
        // that is currently UNLOCKED (IsLocked = 0) and does NOT have a test row recorded yet.
        int targetAppointmentId = 72;

        
        clsTestAppointment targetAppointment = clsTestAppointment.Find(targetAppointmentId);
        Assert.IsNotNull(targetAppointment, "Prerequisite setup failed: Target appointment row does not exist.");
        Assert.IsFalse(targetAppointment.AppointmentDTO.IsLocked, "Prerequisite setup failed: Target appointment is already locked.");

        // 1. Instantiate the fresh test evaluation record
        clsTest newTest = new clsTest();
        newTest.TestDTO.TestAppointmentID = targetAppointmentId;
        newTest.TestDTO.TestResult = true; // 1 = Pass
        newTest.TestDTO.Notes = "Passed effortlessly. Excellent lane control.";
        newTest.TestDTO.CreatedByUserID = 1;

        // 2. Fire the Save pipeline (which executes the code side-effect)
        bool isSaved = newTest.Save();

        // 3. Assertions
        Assert.IsTrue(isSaved, "Failed to save the new test evaluation. Error: " + newTest.TestDTO.LastValidationError);
        Assert.IsTrue(newTest.TestDTO.TestID > 0, "Expected a valid generated TestID primary key.");

        // VERIFY THE LOCKDOWN SIDE EFFECT: Refetch the appointment clean from the database
        clsTestAppointment postTestAppointment = clsTestAppointment.Find(targetAppointmentId);
        Assert.IsTrue(postTestAppointment.AppointmentDTO.IsLocked, "Security Guard Defeated! Saving a test failed to automatically lock the corresponding appointment.");

        Console.WriteLine($"Successfully logged Test ID {newTest.TestDTO.TestID} for Appointment {targetAppointmentId}.");
        Console.WriteLine($"Verification Complete: Appointment status is now locked securely (IsLocked = {postTestAppointment.AppointmentDTO.IsLocked}).");
    }

    [TestMethod]
    public void Test3_AddNewTest_ShouldFailOnDuplicateEvaluation()
    {
        //  Appointment 65 already has a recorded test (TestID = 29)
        int alreadyEvaluatedAppointmentId = 65;

        clsTest duplicateAttempt = new clsTest();
        duplicateAttempt.TestDTO.TestAppointmentID = alreadyEvaluatedAppointmentId;
        duplicateAttempt.TestDTO.TestResult = false;
        duplicateAttempt.TestDTO.CreatedByUserID = 1;

        bool result = duplicateAttempt.Save();

        // Assert that the pipeline identified the pre-existing test and dropped execution safely
        Assert.IsFalse(result, "Security vulnerability! The system allowed submitting duplicate exam results for the same appointment ticket.");
        Assert.IsTrue(duplicateAttempt.TestDTO.LastValidationError.Contains("already been submitted"), "Validation error message was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully blocked duplicate exam injection: " + duplicateAttempt.TestDTO.LastValidationError);
    }

    [TestMethod]
    public void Test4_UpdateTest_ValidNotesChange()
    {

        int targetid = 32;
        clsTest Updated=clsTest.Find(targetid);


        Assert.IsNotNull(Updated, "The Record with  the Id " + Updated.TestDTO.TestID + "Was not found");

        Updated.TestDTO.Notes = "Extra Double Glasses";
     bool IsSaved=   Updated.Save();
        Assert.IsTrue(IsSaved, "The New Data Was nos saved properly" + Updated.TestDTO.LastValidationError);


        
    }

    [TestMethod]
    public void Test5_UpdateTest_ShouldFailOnStructuralLinkHijack()
    {
        int targetTestId = 32;
        clsTest evaluation = clsTest.Find(targetTestId);
        Assert.IsNotNull(evaluation, "Target test record not found.");

        // Force an invalid structural change: try to move this test over to a completely different appointment slot
        int illegalAppointmentId = 9999;
        evaluation.TestDTO.TestAppointmentID = illegalAppointmentId;

        // Commit update pipeline
        bool result = evaluation.Save();

        // Assert that the domain rule caught the structural mutation and killed it
        Assert.IsFalse(result, "Security vulnerability! The business layer allowed changing an immutable TestAppointmentID relation.");
        Assert.IsTrue(evaluation.TestDTO.LastValidationError.Contains("Structural alterations"), "Validation failure reason was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully blocked historical relationship hijack: " + evaluation.TestDTO.LastValidationError);
    }

    [TestMethod]
    public void Test6_GetAllTests()
    {
        DataTable dt = clsTest.GetAllTests();

        Assert.IsNotNull(dt, "Data access returned a null reference datatable.");
        Console.WriteLine($"Total historic tests evaluated in system: {dt.Rows.Count}");

        if (dt.Rows.Count > 0)
        {
            Console.WriteLine($"Top Row Sample Test ID: {dt.Rows[0]["TestID"]}, Result Code: {dt.Rows[0]["TestResult"]}");
        }
    }
}