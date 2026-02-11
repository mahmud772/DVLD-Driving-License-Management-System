using DVLD_DTOs;
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
    public partial class frmAddNew_UpdateDriver : Form
    {
        public frmAddNew_UpdateDriver(clsDriver_DTO DriverInfo)
        {
            InitializeComponent();
        }
        public frmAddNew_UpdateDriver()
        {
            InitializeComponent();
        }
    }
}
