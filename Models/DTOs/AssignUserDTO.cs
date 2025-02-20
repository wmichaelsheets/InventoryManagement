using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models.DTOs
{
    public class AssignUserDTO
    {
        [Required]
        public int UserId { get; set; }
    }
}