using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Data;
using InventoryManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private InventoryManagementDbContext _dbContext;

    public UserProfileController(InventoryManagementDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                FirstName = up.FirstName,
                LastName = up.LastName,
                IdentityUserId = up.IdentityUserId,
                Email = up.IdentityUser.Email,
                Username = up.IdentityUser.UserName
            })
            .ToList());
    }

    [HttpGet("byEmail/{email}")]
    [Authorize]
    public IActionResult GetByEmail(string email)
    {
        var userProfile = _dbContext.UserProfiles
            .FirstOrDefault(up => up.Email == email);

        if (userProfile == null)
        {
            return NotFound($"User profile with email {email} not found.");
        }

        var userProfileDto = new UserProfileDTO
        {
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Username = userProfile.Username
        };

        return Ok(userProfileDto);
    }

}