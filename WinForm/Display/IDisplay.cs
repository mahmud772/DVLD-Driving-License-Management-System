using Common.Queries;
using DVLDWinForm.UIHelper_Manger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public interface IDisplay
    {
        void Load(clsEnums.enDisplayMode mode , IQuery query);
        void NextPage();
        void PreviousPage();
        void InitializeCRUDController();
        void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
                      Label lbTotalCount, PictureBox pbTotal);
    }
}
