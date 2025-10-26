using FontAwesome.Sharp;
using MiniStore.CoreUI;
using MiniStore.Modules.OrderManager.UI;


namespace MiniStore.Modules.OrderManager
{
    public class ExtensionOrderManager

    {
        public static MenuItem Build()
        {
            return new MenuItem
            {
                IconChar = IconChar.FileInvoice,
                Title = "Đơn hàng",
                Content = new MainOrderUI()
            };

        }
    }
}
