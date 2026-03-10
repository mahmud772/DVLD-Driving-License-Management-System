using DVLD_DTOs;
using DVLDWinForm.Forms;
using System;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsCRUDController
    {
        public Func<Form> CreateForm { get; set; }
        public Func<IDTO , Form> PrepareUpdate { get; set; }
        public Func<int, bool> TryDelete { get; set; }
        public Func<frmSortAndFilter> Filter { get; set; }
        public Action Refresh { get; set; }
        public IDTO DTO { get; set; } = null;

        public readonly DataGridView DGV;
        public readonly FlowLayoutPanel FLP;

        public clsCRUDController(DataGridView dgv, FlowLayoutPanel flp)
        {
            DGV = dgv;
            FLP = flp;
        }

        public IDTO GetSelectedDto()
        {
            return DTO == null ? DGV.CurrentRow?.DataBoundItem as IDTO : DTO;
        }
        
        public bool ShowCreateForm()
        {
            Form frm = CreateForm?.Invoke();
            frm?.ShowDialog();
            DTO = null;
            Refresh?.Invoke();
            return frm != null;
        }

        public bool ShowUpdateForm()
        {
            var dto = GetSelectedDto();
            if (dto == null) return false;

            Form frm = PrepareUpdate?.Invoke(dto);
            frm?.ShowDialog();
            DTO = null;
            Refresh?.Invoke();
            return true;
        }

        public bool ConfirmAndDelete()
        {
            var dto = GetSelectedDto();
            if (dto == null) return false;

            if (MessageBox.Show("Are you sure?", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return false;
            
            bool Result = TryDelete?.Invoke(dto.ID) == true;
            Refresh?.Invoke();
            return Result;
        }
        public bool ShowFilterForm()
        {

            Form frm = Filter?.Invoke();
            frm?.ShowDialog();
            DTO = null;
            Refresh?.Invoke();
            return frm != null;
        }
    }
}
