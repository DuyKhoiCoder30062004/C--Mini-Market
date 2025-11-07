using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.SupplierManager.Dtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty; 
        public string Address { get; set; } = string.Empty;
        public string  Email { get; set; } =string.Empty;
        public string Status { get; set; } = "Active"; 

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
