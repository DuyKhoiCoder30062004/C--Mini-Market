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
            OrderManager.UI.OrderStyle.ApplyStyleButtonWithICon(ButtonAdd, "Thêm mới", IconChar.PlusCircle, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
            OrderManager.UI.OrderStyle.ApplyStyleButtonWithICon(ButtonReport, "Báo cáo", IconChar.FileExport, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
            OrderManager.UI.OrderStyle.ApplyStyleButtonWithICon(ButtonSearch, "Tìm kiếm", IconChar.MagnifyingGlass, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
            OrderManager.UI.OrderStyle.ApplyStyleInput(InputSearch, "Nhập mã hoặc tên khách hàng...");
            OrderManager.UI.OrderStyle.ApplyStyleButtonWithICon(ButtonDelete, "Xóa", IconChar.Trash, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
          
        }

        public  Button GetButtonCreate() => ButtonAdd;
        public Button GetButtonDelete() => ButtonDelete;
        public TextBox GetInputSearch() => InputSearch;
        public Button GetButtonSearch() => ButtonSearch;
        private void SupplierHeader_Load(object sender, EventArgs e)
        {
          SetupLayout();  
        }
    }
}
