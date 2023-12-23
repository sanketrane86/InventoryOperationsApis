using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace InventoryOperationsApis.Models.RequestModels
{
    //public class GetAllInventoryRequest
    //{
    //    public int Inventory
    //}

    public class InventoryRequest
    {
        public int InventoryId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
        public int ItemId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
        public int BrandId { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public string? Size { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
        public double? Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid positive number.")]
        public int Quantity { get; set; }

    }

}
