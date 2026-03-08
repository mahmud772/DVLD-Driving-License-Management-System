using Common.Queries;
using DVLD_DTOs;
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
        void Load(clsUIEnums.enDisplayMode mode , IQuery query);
        void NextPage();
        void PreviousPage();
        void InitializeUIActionsManager();
        void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
                      Label lbTotalCount, PictureBox pbTotal);
        IDTO GetSelectedDto();
        void Refresh(bool IsChanged);
    }
}
