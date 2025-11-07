using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.PurchaseOrder.Dtos
{
    public class PurchaseOrderItemDto
    {
        public int Id { get; set; }


        public int PurchaseOrderId { get; set; }

      
        public int ProductId { get; set; }


        public decimal Quantity { get; set; }


        public decimal UnitPrice { get; set; }


        public decimal Discount { get; set; } = 0m;

       
        public decimal TotalPrice { get; set; }
    }
}
