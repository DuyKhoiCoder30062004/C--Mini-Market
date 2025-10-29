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
    public partial class MainSupplierUI : UserControl
    {
        private List<string> itemsSelected = new List<string>();
        public MainSupplierUI()
        {
            InitializeComponent();
            Setuplayout();
        }

        private void Setuplayout()
        {
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.SplitterDistance = 100;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.BackColor = splitContainer1.Panel1.BackColor;

            var header = new SupplierHeader();
            header.Dock = DockStyle.Fill;
            header.BorderStyle = BorderStyle.None;
            this.splitContainer1.Panel1.Controls.Add(header);
            this.splitContainer1.Panel2.Padding = new Padding(0);

            var supplierFIlter = new SupplierFilter();
            supplierFIlter.BorderStyle = BorderStyle.None;
            supplierFIlter.Dock = DockStyle.Top;
            supplierFIlter.Height = 60;
            supplierFIlter.Margin = new Padding(0);
            supplierFIlter.Padding = new Padding(0);

            var orderTable = CreateOrderTable();
            SupplierStyle.ApplyStyleTable(orderTable);
            orderTable.Dock = DockStyle.Fill;
            orderTable.BorderStyle = BorderStyle.None;
            orderTable.Margin = new Padding(8, 0, 0, 0);

            ShowDataTable(orderTable);
            this.splitContainer1.Panel2.Controls.Add(orderTable);
            this.splitContainer1.Panel2.Controls.Add(supplierFIlter);



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
                Name = "FinalAmount",
                HeaderText = "Tổng tiền",
                ValueType = typeof(decimal)
            };


            var dateCol = new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Ngày",
                ValueType = typeof(DateTime)
            };



            var actionCol = new DataGridViewImageColumn
            {
                Name = "Action",
                HeaderText = "Hành động",
                Image = IconChar.Edit.ToBitmap(Color.DodgerBlue, 20),
                Width = 50
            };


            dataGridView.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "Action")
                {
                    var id = dataGridView.Rows[e.RowIndex].Cells["Id"].Value?.ToString();
                    MessageBox.Show($"Xem chi tiết đơn hàng: {id}");
                }
                if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex].Name == "Selected")
                {
                    var cell = dataGridView.Rows[e.RowIndex].Cells["Selected"] as DataGridViewCheckBoxCell;

                    bool currentValue = Convert.ToBoolean(cell.Value ?? false);
                    bool newValue = !currentValue;
                    cell.Value = newValue;

                    string id = dataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                    if (newValue)
                    {
                        AddItemSelected(id);
                    }
                    else
                    {
                        RemoveItemSelected(id);
                    }

                }
            };



            dataGridView.Columns.Add(actionCol);
            dataGridView.Columns.Add("Id", "ID");
            dataGridView.Columns.Add("Employee", "Nhân viên bán");
            dataGridView.Columns.Add("Customer", "Khách hàng");
            dataGridView.Columns.Add("Product", "Hàng");
            dataGridView.Columns.Add(amountCol);

            dataGridView.Columns.Add("Status", "Trạng thái");
            dataGridView.Columns.Add("PaymentMethod", "Thanh toán");

            dataGridView.Columns.Add(dateCol);
            AddHeaderCheckbox(dataGridView);
            dataGridView.Columns["Selected"].DisplayIndex = 0;
            dataGridView.Columns["Id"].DisplayIndex = 1;
            dataGridView.Columns["Employee"].DisplayIndex = 2;
            dataGridView.Columns["Customer"].DisplayIndex = 3;
            dataGridView.Columns["Product"].DisplayIndex = 4;
            dataGridView.Columns["FinalAmount"].DisplayIndex = 5;
            dataGridView.Columns["Status"].DisplayIndex = 6;
            dataGridView.Columns["PaymentMethod"].DisplayIndex = 7;
            dataGridView.Columns["Date"].DisplayIndex = 8;
            dataGridView.Columns["Action"].DisplayIndex = 9;
            dataGridView.Columns["FinalAmount"].SortMode = DataGridViewColumnSortMode.Programmatic;


            SetFixedColumns(dataGridView);
            dataGridView.Columns["FinalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["FinalAmount"].DefaultCellStyle.Format = "N0";
            dataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;






            return dataGridView;
        }
        private void SetFixedColumns(DataGridView dgv)
        {
            // Khóa các cột không cho resize
            dgv.Columns["Selected"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Id"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Date"].Resizable = DataGridViewTriState.False;
            dgv.Columns["FinalAmount"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Status"].Resizable = DataGridViewTriState.False;
            dgv.Columns["PaymentMethod"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Selected"].Width = 10;
            dgv.Columns["Id"].Width = 20;
            dgv.Columns["Date"].Width = 100;
            dgv.Columns["FinalAmount"].Width = 120;
            dgv.Columns["Status"].Width = 100;
            dgv.Columns["PaymentMethod"].Width = 100;
        }

        private void ShowDataTable(DataGridView table)
        {
            for (int i = 0; i < 10; i++)
            {

                var row = table.Rows[table.Rows.Add()];


                row.Cells["Selected"].Value = false;
                row.Cells["Id"].Value = "O001";
                row.Cells["Employee"].Value = "Nguyễn Văn A";
                row.Cells["Customer"].Value = "Trần Thị B";
                row.Cells["Product"].Value = "iPhone 15";
                row.Cells["FinalAmount"].Value = 25000000m;
                row.Cells["Status"].Value = "Hoàn tất";
                row.Cells["PaymentMethod"].Value = "Tiền mặt";
                row.Cells["Date"].Value = new DateTime(2025, 10, 25);


                var row2 = table.Rows[table.Rows.Add()];
                row2.Cells["Selected"].Value = false;
                row2.Cells["Id"].Value = "O002";
                row2.Cells["Employee"].Value = "Nguyễn Văn B";
                row2.Cells["Customer"].Value = "Lê Minh C";
                row2.Cells["Product"].Value = "MacBook Air";
                row2.Cells["FinalAmount"].Value = 32000000m;
                row2.Cells["Status"].Value = "Chờ xử lý";
                row2.Cells["PaymentMethod"].Value = "Chuyển khoản";
                row2.Cells["Date"].Value = new DateTime(2025, 10, 25);
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


        private void MainSupplierUI_Load(object sender, EventArgs e)
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
