using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.SupplierManager.Dtos
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = string.Empty;

       
        public string ContactPerson { get; set; } = string.Empty;


        public string PhoneNumber { get; set; } = string.Empty;

      
        public string Email { get; set; } = string.Empty;


        public string Address { get; set; } = string.Empty;
    }
}
