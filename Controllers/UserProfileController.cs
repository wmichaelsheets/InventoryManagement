using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly InventoryManagementDbContext _dbContext;

    public UserProfileController(InventoryManagementDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<UserProfileDTO>>> GetAllUsers()
    {
        var users = await _dbContext.UserProfiles
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
            .ToListAsync();

        if (users == null || !users.Any())
        {
            return NotFound("No users found.");
        }

        return Ok(users);
    }

    [HttpGet("byEmail/{email}")]
    [Authorize]
    public async Task<ActionResult<UserProfileDTO>> GetByEmail(string email)
    {
        var userProfile = await _dbContext.UserProfiles
            .Include(up => up.IdentityUser)
            .FirstOrDefaultAsync(up => up.Email == email);

        if (userProfile == null)
        {
            return NotFound($"User profile with email {email} not found.");
        }

        var userProfileDto = new UserProfileDTO
        {
            Id = userProfile.Id,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            IdentityUserId = userProfile.IdentityUserId,
            Email = userProfile.IdentityUser.Email,
            Username = userProfile.IdentityUser.UserName
        };

        return Ok(userProfileDto);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUserProfile(int id, UpdateUserProfileDTO updateDto)
    {
        var userProfile = await _dbContext.UserProfiles
            .Include(up => up.IdentityUser)
            .FirstOrDefaultAsync(up => up.Id == id);

        if (userProfile == null)
        {
            return NotFound($"User profile with id {id} not found.");
        }


        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userProfile.IdentityUserId != currentUserId)
        {
            return Forbid();
        }


        userProfile.FirstName = updateDto.FirstName;
        userProfile.LastName = updateDto.LastName;
        userProfile.IdentityUser.Email = updateDto.Email;


        userProfile.Email = updateDto.Email;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserProfileExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }


        var updatedUserProfileDto = new UserProfileDTO
        {
            Id = userProfile.Id,
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            IdentityUserId = userProfile.IdentityUserId,
            Email = userProfile.IdentityUser.Email,
            Username = userProfile.IdentityUser.UserName
        };

        return Ok(updatedUserProfileDto);
    }

    private bool UserProfileExists(int id)
    {
        return _dbContext.UserProfiles.Any(e => e.Id == id);
    }

}