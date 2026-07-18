using System.Data;
using DVLD_DataAccess.People;

namespace DVLD_Business.People
{
    public class clsCountryDTO
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }

    public class clsCountry
    {
        public clsCountryDTO DTO { get; set; }

        private clsCountry(clsCountryDTO filledDTO)
        {
            this.DTO = filledDTO;
        }

        public static clsCountry Find(int countryID)
        {
            string countryName = "";
            if (clsCountryDataAccess.GetCountryInfoByID(countryID, ref countryName))
            {
                return new clsCountry(new clsCountryDTO
                {
                    CountryID = countryID,
                    CountryName = countryName
                });
            }
            return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }
    }
}