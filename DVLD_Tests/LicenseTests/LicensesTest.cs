using DVLD_Business.Licenses;
using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting; // or your test framework

namespace DVLD_Tests_.LicenseTests
{
    [TestClass]
    public class LicensesTest
    {
        [TestMethod]
        public void TestGetAllDriverLicenses()
        {
            // GetDriverLicenses is static, call it directly on the class
            DataTable dt = clsLicense.GetDriverLicenses(8);

            // Assert that it returns data (optional safety check)
            Assert.IsNotNull(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["ClassName"]);
            }
        }

        [TestMethod]

        public void  DeactivateLicense()
        {



            bool Isdeleted= clsLicense.DeactivateLicense(20);


            Assert.IsTrue(Isdeleted, "The License was not deleted");

        }
    }

}