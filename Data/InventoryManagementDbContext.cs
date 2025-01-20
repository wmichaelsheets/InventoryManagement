using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Data;
public class InventoryManagementDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Product> Products { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",

        });

        modelBuilder.Entity<Warehouse>().HasData(new Warehouse[]
                {
            new Warehouse
            {
                Id = 1,
                Name="Main Warehouse",
                Location="123 Main Street, New York, NY 10001",
                Notes="Primary storage."
            },

            new Warehouse
            {
                Id = 2,
                Name="Central Warehouse",
                Location="456 Industrial Avenue, Chicago, IL 60601",
                Notes="Overflow and bulk storage."
            },

            new Warehouse
            {
                Id = 3,
                Name="Western Warehouse",
                Location="789 Delivery Avenue, Los Angeles, CA 90001",
                Notes="Shipping and fulfillment."
            },
                });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
                {
            new UserProfile
            {
                Id = 2,
                FirstName="John",
                LastName="Doe",
                Username="JDoe",
                IdentityUserId = "",
                Email="john.doe@example.com",
            },

            new UserProfile
            {
                Id = 3,
                FirstName="Jane",
                LastName="Smith",
                Username="JSmith",
                IdentityUserId = "",
                Email="jane.smith@example.com",
            },

            new UserProfile
            {
                Id = 4,
                FirstName="Peter",
                LastName="Jones",
                Username="PJones",
                IdentityUserId = "",
                Email="peter.jones@example.com",
            },
                });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
           new Product
{
    Sku = "PROD-001",
    ProductName = "Product Alpha",
    UnitPrice = 19.99M,
    UserId = 2,
    Updated = new DateTime(2024, 5, 15, 10, 30, 0),
    Notes = "High quality item",
},

new Product
{
    Sku = "PROD-002",
    ProductName = "Product Beta",
    UnitPrice = 29.99M,
    UserId = 3,
    Updated = new DateTime(2024, 8, 22, 14, 45, 0),
    Notes = "Popular choice",
},

new Product
{
    Sku = "PROD-003",
    ProductName = "Product Gamma",
    UnitPrice = 9.99M,
    UserId = 4,
    Updated = new DateTime(2024, 3, 10, 9, 15, 0),
    Notes = "",
},

new Product
{
    Sku = "PROD-004",
    ProductName = "Product Delta",
    UnitPrice = 49.99M,
    UserId = 2,
    Updated = new DateTime(2024, 11, 5, 16, 20, 0),
    Notes = "Limited edition",
},

new Product
{
    Sku = "PROD-005",
    ProductName = "Product Epsilon",
    UnitPrice = 14.99M,
    UserId = 3,
    Updated = new DateTime(2024, 7, 18, 12, 0, 0),
    Notes = "",
},

new Product
{
    Sku = "PROD-006",
    ProductName = "Product Zeta",
    UnitPrice = 39.99M,
    UserId = 4,
    Updated = new DateTime(2024, 9, 30, 8, 0, 0),
    Notes = "New arrival",
},

new Product
{
    Sku = "PROD-007",
    ProductName = "Product Eta",
    UnitPrice = 7.99M,
    UserId = 2,
    Updated = new DateTime(2024, 2, 14, 18, 45, 0),
    Notes = "",
},

new Product
{
    Sku = "PROD-008",
    ProductName = "Product Theta",
    UnitPrice = 59.99M,
    UserId = 3,
    Updated = new DateTime(2024, 12, 25, 0, 0, 0),
    Notes = "Premium product",
},

new Product
{
    Sku = "PROD-009",
    ProductName = "Product Iota",
    UnitPrice = 12.99M,
    UserId = 4,
    Updated = new DateTime(2024, 6, 1, 7, 30, 0),
    Notes = "",
},

new Product
{
    Sku = "PROD-010",
    ProductName = "Product Kappa",
    UnitPrice = 24.99M,
    UserId = 2,
    Updated = new DateTime(2024, 4, 20, 11, 10, 0),
    Notes = "",
},
 });

        modelBuilder.Entity<Inventory>().HasData(new Inventory[]
               {
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-001", Quantity = 100 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-002", Quantity = 150 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-003", Quantity = 200 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-004", Quantity = 75 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-005", Quantity = 125 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-006", Quantity = 80 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-007", Quantity = 175 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-008", Quantity = 60 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-009", Quantity = 90 },
            new Inventory { WarehousesId = 1, ProductsSku = "PROD-010", Quantity = 110 },

            new Inventory { WarehousesId = 2, ProductsSku = "PROD-001", Quantity = 200 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-002", Quantity = 180 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-003", Quantity = 250 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-004", Quantity = 120 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-005", Quantity = 160 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-006", Quantity = 140 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-007", Quantity = 220 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-008", Quantity = 100 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-009", Quantity = 130 },
            new Inventory { WarehousesId = 2, ProductsSku = "PROD-010", Quantity = 170 },

            new Inventory { WarehousesId = 3, ProductsSku = "PROD-001", Quantity = 150 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-002", Quantity = 120 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-003", Quantity = 180 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-004", Quantity = 90 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-005", Quantity = 140 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-006", Quantity = 110 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-007", Quantity = 200 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-008", Quantity = 80 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-009", Quantity = 160 },
            new Inventory { WarehousesId = 3, ProductsSku = "PROD-010", Quantity = 130 },
               });



    }
}