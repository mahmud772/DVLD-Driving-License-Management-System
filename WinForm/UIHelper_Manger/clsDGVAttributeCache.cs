using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.UIHelper_Manger
{
    public static class clsDGVAttributeCache<T>
    {
        public static List<string> IgnoredColumns =
            typeof(T).GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(DGVIgnoreAttribute)))
            .Select(p => p.Name)
            .ToList();
    }
}
