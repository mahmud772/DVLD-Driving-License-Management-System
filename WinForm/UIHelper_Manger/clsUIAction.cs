using DVLD_DTOs;
using System;
using static Common.clsUserEnums;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsUIAction
    {
        public clsUIEnums.enUIAction ActionType { get; set; }
        public Func<IDTO, bool> Execute { get; set; }
        public Func<IDTO, bool> CanExecute { get; set; }
        public enPermissions PermissionRequired { get; set; }
    }
}
