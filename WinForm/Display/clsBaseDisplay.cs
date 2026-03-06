using Common.Queries;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public abstract class clsBaseDisplay : IDisplay
    {
        protected clsContextDisplay _context;
        protected IPageableLoader _currentLoader;
        protected IQuery _currentQuery;
        protected clsPaginationManager _paginator;
        public clsBaseDisplay(clsContextDisplay Context)
        {
            _context = Context;
        }
        public IDisplayView<T> GetDisplayView<T>(Func<T, UserControl> ControlCeartor , clsEnums.enDisplayMode DisplayMode)
        {
            return DisplayMode == clsEnums.enDisplayMode.DGV ?
                new clsDGVManager<T>(_context.dgvDisplay) :
                new clsFLPManager<T>(_context.flpUserControls, ControlCeartor);
        }
        public virtual void Load(clsEnums.enDisplayMode DisplayMode, IQuery CurrentQuery) { }
        public virtual void InitializeCRUDController() { }
        public virtual void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal) { }
        public void InitializeAdapter<T>(Func<int, int, IQuery, List<T>> fetcher, Func<IQuery, int> counter, IDisplayView<T> viewManager)
        {
            _currentLoader = new clsDataDisplayAdapter<T>(fetcher, counter, viewManager);

            _paginator = new clsPaginationManager(viewManager.CountItems, _currentLoader.GetTotalCount(_currentQuery));

            LoadData();
        }
        public void LoadData()
        {
            _currentLoader.LoadPage(_paginator.Offset, _paginator.PageSize, _currentQuery);
            UpdatePageUI();
        }
        public void UpdatePageUI()
        {
            _context.PaginationView.SetPageNumber(_paginator.CurrentPage);
            _context.PaginationView.SetNextButtonVisible(_paginator.HasNextPage);
            _context.PaginationView.SetPreviousButtonVisible(_paginator.HasPreviousPage);
        }
        public void NextPage()
        {
            if (_paginator.HasNextPage)
            {
                _paginator.NextPage();
                LoadData();
            }

        }

        public void PreviousPage()
        {
            if (_paginator.HasPreviousPage)
            {
                _paginator.PreviousPage();
                LoadData();
            }
        }
    }
}
