using System.ComponentModel.DataAnnotations;

namespace InventoryOperationsApis.Models
{
    public class Brands
    {
        public int BrandId {  get; set; }

        [Required]
        public string? BrandName { get; set; }
        
    }
}
