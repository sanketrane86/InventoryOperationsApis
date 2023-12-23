using InventoryOperationsApis.Interfaces;
using InventoryOperationsApis.Models.RequestModels;
using InventoryOperationsApis.Models.ResponseModels;
using System.Data;
using Dapper;

namespace InventoryOperationsApis.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        IDbConnection IDB;
        ServiceResponse serviceResponse;

        public InventoryRepository(BaseConnectionRepository BCR, ServiceResponse objServiceResponse)
        {
            IDB = BCR.CreateConnection();
            serviceResponse = objServiceResponse;
        }
        
        public ServiceResponse GetAllInventory(TableOperations objTableOperations)
        {
                      
            var spName = "sp_inventories_view";
           
            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @FilterTerm = objTableOperations.FilterTerm,
                @SortIndex = objTableOperations.SortIndex,
                @SortDirection = objTableOperations.SortDirection,
                @StartRowNum = objTableOperations.StartRowNum,
                @EndRowNum = objTableOperations.EndRowNum,
                @TotalRowsCount = ParameterDirection.Output,
                @FilteredRowsCount = ParameterDirection.Output
            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            if (serviceResponse.IsSuccess)
            {
                List<InventoryResponse> lstInventory = objRetobject.Read<InventoryResponse>().ToList();
                TablePaging objTablePaging = objRetobject.Read<TablePaging>().FirstOrDefault();
                serviceResponse.Data = new
                {
                    InventoryList = lstInventory,
                    iTotalDisplayRecords = objTablePaging.iTotalDisplayRecords,
                    iTotalRecords = objTablePaging.iTotalRecords,
                };
            }

            return serviceResponse;
        }

        public ServiceResponse GetById(int id)
        {
            var spName = "sp_inventory_by_id_view";
           
            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @inve_id = id
            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            if (serviceResponse.IsSuccess)
            {
                List<InventoryResponse> lstInventory = objRetobject.Read<InventoryResponse>().ToList();
                serviceResponse.Data = new
                {
                    InventoryList = lstInventory
                };
            }

            return serviceResponse;
        }

        public ServiceResponse GetByItemId(int itemId)
        {
            var spName = "sp_inventory_by_itemid_view";

            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @inve_item_id = itemId
            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            if (serviceResponse.IsSuccess)
            {
                List<InventoryResponse> lstInventory = objRetobject.Read<InventoryResponse>().ToList();
                serviceResponse.Data = new
                {
                    InventoryList = lstInventory
                };
            }

            return serviceResponse;
        }

        public ServiceResponse PostInventory(InventoryRequest objInventoryRequest)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var spName = "sp_inventory_insert";
            
            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @inve_item_id= objInventoryRequest.ItemId,
                @inve_bran_id= objInventoryRequest.BrandId,
                @inve_color= objInventoryRequest.Color,
                @inve_size= objInventoryRequest.Size,
                @inve_gender= objInventoryRequest.Gender,
                @inve_price= objInventoryRequest.Price,
                @inve_quantity= objInventoryRequest.Quantity,

            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            return serviceResponse;
        }

        public ServiceResponse PutInventory(InventoryRequest objInventoryRequest)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var spName = "sp_inventory_update";

            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @inve_id = objInventoryRequest.InventoryId,
                @inve_item_id = objInventoryRequest.ItemId,
                @inve_bran_id = objInventoryRequest.BrandId,
                @inve_color = objInventoryRequest.Color,
                @inve_size = objInventoryRequest.Size,
                @inve_gender = objInventoryRequest.Gender,
                @inve_price = objInventoryRequest.Price,
                @inve_quantity = objInventoryRequest.Quantity,

            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            return serviceResponse;
        }
        public ServiceResponse DeleteInventory(int id)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var spName = "sp_inventory_delete";

            var objRetobject = this.IDB.QueryMultiple(spName, new
            {
                @inve_id = id,
               
            }, commandType: CommandType.StoredProcedure);

            serviceResponse = objRetobject.Read<ServiceResponse>().FirstOrDefault();

            return serviceResponse;
        }

    }
}
