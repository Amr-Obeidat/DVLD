using DVLD_Business.Tests;
using System;
using System.Data;

namespace DVLD_Tests_;

[TestClass]
public class TestAppointmentsTestcs
{
    [TestMethod]
    public void Test1_FindAppointmentByID()
    {
        // Use a known existing Test Appointment ID from your database snapshot (e.g., 65 or 66)
        int appointmentId = 65;
        clsTestAppointment appointment = clsTestAppointment.Find(appointmentId);

        Assert.IsNotNull(appointment, $"Test Appointment with ID {appointmentId} was not found.");
        Console.WriteLine($"Appointment {appointmentId} found successfully.");
        Console.WriteLine($"Linked to Local App ID: {appointment.AppointmentDTO.LocalDrivingLicenseApplicationID}, Test Type ID: {appointment.AppointmentDTO.TestTypeID}");
    }

    [TestMethod]
    public void Test2_AddNewAppointment_Success()
    {
        // IMPORTANT: Use a Local Driving License Application ID that does NOT have an open/active appointment for Test Type 1
        int targetLocalAppId = 32;
        int testTypeId = 1; // E.g., Vision Test

        clsTestAppointment newAppointment = new clsTestAppointment();
        newAppointment.AppointmentDTO.LocalDrivingLicenseApplicationID = targetLocalAppId;
        newAppointment.AppointmentDTO.TestTypeID = testTypeId;
        newAppointment.AppointmentDTO.AppointmentDate = DateTime.Now.AddDays(2); // Scheduled for 2 days from now
        newAppointment.AppointmentDTO.PaidFees = 10.00m;
        newAppointment.AppointmentDTO.CreatedByUserID = 1;
        newAppointment.AppointmentDTO.IsLocked = false; // Starts open/active

        bool isSaved = newAppointment.Save();

        Assert.IsTrue(isSaved, "Failed to create a new test appointment. Error: " + newAppointment.AppointmentDTO.LastValidationError);
        Assert.IsTrue(newAppointment.AppointmentDTO.TestAppointmentID > 0, "Expected a valid generated TestAppointmentID primary key.");

        Console.WriteLine($"Successfully booked a new test appointment. Generated ID: {newAppointment.AppointmentDTO.TestAppointmentID}");
    }

    [TestMethod]
    public void Test3_AddNewAppointment_ShouldFailOnActiveOpenAppointment()
    {
        // Based on your database data, Local Application 30 already has an acive/open appointment (IsLocked = 0)
        // If we try to add another one for the same Application and Test Type, it must fail.
        int activeLocalAppId = 30;
        int testTypeId = 1;

        clsTestAppointment duplicateAttempt = new clsTestAppointment();
        duplicateAttempt.AppointmentDTO.LocalDrivingLicenseApplicationID = activeLocalAppId;
        duplicateAttempt.AppointmentDTO.TestTypeID = testTypeId;
        duplicateAttempt.AppointmentDTO.CreatedByUserID = 1;
        duplicateAttempt.AppointmentDTO.PaidFees = 10.00m;
        duplicateAttempt.AppointmentDTO.IsLocked = false;

        bool result = duplicateAttempt.Save();

        // Assert that the pipeline identified the open appointment and dropped execution safely
        Assert.IsFalse(result, "Security vulnerability! The system allowed booking an appointment while an active one is pending.");
        Assert.IsTrue(duplicateAttempt.AppointmentDTO.LastValidationError.Contains("already has an active open appointment"), "Validation error message was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully blocked scheduling conflict: " + duplicateAttempt.AppointmentDTO.LastValidationError);
    }

    [TestMethod]
    public void Test4_UpdateAppointment_ValidDateChange()
    {
        // Fetch an existing unlocked target record from your system
        // Make sure this ID points to a record where IsLocked = 0 in your DB to allow updates
        int targetAppointmentId = 73;
        clsTestAppointment appointment = clsTestAppointment.Find(targetAppointmentId);
        Assert.IsNotNull(appointment, "Target appointment not found.");
        Assert.IsFalse(appointment.AppointmentDTO.IsLocked, "Test setup error: This test requires an unlocked appointment.");

        // Change an allowed mutable property (rescheduling the date)
        DateTime newScheduledDate = DateTime.Now.AddDays(5);
        appointment.AppointmentDTO.AppointmentDate = newScheduledDate;

        // Commit update pipeline
        bool isUpdated = appointment.Save();

        // Assert success and verify persistence
        Assert.IsTrue(isUpdated, "Failed to update appointment details. Error: " + appointment.AppointmentDTO.LastValidationError);

        // Refetch clean from database to check changes
        clsTestAppointment updatedSnapshot = clsTestAppointment.Find(targetAppointmentId);
        Assert.AreEqual(newScheduledDate.Date, updatedSnapshot.AppointmentDTO.AppointmentDate.Date, "AppointmentDate did not properly persist to database.");
        Console.WriteLine($"Successfully rescheduled Unlocked Appointment {targetAppointmentId} to {newScheduledDate.ToShortDateString()}");
    }

    [TestMethod]
    public void Test5_UpdateAppointment_ShouldFailOnLockedRecord()
    {
        // Fetch a historically locked record (e.g., ID 65 has IsLocked = 1)
        int lockedAppointmentId = 65;
        clsTestAppointment appointment = clsTestAppointment.Find(lockedAppointmentId);
        Assert.IsNotNull(appointment, "Target locked appointment not found.");
        Assert.IsTrue(appointment.AppointmentDTO.IsLocked, "Test setup error: This record must be locked.");

        // Try to reschedule a completed test
        appointment.AppointmentDTO.AppointmentDate = DateTime.Now.AddDays(10);

        // Commit update pipeline
        bool result = appointment.Save();

        // Assert that the pipeline blocked modifications to completed test histories
        Assert.IsFalse(result, "Security vulnerability! The system allowed editing a locked historical test record.");
        Assert.IsTrue(appointment.AppointmentDTO.LastValidationError.Contains("strictly prohibited on locked"), "Validation failure reason was not tracked correctly.");
        Console.WriteLine("Guard Clause successfully protected historical integrity: " + appointment.AppointmentDTO.LastValidationError);
    }

    [TestMethod]
    public void Test6_UpdateAppointment_ShouldFailOnApplicationLinkHijack()
    {
        // Fetch an active unlocked record
        int targetAppointmentId = 72;
        clsTestAppointment appointment = clsTestAppointment.Find(targetAppointmentId);
        Assert.IsNotNull(appointment, "Target appointment not found.");

        // Force an invalid change: attempt to switch the static base application link to another application
        int illegalAppId = 9999;
        appointment.AppointmentDTO.LocalDrivingLicenseApplicationID = illegalAppId;

        // Commit update pipeline
        bool result = appointment.Save();

        // Assert that the pipeline blocked changing an unchangeable identity tracking link
        Assert.IsFalse(result, "Security vulnerability! The system allowed changing the base Application ID reference.");
        Assert.IsTrue(appointment.AppointmentDTO.LastValidationError.Contains("Validation Fail: Modifying the base LocalDrivingLicenseApplicationID link on active appointments is strictly prohibited."), "Validation failure reason was not caught."+"the last v was"+appointment.AppointmentDTO.LastValidationError);
        Console.WriteLine("Guard Clause successfully blocked pointer tamper attempt: " + appointment.AppointmentDTO.LastValidationError);
    }

    [TestMethod]
    public void Test7_GetApplicationAppointmentsPerTestType()
    {
        // Read historical listings for Application 31, Test Type 2 (Vision/Theory/Practical)
        int appId = 31;
        int testTypeId = 2;

        DataTable dt = clsTestAppointment.GetApplicationAppointmentsPerTestType(appId, testTypeId);

        Assert.IsNotNull(dt, "Data access returned a null reference datatable.");
        Console.WriteLine($"Total appointments tracked for App {appId} under Test Type {testTypeId}: {dt.Rows.Count}");

        if (dt.Rows.Count > 0)
        {
            // From your image data, rows should contain appointments like ID 69, 70, etc.
            Console.WriteLine($"Top Row Captured Appointment ID: {dt.Rows[0]["TestAppointmentID"]}");
            Console.WriteLine($"IsLocked Status: {dt.Rows[0]["IsLocked"]}");
        }
    }
}
