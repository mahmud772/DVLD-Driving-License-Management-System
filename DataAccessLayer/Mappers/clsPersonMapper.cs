using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public static class clsPersonMapper
    {
        public static string MapSearchBy(clsPersonEnums.enPersonSearchBy value)
        {
            switch (value)
            {
                case clsPersonEnums.enPersonSearchBy.PersonID:
                    return "PersonID";

                case clsPersonEnums.enPersonSearchBy.NationalNo:
                    return "NationalNo";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string MapOrderBy(clsPersonEnums.enPersonOrderBy value)
        {
            switch (value)
            {
                case clsPersonEnums.enPersonOrderBy.PersonID:
                    return "PersonID";

                case clsPersonEnums.enPersonOrderBy.NationalNo:
                    return "NationalNo";

                case clsPersonEnums.enPersonOrderBy.FirstName:
                    return "FirstName";

                case clsPersonEnums.enPersonOrderBy.Gendor:
                    return "Gendor";

                case clsPersonEnums.enPersonOrderBy.NationalityCountryID:
                    return "NationalityCountryID";

                default:
                    return "PersonID";
                    //throw new ArgumentOutOfRangeException();
            }
        }
    }

}
