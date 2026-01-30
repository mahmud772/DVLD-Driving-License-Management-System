using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public interface IBLL
    {
        IDTO DTO { get; set; }
        bool Save();
    }
}
