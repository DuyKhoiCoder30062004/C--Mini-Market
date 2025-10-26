using FontAwesome.Sharp;
using MiniStore.CoreUI;
using MiniStore.Modules.Seller.UI;
using MiniStore.Modules.SupplierManager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.Seller
{
    public class ExtensionSeller
    {
        public static MenuItem Build()
        {
            return new MenuItem
            {
                IconChar = IconChar.ShoppingCart,
                Title = "Bán hàng",
                Content = new MainSellerUI()
            };

        }
    }
}
