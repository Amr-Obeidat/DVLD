using System;
using System.Data;
using DVLD_DataAccess.Tests;

namespace DVLD_Business.Tests
{
    public class clsTestTypesDTO
    {
       
        public enum enTestType
        {
            VisionTest = 1,
            WrittenTest = 2,
            RoadTest = 3
        }

   
        public enTestType TestTypeId { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
    }

    public class clsTestTypes
    {
        public clsTestTypesDTO clsTestTypesDTO { get; set; }

        private clsTestTypes(clsTestTypesDTO FilledDTO)
        {
            this.clsTestTypesDTO = FilledDTO;
        }

        public clsTestTypes()
        {
            this.clsTestTypesDTO = new clsTestTypesDTO();
        }

        public static clsTestTypes Find(clsTestTypesDTO.enTestType TestTypeID)
        {
            string Title = string.Empty;
            string Description = string.Empty;
            decimal Fees = 0;

            bool IsFound = clsTestTypeDataAccess.GetTestTypeInfoById(
                (short)TestTypeID,
                ref Title,
                ref Description,
                ref Fees
            );

            if (IsFound)
            {
                clsTestTypesDTO FilledDto = new clsTestTypesDTO
                {
                    TestTypeId = TestTypeID,
                    TestTypeTitle = Title,
                    TestTypeDescription = Description,
                    TestTypeFees = Fees
                };

                return new clsTestTypes(FilledDto);
            }

            return null;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeDataAccess.UpdateTestfees(
                (short)this.clsTestTypesDTO.TestTypeId,
                this.clsTestTypesDTO.TestTypeFees
            );
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeDataAccess.GetAllTestTypes();
        }

        public bool Save()
        {
            return _UpdateTestType();
        }
    }
}