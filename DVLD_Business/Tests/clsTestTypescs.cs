using System;
using System.Data;
using DVLD_DataAccess.Tests;

namespace DVLD_Business.Tests
{
    public class clsTestTypesDTO
    {
        public short TestTypeId { get; set; }
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

        public static clsTestTypes Find(short TestTypeId)
        {
            string Title = string.Empty;
            string Description = string.Empty;
            decimal Fees = 0;

            bool IsFound = clsTestTypeDataAccess.GetTestTypeInfoById(TestTypeId, ref Title, ref Description, ref Fees);

            if (IsFound)
            {
                // FIXED: Instantiate the actual DTO data carrier cleanly
                clsTestTypesDTO FilledDto = new clsTestTypesDTO
                {
                    TestTypeId = TestTypeId,
                    TestTypeTitle = Title, // FIXED: Added missing title mapping
                    TestTypeDescription = Description,
                    TestTypeFees = Fees
                };

                return new clsTestTypes(FilledDto);
            }

            return null;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeDataAccess.UpdateTestType(
                this.clsTestTypesDTO.TestTypeId,    
                this.clsTestTypesDTO.TestTypeTitle,
                this.clsTestTypesDTO.TestTypeDescription,
                this.clsTestTypesDTO.TestTypeFees
            );
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeDataAccess.GetAllTestTypes();
        }

        public bool Save()
        {
            // Since this is a system lookup table, we only allow updates to existing rows.
            return _UpdateTestType();
        }
    }
}