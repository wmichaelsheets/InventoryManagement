using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Data;
using InventoryManagement.Models;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductWithInventoryAndUserDTO>>> GetAllProducts()
    {
        var products = await _dbContext.Products
            .Include(p => p.Inventories)
            .Include(p => p.UserProfile)
            .Select(p => new ProductWithInventoryAndUserDTO
            {
                Sku = p.Sku,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                Updated = p.Updated,
                Notes = p.Notes,
                UserId = p.UserProfileId,
                UserFirstName = p.UserProfile.FirstName,
                UserLastName = p.UserProfile.LastName,
                UserEmail = p.UserProfile.Email,
                Inventories = p.Inventories.Select(i => new InventoryDTO
                {
                    WarehouseId = i.WarehouseId,
                    ProductSku = i.ProductSku,
                    Quantity = i.Quantity
                }).ToList()
            })
            .ToListAsync();

        if (!products.Any())
        {
            return NotFound("No products found.");
        }

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] CreateProductDTO createProductDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var userProfile = await _dbContext.UserProfiles
            .FirstOrDefaultAsync(u => u.Id == createProductDTO.UserId);

        if (userProfile == null)
        {
            return NotFound($"UserProfile with Id {createProductDTO.UserId} not found.");
        }


        var product = new Product
        {
            Sku = createProductDTO.Sku,
            ProductName = createProductDTO.ProductName,
            UnitPrice = createProductDTO.UnitPrice,
            UserProfileId = createProductDTO.UserId,
            Updated = DateTime.UtcNow,
            Notes = createProductDTO.Notes ?? string.Empty
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();


        var productDTO = new ProductDTO
        {
            Sku = product.Sku,
            ProductName = product.ProductName,
            UnitPrice = product.UnitPrice,
            UserId = product.UserProfileId,
            Updated = product.Updated,
            Notes = product.Notes
        };

        return CreatedAtAction(nameof(GetProductWithInventory), new { productName = product.ProductName }, productDTO);
    }

    [HttpPut("{sku}")]
    public async Task<ActionResult<ProductDTO>> UpdateProduct(string sku, [FromBody] UpdateProductDTO updateProductDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = await _dbContext.Products
            .FirstOrDefaultAsync(p => p.Sku == sku);

        if (product == null)
        {
            return NotFound($"Product with SKU {sku} not found.");
        }


        var userProfile = await _dbContext.UserProfiles
            .FirstOrDefaultAsync(u => u.Id == updateProductDTO.UserId);

        if (userProfile == null)
        {
            return NotFound($"UserProfile with Id {updateProductDTO.UserId} not found.");
        }


        product.ProductName = updateProductDTO.ProductName;
        product.UnitPrice = updateProductDTO.UnitPrice;
        product.UserProfileId = updateProductDTO.UserId;
        product.Updated = DateTime.UtcNow;
        product.Notes = updateProductDTO.Notes ?? string.Empty;

        await _dbContext.SaveChangesAsync();

        var productDTO = new ProductDTO
        {
            Sku = product.Sku,
            ProductName = product.ProductName,
            UnitPrice = product.UnitPrice,
            UserId = product.UserProfileId,
            Updated = product.Updated,
            Notes = product.Notes
        };

        return Ok(productDTO);
    }

    [HttpDelete("{sku}")]
    public async Task<IActionResult> DeleteProduct(string sku)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Sku == sku);

            if (product == null)
            {
                return NotFound($"Product with SKU {sku} not found.");
            }


            var relatedInventories = await _dbContext.Inventories
                .Where(i => i.ProductSku == sku)
                .ToListAsync();

            _dbContext.Inventories.RemoveRange(relatedInventories);


            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            await transaction.CommitAsync();

            return NoContent();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, "An error occurred while deleting the product and its inventory records.");
        }
    }

    [HttpPut("{sku}/assign-user")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> AssignUserToProduct(string sku, [FromBody] AssignUserDTO assignUserDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var product = await _dbContext.Products.FindAsync(sku);
        if (product == null)
        {
            return NotFound($"Product with SKU {sku} not found.");
        }

        var user = await _dbContext.UserProfiles.FindAsync(assignUserDTO.UserId);
        if (user == null)
        {
            return NotFound($"User with ID {assignUserDTO.UserId} not found.");
        }

        product.UserProfileId = assignUserDTO.UserId;
        product.Updated = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return Ok(new { Message = $"Product {sku} has been assigned to user {assignUserDTO.UserId}." });
    }


}