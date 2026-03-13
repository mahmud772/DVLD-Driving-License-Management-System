using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsDisplayUIManager
    {
        private ComboBox _cbSearchBy;
        private Label _lbTotalTypeTitle;
        private Label _lbTotalCount;
        private PictureBox _pbTotal;
        private Button _btnFLP;
        private Button _btnDGV;
        public clsDisplayUIManager(ComboBox cbSearchBy,Label lbTotalTypeTitle,
            Label lbTotalCount, PictureBox pbTotal , Button btnFLP , Button btnDGV)
        {
            _cbSearchBy = cbSearchBy;
            _lbTotalTypeTitle = lbTotalTypeTitle;
            _lbTotalCount = lbTotalCount;
            _pbTotal = pbTotal;
            _btnFLP = btnFLP;
            _btnDGV = btnDGV;
        }

        public void InitializeHeaderBox<TEnum>(string title, Image image)
            where TEnum : Enum
        {
            _cbSearchBy.DataSource = Enum.GetValues(typeof(TEnum));

            _lbTotalTypeTitle.Text = title;

            _pbTotal.Image = image;
        }
        public void InitializeButtonFLPandDGV(clsUIEnums.enDisplayMode DisplayMode)
        {
            if (DisplayMode == clsUIEnums.enDisplayMode.DGV)
            {
                _btnFLP.BackgroundImage = Properties.Resources.Menu_Gray_FLP;
                _btnDGV.BackgroundImage = Properties.Resources.Menu_RGB_DGV;
            }
            else if (DisplayMode == clsUIEnums.enDisplayMode.FLP)
            {
                _btnFLP.BackgroundImage = Properties.Resources.Menu_RGB_FLP;
                _btnDGV.BackgroundImage = Properties.Resources.Menu_Gray_DGV;
            }
        }

        public void UpdateTotal(int total)
        {
            _lbTotalCount.Text = total.ToString();
        }
    }
}
