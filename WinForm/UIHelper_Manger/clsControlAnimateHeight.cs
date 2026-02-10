using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{

    public class clsControlAnimateHeight
    {
        public enum enStatus { Expanded = 1 , Closed = 2 };
        public enStatus Status {  get;private set; }
        // الحقول الخاصة (Private Fields)
        private readonly UserControl _userControl;
        private readonly int _expandedHeight;
        private readonly int _collapsedHeight;
        private readonly Timer _animationTimer;
        private bool _isExpanding;
        private int _step; // مقدار الزيادة أو النقص في كل تكة تايمر

        public event Action OnExpand;
        public event Action OnCollapse;

        public clsControlAnimateHeight(UserControl userControl, int expandedHeight, int collapsedHeight , int step = 10)
        {
            Status = enStatus.Expanded;

            _userControl = userControl;
            _expandedHeight = expandedHeight;
            _collapsedHeight = collapsedHeight;
            _step = step;

            // إعداد التايمر (Setting up the timer)
            _animationTimer = new Timer();
            _animationTimer.Interval = 15; // سرعة الحركة (أقل = أنعم)
            _animationTimer.Tick += _animationTimer_Tick;
        }

        // الدالة المسؤولة عن منطق الحركة (Internal Logic)
        private void _animationTimer_Tick(object sender, EventArgs e)
        {
            if (_isExpanding)
            {
                _applyExpansion();
            }
            else
            {
                _applyCollapse();
            }
        }

        private void _applyExpansion()
        {
            if (_userControl.Height < _expandedHeight)
            {
                _userControl.Height += _step;
            }
            else
            {
                _userControl.Height = _expandedHeight;
                _animationTimer.Stop();
            }
        }

        private void _applyCollapse()
        {
            if (_userControl.Height > _collapsedHeight)
            {
                _userControl.Height -= _step;
            }
            else
            {
                _userControl.Height = _collapsedHeight;
                _animationTimer.Stop();
            }
        }


        public void Expand()
        {
            Status = enStatus.Expanded;
            _isExpanding = true;
            OnExpand?.Invoke();
            _animationTimer.Start();
        }

        public void Collapse()
        {
            Status = enStatus.Closed;
            _isExpanding = false;
            OnCollapse?.Invoke();
            _animationTimer.Start();
        }
    }
}
