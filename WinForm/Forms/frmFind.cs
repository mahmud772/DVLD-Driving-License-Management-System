using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
using DVLDWinForm.UIHelper;
using DVLDWinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Forms
{
    public partial class frmFind : Form
    {
        public string? SelectedID { get; private set; }

        IUserControl _controlInterface;
        UserControl _uiControl;
        string _OldTextBoxValue;
        Func<int, IBLL> _fncFind;
        public frmFind(IUserControl controlInterface, Func<int, IBLL> fncFind)
        {
            InitializeComponent();
            _controlInterface = controlInterface;
            _fncFind = fncFind;
            _uiControl = controlInterface as UserControl;
            _LoadDesign();

        }

        
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlFind, 15);
            if (_uiControl != null)
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Size = _uiControl.Size;
                pnlContainer.Controls.Add(_uiControl);
                _uiControl.Show();
            }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {

            string Value = tbFindBy.Text.Trim();
            if (Value == string.Empty || Value == _OldTextBoxValue) return;
            _OldTextBoxValue = Value;
            _controlInterface.Info = _fncFind.Invoke(Convert.ToInt32(Value))?.DTO;
            if (_controlInterface.Info != null)
            {
                SelectedID = _controlInterface.Info.ID.ToString();
            }
            else
                MessageBox.Show("Not Found !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
