using FontAwesome.Sharp;
using MiniStore.Modules.OrderManager.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStore.Modules.SupplierManager.UI
{
    public partial class SupplierFilter : UserControl
    {
        public SupplierFilter()
        {
            InitializeComponent();
               
        }
        private void SetupLayout()
        {
            OrderStyle.ApplyStyleLabelWithIcon(LabelFilter, IconChar.Filter, "Bộ lọc");
            OrderStyle.ApplyStyleDatePicker(dateTimePicker1);
            OrderStyle.ApplyStyleDatePicker(dateTimePicker2);
            OrderStyle.ApplyStyleLable(LableDatePick, "Đến");
            OrderStyle.ApplyStyleRadioButton(RadioButtonIncre, "Giá tăng dần");
            OrderStyle.ApplyStyleRadioButton(RadioButtonDecre, "Giá giảm dần");
            OrderStyle.ApplyStyleInvisibleGroupBox(groupBox1);
            OrderStyle.ApplyStyleButtonWithICon(ButtonFilter, "Lọc", IconChar.MagnifyingGlass, Color.FromArgb(79, 64, 187));
            OrderStyle.ApplyStyleButtonWithICon(ButtonRefresh, "Làm mới", IconChar.Refresh, Color.FromArgb(79, 64, 187));
            OrderStyle.ApplyStyleCompoBox(comboBox1);
        }
        private void SupplierFilter_Load(object sender, EventArgs e)
        {
            SetupLayout();
        }
    }
}
