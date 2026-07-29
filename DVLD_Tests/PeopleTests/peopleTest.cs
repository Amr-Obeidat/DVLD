using Microsoft.VisualStudio.TestTools.UnitTesting;
using DVLD_Business.People;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using DVLD_DataAccess.People;
namespace DVLD_Tests_.PeopleTests
{
    [TestClass]
    public sealed class peopleTest 
    {
        // 1. TEST FIND BY NATIONAL NO
        [TestMethod]
        public void Test2_FindByNationalNo()
        {
            // Use the NationalNo of your existing record (ID 1)
            string targetNationalNo = "N101"; // <-- Change this to Mohammed's actual NationalNo from DB

            clsPerson person = clsPerson.Find(targetNationalNo);

            Assert.IsNotNull(person, $"Fail: Person with NationalNo '{targetNationalNo}' not found.");

            Console.WriteLine($"[SUCCESS - FIND BY NATIONAL NO]");
            Console.WriteLine($"Name: {person.PersonDTO.FirstName} {person.PersonDTO.LastName}");
        }

        [TestMethod]
        public void Test3_AddNewPerson()
        {
            clsPerson newPerson = new clsPerson();

            string uniqueNationalNo = "T" + new Random().Next(1000, 9999).ToString();

            newPerson.PersonDTO.NationalNo = uniqueNationalNo;
            newPerson.PersonDTO.FirstName = "TestCoder";
            newPerson.PersonDTO.SecondName = "Automated";
            newPerson.PersonDTO.ThirdName = "";
            newPerson.PersonDTO.LastName = "Runner";
            newPerson.PersonDTO.DateOfBirth = new DateTime(2000, 1, 1);
            newPerson.PersonDTO.Gender = 'M';
            newPerson.PersonDTO.Phone = "0790000000";
            newPerson.PersonDTO.Email = "test@runner.com";
            newPerson.PersonDTO.NationalityCountryID = 1; // Ensure Country ID 1 exists!
            newPerson.PersonDTO.Address = "Test Suite Street";
            newPerson.PersonDTO.ImagePath = "";

            bool saveResult = newPerson.Save();
            Assert.IsTrue(saveResult, "Fail: New person could not be saved.");
            Assert.IsTrue(newPerson.PersonDTO.PersonID > 0, "Fail: New person ID was not set after save.");
            Console.WriteLine($"[SUCCESS - INSERT NEW RECORD]");
            Console.WriteLine($"Generated New Person ID: {newPerson.PersonDTO.PersonID}");
        }


        [TestMethod]

        public void Test4_UpdatePerson()
        {

            string targetNationalNo = "N101";
            clsPerson personToUpdate = clsPerson.Find(targetNationalNo);
            Assert.IsNotNull(personToUpdate, $"Fail: Person with NationalNo '{targetNationalNo}' not found for update.");
            // Update some fields
            personToUpdate.PersonDTO.FirstName = "UpdatedFirstName";
            personToUpdate.PersonDTO.SecondName = "UpdatedSecondName";
            personToUpdate.PersonDTO.LastName = "UpdatedLastName";
            bool updateResult = personToUpdate.Save();
            Assert.IsTrue(updateResult, "Fail: Person update failed.");
            Console.WriteLine($"[SUCCESS - UPDATE RECORD]");
            Console.WriteLine($"Updated Name: {personToUpdate.PersonDTO.FirstName} {personToUpdate.PersonDTO.SecondName} {personToUpdate.PersonDTO.LastName}");
        }
      //  [TestMethod]
        //public void Test5_DeletePerson()
        //{
        //    string targetNp = "T4324";
        //    clsPerson person = clsPerson.Find(targetNp);


        //    Assert.IsNotNull(person, $"Setup Fail: Person with NationalNo '{targetNp}' wasn't found in the DB to begin with.");
        //    int targetId = person.DTO.PersonID;


        //    bool deleteResult = clsPerson.DeletePerson(targetId);


        //    Assert.IsTrue(deleteResult, "Fail: Database engine reported that no rows were deleted.");


        //    clsPerson freshlySearchedPerson = clsPerson.Find(targetId);
        //    Assert.IsNull(freshlySearchedPerson, $"Fail: Person with NationalNo '{targetNp}' still exists in the database after deletion!");


        //}
    
    [TestMethod]
        public void Test6_GetAllPeople()
        {
            System.Data.DataTable dtAllPeople = clsPerson.GetAllPeople();

            // Assert 1: Make sure the object isn't null (proves the adapter filled successfully)
            Assert.IsNotNull(dtAllPeople, "Fail: GetAllPeople returned a null DataTable object reference.");

            // Assert 2: Verify there is actually data rows inside (proves your database isn't empty)
            Assert.IsTrue(dtAllPeople.Rows.Count > 0, "Fail: The People table came back completely empty.");

            // Assert 3: Column Sanity Check (Verifies core schema mapping didn't break)
            Assert.IsTrue(dtAllPeople.Columns.Contains("PersonID"), "Fail: Table schema is missing 'PersonID' column.");
            Assert.IsTrue(dtAllPeople.Columns.Contains("NationalNo"), "Fail: Table schema is missing 'NationalNo' column.");
            Assert.IsTrue(dtAllPeople.Columns.Contains("FirstName"), "Fail: Table schema is missing 'FirstName' column.");

            // Standard Output logs for your Test Explorer view
            Console.WriteLine($"[SUCCESS - FETCHED ALL PEOPLE]");
            Console.WriteLine($"Total Rows Found: {dtAllPeople.Rows.Count}");
            Console.WriteLine("Columns Verified: OK");


            foreach (DataRow row in dtAllPeople.Rows)
            {
                Console.WriteLine(
                    $"ID: {row["PersonID"]} | " +
                    $"National No: {row["NationalNo"]} | " +
                    $"Name: {row["FirstName"]} {row["SecondName"]} {row["ThirdName"]} {row["LastName"]} | " +
                    $"Gender: {row["GenderCaption"]} | " +
                    $"Email: {(string.IsNullOrEmpty(row["Email"].ToString()) ? "[N/A]" : row["Email"])} | " +
                    $"Image: {(string.IsNullOrEmpty(row["ImagePath"].ToString()) ? "[No Image]" : row["ImagePath"])}"
                );
            }
        }
    }
}
