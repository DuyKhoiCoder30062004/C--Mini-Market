using MiniStore.Commom.Config;
using MiniStore.Commom.Dtos;
using MiniStore.Modules.PurchaseOrder.Dtos;
using MiniStore.Modules.SupplierManager.Dtos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.PurchaseOrder.DAL
{
    public class PurchaseOrderDAL
    {
        public DataResponse<List<PurchaseOrderDto>> GetPurchaseOrders()
        {
   
            string sql = PurchaseOrderSqlProvider.GET_ALL_ORDERS;

            var orders = new List<PurchaseOrderDto>();

            using (var connection = AppDbConnect.GetConnection())
            {
                if (connection == null) return DataResponse<List<PurchaseOrderDto>>.Failed("Lõi kết nối DB");

                try
                {
                    using (var command = new MySqlCommand(sql, connection))
                    {
              
                        using (var reader = command.ExecuteReader())
                        {
                           
                            while (reader.Read())
                            {
                               
                                orders.Add(ToPurchaseOrderDto(reader));
                            }
                        }
                    }

      
                    return DataResponse<List<PurchaseOrderDto>>.Ok(orders, "Lấy danh sách đơn nhập hàng thành công.");
                }
                catch (Exception ex)
                {
                 
                    return DataResponse<List<PurchaseOrderDto>>.Failed($"Lỗi truy vấn DB: {ex.Message}");
                }
            }
        }

        private PurchaseOrderDto ToPurchaseOrderDto(MySqlDataReader reader)
        {
            return new PurchaseOrderDto
            {

                Id = reader.GetInt32("id"),
                Code = reader.GetString("code"),
                SupplierId = reader.GetInt32("supplier_id"),
                OrderDate = reader.GetDateTime("order_date"),
                TotalAmount = reader.GetDecimal("total_amount"),
                Status = reader.GetString("status"),
                CreatedAt = reader.GetDateTime("created_at"),
                ExpectedDate = reader.IsDBNull("expected_date") ? (DateTime?)null : reader.GetDateTime("expected_date"),
                UpdatedAt = reader.IsDBNull("updated_at") ? (DateTime)reader.GetDateTime("created_at") : reader.GetDateTime("updated_at"),
                PaymentMethod = reader.IsDBNull("payment_method") ? string.Empty : reader.GetString("payment_method"),
                SupplierName = reader.IsDBNull("supplier_name") ? string.Empty : reader.GetString("supplier_name")
            };

        }
    }
}
