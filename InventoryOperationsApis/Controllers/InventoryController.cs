using InventoryOperationsApis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryOperationsApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetAllInventory()
        {
            return "Get all inventory";
        }

        [HttpGet("GetById/{id}")]
        public string GetById(int id)
        {
            return $"Get inventory by Id {id}";
        }

        [HttpGet("GetByItemId/{itemId}")]
        public string GetByItemId(int itemId)
        {
            return $"Get inventory by ItemId {itemId}";
        }

        [HttpPost]
        public string PostInventory([FromBody] Inventory objInventory)
        {
            return $"Create new inventory {objInventory.ItemId}";
        }

        [HttpPut]
        public string PutInventory([FromBody] Inventory objInventory)
        {
            return $"Update inventory {objInventory.ItemId}";
        }

        [HttpDelete("{id}")]
        public string DeleteInventory(int id)
        {
            return $"Delete inventory by Id {id}";
        }

    }
}
