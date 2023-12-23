using InventoryOperationsApis.Interfaces;
using InventoryOperationsApis.Models.RequestModels;
using InventoryOperationsApis.Models.ResponseModels;
using System.Data;
using Dapper;

namespace InventoryOperationsApis.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        IDbConnection IDB;
        ServiceResponse serviceResponse;

        public CommonRepository(BaseConnectionRepository BCR, ServiceResponse objServiceResponse)
        {
            IDB = BCR.CreateConnection();
            serviceResponse = objServiceResponse;
        }
        
        public ServiceResponse GetAllBrands()
        {
                      
            var spName = "sp_brands_list";
           
            var objRetobject = this.IDB.QueryMultiple(spName, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            if (serviceResponse.IsSuccess)
            {
                List<BrandResponse> lstBrand = objRetobject.Read<BrandResponse>().ToList();
                
                serviceResponse.Data = new
                {
                    BrandList = lstBrand,                
                };
            }

            return serviceResponse;
        }

        public ServiceResponse GetAllItems()
        {

            var spName = "sp_items_list";

            var objRetobject = this.IDB.QueryMultiple(spName, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            if (serviceResponse.IsSuccess)
            {
                List<ItemResponse> lstItem = objRetobject.Read<ItemResponse>().ToList();

                serviceResponse.Data = new
                {
                    ItemList = lstItem,
                };
            }

            return serviceResponse;
        }

        public ServiceResponse GetBrandById(int brandId)
        {
            var spName = "sp_brand_by_id_select";

            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @bran_id = brandId
            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            if (serviceResponse.IsSuccess)
            {
                List<BrandResponse> lstBrand = objRetobject.Read<BrandResponse>().ToList();
                serviceResponse.Data = new
                {
                    BrandList = lstBrand
                };
            }

            return serviceResponse;
        }

        public ServiceResponse GetItemById(int itemId)
        {
            var spName = "sp_item_by_id_select";

            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @item_id = itemId
            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            if (serviceResponse.IsSuccess)
            {
                List<ItemResponse> lstItem = objRetobject.Read<ItemResponse>().ToList();
                serviceResponse.Data = new
                {
                    ItemList = lstItem
                };
            }

            return serviceResponse;
        }
    }
}
