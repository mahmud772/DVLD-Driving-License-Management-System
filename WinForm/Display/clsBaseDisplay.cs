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
        protected IPageableLoader _currentLoader;
        protected clsPaginationManager _paginator;
        protected DataGridView dgvDisplay;
        protected FlowLayoutPanel flpUserControls;
        protected IQuery _currentQuery;
        protected Label lbPageNumber;
        protected Button btnNextPage;
        protected Button btnPreviousPage;
        protected clsCRUDController CRUDController;
        protected IPaginationView _paginationView;
        public clsBaseDisplay(DataGridView dgvDisplay , FlowLayoutPanel flpUserControls ,
            IPaginationView paginationView, clsCRUDController CRUDController)
        {
            _paginationView = paginationView;
            this.dgvDisplay = dgvDisplay;
            this.flpUserControls = flpUserControls;
            this.CRUDController = CRUDController;
        }
        public IDisplayView<T> GetDisplayView<T>(Func<T, UserControl> ControlCeartor , clsEnums.enDisplayMode DisplayMode)
        {
            return DisplayMode == clsEnums.enDisplayMode.DGV ?
                new clsDGVManager<T>(dgvDisplay) :
                new clsFLPManager<T>(flpUserControls, ControlCeartor);
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
            _paginationView.SetPageNumber(_paginator.CurrentPage);
            _paginationView.SetNextButtonVisible(_paginator.HasNextPage);
            _paginationView.SetPreviousButtonVisible(_paginator.HasPreviousPage);
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
