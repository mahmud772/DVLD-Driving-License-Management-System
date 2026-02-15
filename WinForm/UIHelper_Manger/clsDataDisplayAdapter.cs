using Common.Queries;
using DVLDWinForm.UIHelper;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsDataDisplayAdapter<T> : IPageableLoader
    {
        private readonly Func<int, int, IQuery , List<T>> _dataSource; // دالة جلب البيانات من BLL
        private readonly IDisplayView<T> _viewManager;         
        private readonly Func<IQuery ,int> _countSource;             // دالة جلب العدد الكلي

        private IQuery _lastQuery;

        private List<T> _cache = new List<T>();
        private int _cacheStart = 0;
        private int _cacheSize = 198;
        public int CurrentPage { get; set; } = 1;

        public clsDataDisplayAdapter(Func<int, int , IQuery, List<T>> dataSource, Func<IQuery,int> countSource,  IDisplayView<T> viewManager)
        {
            _dataSource = dataSource;
            _countSource = countSource;
            _viewManager = viewManager;
        }
        private bool NeedLoad(int offset, int pageSize , IQuery query)
        {
            return _cache.Count == 0 ||
                   offset < _cacheStart ||
                   offset + pageSize > _cacheStart + _cache.Count ||
                   _lastQuery != query;
        }

        private void LoadCache(int offset, IQuery query)
        {
            _cacheStart = offset;
            _cache = _dataSource(_cacheStart, _cacheSize, query);
            _lastQuery = query;
        }


        public void LoadPage(int offset, int pageSize, IQuery query)
        {
            if (NeedLoad(offset, pageSize ,query))
                LoadCache(offset, query);
            int LocalOffset = offset - _cacheStart;

            List<T> pageData = _cache
                .Skip(LocalOffset)
                .Take(pageSize)
                .ToList();

            _viewManager.Display(pageData);
        }

        public int GetTotalCount(IQuery query) => _countSource(query);
    }
}
