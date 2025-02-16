using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Data;
using InventoryManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private InventoryManagementDbContext _dbContext;

    public InventoryController(InventoryManagementDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> GetAllInventoryItems()
    {
        var inventoryItems = await _dbContext.Inventories
            .Include(i => i.Product)
            .Include(i => i.Warehouse)
            .Select(i => new InventoryItemDTO
            {
                WarehouseId = i.WarehouseId,
                WarehouseName = i.Warehouse.Name,
                WarehouseLocation = i.Warehouse.Location,
                WarehouseNotes = i.Warehouse.Notes,
                ProductSku = i.ProductSku,
                ProductName = i.Product.ProductName,
                UnitPrice = i.Product.UnitPrice,
                UserId = i.Product.UserProfileId,
                ProductNotes = i.Product.Notes,
                Quantity = i.Quantity,
                ProductUpdated = i.Product.Updated
            })
            .ToListAsync();

        if (!inventoryItems.Any())
        {
            return NotFound("No inventory items found.");
        }

        return Ok(inventoryItems);
    }

    [HttpPost]
    public async Task<IActionResult> AddInventoryItem([FromBody] AddInventoryItemDTO addInventoryItemDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if the product exists
        var product = await _dbContext.Products.FindAsync(addInventoryItemDTO.ProductSku);
        if (product == null)
        {
            return NotFound($"Product with SKU {addInventoryItemDTO.ProductSku} not found.");
        }

        // Check if the warehouse exists
        var warehouse = await _dbContext.Warehouses.FindAsync(addInventoryItemDTO.WarehouseId);
        if (warehouse == null)
        {
            return NotFound($"Warehouse with ID {addInventoryItemDTO.WarehouseId} not found.");
        }

        // Check if the inventory item already exists
        var inventoryItem = await _dbContext.Inventories
            .FirstOrDefaultAsync(i => i.WarehouseId == addInventoryItemDTO.WarehouseId && i.ProductSku == addInventoryItemDTO.ProductSku);

        if (inventoryItem == null)
        {
            // Create new inventory item
            inventoryItem = new Inventory
            {
                WarehouseId = addInventoryItemDTO.WarehouseId,
                ProductSku = addInventoryItemDTO.ProductSku,
                Quantity = addInventoryItemDTO.Quantity
            };
            _dbContext.Inventories.Add(inventoryItem);
        }
        else
        {
            // Update existing inventory item
            inventoryItem.Quantity = addInventoryItemDTO.Quantity;
        }

        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(AddInventoryItem), new { warehouseId = inventoryItem.WarehouseId, productSku = inventoryItem.ProductSku }, inventoryItem);
    }

    [HttpPut("{warehouseId}")]
    public async Task<IActionResult> UpdateInventoryItem(int warehouseId, [FromBody] UpdateInventoryItemDTO updateInventoryItemDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var warehouse = await _dbContext.Warehouses.FindAsync(warehouseId);
        if (warehouse == null)
        {
            return NotFound($"Warehouse with ID {warehouseId} not found.");
        }


        var product = await _dbContext.Products.FindAsync(updateInventoryItemDTO.ProductSku);
        if (product == null)
        {
            return NotFound($"Product with SKU {updateInventoryItemDTO.ProductSku} not found.");
        }


        var inventoryItem = await _dbContext.Inventories
            .FirstOrDefaultAsync(i => i.WarehouseId == warehouseId && i.ProductSku == updateInventoryItemDTO.ProductSku);

        if (inventoryItem == null)
        {

            inventoryItem = new Inventory
            {
                WarehouseId = warehouseId,
                ProductSku = updateInventoryItemDTO.ProductSku,
                Quantity = updateInventoryItemDTO.Quantity
            };
            _dbContext.Inventories.Add(inventoryItem);
        }
        else
        {

            inventoryItem.Quantity = updateInventoryItemDTO.Quantity;
        }


        product.Updated = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();


        var updatedInventoryItemDTO = new InventoryItemDTO
        {
            WarehouseId = inventoryItem.WarehouseId,
            WarehouseName = warehouse.Name,
            WarehouseLocation = warehouse.Location,
            WarehouseNotes = warehouse.Notes,
            ProductSku = inventoryItem.ProductSku,
            ProductName = product.ProductName,
            UnitPrice = product.UnitPrice,
            UserId = product.UserProfileId,
            ProductNotes = product.Notes,
            Quantity = inventoryItem.Quantity,
            ProductUpdated = product.Updated
        };

        return Ok(updatedInventoryItemDTO);
    }

}