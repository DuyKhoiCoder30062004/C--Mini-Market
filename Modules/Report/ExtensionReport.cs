using FontAwesome.Sharp;
using MiniStore.CoreUI;
using MiniStore.Modules.OrderManager.UI;
using MiniStore.Modules.Report.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.Report
{
    public class ExtensionReport
    {
        public static MenuItem Build()
        {
            return new MenuItem
            {
                IconChar = IconChar.ChartColumn,
                Title = "Thông kê",
                Content = new MainReportUI()
            };

        }
    }
}
