namespace MiniStore.Modules.SupplierManager.UI
{
    using FontAwesome.Sharp;
    using MiniStore.Modules.OrderManager.UI;
    using MiniStore.Modules.SupplierManager.Constants;
    using MiniStore.Modules.SupplierManager.Dtos;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

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
            OrderStyle.ApplyStyleCompoBox(ComboboxStatus);
            ComboboxStatus.Items.AddRange(SupplierConstants.GetArrayStatusSupplier().Concat(["Tất cả"]).ToArray());
            ComboboxStatus.Text = "Tất cả";

        }

        public  FilterValueDto? GetValueFilter()
        {
            FilterValueDto filterValue = new FilterValueDto();
            if(CheckBoxFilterTime.Checked)
            {
                filterValue.TimeStart = dateTimePicker1.Value.Date;
                filterValue.TimeEnd = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

                if (filterValue.TimeEnd < filterValue.TimeStart)
                {
                    MessageBox.Show("Lỗi thời gian kế thúc không được nhỏ hơn thời gian bắt đầu");
                    dateTimePicker2.Focus();
                    return null;
                }

            }

            string selectedStatus = ComboboxStatus.Text;


            if (string.IsNullOrEmpty(selectedStatus) || selectedStatus == "Tất cả")
            {
              
                filterValue.status = null;
            }
            else
            {
               
                filterValue.status = selectedStatus;
            }
            return filterValue;
            


        }

                private void SupplierFilter_Load(object sender, EventArgs e)
        {
            SetupLayout();
        }

                public Button GetButtonRefresh() => ButtonRefresh;
               public Button GetButtonFilter() => ButtonFilter;
    }
}
