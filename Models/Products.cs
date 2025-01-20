using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;
{
    public class Product
{
    public string Sku { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UserId { get; set; }
    public DateTime Updated { get; set; }
    public string Notes { get; set; }


    public UserProfile UserProfile { get; set; }
    public ICollection<Inventory> Inventories { get; set; }
}
}