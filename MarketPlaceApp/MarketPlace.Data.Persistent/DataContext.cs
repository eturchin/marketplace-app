using System.Security.Cryptography;
using System.Text;
using MarketPlace.Data.Persistent.Classes;
using MarketPlace.Data.Persistent.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Data.Persistent;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Product?> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartItem> CartItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CartItem>()
            .HasKey(ci => new { ci.CartId, ci.ProductId });

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(ci => ci.ProductId);

        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId);

        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<User>()
            .HasOne(r => r.Role)
            .WithMany(u => u.Users)
            .HasForeignKey(x => x.RoleId);

        modelBuilder.Entity<Role>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Role>()
            .HasMany(u => u.Users)
            .WithOne(r => r.Role);

        modelBuilder.Entity<Role>()
            .HasData(
                new Role
                {
                    Id = 1,
                    Name = "admin",
                    Users = default
                },
                new Role
                {
                    Id = 2,
                    Name = "customer",
                    Users = default
                });

        var hmac = new HMACSHA512();

        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 111,
                    FirstName = "admin",
                    LastName = "admin",
                    Login = "admin",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                    PasswordSalt = hmac.Key,
                    RoleId = 1,
                    Email = "admin@mail.ru",
                    CreationDate = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsActive = true,
                    Role = default

                },
                new User
                {
                    Id = 222,
                    FirstName = "customer",
                    LastName = "customer",
                    Login = "customer",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("customer")),
                    PasswordSalt = hmac.Key,
                    RoleId = 2,
                    Email = "customer@mail.ru",
                    CreationDate = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    IsActive = true,
                    Role = default
                });

        modelBuilder.Entity<Category>()
            .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Cars",
                    Description = "In this category will be only cars",
                    Products = default
                },
                new Category
                {
                    Id = 2,
                    Name = "Food",
                    Description = "In this category will be only food",
                    Products = default
                },
                new Category
                {
                    Id = 3,
                    Name = "Technologies",
                    Description = "In this category will be only technologies",
                    Products = default
                });

        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Volkswagen Polo",
                    Description = "Description for Volkswagen Polo",
                    Price = 10000,
                    Quantity = 7,
                    CategoryId = 1,
                    Category = default,
                    CartItems = default,
                    OrderItems = default
                },
                new Product
                {
                    Id = 2,
                    Name = "BMW M3",
                    Description = "Description for BMW M3",
                    Price = 15000,
                    Quantity = 3,
                    CategoryId = 1,
                    Category = default,
                    CartItems = default,
                    OrderItems = default
                },
                new Product
                {
                    Id = 3,
                    Name = "Apple",
                    Description = "Description for Apple",
                    Price = 10,
                    Quantity = 120,
                    CategoryId = 2,
                    Category = default,
                    CartItems = default,
                    OrderItems = default
                },
                new Product
                {
                    Id = 4,
                    Name = "Potato",
                    Description = "Description for Potato",
                    Price = 7,
                    Quantity = 40,
                    CategoryId = 2,
                    Category = default,
                    CartItems = default,
                    OrderItems = default
                },
                new Product
                {
                    Id = 5,
                    Name = "Carrot",
                    Description = "Description for Carrot",
                    Price = 8,
                    Quantity = 73,
                    CategoryId = 2,
                    Category = default,
                    CartItems = default,
                    OrderItems = default
                });
    }
}