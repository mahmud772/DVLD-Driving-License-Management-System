using Common;
using DVLDWinForm.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.clsEnSearchBy;

namespace DVLDWinForm.User_Controls.Display.ucApplication
{
    public class FormStateManager
    {
        private System.Windows.Forms.Label _lbLicenseClass;
        private ComboBox _cbLicenseClass;
        private System.Windows.Forms.Label _lbID;
        private CheckBox _ckbOperation;
        public FormStateManager(System.Windows.Forms.Label lbLicenseClass,ComboBox cbLicenseClass,
            System.Windows.Forms.Label lbID,
            CheckBox ckbOperation)
        {
            _lbLicenseClass = lbLicenseClass;
            _cbLicenseClass = cbLicenseClass;
            _lbID = lbID;
            _ckbOperation = ckbOperation;
        }
        //private void _LoadDesign()
        //{
        //    clsUIHelper.CornerRadius(pnlApplication, 15);
        //    lbLicenseClass.Visible = false;
        //    cbLicenseClass.Visible = false;
        //    ckbOperationLicense.Visible = false;
        //    ckbOperationLicense.Checked = true;
        //    ckbOperationLicense.Location = lbLicenseClass.Location;
        //    lbPaidFees2.Visible = false;
        //}
        public void UpdateState(clsApplicationEnums.enApplicationType type)
        {
            if (type == clsApplicationEnums.enApplicationType.NewLocalDrivingLicense)
            {
                ShowLicenseClass();
                _lbID.Text = "Person ID:";
                _ckbOperation.Visible = false;
            }
            else if (type == clsApplicationEnums.enApplicationType.RetakeTest)
            {
                ShowLicenseClass();
                _lbID.Text = "Local Application ID:";
                _ckbOperation.Visible = false;
            }
            else
            {
                HideLicenseClass();
                _lbID.Text = "License ID:";
                _ckbOperation.Visible = true;
            }
        }

        private void ShowLicenseClass()
        {
            _lbLicenseClass.Visible = true;
            _cbLicenseClass.Visible = true;
        }

        private void HideLicenseClass()
        {
            _lbLicenseClass.Visible = false;
            _cbLicenseClass.Visible = false;
        }
    }
}
