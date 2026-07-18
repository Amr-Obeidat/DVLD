using DVLD_Business.People;
using System.Security.Cryptography.X509Certificates;

namespace DVLD_Tests_;
[TestClass]
public class CountryTestcs
{
    [TestMethod]
    public void Test1_FindCountry()
    {

        clsCountry country = clsCountry.Find(1);

        Assert.IsNotNull(country,"Country not found");

        Console.WriteLine("Country with the id "+country.DTO.CountryID+ " was found , the country name is "+country.DTO.CountryName);



    }
    [TestMethod]
    public void Test2_GetAllCountries()
    {
        var dtCountries = clsCountry.GetAllCountries();
        Assert.IsNotNull(dtCountries, "No countries found");
        Assert.IsTrue(dtCountries.Rows.Count > 0, "No countries found");
        Assert.IsTrue(dtCountries.Columns.Contains("CountryID"), "CountryID column not found"); 
        Assert.IsTrue(dtCountries.Columns.Contains("CountryName"), "CountryName column not found");
        Console.WriteLine("Total countries found: " + dtCountries.Rows.Count);
        
    }
}
