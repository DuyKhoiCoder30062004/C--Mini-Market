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
    public partial class OrderHeader : UserControl
    {
        public OrderHeader()
        {
            InitializeComponent();
            SetupLayout();
        }

        private void SetupLayout()
        {
            Style.ApplyStyleButtonWithICon(ButtonAdd,"Thêm mới", IconChar.PlusCircle, Style.PRIMARY_COLOR);
            Style.ApplyStyleButtonWithICon(ButtonExport, "Báo cáo", IconChar.FileExport, Style.PRIMARY_COLOR);
            Style.ApplyStyleButtonWithICon(ButtonSearch, "Tìm kiếm", IconChar.MagnifyingGlass,Style.PRIMARY_COLOR);
            Style.ApplyStyleInput(SearchInput, "Nhập mã hoặc tên khách hàng...");
            Style.ApplyStyleButtonWithICon(ButtonDelete, "Xóa", IconChar.Trash,Style.PRIMARY_COLOR);
        }

        public void HandleButtonDelete(List<string> ids) {
            this.ButtonDelete.Click += (sender, e) =>
            {
                if (ids.Count == 0) {
                    MessageBox.Show("Vui lòng chọn đối tượng cần xóa");
                }
                else
                {
                    StringBuilder id = new StringBuilder();
                    foreach (string item in ids) { 
                      id.Append(item);
                    }
                    MessageBox.Show($"xóa item ${id}");
                }
            };
        }
   
        private void Header_Load(object sender, EventArgs e)
        {

        }
    }
}
