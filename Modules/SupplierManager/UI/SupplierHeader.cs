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
    public partial class SupplierHeader : UserControl
    {
        public SupplierHeader()
        {
            InitializeComponent();
        }

        private void SetupLayout()
        {
             OrderStyle.ApplyStyleButtonWithICon(ButtonAdd, "Thêm mới", IconChar.PlusCircle, OrderStyle.PRIMARY_COLOR);
            OrderStyle.ApplyStyleButtonWithICon(ButtonReport, "Báo cáo", IconChar.FileExport, OrderStyle.PRIMARY_COLOR);
            OrderStyle.ApplyStyleButtonWithICon(ButtonSearch, "Tìm kiếm", IconChar.MagnifyingGlass, OrderStyle.PRIMARY_COLOR);
            OrderStyle.ApplyStyleInput(InputSearch, "Nhập mã hoặc tên khách hàng...");
            OrderStyle.ApplyStyleButtonWithICon(ButtonDelete, "Xóa", IconChar.Trash, OrderStyle.PRIMARY_COLOR);
        }
        private void SupplierHeader_Load(object sender, EventArgs e)
        {
          SetupLayout();  
        }
    }
}
