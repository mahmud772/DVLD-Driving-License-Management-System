using System;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{

    public class clsControlAnimateHeight
    {
        public enum enStatus { Expanded = 1 , Closed = 2 };
        public enStatus Status {  get;private set; }
        
        private UserControl _userControl;
        private int _expandedHeight;
        private int _collapsedHeight;
        private Timer _animationTimer;
        private bool _isExpanding;
        private int _step; 

        public event Action OnExpand;
        public event Action OnCollapse;

        public clsControlAnimateHeight(UserControl userControl, int expandedHeight, int collapsedHeight , int step = 10)
        {
            Status = enStatus.Expanded;

            _userControl = userControl;
            _expandedHeight = expandedHeight;
            _collapsedHeight = collapsedHeight;
            _step = step;

            _animationTimer = new Timer();
            _animationTimer.Interval = 15; 
            _animationTimer.Tick += _animationTimer_Tick;
        }

        
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
        public void QuickCollapse()
        {
            Status = enStatus.Closed;
            _isExpanding = false;
            OnCollapse?.Invoke();
            _userControl.Height = _collapsedHeight;
        }
    }
}
