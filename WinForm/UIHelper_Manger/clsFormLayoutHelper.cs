using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsFormLayoutHelper
    {
        private readonly Form _form;
        private readonly Panel _panel;
        private readonly Button[] _buttons;
        public static int spacing { get; set; } = 15;

        public clsFormLayoutHelper(Form form, Panel panel, params Button[] buttons)
        {
            _form = form;
            _panel = panel;
            _buttons = buttons;
        }

        public void ApplyLayout()
        {
            if (_form == null || _panel == null) return;

            _AdjustWidth();
            _AdjustButtonsPosition();
            _AdjustHeight();
        }

        private void _AdjustWidth()
        {
            int marginLeft = _panel.Location.X;

            _form.ClientSize = new Size(_panel.Width + (marginLeft * 2), _form.ClientSize.Height);
        }

        private void _AdjustButtonsPosition()
        {
            if (_buttons == null || _buttons.Length == 0) return;

            foreach (var btn in _buttons)
            {
                if (btn == null) continue;

                btn.Location = new Point(btn.Location.X, _panel.Bottom + spacing);
            }
        }

        private void _AdjustHeight()
        {
            int lowestPoint = _panel.Bottom;

            if (_buttons != null && _buttons.Length > 0)
            {
                foreach (var btn in _buttons)
                {
                    if (btn != null && btn.Bottom > lowestPoint)
                        lowestPoint = btn.Bottom;
                }
            }

            int marginBottom = _panel.Location.X;
            _form.ClientSize = new Size(_form.ClientSize.Width, lowestPoint + marginBottom);
        }
    }
}
