using FontAwesome.Sharp;
using MiniStore.Modules.PurchaseOrder.UI;
using MiniStore.Modules.SupplierManager.BLL;
using MiniStore.Modules.SupplierManager.Constants;
using MiniStore.Modules.SupplierManager.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniStore.Modules.SupplierManager.UI
{
    public partial class PopupSupplier : Form
    {
        private SupplierDto _supplier;
        private SupplierBLL _supplierBLL;
        public delegate void SupplierUpdatedEventHandler(SupplierDto updatedSupplier);
        public event SupplierUpdatedEventHandler SupplierUpdated;
        public SupplierDto SupplierData
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        public PopupSupplier()
        {
          
            InitializeComponent();
            SetupLayout();
            _supplierBLL = new SupplierBLL();
        }
        private void SetupLayout()
        {
            SupplierStyle.ApplyStyleButtonWithICon(ButtonCancel, "Thoát", IconChar.Cancel, PurchaseOrderStyle.DANGER_COLOR);
            SupplierStyle.ApplyStyleButtonWithICon(ButtonSave, "Lưu", IconChar.Save, PurchaseOrderStyle.PRIMARY_COLOR);
            SupplierStyle.ApplyStyleLable(LableHistoryTransaction, "Lịch sử giao dịch");
            LableHistoryTransaction.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            InputStatus.Items.AddRange(SupplierConstants.GetArrayStatusSupplier());
            InputStatus.Text = SupplierConstants.STATUS_ACTIVE.ToString();
            var table = CreateInvoiceHistoryTable();
            table.Dock = DockStyle.Fill;
            table.BorderStyle = BorderStyle.None;
            table.Margin = new Padding(8, 0, 0, 10);
            SupplierStyle.ApplyStyleTable(table);
            panel2.Controls.Add(table);
            InitialDataTable(table);
            HandleButtonSave();
            HandleClickButtonCancel();
        }

        public void ShowSupplierData(SupplierDto supplier)
        {
            _supplier = supplier;
            InputId.Enabled = false;
            InputUpdateAt.Enabled = false;
            InputCreateAt.Enabled = false;
            if (_supplier.Status==SupplierConstants.STATUS_INACTIVE)
            {
                InputName.Enabled = false;
                InputPhone.Enabled = false;
                InputAddress.Enabled = false;
                InputEmail.Enabled = false;
                InputContact.Enabled = false;
            }
            if(_supplier.Status==SupplierConstants.STATUS_DELETED)
            {
                InputName.Enabled = false;
                InputPhone.Enabled = false;
                InputAddress.Enabled = false;
                InputEmail.Enabled = false;
                InputContact.Enabled = false;
                InputStatus.Enabled = false;
                SupplierStyle.ApplyStyleButtonWithICon(ButtonSave, "khôi phục", IconChar.Save, PurchaseOrderStyle.PRIMARY_COLOR);
            }
            InputId.Text = _supplier.Id.ToString();
            InputName.Text = _supplier.Name;
            InputPhone.Text = _supplier.Phone;
            InputEmail.Text = _supplier.Email;
            InputContact.Text = _supplier.ContactPerson;
            InputStatus.Text = _supplier.Status;   
            InputAddress.Text = _supplier.Address;
            InputCreateAt.Text = _supplier.CreatedAt.ToString();
            InputUpdateAt.Text = _supplier.UpdatedAt.ToString();


        }
        public SupplierDto? GetSupplierData()
        {
            SupplierDto updatedSupplier = _supplier;
            updatedSupplier.Id = _supplier.Id;
            string name = InputName.Text.Trim();
            string phone = InputPhone.Text.Trim();
            string address = InputAddress.Text.Trim();
            string email = InputEmail.Text.Trim();
            string contactPerson = InputContact.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputName.Focus();
                return null;
            }

            if (string.IsNullOrEmpty(contactPerson))
            {
                MessageBox.Show("Tên người liên hệ không được để trống.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputContact.Focus();
                return null;
            }


            string vnPhonePattern = @"^(0|(\+84))[3|5|7|8|9](\d{8}|\d{9})$";

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputPhone.Focus();
                return null;
            }

            if (!Regex.IsMatch(phone, vnPhonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập SĐT Việt Nam hợp lệ (ví dụ: 09x, 03x, ...).", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputPhone.Focus();
                return null;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrEmpty(email) && !System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Địa chỉ Email không hợp lệ.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputEmail.Focus();
                return null;
            }
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Địa chỉ Email không hợp lệ.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputEmail.Focus();
                return null;
            }
            updatedSupplier.Email = email;
            updatedSupplier.Name = name;
            updatedSupplier.Phone = phone;
            updatedSupplier.Address = address;
            updatedSupplier.ContactPerson = contactPerson;
            updatedSupplier.Status = InputStatus.Text.Trim();
            updatedSupplier.CreatedAt = _supplier.CreatedAt;
            updatedSupplier.UpdatedAt =  DateTime.Now;
            return updatedSupplier;
        }
        private void HandleClickButtonCancel()
        {
            ButtonCancel.Click += (obj, ev) =>
            {
                var opt = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy bỏ thao tác này không?",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );
                if (opt == DialogResult.Yes)
                {
                    Close();
                }
            };
        }
        private void HandleButtonSave()
        {
            ButtonSave.Click += (obj, ev) =>
            {
                if (_supplier.Status == SupplierConstants.STATUS_DELETED)
                {
                    var res = _supplierBLL.RestoreSupplier(_supplier.Id.ToString());
                    _supplier.Status = SupplierConstants.STATUS_ACTIVE;

                    MessageBox.Show(res.Message);
                    if (res.Success)
                    {
                        SupplierUpdated?.Invoke(_supplier);
                        Close();
                    }

                }
                else
                {
                    var data = GetSupplierData();
                    if (data != null)
                    {
                        var res = _supplierBLL.UpdateSupplier(data);

                        MessageBox.Show(res.Message);
                        if (res.Success)
                        {
                            SupplierUpdated?.Invoke(data);
                            Close();
                        }



                    }
                }
            };
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {


        }
        private DataGridView CreateInvoiceHistoryTable()
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


            dataGridView.Columns.Add("Code", "Mã hóa đơn");


            dataGridView.Columns.Add("StaffName", "Nhân viên thực hiện");


            var totalAmountCol = new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Tổng tiền",
                ValueType = typeof(decimal)
            };
            dataGridView.Columns.Add(totalAmountCol);


            dataGridView.Columns.Add("PaymentMethod", "Thanh toán");


            var paymentDateCol = new DataGridViewTextBoxColumn
            {
                Name = "PaymentTime",
                HeaderText = "Ngày giao dịch",
                ValueType = typeof(DateTime)
            };
            dataGridView.Columns.Add(paymentDateCol);


            dataGridView.Columns.Add("Id", "ID");



            dataGridView.Columns["Code"].DisplayIndex = 0;         // Mã hóa đơn
            dataGridView.Columns["StaffName"].DisplayIndex = 1;    // Nhân viên thực hiện
            dataGridView.Columns["TotalAmount"].DisplayIndex = 2;  // Tổng tiền
            dataGridView.Columns["PaymentMethod"].DisplayIndex = 3; // Thanh toán
            dataGridView.Columns["PaymentTime"].DisplayIndex = 4;  // Ngày giao dịch
            dataGridView.Columns["Id"].Visible = false;            // Ẩn ID




            dataGridView.Columns["TotalAmount"].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridView.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";


            dataGridView.Columns["PaymentTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dataGridView.Columns["PaymentTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            return dataGridView;
        }

        private void InitialDataTable(DataGridView table)
        {
            for (int i = 0; i < 5; i++)
            {
                var rowIndex = table.Rows.Add();
                var row = table.Rows[rowIndex];
                row.Cells["Code"].Value = "";
                row.Cells["StaffName"].Value = "";
                row.Cells["TotalAmount"].Value = "";

            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PanelInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
