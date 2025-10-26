using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStore.Modules.OrderManager.UI
{
    public partial class OrderFilter : UserControl
    {
        public OrderFilter()
        {
            InitializeComponent();

        }
        private void setupLayout()
        {
            Style.ApplyStyleLabelWithIcon(LabelFilter, IconChar.Filter, "Bộ lọc");
            Style.ApplyStyleDatePicker(dateTimePicker1);
            Style.ApplyStyleDatePicker(dateTimePicker2);
            Style.ApplyStyleLable(LableDatePick, "Đến");
            Style.ApplyStyleRadioButton(RadioButtonIncre, "Giá tăng dần");
            Style.ApplyStyleRadioButton(RadioButtonDecre, "Giá giảm dần");
            Style.ApplyStyleInvisibleGroupBox(groupBox1);
            Style.ApplyStyleButtonWithICon(ButtonFilter, "Lọc", IconChar.MagnifyingGlass, Color.FromArgb(79, 64, 187));
            Style.ApplyStyleButtonWithICon(ButtonRefresh, "Làm mới", IconChar.Refresh, Color.FromArgb(79, 64, 187));
            Style.ApplyStyleCompoBox(comboBox1);
        }
        private void OrderFilter_Load(object sender, EventArgs e)
        {
            setupLayout();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LabelFilter_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {

        }
        private void ButtonFilter_Click(object sender, EventArgs e)
        {

        }
        private void LableDatePick_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
