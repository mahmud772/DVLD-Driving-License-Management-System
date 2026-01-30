using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public static class clsStaticData_BLL
    {
        

        public static List<clsTestType_DTO> TestTypes;
        public static List<clsApplicationType_DTO> ApplicationTypes;
        public static List<clsLicenseClass_DTO> LicenseClasses;
        public static List<clsCountry_DTO> Countries;


        public static void LoadAllStaticData()
        {
            TestTypes = clsTestType_BLL.GetAllTestTypes();
            ApplicationTypes = clsApplicationType_BLL.GetAllApplicationTypes();
            LicenseClasses = clsLicenseClass_BLL.GetAllLicenseClasses();
            Countries = clsCountry_BLL.GetAllCountries();
        }
    }
}
