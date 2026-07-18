using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DVLD_DataAccess.Applications;
namespace DVLD_Business.Applications
{

    public class clsApplicationTypeDTO
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }
    }
    public class clsApplicationTypes
    {

        public clsApplicationTypeDTO DTO { get; set; }
        public clsApplicationTypes()
        {
            this.DTO = new clsApplicationTypeDTO();
        }
        private clsApplicationTypes(clsApplicationTypeDTO FilledDTO)
        {
            this.DTO = FilledDTO;
        }
        
        public static clsApplicationTypes Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = 0.0m;
            bool IsFound = clsApplicationTypeDataAccess.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees);
            if (IsFound)
            {
                clsApplicationTypeDTO dto = new clsApplicationTypeDTO
                {
                    ApplicationTypeID = ApplicationTypeID,
                    ApplicationTypeTitle = ApplicationTypeTitle,
                    ApplicationFees = ApplicationFees
                };
                return new clsApplicationTypes(dto);
            }
            return null;
        }


        public static DataTable GetAllApplicationTypes()
        {

     

            return clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }

        private bool _Update()
        {
            return clsApplicationTypeDataAccess.UpdateApplicationTypeInfo(this.DTO.ApplicationTypeID, this.DTO.ApplicationTypeTitle, this.DTO.ApplicationFees);
        }
       public  bool  Save()
        {
            return _Update();
        }
    }
}