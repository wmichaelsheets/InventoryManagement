using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Data;
using InventoryManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private InventoryManagementDbContext _dbContext;

    public WarehouseController(InventoryManagementDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{warehouseId}/inventory")]
    public async Task<ActionResult<IEnumerable<WarehouseInventoryDTO>>> GetWarehouseInventory(int warehouseId)
    {
        var warehouseInventory = await _dbContext.Inventories
            .Where(i => i.WarehouseId == warehouseId)
            .Join(
                _dbContext.Products,
                inventory => inventory.ProductSku,
                product => product.Sku,
                (inventory, product) => new WarehouseInventoryDTO
                {
                    ProductName = product.ProductName,
                    ProductSku = product.Sku,
                    Quantity = inventory.Quantity,
                    WarehouseId = inventory.WarehouseId
                }
            )
            .ToListAsync();

        if (warehouseInventory == null || !warehouseInventory.Any())
        {
            return NotFound($"No inventory found for warehouse with ID {warehouseId}");
        }

        return Ok(warehouseInventory);
    }

    [HttpGet("all-inventory")]
    public async Task<ActionResult<IEnumerable<AllWarehousesInventoryDTO>>> GetAllWarehousesInventory()
    {
        var allInventory = await _dbContext.Inventories
            .Join(
                _dbContext.Products,
                inventory => inventory.ProductSku,
                product => product.Sku,
                (inventory, product) => new
                {
                    inventory.WarehouseId,
                    product.ProductName,
                    product.Sku,
                    inventory.Quantity
                }
            )
            .Join(
                _dbContext.Warehouses,
                inventoryProduct => inventoryProduct.WarehouseId,
                warehouse => warehouse.Id,
                (inventoryProduct, warehouse) => new AllWarehousesInventoryDTO
                {
                    WarehouseId = warehouse.Id,
                    ProductName = inventoryProduct.ProductName,
                    ProductSku = inventoryProduct.Sku,
                    Quantity = inventoryProduct.Quantity
                }
            )
            .ToListAsync();

        if (allInventory == null || !allInventory.Any())
        {
            return NotFound("No inventory found for any warehouse");
        }

        return Ok(allInventory);
    }


}