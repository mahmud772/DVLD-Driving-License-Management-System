using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsUser_DTO : clsPerson_DTO , IDTO
    {
        int IDTO.ID { get => UserID; set => value = UserID; }
        public int UserID { get;  set; }
        public string UserName { get;  set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Permissions { get; set; }
    }
}
