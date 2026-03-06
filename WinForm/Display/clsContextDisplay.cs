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
        public clsCRUDController CRUDController { get; set; }
        public ContextMenuStrip SharedContextMenu { get; set; }
        public clsContextDisplay(IPaginationView paginationView,DataGridView dgv,
            FlowLayoutPanel flp,clsCRUDController crudController, ContextMenuStrip sharedContextMenu)
        {
            PaginationView = paginationView;
            dgvDisplay = dgv;
            flpUserControls = flp;
            CRUDController = crudController;
            SharedContextMenu = sharedContextMenu;
        }
    }
}
