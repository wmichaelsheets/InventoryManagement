namespace InventoryManagement.Models.DTOs;
public class ProductDto
{
    public string Sku { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UserId { get; set; }
    public DateTime Updated { get; set; }
    public string Notes { get; set; }
}