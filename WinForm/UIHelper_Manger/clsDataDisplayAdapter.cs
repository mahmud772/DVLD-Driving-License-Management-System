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
        
        private List<T> _LoadData {  get; set; }
        public int CurrentPage { get; set; } = 1;

        public clsDataDisplayAdapter(Func<int, int , IQuery, List<T>> dataSource, Func<IQuery,int> countSource,  IDisplayView<T> viewManager)
        {
            _dataSource = dataSource;
            _countSource = countSource;
            _viewManager = viewManager;
        }
        
        //private bool _LoadNewDataSource(int offset, int pageSize )// بهذه الدالة نجلب عدد معين من السجلات لكي نقلل عدد الاستعلامات
        //{
        //    int CountRows = 198; // هذا العدد هو مضاعف الاصغر للعددين 22 و 9 الذان هما عدد Items في DGV , FLP

        //    if (CountRows % (offset + pageSize + 1) == 0 || offset == 0) //  التحقق هل نحتاج الى تحميل بيانات جديده ام لا عن طريق معرفة هل نحن في اول استدعاء ام هل اخر صف مستدعى هو من مضاعفات العدد 198
        //    {
        //        _LoadData = _dataSource(offset, CountRows);
        //        return true;
        //    }
        //    return false;
        //}
        public void LoadPage(int offset, int pageSize , IQuery Query)
        {
            //_LoadNewDataSource(offset, pageSize);
            //List<T> data = _LoadData.GetRange(offset , pageSize);
            List<T> data = _dataSource(offset, pageSize , Query);
            _viewManager.Display(data);
        }
        
        public int GetTotalCount(IQuery query) => _countSource(query);
    }
}
