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
    public partial class FormCreareSupplier : Form
    {
        private SupplierBLL _supplierBLL;

        public delegate void SupplierAddNewEnventHandler(SupplierDto newSupplier);
        public event SupplierAddNewEnventHandler SupplierAdd;
        public FormCreareSupplier()
        {
            _supplierBLL = new SupplierBLL();
            InitializeComponent();
            SetupLayout();
        }
        private void SetupLayout()
        {
            SupplierStyle.ApplyStyleButtonWithICon(ButtonCancel, "Thoát", IconChar.Cancel, PurchaseOrderStyle.DANGER_COLOR);
            SupplierStyle.ApplyStyleButtonWithICon(ButtonSave, "Lưu", IconChar.Save, PurchaseOrderStyle.PRIMARY_COLOR);
            InputStatus.Items.AddRange(SupplierConstants.GetArrayStatusSupplier());
        }

        public SupplierDto? GetSupplierData()
        {
            SupplierDto newSupplier = new SupplierDto();
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
            newSupplier.Email = email;
            newSupplier.Name = name;
            newSupplier.Phone = phone;
            newSupplier.Address = address;
            newSupplier.ContactPerson = contactPerson;
            newSupplier.Status = InputStatus.Text.Trim();
            newSupplier.CreatedAt = DateTime.Now;
            return newSupplier;
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
                var data = GetSupplierData();
                if (data != null)
                {
                    var res = _supplierBLL.AddSupplier(data);
                    MessageBox.Show(res.Message);
                    if(res.Success)
                    {
                      
                        SupplierAdd?.Invoke(res.Data);
                        Close();
                    }
                }


            };
        }
        private void FormCreareSupplier_Load(object sender, EventArgs e)
        {
            HandleClickButtonCancel();
            HandleButtonSave();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {

        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {

        }
       
    }
}
