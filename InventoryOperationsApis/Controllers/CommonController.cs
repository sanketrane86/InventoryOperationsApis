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
    [Produces("application/json")]
    public class CommonController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        CommonRepository _objCommonRepository;

        public CommonController(ILogger<InventoryController> logger, CommonRepository objCommonRepository)
        {
            _logger = logger;            
            _objCommonRepository = objCommonRepository;
        }

        /// <summary>
        /// This endpoint gets list of all brands
        /// </summary>
        /// <response code="200">Data received successfully</response>
        /// <response code="404">Data not found</response>
        [HttpGet("GetAllBrands")]
        [ProducesResponseType(typeof(List<BrandResponse>), 200)]
        public IActionResult GetAllBrands()
        {
           
            ServiceResponse objServiceResponse = _objCommonRepository.GetAllBrands();
            
            return Ok(objServiceResponse);

        }

        /// <summary>
        /// This endpoint gets list of all items
        /// </summary>
        /// <response code="200">Data received successfully</response>
        /// <response code="404">Data not found</response>
        [HttpGet("GetAllItems")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public IActionResult GetAllItems()
        {

            ServiceResponse objServiceResponse = _objCommonRepository.GetAllItems();

            return Ok(objServiceResponse);

        }

    }
}
