namespace InventoryManagement.Models.DTOs;

public class InventoryDTO
{
    public int WarehouseId { get; set; }
    public string ProductSku { get; set; }
    public int Quantity { get; set; }
}