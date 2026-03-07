using DVLD_DTOs;
using System;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsUIAction
    {
        public clsUIEnums.enUIAction ActionType { get; set; }
        public Func<IDTO, bool> Execute { get; set; }
        public Func<IDTO, bool> CanExecute { get; set; }
    }
}
