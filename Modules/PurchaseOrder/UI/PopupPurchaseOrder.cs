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

namespace MiniStore.Modules.PurchaseOrder.UI
{
    public partial class PopupPurchaseOrder : Form
    {
        public PopupPurchaseOrder()
        {
            InitializeComponent();
            SetupLayout();
            
        }

        private void SetupLayout()
        {
            PurchaseOrderStyle.ApplyStyleButtonWithICon(ButtonCancel, "Thoát", IconChar.Cancel, PurchaseOrderStyle.DANGER_COLOR);
            PurchaseOrderStyle.ApplyStyleButtonWithICon(ButtonSave,"Lưu",IconChar.Save, PurchaseOrderStyle.PRIMARY_COLOR);
            
          


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
              
            };
        }

      


        public void SetTile(string title)
        {
            this.Text = title;
        }

        private void PopupPurchaseOrder_Load(object sender, EventArgs e)
        {
            HandleClickButtonCancel();
            HandleButtonSave();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
