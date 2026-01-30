using DVLD_BLL;
using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsCRUDController
    {
        public Func<Form> CreateForm { get; set; }
        public Func<IDTO , Form> PrepareUpdate { get; set; }
        public Func<int, bool> TryDelete { get; set; }
        public Func<int ,IBLL> Search { get; set; }
        public IDTO DTO { get; set; } = null;
        public readonly DataGridView DataGrid;
        public readonly FlowLayoutPanel ActionsPanel;

        public clsCRUDController(DataGridView dgv, FlowLayoutPanel flp)
        {
            DataGrid = dgv;
            ActionsPanel = flp;
        }

        public IDTO GetSelectedDto()
        {
            return DTO == null ? DataGrid.CurrentRow?.DataBoundItem as IDTO : DTO;
        }
        
        public bool ShowCreateForm()
        {
            Form frm = CreateForm?.Invoke();
            frm?.ShowDialog();
            DTO = null;
            return frm != null;
        }

        public bool ShowUpdateForm()
        {
            var dto = GetSelectedDto();
            if (dto == null) return false;

            Form frm = PrepareUpdate?.Invoke(dto);
            frm?.ShowDialog();
            DTO = null;
            return true;
        }

        public bool ConfirmAndDelete()
        {
            var dto = GetSelectedDto();
            if (dto == null) return false;

            if (MessageBox.Show("Are you sure?", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return false;

            return TryDelete?.Invoke(dto.ID) == true;
        }
        public bool ShowDTO(int ID)
        {
            IDTO dto = GetSelectedDto();    
            if (dto == null) return false;
            Search?.Invoke(ID);
            return true;
        }
    }
}
