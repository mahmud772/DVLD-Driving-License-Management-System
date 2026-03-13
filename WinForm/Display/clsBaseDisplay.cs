using Common.Queries;
using DVLD_DTOs;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDWinForm.UIHelper_Manger.clsUIEnums;

namespace DVLDWinForm.Display
{
    public abstract class clsBaseDisplay : IDisplay
    {
        protected clsContextDisplay _context;
        protected IPageableLoader _currentLoader;
        protected IQuery _currentQuery;
        protected clsPaginationManager _paginator;
        public clsUIEnums.enDisplayMode DisplayMode { get; protected set; } = enDisplayMode.FLP;
        public clsBaseDisplay(clsContextDisplay Context)
        {
            _context = Context;
        }
        public void Display()
        {
            if (DisplayMode == enDisplayMode.FLP)
                ShowFLP();
            else
                ShowDGV();
        }
        public IDisplayView<T> GetDisplayView<T>(Func<T, UserControl> ControlCeartor , clsUIEnums.enDisplayMode DisplayMode)
        {
            return DisplayMode == clsUIEnums.enDisplayMode.DGV ?
                new clsDGVManager<T>(_context.dgvDisplay) :
                new clsFLPManager<T>(_context.flpUserControls, ControlCeartor);
        }
        public virtual void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery CurrentQuery) { }
        public virtual void InitializeUIActionsManager() { }
        public virtual void UpdateUI() { }
        public void Refresh(bool IsChanged)
        {
            if (IsChanged)
                Display();
        }
        public void InitializeAdapter<T>(Func<int, int, IQuery, List<T>> fetcher, Func<IQuery, int> counter, IDisplayView<T> viewManager)
        {
            _currentLoader = new clsDataDisplayAdapter<T>(fetcher, counter, viewManager);

            _paginator = new clsPaginationManager(viewManager.CountItems, _currentLoader.GetTotalCount(_currentQuery));

            LoadData();
        }
        public void LoadData()
        {
            _context.DisplayUIManager.UpdateTotal(_paginator.TotalItems);
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
        public IDTO GetSelectedDto()
        {
            IDTO DTO = _context.SharedContextMenu.Tag as IDTO ?? _context.dgvDisplay.CurrentRow?.DataBoundItem as IDTO;
            _context.SharedContextMenu.Tag = null;
            return DTO;
        }
        public virtual void UpdateContextMenu()
        {
            _context.SharedContextMenu.Items.Clear();

            _context.SharedContextMenu.Items.Add("UPDATE", Properties.Resources.Update_Person ,
                (s,e) => _context.UIActionsManager.Execute(clsUIEnums.enUIAction.Update , GetSelectedDto(), Refresh));

            _context.SharedContextMenu.Items.Add("DELETE", Properties.Resources.Delete_Person,
                (s, e) => _context.UIActionsManager.Execute(clsUIEnums.enUIAction.Delete, GetSelectedDto(), Refresh));
        }
        public void ShowDGV()
        {
            this.DisplayMode = enDisplayMode.DGV;
            _context.DisplayUIManager.InitializeButtonFLPandDGV(DisplayMode);
            _context.flpUserControls.Visible = false;
            _context.dgvDisplay.Visible = true;
            Load(DisplayMode, _currentQuery);
            this.UpdateUI();
            InitializeUIActionsManager();
        }
        public void ShowFLP()
        {
            this.DisplayMode = enDisplayMode.FLP;
            _context.DisplayUIManager.InitializeButtonFLPandDGV(DisplayMode);
            _context.flpUserControls.Visible = true;
            _context.dgvDisplay.Visible = false;
            Load(DisplayMode, _currentQuery);
            this.UpdateUI();
            InitializeUIActionsManager();
        }
    }
}
