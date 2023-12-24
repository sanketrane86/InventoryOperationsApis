using InventoryOperationsApis.Models.ResponseModels;

namespace InventoryOperationsApis.Models.SwaggerModels
{
    public class SwaggerInventoryResponse
    {
        public SwaggerInventoryResponse()
        {

        }
        public SwaggerInventoryResponse(bool IsSuccess = false, long ReturnID = 0, string StatusCode = "", string Message = "", InventoryResponseList objInventoryList = null)
        {
            this.IsSuccess = IsSuccess;
            this.ReturnID = ReturnID;
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Data = (objInventoryList == null) ? new InventoryResponseList() : objInventoryList;
        }
        public bool IsSuccess { get; set; }
        public long ReturnID { get; set; }
        public string? StatusCode { get; set; }
        public string? Message { get; set; }

        public InventoryResponseList Data { get; set; }

    }

    public class InventoryResponseList
    {
        public List<InventoryResponse> InventoryList { get; set; }

    }


    public class SwaggerBrandResponse
    {
        public SwaggerBrandResponse()
        {

        }
        public SwaggerBrandResponse(bool IsSuccess = false, long ReturnID = 0, string StatusCode = "", string Message = "", BrandResponseList objBrandResponseList = null)
        {
            this.IsSuccess = IsSuccess;
            this.ReturnID = ReturnID;
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Data = (objBrandResponseList == null) ? new BrandResponseList() : objBrandResponseList;
        }
        public bool IsSuccess { get; set; }
        public long ReturnID { get; set; }
        public string? StatusCode { get; set; }
        public string? Message { get; set; }

        public BrandResponseList Data { get; set; }

    }

    public class BrandResponseList
    {
        public List<BrandResponse> BrandList { get; set; }

    }

    public class SwaggerItemResponse
    {
        public SwaggerItemResponse()
        {

        }
        public SwaggerItemResponse(bool IsSuccess = false, long ReturnID = 0, string StatusCode = "", string Message = "", ItemResponseList objItemResponseList = null)
        {
            this.IsSuccess = IsSuccess;
            this.ReturnID = ReturnID;
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Data = (objItemResponseList == null) ? new ItemResponseList() : objItemResponseList;
        }
        public bool IsSuccess { get; set; }
        public long ReturnID { get; set; }
        public string? StatusCode { get; set; }
        public string? Message { get; set; }

        public ItemResponseList Data { get; set; }

    }

    public class ItemResponseList
    {
        public List<ItemResponse> ItemList { get; set; }

    }
}
