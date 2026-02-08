using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public class clsOrderDirectionMapper
    {
        public static string MapOrderDirection(clsOrderDirectionEnums.enOrderDirection By)
        {
            switch (By)
            {
                case clsOrderDirectionEnums.enOrderDirection.Desc:
                    return "Desc";
                case clsOrderDirectionEnums.enOrderDirection.Asc:
                    return "Asc";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
