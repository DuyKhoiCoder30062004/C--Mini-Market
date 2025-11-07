using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.SupplierManager.Constants
{
    public class SupplierConstants
    {
        public static readonly string STATUS_ACTIVE = "Active";
        public static readonly string STATUS_INACTIVE = "Inactive";
        public static readonly string STATUS_DELETED = "Deleted";

        public static string[] GetArrayStatusSupplier()
        {
            return [STATUS_ACTIVE, STATUS_DELETED, STATUS_INACTIVE];
        }
    }
}
