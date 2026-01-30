using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTO
{
    public class clsTestType_DTO : IDTO
    {
        public int ID { get => TestTypeID; set => value = TestTypeID; }
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
            
    }
}
