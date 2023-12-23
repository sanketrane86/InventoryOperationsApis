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
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        InventoryRepository _objInventoryRepository;
        CommonRepository _objCommonRepository;

        public InventoryController(ILogger<InventoryController> logger, InventoryRepository objInventoryRepository, CommonRepository objCommonRepository)
        {
            _logger = logger;
            _objInventoryRepository = objInventoryRepository;
            _objCommonRepository = objCommonRepository;
        }

        /// <summary>
        /// This endpoint gets all inventory in system pagewise
        /// </summary>
        /// <param name="objTableOperations"></param>
        /// <returns></returns>
        [HttpPost("GetAllInventory")]
        public IActionResult GetAllInventory(TableOperations objTableOperations)
        {
           
            if (objTableOperations == null)
            {
                return BadRequest();
            }

            ServiceResponse objServiceResponse = _objInventoryRepository.GetAllInventory(objTableOperations);
            
            return Ok(objServiceResponse);

        }

        /// <summary>
        /// This endpoint gets inventory details based on inventory id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse objServiceResponse = _objInventoryRepository.GetById(id);

            return Ok(objServiceResponse);
        }

        /// <summary>
        /// This endpoint gets list of all inventories based on item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("GetByItemId/{itemId}")]
        public IActionResult GetByItemId(int itemId)
        {
            if (itemId <= 0)
            {
                return BadRequest();
            }

            ServiceResponse objServiceResponse = _objInventoryRepository.GetByItemId(itemId);

            return Ok(objServiceResponse);
        }

        /// <summary>
        /// This endpoint inserts inventory details
        /// </summary>
        /// <param name="objInventoryRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostInventory([FromBody] InventoryRequest objInventoryRequest)
        {
            if (objInventoryRequest == null)
            {
                return BadRequest();
            }

            //validate item id
            ServiceResponse objServiceResponse = _objCommonRepository.GetItemById(objInventoryRequest.ItemId);
            if (objServiceResponse.IsSuccess == false)
            {
                return Ok(objServiceResponse);
            }

            //validate brand id
            objServiceResponse = _objCommonRepository.GetBrandById(objInventoryRequest.BrandId);
            if (objServiceResponse.IsSuccess == false)
            {
                return Ok(objServiceResponse);
            }

            objServiceResponse = _objInventoryRepository.PostInventory(objInventoryRequest);

            return Ok(objServiceResponse);
        }

        /// <summary>
        /// This endpoint updates inventory details based on inventory id
        /// </summary>
        /// <param name="objInventoryRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutInventory([FromBody] InventoryRequest objInventoryRequest)
        {
            if (objInventoryRequest == null)
            {
                return BadRequest();
            }

            //validate item id
            ServiceResponse objServiceResponse = _objCommonRepository.GetItemById(objInventoryRequest.ItemId);
            if (objServiceResponse.IsSuccess == false)
            {
                return Ok(objServiceResponse);
            }

            //validate brand id
            objServiceResponse = _objCommonRepository.GetBrandById(objInventoryRequest.BrandId);
            if (objServiceResponse.IsSuccess == false)
            {
                return Ok(objServiceResponse);
            }

            objServiceResponse = _objInventoryRepository.PutInventory(objInventoryRequest);

            return Ok(objServiceResponse);
        }

        /// <summary>
        /// This endpoint deletes inventory details based on inventory id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteInventory(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            ServiceResponse objServiceResponse = _objInventoryRepository.DeleteInventory(id);

            return Ok(objServiceResponse);
        }

    }
}
