﻿// <auto-generated />
using System;
using InventoryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InventoryManagement.Migrations
{
    [DbContext(typeof(InventoryManagementDbContext))]
    [Migration("20250122194722_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Inventory", b =>
                {
                    b.Property<int>("WarehouseId")
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<string>("ProductsSku")
                        .HasColumnType("text")
                        .HasColumnOrder(1);

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("WarehouseId", "ProductsSku");

                    b.HasIndex("ProductsSku");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-001",
                            Quantity = 100
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-002",
                            Quantity = 150
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-003",
                            Quantity = 200
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-004",
                            Quantity = 75
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-005",
                            Quantity = 125
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-006",
                            Quantity = 80
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-007",
                            Quantity = 175
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-008",
                            Quantity = 60
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-009",
                            Quantity = 90
                        },
                        new
                        {
                            WarehouseId = 1,
                            ProductsSku = "PROD-010",
                            Quantity = 110
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-001",
                            Quantity = 200
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-002",
                            Quantity = 180
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-003",
                            Quantity = 250
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-004",
                            Quantity = 120
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-005",
                            Quantity = 160
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-006",
                            Quantity = 140
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-007",
                            Quantity = 220
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-008",
                            Quantity = 100
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-009",
                            Quantity = 130
                        },
                        new
                        {
                            WarehouseId = 2,
                            ProductsSku = "PROD-010",
                            Quantity = 170
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-001",
                            Quantity = 150
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-002",
                            Quantity = 120
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-003",
                            Quantity = 180
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-004",
                            Quantity = 90
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-005",
                            Quantity = 140
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-006",
                            Quantity = 110
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-007",
                            Quantity = 200
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-008",
                            Quantity = 80
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-009",
                            Quantity = 160
                        },
                        new
                        {
                            WarehouseId = 3,
                            ProductsSku = "PROD-010",
                            Quantity = 130
                        });
                });

            modelBuilder.Entity("InventoryManagement.Models.Products", b =>
                {
                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Sku");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Sku = "PROD-001",
                            Notes = "High quality item",
                            ProductName = "Product Alpha",
                            UnitPrice = 19.99m,
                            Updated = new DateTime(2024, 5, 15, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-002",
                            Notes = "Popular choice",
                            ProductName = "Product Beta",
                            UnitPrice = 29.99m,
                            Updated = new DateTime(2024, 8, 22, 14, 45, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-003",
                            Notes = "",
                            ProductName = "Product Gamma",
                            UnitPrice = 9.99m,
                            Updated = new DateTime(2024, 3, 10, 9, 15, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-004",
                            Notes = "Limited edition",
                            ProductName = "Product Delta",
                            UnitPrice = 49.99m,
                            Updated = new DateTime(2024, 11, 5, 16, 20, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-005",
                            Notes = "",
                            ProductName = "Product Epsilon",
                            UnitPrice = 14.99m,
                            Updated = new DateTime(2024, 7, 18, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-006",
                            Notes = "New arrival",
                            ProductName = "Product Zeta",
                            UnitPrice = 39.99m,
                            Updated = new DateTime(2024, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-007",
                            Notes = "",
                            ProductName = "Product Eta",
                            UnitPrice = 7.99m,
                            Updated = new DateTime(2024, 2, 14, 18, 45, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-008",
                            Notes = "Premium product",
                            ProductName = "Product Theta",
                            UnitPrice = 59.99m,
                            Updated = new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-009",
                            Notes = "",
                            ProductName = "Product Iota",
                            UnitPrice = 12.99m,
                            Updated = new DateTime(2024, 6, 1, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        },
                        new
                        {
                            Sku = "PROD-010",
                            Notes = "",
                            ProductName = "Product Kappa",
                            UnitPrice = 24.99m,
                            Updated = new DateTime(2024, 4, 20, 11, 10, 0, 0, DateTimeKind.Unspecified),
                            UserProfileId = 1
                        });
                });

            modelBuilder.Entity("InventoryManagement.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admina@strator.comx",
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Strator",
                            Username = "Administrator"
                        });
                });

            modelBuilder.Entity("InventoryManagement.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "123 Main Street, New York, NY 10001",
                            Name = "Main Warehouse",
                            Notes = "Primary storage."
                        },
                        new
                        {
                            Id = 2,
                            Location = "456 Industrial Avenue, Chicago, IL 60601",
                            Name = "Central Warehouse",
                            Notes = "Overflow and bulk storage."
                        },
                        new
                        {
                            Id = 3,
                            Location = "789 Delivery Avenue, Los Angeles, CA 90001",
                            Name = "Western Warehouse",
                            Notes = "Shipping and fulfillment."
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            Name = "Admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3668d417-699e-4c30-af7e-b2a1a8b67b65",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEKU+Dgli5TMoIRnf7djAMpZrH9dqUqvWhAc6zwvVegPXxto8TAIzMHWCC/YNKNJJuw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "13856ba8-ede5-44af-baee-8a343b81a67d",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Inventory", b =>
                {
                    b.HasOne("InventoryManagement.Models.Products", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductsSku")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryManagement.Models.Warehouse", "Warehouse")
                        .WithMany("Inventories")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("InventoryManagement.Models.Products", b =>
                {
                    b.HasOne("InventoryManagement.Models.UserProfile", "UserProfile")
                        .WithMany("Products")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("InventoryManagement.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InventoryManagement.Models.Products", b =>
                {
                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("InventoryManagement.Models.UserProfile", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("InventoryManagement.Models.Warehouse", b =>
                {
                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
