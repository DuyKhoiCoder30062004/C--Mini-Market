using FontAwesome.Sharp;
using MiniStore.Modules.OrderManager.UI;
using MiniStore.Modules.SupplierManager.BLL;
using MiniStore.Modules.SupplierManager.Dtos;
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
        private readonly SupplierBLL _supplierBLL;
        private List<SupplierDto> _supplierDtos;
        private DataGridView _supplierTable;
        public MainSupplierUI()
        {
            _supplierBLL = new SupplierBLL();
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

            _supplierTable = CreateSupplierTable();
            SupplierStyle.ApplyStyleTable(_supplierTable);
            _supplierTable.Dock = DockStyle.Fill;
            _supplierTable.BorderStyle = BorderStyle.None;
            _supplierTable.Margin = new Padding(8, 0, 0, 0);
            SetFixedColumns(_supplierTable);
            this.splitContainer1.Panel2.Controls.Add(_supplierTable);
            this.splitContainer1.Panel2.Controls.Add(supplierFIlter);

            LoadData();

            LoadSupplierDataTable(_supplierTable, _supplierDtos);

            supplierFIlter.GetButtonRefresh().Click += (obj, e) =>
            {
                LoadSupplierDataTable(_supplierTable, _supplierDtos);
            };

            header.GetButtonCreate().Click += (obj, e) =>
            {
                var formCreate = new FormCreareSupplier();
                formCreate.ShowDialog();
                formCreate.SupplierAdd += HandleEventAddNewSupplier;
            };

            header.GetButtonDelete().Click += (obj, e) =>
            {
                if (itemsSelected.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhà  cung cấp cần xóa");
                    return;
                }
                else
                {

                    if (itemsSelected.Count > 2)
                    {
                        var warningResult = MessageBox.Show(
                            $"Bạn đang chọn xóa {itemsSelected.Count} nhà cung cấp cùng lúc. Thao tác này không thể hoàn tác.\n\nBạn có chắc chắn muốn tiếp tục xóa hàng loạt?",
                            "CẢNH BÁO XÓA HÀNG LOẠT",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2
                        );


                        if (warningResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    var opt = MessageBox.Show("Xác nhận xóa nhà cung cấp", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opt == DialogResult.OK)
                    {
                        var res = _supplierBLL.DeleteSuppliers(itemsSelected);
                        MessageBox.Show(res.Message);
                        if (res.Success)
                        {

                            _supplierDtos.RemoveAll(supplier => itemsSelected.Contains(supplier.Id.ToString()));
                            LoadSupplierDataTable(_supplierTable, _supplierDtos);
                            itemsSelected = new List<string>();
                        }
                    }
                }

            };

            supplierFIlter.GetButtonFilter().Click += (obj, ev) =>
            {
                var filterValue = supplierFIlter.GetValueFilter();

                if (filterValue != null)
                {

                    IEnumerable<SupplierDto> filteredList = _supplierDtos;


                    if (filterValue.TimeStart.HasValue && filterValue.TimeEnd.HasValue)
                    {

                        filteredList = filteredList.Where(sup =>
                            sup.CreatedAt >= filterValue.TimeStart.Value &&
                            sup.CreatedAt <= filterValue.TimeEnd.Value
                        );
                    }

                    if (!string.IsNullOrEmpty(filterValue.status))
                    {

                        filteredList = filteredList.Where(sup =>
                            sup.Status == filterValue.status
                        );
                    }


                    var list = filteredList.ToList();
                    if (list.Count == 0)
                    {
                        MessageBox.Show("Không có kết quả nào trùng khớp");
                    }
                    else
                    {
                        LoadSupplierDataTable(_supplierTable, list);
                    }
                }
            };

            header.GetButtonSearch().Click += (obj, ev) =>
            {
                string searchTerm = header.GetInputSearch().Text.Trim();
                if (String.IsNullOrWhiteSpace(searchTerm)) return;
                if (searchTerm.Contains("Nhập mã hoặc tên khách hàng...")) return;
                var res = _supplierBLL.SearchByNameOrPhone(searchTerm);
                if (res.Success && res.Data != null)
                {
                    if (res.Data.Count > 0)
                    {

                        LoadSupplierDataTable(_supplierTable, res.Data);
                        MessageBox.Show($"Tìm thấy {res.Data.Count} kết quả khớp với '{searchTerm}'.", "Tìm kiếm hoàn tất");
                    }
                    else
                    {

                        LoadSupplierDataTable(_supplierTable, _supplierDtos);
                        MessageBox.Show($"Không tìm thấy nhà cung cấp nào khớp với '{searchTerm}'.", "Không tìm thấy");
                    }
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            };

        }
        private void HandleEventAddNewSupplier(SupplierDto supplierDto)
        {
            _supplierDtos.Add(supplierDto);
            LoadSupplierDataTable(_supplierTable, _supplierDtos);
        }


        private void LoadData()
        {
            var response = _supplierBLL.GetListSupplier();
            if (response.Success == false)
            {
                MessageBox.Show(response.Message, "Lổi tải dữ liệu");
                return;
            }
            _supplierDtos = response.Data;
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
        private DataGridView CreateSupplierTable()
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
                Width = 900
            };


            var checkCol = new DataGridViewCheckBoxColumn
            {
                Name = "Selected",
                HeaderText = "",
                Width = 10,
                ReadOnly = false
            };
            dataGridView.Columns.Add(checkCol);


            var createdDateCol = new DataGridViewTextBoxColumn
            {
                Name = "CreatedAt",
                HeaderText = "Ngày tạo",
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
                    var supplier = _supplierDtos.Where(s => s.Id.ToString() == id).First();
                    var popup = new PopupSupplier();
                    popup.Text = "Chi tiết nhà cung cấp";
                    popup.SupplierUpdated += Popup_SupplierUpdated;
                    popup.ShowSupplierData(supplier);
                    popup.ShowDialog();

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
            dataGridView.Columns.Add("Name", "Tên NCC");

            dataGridView.Columns.Add("Contact", "Người liên hệ");
            dataGridView.Columns.Add("Phone", "Số điện thoại");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("Address", "Địa chỉ");
            dataGridView.Columns.Add("Status", "Trạng thái");

            dataGridView.Columns.Add(createdDateCol);

            AddHeaderCheckbox(dataGridView);
            dataGridView.Columns["Selected"].DisplayIndex = 0;
            dataGridView.Columns["Id"].DisplayIndex = 1;
            dataGridView.Columns["Name"].DisplayIndex = 2;
            dataGridView.Columns["Contact"].DisplayIndex = 3;
            dataGridView.Columns["Phone"].DisplayIndex = 4;
            dataGridView.Columns["Email"].DisplayIndex = 5;
            dataGridView.Columns["Address"].DisplayIndex = 6;
            dataGridView.Columns["Status"].DisplayIndex = 7;
            dataGridView.Columns["CreatedAt"].DisplayIndex = 8;
            dataGridView.Columns["Action"].DisplayIndex = 9;


            dataGridView.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView.Columns["CreatedAt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            return dataGridView;
        }

        private void Popup_SupplierUpdated(SupplierDto updatedSupplier)
        {
            var oldSupplier = _supplierDtos.FirstOrDefault(s => s.Id == updatedSupplier.Id);
            if (oldSupplier != null)
            {
                int index = _supplierDtos.FindIndex(s => s.Id == updatedSupplier.Id);
                if (index >= 0)
                {
                    _supplierDtos[index] = updatedSupplier;
                }
            }
            LoadSupplierDataTable(_supplierTable, _supplierDtos);
        }

        private void SetFixedColumns(DataGridView dgv)
        {
            dgv.Columns["Selected"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Id"].Resizable = DataGridViewTriState.False;
            dgv.Columns["CreatedAt"].Resizable = DataGridViewTriState.False;
            dgv.Columns["Status"].Resizable = DataGridViewTriState.False;


            dgv.Columns["Selected"].Width = 30;
            dgv.Columns["Id"].Width = 20;
            dgv.Columns["CreatedAt"].Width = 100;
            dgv.Columns["Status"].Width = 80;
            dgv.Columns["Name"].Width = 200;
            dgv.Columns["Contact"].Width = 100;
        }

        private void LoadSupplierDataTable(DataGridView table, List<SupplierDto> list)
        {

            table.Rows.Clear();



            foreach (var supplier in list)
            {
                var rowIndex = table.Rows.Add();
                var row = table.Rows[rowIndex];


                row.Cells["Selected"].Value = false;
                row.Cells["Id"].Value = supplier.Id;
                row.Cells["Name"].Value = supplier.Name;
                row.Cells["Contact"].Value = supplier.ContactPerson;
                row.Cells["Phone"].Value = supplier.Phone;
                row.Cells["Email"].Value = supplier.Email;
                row.Cells["Address"].Value = supplier.Address;
                row.Cells["Status"].Value = supplier.Status;
                row.Cells["CreatedAt"].Value = supplier.CreatedAt;
            }
            foreach (var supplier in list)
            {
                var rowIndex = table.Rows.Add();
                var row = table.Rows[rowIndex];


                row.Cells["Selected"].Value = false;
                row.Cells["Id"].Value = supplier.Id;
                row.Cells["Name"].Value = supplier.Name;
                row.Cells["Contact"].Value = supplier.ContactPerson;
                row.Cells["Phone"].Value = supplier.Phone;
                row.Cells["Email"].Value = supplier.Email;
                row.Cells["Address"].Value = supplier.Address;
                row.Cells["Status"].Value = supplier.Status;
                row.Cells["CreatedAt"].Value = supplier.CreatedAt;
            }
            foreach (var supplier in list)
            {
                var rowIndex = table.Rows.Add();
                var row = table.Rows[rowIndex];


                row.Cells["Selected"].Value = false;
                row.Cells["Id"].Value = supplier.Id;
                row.Cells["Name"].Value = supplier.Name;
                row.Cells["Contact"].Value = supplier.ContactPerson;
                row.Cells["Phone"].Value = supplier.Phone;
                row.Cells["Email"].Value = supplier.Email;
                row.Cells["Address"].Value = supplier.Address;
                row.Cells["Status"].Value = supplier.Status;
                row.Cells["CreatedAt"].Value = supplier.CreatedAt;
            }
            foreach (var supplier in list)
            {
                var rowIndex = table.Rows.Add();
                var row = table.Rows[rowIndex];


                row.Cells["Selected"].Value = false;
                row.Cells["Id"].Value = supplier.Id;
                row.Cells["Name"].Value = supplier.Name;
                row.Cells["Contact"].Value = supplier.ContactPerson;
                row.Cells["Phone"].Value = supplier.Phone;
                row.Cells["Email"].Value = supplier.Email;
                row.Cells["Address"].Value = supplier.Address;
                row.Cells["Status"].Value = supplier.Status;
                row.Cells["CreatedAt"].Value = supplier.CreatedAt;
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

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
