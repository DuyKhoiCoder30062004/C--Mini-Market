using MiniStore.Commom.Config;
using MiniStore.Modules.OrderManager.Dtos;
using MiniStore.Modules.SupplierManager.Constants;
using MiniStore.Modules.SupplierManager.Dtos;
using MySql.Data.MySqlClient;
using MiniStore.Commom.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Modules.SupplierManager.DAL
{
    public class SupplierDAL
    {
        public DataResponse<SupplierDto> AddSupplier(SupplierDto supplier)
        {
            string sql = SupplierSqlProvider.INSERT_SUPPLIER;
            using(var connection = AppDbConnect.GetConnection())
            {
                if (connection == null) return DataResponse<SupplierDto>.Failed(message:"Lỗi kêt nối đến DB");

                try
                {
                    var checkSupplier = GetSupplierByPhone(supplier.Phone);
                    if(checkSupplier.Success==false)
                    {
                        return DataResponse<SupplierDto>.Failed(message: $"Nhà cung cấp${supplier.Name} đã tồn tại ");
                    }
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@ContactPerson", supplier.ContactPerson);
                        command.Parameters.AddWithValue("@Phone", supplier.Phone);
                        command.Parameters.AddWithValue("@Email", supplier.Email);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@Status",supplier.Status);

                      
                        object newId = command.ExecuteScalar();

                        if (newId != null && newId != DBNull.Value)
                        {
                       
                            supplier.Id = Convert.ToInt32(newId);


                            return DataResponse<SupplierDto>.Ok(supplier, "Thêm nhà cung cấp thành công!");
                        }
                        else
                        {
                           
                            return DataResponse<SupplierDto>.Failed(message: "Lỗi: Không lấy được ID nhà cung cấp vừa thêm.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    return DataResponse<SupplierDto>.Failed(message: $"Lỗi truy vấn DB: {ex.Message}");
                }
            
        }

            
        }

        public DataResponse<List<SupplierDto>> SearchSuppliers(string searchTerm)
        {
            var suppliers = new List<SupplierDto>();


            string sql = SupplierSqlProvider.SEARCH_BY_NAME_OR_PHONE;

            using (var connection = AppDbConnect.GetConnection())
            {
                if (connection == null) return DataResponse<List<SupplierDto>>.Failed("Lỗi kết nối DB");

                try
                {
                  

                    using (var command = new MySqlCommand(sql, connection))
                    {
                       
                        string wildcardTerm = $"%{searchTerm}%";
                        command.Parameters.AddWithValue("@SearchTerm", wildcardTerm);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                              
                                suppliers.Add(ToSupplier(reader));
                            }
                        }
                    }
                    return DataResponse<List<SupplierDto>>.Ok(suppliers, message: $"Tìm thấy {suppliers.Count} nhà cung cấp.");
                }
                catch (Exception ex)
                {
                  
                    return DataResponse<List<SupplierDto>>.Failed("Lỗi thực thi truy vấn tìm kiếm: " + ex.Message);
                }
            }
        }

        public DataResponse<List<SupplierDto>> GetListSupplier()
        {
            var suppliers = new List<SupplierDto>();
            using (var connection = AppDbConnect.GetConnection())
            {
                if (connection == null) return DataResponse<List<SupplierDto>>.Failed("Lõi kết nối DB");
                string sql = SupplierSqlProvider.GET_ALL_SUPPLIERS;
                try
                {
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                suppliers.Add(ToSupplier(reader));
                            }
                        }
                    }
                    return DataResponse<List<SupplierDto>>.Ok(suppliers, message: "Lấy danh sách thành công");
                }
                catch (Exception ex)
                {
                    return DataResponse<List<SupplierDto>>.Failed("Lõi kết nối DB");
                }
            }
        }

        public DataResponse<SupplierDto> UpdateSupplier(SupplierDto supplier)
        {
            var sql = SupplierSqlProvider.UPDATE_SUPPLIER;

            using(var connection = AppDbConnect.GetConnection()) {

                if (connection == null) return DataResponse<SupplierDto>.Failed("lỗi kết nối DB");
                try
                {

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@Phone", supplier.Phone);
                        command.Parameters.AddWithValue("@ContactPerson", supplier.ContactPerson);
                        command.Parameters.AddWithValue("@Address", supplier.Address);
                        command.Parameters.AddWithValue("@Email", supplier.Email);
                        command.Parameters.AddWithValue("@Status", supplier.Status);
                        command.Parameters.AddWithValue("@Id", supplier.Id);
                        command.ExecuteNonQuery();
                        return DataResponse<SupplierDto>.Ok(supplier,message:"Cập nhật thành công");
                    }
                }
                catch (Exception ex) {
                    return DataResponse<SupplierDto>.Failed("Lõi thực thi hành động");

                }
                    
              }
        }

        public DataResponse DeleteOneOrMany(List<string> ids)
        {
            var parameterNames = ids.Select((id, index) => $"@p{index}").ToList();
            string inClause = string.Join(",", parameterNames);
            string query = $@"
        UPDATE Suppliers 
        SET 
            status = 'Deleted', 
            updated_at = NOW() 
        WHERE 
            id IN ({inClause});";
            using (var connection = AppDbConnect.GetConnection())
            {

                if (connection == null) return DataResponse.Failed("lỗi kết nối DB");
                try
                {

                    using (var command = new MySqlCommand(query, connection))
                    {
                        for (int i = 0; i < ids.Count; i++)
                        {
                            
                            command.Parameters.AddWithValue(parameterNames[i], ids[i]);
                        }
                        command.ExecuteNonQuery();
                        return DataResponse.Ok( message: "Xóa thành công");
                    }
                }
                catch (Exception ex)
                {
                    return DataResponse.Failed("Lõi thực thi hành động");

                }

            }

        }

        public DataResponse RestoreSupplier(string id)
        {
            string query = SupplierSqlProvider.RESTORE_SUPPLIER_BY_ID;
            using (var connection = AppDbConnect.GetConnection())
            {
                if (connection == null) return DataResponse.Failed("Lỗi kết nối DB");
                try
                {
                    using (var command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return DataResponse.Ok(message: "Khôi phục thành công");
                        }
                        else
                        {

                            return DataResponse.Failed("Không tìm thấy nhà cung cấp để khôi phục.");
                        }
                    }
                    }catch(Exception e)
                {
                    return DataResponse.Failed("Lõi thực thi hành động");
                }
            }
        }

        public  DataResponse<SupplierDto> GetSupplierByPhone(string phone)
        {
            string sql = SupplierSqlProvider.GET_SUPPLIER_BY_PhONE;

            using(var connection = AppDbConnect.GetConnection())
            {
                if (connection == null) return DataResponse<SupplierDto>.Failed("Lỗi kết nối DB");

                try
                {
                    using(var command = new MySqlCommand(sql,connection))
                    {
                        command.Parameters.AddWithValue("@Phone", phone);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                SupplierDto supplier = ToSupplier(reader);
                                return DataResponse<SupplierDto>.Ok(supplier, message: "Tìm thấy nhà cung cấp.");
                            }
                            else
                            {

                                return DataResponse<SupplierDto>.Failed("Lõi thực thi hành động");
                            }
                        }

                    }
                } catch(Exception ex)
                {
                    return DataResponse<SupplierDto>.Failed("Lõi thực thi hành động");
                }
            }

        }
        
            private SupplierDto ToSupplier(MySqlDataReader reader)
        {
            return new SupplierDto
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                ContactPerson = reader.IsDBNull("contact") ? string.Empty : reader.GetString("contact"),
                Phone = reader.IsDBNull("phone") ? string.Empty : reader.GetString("phone"),
                Email = reader.IsDBNull("email") ? string.Empty : reader.GetString("email"),
                Address = reader.IsDBNull("address") ? string.Empty : reader.GetString("address"),
                Status = reader.GetString("status"),
                CreatedAt = reader.GetDateTime("created_at"),
                UpdatedAt = reader.IsDBNull("updated_at") ? (DateTime?)null : reader.GetDateTime("updated_at")
            };
        }
       
    }
}
