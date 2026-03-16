using Common;
using DVLD_BLL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    public static class clsUIActionService
    {
        public static clsUIAction Delete(Func<int, bool> deleteFunc 
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
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
                ,
                PermissionRequired = permissions
            };
        }

        public static clsUIAction Create(Func<Form> createForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.AddNew,
                Execute = dto =>
                {
                    if (createForm == null) return false;

                    return createForm?.Invoke()?.ShowDialog() == DialogResult.OK;
                },
                PermissionRequired = permissions
            };
        }

        public static clsUIAction Update(Func<IDTO, Form> updateForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Update,
                Execute = dto =>
                {
                    if (updateForm == null) return false;
                    return updateForm?.Invoke(dto)?.ShowDialog() == DialogResult.OK;

                },
                CanExecute = dto => dto != null
                ,
                PermissionRequired = permissions
            };
        }

        public static clsUIAction Filter(Func<Form> filterForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Filter,
                Execute = dto =>
                {

                    if (filterForm == null) return false;

                    return filterForm?.Invoke()?.ShowDialog() == DialogResult.OK;
                }
                ,
                PermissionRequired = clsUserEnums.enPermissions.None
            };
        }
        public static clsUIAction AssignAsDriver(Func<IDTO, Form> AddDriverForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.AssignAsDriver,
                Execute = dto =>
                {

                    if (AddDriverForm == null) return false;

                    return AddDriverForm?.Invoke(dto)?.ShowDialog() == DialogResult.OK;
                },
                CanExecute = dto => dto != null
                ,
                PermissionRequired = permissions
            };
        }
        public static clsUIAction AssignAsUser(Func<IDTO, Form> AddUserForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.AssignAsUser,
                Execute = dto =>
                {

                    if (AddUserForm == null) return false;

                    return AddUserForm?.Invoke(dto)?.ShowDialog() == DialogResult.OK;
                },
                CanExecute = dto => dto != null 
                ,
                PermissionRequired = permissions
            };
        }
        public static clsUIAction DetaindLicense(Func<IDTO, Form> AddDetaidLicenseForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.DetainLicense,
                Execute = dto =>
                {

                    if (AddDetaidLicenseForm == null) return false;

                    return AddDetaidLicenseForm?.Invoke(dto)?.ShowDialog() == DialogResult.OK;
                },
                CanExecute = dto => dto != null 
                ,
                PermissionRequired = permissions
            };
        }
        public static clsUIAction Testing(Func<IDTO, Form> AddtTestForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.Testing,
                Execute = dto =>
                {

                    if (AddtTestForm == null) return false;

                    return AddtTestForm?.Invoke(dto)?.ShowDialog() == DialogResult.OK;
                },
                CanExecute = dto => dto != null 
                ,
                PermissionRequired = permissions
            };
        }
        public static clsUIAction TestAppointment(Func<IDTO, Form> AddtTestAppointmentForm
            , clsUserEnums.enPermissions permissions)
        {
            return new clsUIAction
            {
                ActionType = clsUIEnums.enUIAction.TestAppointment,
                Execute = dto =>
                {

                    if (AddtTestAppointmentForm == null) return false;

                    return AddtTestAppointmentForm?.Invoke(dto)?.ShowDialog() == DialogResult.OK;
                },
                CanExecute = dto => dto != null 
                ,
                PermissionRequired = permissions
            };
        }

    }
}
