// file Bootstrap.cs (Phiên bản đã sửa đổi)

using MiniStore.Commom.Config;
using MiniStore.CoreUI;
using MiniStore.Modules.OrderManager;
using MiniStore.Modules.ProductManager;
using MiniStore.Modules.Report;
using MiniStore.Modules.Seller;
using MiniStore.Modules.SupplierManager;

namespace MiniStore
{
    public class Bootstrap
    {
        public static List<MenuItem> BuildMenuItems() 
        {
             return new List<MenuItem>
            {
                ExtensionReport.Build(),
                ExtensionProductManager.Build(),
                ExtensionOrderManager.Build(),
                ExtensionSeller.Build(),
                ExtensionSupplierManager.Build(),
            };
          
        }
        public static App BuildApp()
        {
            var app = new App();
            app.MenuItems = BuildMenuItems();
            app.StartAppUI();
            //AppDbConnect.TestConnection();
            return app;
        }
    }
}