using DVLDWinForm.UIHelper_Manger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsContextDisplay
    {
        public IPaginationView PaginationView { get; set; }
        public DataGridView dgvDisplay { get; set; }
        public FlowLayoutPanel flpUserControls { get; set; }
        public ContextMenuStrip SharedContextMenu { get; set; }
        public clsUIActionsManager UIActionsManager { get; set; }
        public clsDisplayUIManager DisplayUIManager { get; set; }
        public clsContextDisplay(IPaginationView paginationView,DataGridView dgv,
            FlowLayoutPanel flp , ContextMenuStrip sharedContextMenu ,
            clsUIActionsManager actionsManager , clsDisplayUIManager displayUIManager)
        {
            PaginationView = paginationView;
            dgvDisplay = dgv;
            flpUserControls = flp;
            SharedContextMenu = sharedContextMenu;
            UIActionsManager = actionsManager;
            DisplayUIManager = displayUIManager;
        }
    }
}
