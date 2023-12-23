
namespace InventoryOperationsApis.Models.ResponseModels
{
    public class InventoryResponse
    {
        public int InventoryId { get; set; }

        public int ItemId { get; set; }
        public string? ItemName { get; set; }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public string? Color { get; set; }

        public string? Size { get; set; }

        public string? Gender { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
