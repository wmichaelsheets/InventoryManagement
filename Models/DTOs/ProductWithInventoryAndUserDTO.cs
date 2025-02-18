using System;
using System.Collections.Generic;

namespace InventoryManagement.Models.DTOs
{
    public class ProductWithInventoryAndUserDTO
    {
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime Updated { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public List<InventoryDTO> Inventories { get; set; }
    }
}