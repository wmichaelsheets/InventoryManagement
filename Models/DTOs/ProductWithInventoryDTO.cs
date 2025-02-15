
using InventoryManagement.Models.DTOs;

public class ProductWithInventoryDTO
{
    public string Sku { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UserId { get; set; }
    public DateTime Updated { get; set; }
    public string Notes { get; set; }
    public List<InventoryDTO> Inventories { get; set; }
}