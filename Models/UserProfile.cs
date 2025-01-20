using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
    public ICollection<Product> Products { get; set; }


}