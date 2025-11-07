using FontAwesome.Sharp;
using System.Text;


namespace MiniStore.Modules.PurchaseOrder.UI
{
    public partial class PurchaseOrderHeader : UserControl
    {
        public PurchaseOrderHeader()
        {
            InitializeComponent();
            SetupLayout();
        }

        private void SetupLayout()
        {
            PurchaseOrderStyle.ApplyStyleButtonWithICon(ButtonAdd, "Thêm mới", IconChar.PlusCircle, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
            PurchaseOrderStyle.ApplyStyleButtonWithICon(ButtonExport, "Báo cáo", IconChar.FileExport, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
            PurchaseOrderStyle.ApplyStyleButtonWithICon(ButtonSearch, "Tìm kiếm", IconChar.MagnifyingGlass, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
            PurchaseOrderStyle.ApplyStyleInput(SearchInput, "Nhập mã hoặc tên khách hàng...");
            PurchaseOrderStyle.ApplyStyleButtonWithICon(ButtonDelete, "Xóa", IconChar.Trash, OrderManager.UI.OrderStyle.PRIMARY_COLOR);
        }
        private void PurchaseOrderHeader_Load(object sender, EventArgs e)
        {

        }

        public void HandleButtonDelete(List<string> ids)
        {
            this.ButtonDelete.Click += (sender, e) =>
            {
                if (ids.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đối tượng cần xóa");
                }
                else
                {
                    StringBuilder id = new StringBuilder();
                    foreach (string item in ids)
                    {
                        id.Append(item);
                    }
                    MessageBox.Show($"xóa item ${id}");
                }
            };
        }

        private void LabelNameUI_Click(object sender, EventArgs e)
        {

        }
    }
}
