using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.OrderManager.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Decimal FinalPrice { get; set; }

        public string ProductName { get; set; }
    }
}
