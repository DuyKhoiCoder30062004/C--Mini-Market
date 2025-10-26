using FontAwesome.Sharp;
using MiniStore.CoreUI;
using MiniStore.Modules.OrderManager.UI;
using MiniStore.Modules.ProductManager.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.ProductManager
{
    public class ExtensionProductManager
    {
        public static MenuItem Build()
        {
            return new MenuItem
            {
                IconChar = IconChar.ProductHunt,
                Title = "Sản phẩm",
                Content = new MainProductManagerUI()
            };

        }
    }
}
