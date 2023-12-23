using System.ComponentModel.DataAnnotations;

namespace InventoryOperationsApis.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        public int ItemId { get; set; }
        
        [Required]
        public int? BrandId { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public int? Size { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public int Quantity {  get; set; }

    }
}
