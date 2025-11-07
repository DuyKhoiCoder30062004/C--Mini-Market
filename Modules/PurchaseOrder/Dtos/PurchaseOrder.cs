using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.PurchaseOrder.Dtos
{
    public class PurchaseOrderDto
    {

        public int Id { get; set; }


        public string Code { get; set; } = string.Empty;


        public int SupplierId { get; set; }

        public  string? SupplierName { get; set; } 


        public DateTime OrderDate { get; set; }


        public DateTime? ExpectedDate { get; set; }

        public decimal TotalAmount { get; set; } = 0m;

        public string Status { get; set; } = "pending";

        public string PaymentMethod { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public List<PurchaseOrderItemDto> Items { get; set; } = new List<PurchaseOrderItemDto>();
    }
}
