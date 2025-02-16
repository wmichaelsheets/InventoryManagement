using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models.DTOs
{
    public class UpdateInventoryItemDTO
    {
        [Required]
        public string ProductSku { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }
    }
}