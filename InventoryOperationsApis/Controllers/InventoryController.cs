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
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        InventoryRepository _objInventoryRepository;
       

        public InventoryController(ILogger<InventoryController> logger, InventoryRepository objInventoryRepository)
        {
            _logger = logger;
            _objInventoryRepository = objInventoryRepository;
            
        }

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

        [HttpPost]
        public IActionResult PostInventory([FromBody] InventoryRequest objInventoryRequest)
        {
            if (objInventoryRequest == null)
            {
                return BadRequest();
            }

            ServiceResponse objServiceResponse = _objInventoryRepository.PostInventory(objInventoryRequest);

            return Ok(objServiceResponse);
        }

        [HttpPut]
        public IActionResult PutInventory([FromBody] InventoryRequest objInventoryRequest)
        {
            if (objInventoryRequest == null)
            {
                return BadRequest();
            }

            ServiceResponse objServiceResponse = _objInventoryRepository.PutInventory(objInventoryRequest);

            return Ok(objServiceResponse);
        }

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
