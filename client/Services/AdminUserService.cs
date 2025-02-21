using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class AdminUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AdminUserService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task EnsureAdminUserAsync()
        {
            var adminEmail = "admina@strator.comx";
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "Administrator",
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(adminUser, _configuration["AdminPassword"]);

                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create admin user: " + string.Join(", ", result.Errors));
                }
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await _userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}