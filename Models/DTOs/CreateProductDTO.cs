namespace InventoryManagement.Models.DTOs;

public class CreateProductDTO
{
    public string Sku { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UserId { get; set; }
    public string? Notes { get; set; }
}