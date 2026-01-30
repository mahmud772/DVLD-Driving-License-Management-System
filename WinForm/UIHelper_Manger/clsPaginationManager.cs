using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.UIHelper
{
    public class clsPaginationManager
    {
        public int CurrentPage { get; private set; } = 1;
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public clsPaginationManager(int PageSize, int TotalItems)
        {
            this.PageSize = PageSize;
            this.TotalItems = TotalItems;
        }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public int Offset => (CurrentPage - 1) * PageSize;
        public bool HasNextPage => CurrentPage < TotalPages;
        public bool HasPreviousPage => CurrentPage > 1;

        public void NextPage() { if (HasNextPage) CurrentPage++; }
        public void PreviousPage() { if (HasPreviousPage) CurrentPage--; }
    }
}
