using DVLD_DTOs;
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
        public void Execute(clsUIEnums.enUIAction ActionType, IDTO dto)
        {
            var action = Actions.FirstOrDefault(a => a.ActionType == ActionType);

            if (action == null) return;

            if (action.CanExecute == null || action.CanExecute(dto))
                action.Execute(dto);
        }
        public void RegisterDelete(Func<int, bool> deleteFunc)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Delete,
                Execute = dto =>
                {
                    return deleteFunc(dto.ID);
                },
                CanExecute = dto => dto != null
            });
        }

        public void RegisterCreate(Func<Form> createForm)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.AddNew,
                Execute = dto =>
                {
                    createForm().ShowDialog();
                    return true;
                }
            });
        }

        public void RegisterUpdate(Func<IDTO, Form> updateForm)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Update,
                Execute = dto =>
                {
                    updateForm(dto).ShowDialog();
                    return true;
                },
                CanExecute = dto => dto != null
            });
        }

        public void RegisterFilter(Func<Form> filterForm)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Filter,
                Execute = dto =>
                {
                    filterForm().ShowDialog();
                    return true;
                }
            });
        }
        
    }
}
