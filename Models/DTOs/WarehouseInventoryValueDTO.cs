using System.Collections.Generic;

namespace InventoryManagement.Models.DTOs
{
    public class WarehouseInventoryValueDTO
    {
        public required int WarehouseId { get; set; }
        public required string WarehouseName { get; set; }
        public required string WarehouseLocation { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public required List<InventoryItemValueDTO> InventoryItems { get; set; }
    }

}