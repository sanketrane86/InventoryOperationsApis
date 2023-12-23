using InventoryOperationsApis.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryOperationsApis.Repositories;
using InventoryOperationsApis.Models.ResponseModels;
using System.Net;

namespace InventoryOperationsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CommonController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        CommonRepository _objCommonRepository;

        public CommonController(ILogger<InventoryController> logger, CommonRepository objCommonRepository)
        {
            _logger = logger;            
            _objCommonRepository = objCommonRepository;
        }

        [HttpGet("GetAllBrands")]
        public IActionResult GetAllBrands()
        {
           
            ServiceResponse objServiceResponse = _objCommonRepository.GetAllBrands();
            
            return Ok(objServiceResponse);

        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAllItems()
        {

            ServiceResponse objServiceResponse = _objCommonRepository.GetAllItems();

            return Ok(objServiceResponse);

        }

    }
}
