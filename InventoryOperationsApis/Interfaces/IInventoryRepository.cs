using InventoryOperationsApis.Models.RequestModels;
using InventoryOperationsApis.Models.ResponseModels;

namespace InventoryOperationsApis.Interfaces
{
    public interface IInventoryRepository
    {
        public ServiceResponse GetAllInventory(TableOperations objTableOperations);
        public ServiceResponse GetById(int id);
        public ServiceResponse GetByItemId(int itemId);
        public ServiceResponse PostInventory(InventoryRequest objInventoryRequest);
        public ServiceResponse PutInventory(InventoryRequest objInventoryRequest);
        public ServiceResponse DeleteInventory(int id);
    }
}
