using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryManagement.Models;

public class Inventory
{
    [Key]
    [Column(Order = 0)]
    public int WarehouseId { get; set; }

    [Key]
    [Column(Order = 1)]
    public string ProductSku { get; set; }

    public int Quantity { get; set; }

    public Warehouse Warehouse { get; set; }
    public Product Product { get; set; }
}
