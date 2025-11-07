using MiniStore.Commom.Dtos;
using MiniStore.Modules.PurchaseOrder.DAL;
using MiniStore.Modules.PurchaseOrder.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.PurchaseOrder.BLL
{
    public class PurchaseOrderBLL
    {
        private readonly PurchaseOrderDAL _purchaseOrderDAL;
        public PurchaseOrderBLL() { 
         _purchaseOrderDAL = new PurchaseOrderDAL();
        }

        public DataResponse<List<PurchaseOrderDto>> GetListPurchaseOrder()
        {
            return _purchaseOrderDAL.GetPurchaseOrders();
        }
    }
}
