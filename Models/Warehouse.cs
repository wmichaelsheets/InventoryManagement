using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;
public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Notes { get; set; }


    public ICollection<Inventory> Inventories { get; set; }
}