using System.ComponentModel.DataAnnotations;

namespace InventoryOperationsApis.Models
{
    public class Items
    {
        public int ItemId {  get; set; }

        [Required]
        public string? ItemName { get; set; }
        public string? ItemDescription {  get; set; }
        
    }
}
