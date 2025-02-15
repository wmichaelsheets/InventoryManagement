namespace InventoryManagement.Models.DTOs
{
    public class InventoryItemDTO
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }
        public string WarehouseNotes { get; set; }
        public string ProductSku { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UserId { get; set; }
        public string ProductNotes { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductUpdated { get; set; }
    }
}