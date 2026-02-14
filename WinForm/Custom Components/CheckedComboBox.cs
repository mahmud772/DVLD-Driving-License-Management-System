using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public class CheckedComboBox : ComboBox
{
    private CheckedListBox _checkListBox;
    private ToolStripDropDown _dropDown;
    private ToolStripControlHost _controlHost;

    public CheckedComboBox()
    {
        _checkListBox = new CheckedListBox();
        _checkListBox.BorderStyle = BorderStyle.None;
        _checkListBox.CheckOnClick = true;
        _checkListBox.ItemCheck += CheckListBox_ItemCheck;

        _controlHost = new ToolStripControlHost(_checkListBox);
        _controlHost.Padding = Padding.Empty;
        _controlHost.Margin = Padding.Empty;
        _controlHost.AutoSize = false;

        _dropDown = new ToolStripDropDown();
        _dropDown.Padding = Padding.Empty;
        _dropDown.Items.Add(_controlHost);

        this.DropDownHeight = 1; // منع القائمة الافتراضية
    }

    protected override void OnDropDown(EventArgs e)
    {
        base.OnDropDown(e);

        if (_dropDown != null)
        {
            _checkListBox.Width = this.DropDownWidth;
            _checkListBox.Height = 200;
            _controlHost.Size = _checkListBox.Size;

            _dropDown.Show(this, 0, this.Height);
        }
    }

    public CheckedListBox.ObjectCollection ItemsList
    {
        get { return _checkListBox.Items; }
    }

    public CheckedListBox.CheckedItemCollection CheckedItems
    {
        get { return _checkListBox.CheckedItems; }
    }

    private void CheckListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        this.BeginInvoke((MethodInvoker)UpdateText);
    }

    private void UpdateText()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in _checkListBox.CheckedItems)
        {
            sb.Append(item.ToString());
            sb.Append(", ");
        }

        if (sb.Length > 2)
            sb.Length -= 2;

        this.Text = sb.ToString();
    }

    public void AddItem(object item, bool isChecked = false)
    {
        _checkListBox.Items.Add(item, isChecked);
        UpdateText();
    }
}