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

        public void RegisterCreate(Func<IForm> createForm)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.AddNew,
                Execute = dto =>
                {
                    if (createForm == null) return false;

                    IForm form = createForm.Invoke();

                    Form frm = form as Form;
                    frm.ShowDialog();

                    return form.IsChange;
                }
            });
        }

        public void RegisterUpdate(Func<IDTO, IForm> updateForm)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Update,
                Execute = dto =>
                {
                    if (updateForm == null) return false;

                    IForm form = updateForm.Invoke(dto);

                    Form frm = form as Form;
                    frm.ShowDialog();

                    return form.IsChange;
                },
                CanExecute = dto => dto != null
            });
        }

        public void RegisterFilter(Func<IForm> filterForm)
        {
            Register(new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Filter,
                Execute = dto =>
                {
                    if (filterForm == null) return false;

                    IForm form = filterForm.Invoke();

                    Form frm = form as Form;
                    frm.ShowDialog();

                    return form.IsChange;
                }
            });
        }
        
    }
}
