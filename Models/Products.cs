using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models;

public class Products
{
    [Key]
    public required string Sku { get; set; }
    public required string ProductName { get; set; }
    public decimal UnitPrice { get; set; }

    [ForeignKey("UserProfile")]
    public int UserProfileId { get; set; }

    public DateTime Updated { get; set; }
    public required string Notes { get; set; }

    public UserProfile? UserProfile { get; set; }
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}