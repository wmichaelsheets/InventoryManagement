namespace InventoryManagement.Models.DTOs;
public class ProductDTO
{
    public string Sku { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UserId { get; set; }
    public DateTime Updated { get; set; }
    public string Notes { get; set; }
}