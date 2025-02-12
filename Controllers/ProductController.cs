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


}