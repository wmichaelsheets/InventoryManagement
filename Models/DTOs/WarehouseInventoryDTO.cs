namespace InventoryManagement.Models.DTOs;

public class WarehouseInventoryDTO
{
    public string ProductName { get; set; }
    public string ProductSku { get; set; }
    public int Quantity { get; set; }
    public int WarehouseId { get; set; }
}