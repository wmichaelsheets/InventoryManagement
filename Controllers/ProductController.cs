using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Data;
using InventoryManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private InventoryManagementDbContext _dbContext;

    public ProductController(InventoryManagementDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{productName}")]
    public async Task<ActionResult<ProductWithInventoryDTO>> GetProductWithInventory(string productName)
    {
        var product = await _dbContext.Products
            .Include(p => p.Inventories)
            .FirstOrDefaultAsync(p => p.ProductName == productName);

        if (product == null)
        {
            return NotFound();
        }

        var productWithInventoryDTO = new ProductWithInventoryDTO
        {
            Sku = product.Sku,
            ProductName = product.ProductName,
            UnitPrice = product.UnitPrice,
            UserId = product.UserProfileId,
            Updated = product.Updated,
            Notes = product.Notes,
            Inventories = product.Inventories.Select(i => new InventoryDTO
            {
                WarehouseId = i.WarehouseId,
                ProductSku = i.ProductSku,
                Quantity = i.Quantity
            }).ToList()
        };

        return Ok(productWithInventoryDTO);
    }
}