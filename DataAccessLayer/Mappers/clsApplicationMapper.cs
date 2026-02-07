using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public static class clsApplicationMapper
    {
        public static string MapSearchBy(clsApplicationEnums.enApplicationSearchBy value)
        {
            switch (value)
            {
                case clsApplicationEnums.enApplicationSearchBy.ApplicationID:
                    return "ApplicationID";

                case clsApplicationEnums.enApplicationSearchBy.ApplicantPersonID:
                    return "ApplicantPersonID";

                case clsApplicationEnums.enApplicationSearchBy.CreatedByUserID:
                    return "CreatedByUserID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string MapOrderBy(clsApplicationEnums.enApplicationOrderBy value)
        {
            switch (value)
            {
                case clsApplicationEnums.enApplicationOrderBy.ApplicationID:
                    return "ApplicationID";

                case clsApplicationEnums.enApplicationOrderBy.ApplicantPersonID:
                    return "ApplicantPersonID";

                case clsApplicationEnums.enApplicationOrderBy.ApplicationTypeID:
                    return "ApplicationTypeID";

                case clsApplicationEnums.enApplicationOrderBy.CreatedByUserID:
                    return "CreatedByUserID";

                case clsApplicationEnums.enApplicationOrderBy.ApplicationStatus:
                    return "ApplicationStatus";

                case clsApplicationEnums.enApplicationOrderBy.ApplicationDate:
                    return "ApplicationDate";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }


}
