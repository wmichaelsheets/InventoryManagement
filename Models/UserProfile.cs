using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Models;

public class UserProfile
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }
    public ICollection<Products> Products { get; set; } = new List<Products>();
}