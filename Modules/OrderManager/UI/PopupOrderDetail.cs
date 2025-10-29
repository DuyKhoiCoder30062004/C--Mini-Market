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
    public partial class PopupOrderDetail : Form
    {
        public PopupOrderDetail()
        {
            InitializeComponent();
            SetupLayout();
      
        }
         private void SetupLayout()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        private void PopupOrderDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
