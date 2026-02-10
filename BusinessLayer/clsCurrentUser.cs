using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD_BLL
{
    public static class clsCurrentUser
    {
        public static clsUser_DTO User { get; private set; }

        public static bool IsAuthenticated => User != null;

        public static void SetUser(clsUser_DTO user)
        {
            User = user;
        }

        public static void Logout()
        {
            User = null;
            Application.Restart();
        }
    }

}
