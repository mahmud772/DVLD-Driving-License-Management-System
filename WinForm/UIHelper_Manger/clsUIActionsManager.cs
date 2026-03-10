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
            var action = Actions.FirstOrDefault(a => a.ActionType == ActionType);

            if (action == null) return;

            if (action.CanExecute == null || action.CanExecute(dto))
                Refresh?.Invoke(action.Execute(dto));
        }
        public void RegisterDelete(Func<int, bool> deleteFunc)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Delete,
                Execute = dto =>
                {
                    if (MessageBox.Show("Are you sure?", "Warning",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        return false;
                    return deleteFunc?.Invoke(dto.ID) != null;
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
                    if (createForm == null) return false;

                    return createForm.Invoke()?.ShowDialog() == DialogResult.OK;
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
                    if (updateForm == null) return false;
                    return updateForm.Invoke(dto).ShowDialog() == DialogResult.OK;
                     
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

                    if (filterForm == null) return false;

                    return filterForm.Invoke().ShowDialog() == DialogResult.OK;
                }
            });
        }
        //public void RegisterPassedTest(Func<Form> filterForm)
        //{
        //    Register(new clsUIAction
        //    {
        //        ActionType = clsUIEnums.enUIAction.PassedTest,
        //        Execute = dto =>
        //        {
                    
        //        }
        //    });
        //}
        
    }
}
