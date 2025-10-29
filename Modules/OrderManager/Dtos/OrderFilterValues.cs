using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.OrderManager.Dtos
{
    public class OrderFilterValues
    {
        public string KeySearch { get; set; } = string.Empty;
        public string StatusOrder { get; set; } = StatusOrderEnum.None.ToString();
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public string Sort { get; set; }

    }
}
