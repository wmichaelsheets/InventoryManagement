namespace InventoryManagement.Models.DTOs
{
    public class InventoryItemValueDTO
    {
        public required string ProductSku { get; set; }
        public required string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }
    }
}