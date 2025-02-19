namespace InventoryManagement.Models.DTOs
{
    public class AllWarehousesInventoryDTO
    {
        public int WarehouseId { get; set; }
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public int Quantity { get; set; }
    }
}