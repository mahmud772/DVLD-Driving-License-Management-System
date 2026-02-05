using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.User_Controls.Filters
{
    public interface IUserControlFilter
    {
        IFilter Filter { get; set; }
    }
}
