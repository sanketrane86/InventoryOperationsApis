using System.ComponentModel;
using System.Net;

namespace InventoryOperationsApis.Models.ResponseModels
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {

        }
        public ServiceResponse(bool IsSuccess = false, long ReturnID = 0, string StatusCode = "", string Message = "", object OptionalDataTemp = null)
        {
            this.IsSuccess = IsSuccess;
            this.ReturnID = ReturnID;
            this.Status = StatusCode;
            this.Title = Message;
            this.Data = (OptionalDataTemp == null) ? new object() : OptionalDataTemp; ;
        }
        public bool IsSuccess { get; set; }
        public long ReturnID { get; set; }
        public string? Status { get; set; }
        public string? Title { get; set; }

        public object Data { get; set; }

    }


}
