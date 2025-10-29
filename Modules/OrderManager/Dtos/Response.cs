using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.OrderManager.Dtos
{

    public class Response
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
    }

    public class ListOrderResponse : Response
    {
        public List<OrderDto> List { get; set; }
    }

}
