using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public static class clsUserMapper
    {
        public static string MapSearchBy(clsUserEnums.enUserSearchBy value)
        {
            switch (value)
            {
                case clsUserEnums.enUserSearchBy.UserID:
                    return "UserID";

                case clsUserEnums.enUserSearchBy.UserName:
                    return "UserName";

                case clsUserEnums.enUserSearchBy.NationalNo:
                    return "NationalNo";

                case clsUserEnums.enUserSearchBy.PersonID:
                    return "PersonID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string MapOrderBy(clsUserEnums.enUserOrderBy value)
        {
            switch (value)
            {
                case clsUserEnums.enUserOrderBy.UserID:
                    return "UserID";

                case clsUserEnums.enUserOrderBy.UserName:
                    return "UserName";

                case clsUserEnums.enUserOrderBy.IsActive:
                    return "IsActive";

                case clsUserEnums.enUserOrderBy.NationalNo:
                    return "NationalNo";

                case clsUserEnums.enUserOrderBy.Gendor:
                    return "Gendor";

                case clsUserEnums.enUserOrderBy.NationalityCountryID:
                    return "NationalityCountryID";

                case clsUserEnums.enUserOrderBy.PersonID:
                    return "PersonID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
