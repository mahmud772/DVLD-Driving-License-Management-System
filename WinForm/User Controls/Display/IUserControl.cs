using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.Forms
{
    public interface IUserControl
    {
        IDTO Info { get; set; }
    }
}
