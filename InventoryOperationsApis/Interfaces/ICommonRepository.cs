using InventoryOperationsApis.Models.RequestModels;
using InventoryOperationsApis.Models.ResponseModels;

namespace InventoryOperationsApis.Interfaces
{
    public interface ICommonRepository
    {
        public ServiceResponse GetAllBrands();
        public ServiceResponse GetAllItems();

        public ServiceResponse GetItemById(int itemId);

        public ServiceResponse GetBrandById(int brandId);
    }
}
