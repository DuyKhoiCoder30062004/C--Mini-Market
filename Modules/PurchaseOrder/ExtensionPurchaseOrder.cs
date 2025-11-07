using FontAwesome.Sharp;
using MiniStore.CoreUI;
using MiniStore.Modules.ProductManager.UI;
using MiniStore.Modules.PurchaseOrder.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.PurchaseOrder
{
    public class ExtensionPurchaseOrder
    {
        public static MenuItem Build()
        {
            return new MenuItem
            {
                IconChar = IconChar.ProductHunt,
                Title = "Quản lý phiếu nhập",
                Content = new MainPurchaseOrder()
            };

        }
    }
}
