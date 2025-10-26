using FontAwesome.Sharp;
using MiniStore.CoreUI;
using MiniStore.Modules.OrderManager.UI;
using MiniStore.Modules.SupplierManager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.SupplierManager
{
    public class ExtensionSupplierManager
    {
        public static MenuItem Build()
        {
            return new MenuItem
            {
                IconChar = IconChar.Truck,
                Title = "Nhà cung cấp",
                Content = new MainSupplierUI()
            };

        }
    }
}
