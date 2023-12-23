using System.ComponentModel.DataAnnotations;

namespace InventoryOperationsApis.Models.RequestModels
{
    public class LoginRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

    }
}
