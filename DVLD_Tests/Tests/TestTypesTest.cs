using Microsoft.VisualStudio.TestTools.UnitTesting;
using DVLD_Business.Tests;
using DVLD_DataAccess.Tests;
using System;
using System.Data;

namespace DVLD_Tests_
{
    [TestClass]
    public class TestTypesTest
    {
        [TestMethod]
        public void Test1_FindTestTypeInfo()
        {
            // Arrange
            clsTestTypesDTO.enTestType testType = clsTestTypesDTO.enTestType.VisionTest;

            // Act
            clsTestTypes testTypes = clsTestTypes.Find(testType);

            // Assert
            Assert.IsNotNull(testTypes, "Test Type was not found.");

            Assert.AreEqual(
                testType,
                testTypes.clsTestTypesDTO.TestTypeId,
                "The returned Test Type ID is incorrect."
            );

            Assert.IsFalse(
                string.IsNullOrEmpty(testTypes.clsTestTypesDTO.TestTypeTitle),
                "Test Type Title is empty."
            );

            Assert.IsFalse(
                string.IsNullOrEmpty(testTypes.clsTestTypesDTO.TestTypeDescription),
                "Test Type Description is empty."
            );

            Assert.IsTrue(
                testTypes.clsTestTypesDTO.TestTypeFees >= 0,
                "Test Type Fees cannot be negative."
            );

            Console.WriteLine(
                $"Test Type: {testTypes.clsTestTypesDTO.TestTypeTitle}"
            );

            Console.WriteLine(
                $"Fees: {testTypes.clsTestTypesDTO.TestTypeFees}"
            );
        }


        [TestMethod]
        public void Test2_GetAllTestTypes()
        {
            // Act
            DataTable dt = clsTestTypeDataAccess.GetAllTestTypes();

            // Assert
            Assert.IsNotNull(dt, "No Test Types table was returned.");

            Assert.IsTrue(
                dt.Rows.Count > 0,
                "No Test Type records were found."
            );

            Assert.IsTrue(
                dt.Columns.Contains("TestTypeID"),
                "TestTypeID column does not exist."
            );

            Assert.IsTrue(
                dt.Columns.Contains("TestTypeTitle"),
                "TestTypeTitle column does not exist."
            );

            Assert.IsTrue(
                dt.Columns.Contains("TestTypeDescription"),
                "TestTypeDescription column does not exist."
            );

            Assert.IsTrue(
                dt.Columns.Contains("TestTypeFees"),
                "TestTypeFees column does not exist."
            );

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(
                    $"Test Type ID: {row["TestTypeID"]}, " +
                    $"Title: {row["TestTypeTitle"]}, " +
                    $"Fees: {row["TestTypeFees"]}"
                );
            }
        }


        [TestMethod]
        public void Test3_UpdateTestFees()
        {
            // Arrange
            clsTestTypesDTO.enTestType testType =
                clsTestTypesDTO.enTestType.VisionTest;

            clsTestTypes testTypes = clsTestTypes.Find(testType);

            Assert.IsNotNull(
                testTypes,
                "Test Type was not found before updating."
            );

            decimal oldFees = testTypes.clsTestTypesDTO.TestTypeFees;

            decimal newFees = oldFees == 15 ? 20 : 15;

            testTypes.clsTestTypesDTO.TestTypeFees = newFees;

            // Act
            bool isSaved = testTypes.Save();

            // Assert
            Assert.IsTrue(
                isSaved,
                "The Test Type fees were not updated."
            );

            // Get the record again from the DATABASE
            clsTestTypes updatedTestType =
                clsTestTypes.Find(testType);

            Assert.IsNotNull(
                updatedTestType,
                "Test Type could not be found after updating."
            );

            Assert.AreEqual(
                newFees,
                updatedTestType.clsTestTypesDTO.TestTypeFees,
                "The updated fees were not saved to the database."
            );

            Console.WriteLine(
                $"Old Fees: {oldFees}"
            );

            Console.WriteLine(
                $"New Fees: {updatedTestType.clsTestTypesDTO.TestTypeFees}"
            );
        }
    }
}