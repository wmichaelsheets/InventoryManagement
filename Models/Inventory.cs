using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;
public class Inventory
{
    public int WarehousesId { get; set; }
    public string ProductsSku { get; set; }
    public int Quantity { get; set; }


    public Warehouse Warehouse { get; set; }
    public Product Product { get; set; }
}
