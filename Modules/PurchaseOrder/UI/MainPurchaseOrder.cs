using FontAwesome.Sharp;
using MiniStore.Modules.OrderManager.UI;
using MiniStore.Modules.PurchaseOrder.BLL;
using MiniStore.Modules.PurchaseOrder.Dtos;


namespace MiniStore.Modules.PurchaseOrder.UI
{
    public partial class MainPurchaseOrder : UserControl
    {
        private List<string> itemsSelected = new List<string>();
        private readonly PurchaseOrderBLL _purchaseOrderBLL;
        private List<PurchaseOrderDto> _data;
        public MainPurchaseOrder()
        {
            _purchaseOrderBLL = new PurchaseOrderBLL();
            InitializeComponent();
            SetupLayout();
        }

        private void SetupLayout()
        {
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.SplitterDistance = 100;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.BackColor = splitContainer1.Panel1.BackColor;
            var header = new PurchaseOrderHeader();
            header.Dock = DockStyle.Fill;
            header.BorderStyle = BorderStyle.None;
            this.splitContainer1.Panel1.Controls.Add(header);
            this.splitContainer1.Panel2.Padding = new Padding(0);
            var filter = new PurchaseOrderFilter();
            filter.BorderStyle = BorderStyle.None;
            filter.Dock = DockStyle.Top;
            filter.Height = 60;
            filter.Margin = new Padding(0);
            filter.Padding = new Padding(0);
            var table = CreateOrderTable();
            OrderStyle.ApplyStyleTable(table);
            table.Dock = DockStyle.Fill;
            table.BorderStyle = BorderStyle.None;
            table.Margin = new Padding(8, 0, 0, 10);
            SetFixedColumns(table);
            this.splitContainer1.Panel2.Controls.Add(table);
            this.splitContainer1.Panel2.Controls.Add(filter);

            LoadData();
            header.HandleButtonDelete(itemsSelected);
            LoadPurchaseOrderData(table,_data);

        }

        private void LoadData()
        {
            var listPurchaseOrderResponse = _purchaseOrderBLL.GetListPurchaseOrder();
            if(!listPurchaseOrderResponse.Success)
            {
                    MessageBox.Show(listPurchaseOrderResponse.Message, "Lỗi Tải phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            _data = listPurchaseOrderResponse.Data;
        }


        private void AddItemSelected(string id)
        {
            if (!itemsSelected.Contains(id))
            {
                itemsSelected.Add(id);
            }
        }
        private void RemoveItemSelected(string id)
        {
            itemsSelected.Remove(id);
        }
        private DataGridView CreateOrderTable()
        {
            var dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
            };


            var checkCol = new DataGridViewCheckBoxColumn
            {
                Name = "Selected",
                HeaderText = "",
                Width = 30,
                ReadOnly = false
            };
            dataGridView.Columns.Add(checkCol);


            var amountCol = new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Tổng tiền",
                ValueType = typeof(decimal)
            };


            var orderDateCol = new DataGridViewTextBoxColumn
            {
                Name = "OrderDate",
                HeaderText = "Ngày tạo đơn",
                ValueType = typeof(DateTime)
            };


            var expectedDateCol = new DataGridViewTextBoxColumn
            {
                Name = "ExpectedDate",
                HeaderText = "Ngày nhận dự kiến",
                ValueType = typeof(DateTime)
            };


            var actionCol = new DataGridViewImageColumn
            {
                Name = "Action",
                HeaderText = "Thao tác",
                Image = IconChar.Edit.ToBitmap(Color.DodgerBlue, 20),
                Width = 50
            };



            dataGridView.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "Action")
                {
                    var id = dataGridView.Rows[e.RowIndex].Cells["Id"].Value?.ToString();
                    var popup = new PopupPurchaseOrder();
                    popup.SetTile("Chi tiết nhập hàng");
                    popup.ShowDialog();

                }

            };


            dataGridView.Columns.Add(actionCol);
            dataGridView.Columns.Add("Id", "ID");
            dataGridView.Columns.Add("Code", "Mã đơn");


            dataGridView.Columns.Add("SupplierName", "Nhà cung cấp");



            dataGridView.Columns.Add(amountCol);

            dataGridView.Columns.Add("Status", "Trạng thái");


            dataGridView.Columns.Add("PaymentMethod", "Thanh toán");


            dataGridView.Columns.Add(orderDateCol);
            dataGridView.Columns.Add(expectedDateCol);


            AddHeaderCheckbox(dataGridView);


            dataGridView.Columns["Selected"].DisplayIndex = 0;
            dataGridView.Columns["Id"].DisplayIndex = 1;
            dataGridView.Columns["Code"].DisplayIndex = 2;
            dataGridView.Columns["SupplierName"].DisplayIndex = 3;
            dataGridView.Columns["Status"].DisplayIndex = 5;
            dataGridView.Columns["OrderDate"].DisplayIndex = 6;
            dataGridView.Columns["ExpectedDate"].DisplayIndex = 7;
            dataGridView.Columns["PaymentMethod"].DisplayIndex = 8;
            dataGridView.Columns["Action"].DisplayIndex = 9;



            dataGridView.Columns["TotalAmount"].SortMode = DataGridViewColumnSortMode.Programmatic;
            

            dataGridView.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";


            dataGridView.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView.Columns["OrderDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["ExpectedDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView.Columns["ExpectedDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            return dataGridView;
        }


        private void SetFixedColumns(DataGridView dgv)
        {

            dgv.Columns["Selected"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Id"].Resizable = DataGridViewTriState.False;
            dgv.Columns["OrderDate"].Resizable = DataGridViewTriState.False;
            dgv.Columns["ExpectedDate"].Resizable = DataGridViewTriState.False;
            dgv.Columns["TotalAmount"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Status"].Resizable = DataGridViewTriState.False;

            dgv.Columns["Selected"].Width = 5;
            dgv.Columns["Id"].Width = 10;
            dgv.Columns["Code"].Width = 10;
            dgv.Columns["OrderDate"].Width = 100;
            dgv.Columns["ExpectedDate"].Width = 100;
            dgv.Columns["TotalAmount"].Width = 120;
            dgv.Columns["Status"].Width = 50;
            dgv.Columns["Action"].Width = 50;
            dgv.Columns["PaymentMethod"].Width = 100;
            dgv.Columns["SupplierName"].Width = 80;
        }

        private void LoadPurchaseOrderData(DataGridView table,List<PurchaseOrderDto> data)
        {

                table.Rows.Clear();
                foreach (var order in data)
                {
                    var rowIndex = table.Rows.Add();
                    var row = table.Rows[rowIndex];

                    row.Cells["PaymentMethod"].Value = order.PaymentMethod;
                    row.Cells["Selected"].Value = false;
                    row.Cells["Id"].Value = order.Id;
                    row.Cells["Code"].Value = order.Code;
                    row.Cells["SupplierName"].Value = order.SupplierName;
                    row.Cells["TotalAmount"].Value = order.TotalAmount;
                    row.Cells["Status"].Value = order.Status;
                    row.Cells["OrderDate"].Value = order.OrderDate;
                    row.Cells["ExpectedDate"].Value = order.ExpectedDate.HasValue ? order.ExpectedDate.Value : (object)DBNull.Value;

                }
            
        }


        private void AddHeaderCheckbox(DataGridView dgv)
        {

            CheckBox cbHeader = new CheckBox();
            cbHeader.Size = new Size(18, 18);
            cbHeader.BackColor = Color.Transparent;


            Rectangle rect = dgv.GetCellDisplayRectangle(0, -1, true);
            cbHeader.Location = new Point(
                rect.Location.X + (rect.Width - cbHeader.Width) / 2,
                rect.Location.Y + (rect.Height - cbHeader.Height) / 2
            );


            dgv.Controls.Add(cbHeader);


            cbHeader.CheckedChanged += (s, e) =>
            {
                dgv.EndEdit();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["Selected"] is DataGridViewCheckBoxCell cell)
                    {
                        cell.Value = cbHeader.Checked;

                    }
                    if (cbHeader.Checked)
                    {
                        AddItemSelected(row.Cells["Id"].Value.ToString());
                    }
                    else
                    {
                        RemoveItemSelected(row.Cells["Id"].Value.ToString());
                    }

                }

            };


            dgv.Scroll += (s, e) => UpdateHeaderCheckboxLocation(dgv, cbHeader);
            dgv.ColumnWidthChanged += (s, e) => UpdateHeaderCheckboxLocation(dgv, cbHeader);
            dgv.SizeChanged += (s, e) => UpdateHeaderCheckboxLocation(dgv, cbHeader);
            dgv.CellPainting += (s, e) =>
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 0)
                    UpdateHeaderCheckboxLocation(dgv, cbHeader);
            };
        }

        private void UpdateHeaderCheckboxLocation(DataGridView dgv, CheckBox cbHeader)
        {

            Rectangle rect = dgv.GetCellDisplayRectangle(0, -1, true);
            cbHeader.Location = new Point(
                rect.Location.X + (rect.Width - cbHeader.Width) / 2,
                rect.Location.Y + (rect.Height - cbHeader.Height) / 2
            );
        }
        private void MainPurchaseOrder_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
