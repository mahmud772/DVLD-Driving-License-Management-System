using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsUIActionsManager
    {
        public List<clsUIAction> Actions = new List<clsUIAction>();
        public void Reset()
        {
            Actions.Clear();
        }
        public void Register(clsUIAction action)
        {
            Actions.Add(action);
        }
        public void Execute(clsUIEnums.enUIAction ActionType, IDTO dto , Action<bool> Refresh)
        {
            clsUIAction action = Actions.FirstOrDefault(a => a.ActionType == ActionType);

            if (action == null) return;
            if (!clsUser_BLL.CheckAccessPermission(clsCurrentUser.User.Permissions 
                , action.PermissionRequired)) return;

            if (action.CanExecute == null || action.CanExecute(dto))
                Refresh?.Invoke(action.Execute(dto));
        }

        
        
    }
}
