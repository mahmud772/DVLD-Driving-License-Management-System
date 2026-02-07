using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public static class clsDriverMapper
    {
        public static string MapSearchBy(clsDriverEnums.enDriverSearchBy value)
        {
            switch (value)
            {
                case clsDriverEnums.enDriverSearchBy.DriverID:
                    return "DriverID";

                case clsDriverEnums.enDriverSearchBy.CreatedByUserID:
                    return "CreatedByUserID";

                case clsDriverEnums.enDriverSearchBy.PersonID:
                    return "PersonID";

                case clsDriverEnums.enDriverSearchBy.NationalNo:
                    return "NationalNo";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string MapOrderBy(clsDriverEnums.enDriverOrderBy value)
        {
            switch (value)
            {
                case clsDriverEnums.enDriverOrderBy.DriverID:
                    return "DriverID";

                case clsDriverEnums.enDriverOrderBy.CreatedByUserID:
                    return "CreatedByUserID";

                case clsDriverEnums.enDriverOrderBy.PersonID:
                    return "PersonID";

                case clsDriverEnums.enDriverOrderBy.NationalNo:
                    return "NationalNo";

                case clsDriverEnums.enDriverOrderBy.Gendor:
                    return "Gendor";

                case clsDriverEnums.enDriverOrderBy.NationalityCountryID:
                    return "NationalityCountryID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
