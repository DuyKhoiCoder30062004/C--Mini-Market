using MiniStore.Commom.Dtos;
using MiniStore.Modules.SupplierManager.DAL;
using MiniStore.Modules.SupplierManager.Dtos;


namespace MiniStore.Modules.SupplierManager.BLL
{
    public class SupplierBLL
    {
        private readonly SupplierDAL _supplierDAL;
        public SupplierBLL()
        {
            _supplierDAL = new SupplierDAL();
        }

        public DataResponse<List<SupplierDto>> GetListSupplier()
        {
            return _supplierDAL.GetListSupplier();
        }

        public DataResponse<SupplierDto> UpdateSupplier(SupplierDto supplier)
        {
            return _supplierDAL.UpdateSupplier(supplier);
        }

        public DataResponse<SupplierDto> AddSupplier(SupplierDto supplier)
        {
            return _supplierDAL.AddSupplier(supplier);
        }

        public DataResponse DeleteSuppliers(List<string> ids) { 
           return _supplierDAL.DeleteOneOrMany(ids);
        }

        public DataResponse RestoreSupplier(string id)
        {
            return _supplierDAL.RestoreSupplier(id);
        }

        public DataResponse<List<SupplierDto>> SearchByNameOrPhone(string searchTerm)
        {
            return _supplierDAL.SearchSuppliers(searchTerm);
        }
    }
}
