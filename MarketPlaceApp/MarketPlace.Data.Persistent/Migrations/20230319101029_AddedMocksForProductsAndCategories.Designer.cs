﻿// <auto-generated />
using System;
using MarketPlace.Data.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarketPlace.Data.Persistent.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230319101029_AddedMocksForProductsAndCategories")]
    partial class AddedMocksForProductsAndCategories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "In this category will be only cars",
                            Name = "Cars"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In this category will be only food",
                            Name = "Food"
                        },
                        new
                        {
                            Id = 3,
                            Description = "In this category will be only technologies",
                            Name = "Technologies"
                        });
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Description for Volkswagen Polo",
                            Name = "Volkswagen Polo",
                            Price = 10000m,
                            Quantity = 7
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Description for BMW M3",
                            Name = "BMW M3",
                            Price = 15000m,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Description for Apple",
                            Name = "Apple",
                            Price = 10m,
                            Quantity = 120
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Description for Potato",
                            Name = "Potato",
                            Price = 7m,
                            Quantity = 40
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Description for Carrot",
                            Name = "Carrot",
                            Price = 8m,
                            Quantity = 73
                        });
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "customer"
                        });
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 111L,
                            CreationDate = new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(906),
                            Email = "admin@mail.ru",
                            FirstName = "admin",
                            IsActive = true,
                            LastModified = new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(909),
                            LastName = "admin",
                            Login = "admin",
                            PasswordHash = new byte[] { 255, 104, 160, 53, 169, 181, 187, 237, 57, 105, 106, 198, 184, 77, 48, 103, 149, 234, 32, 229, 151, 101, 31, 193, 146, 193, 99, 101, 37, 158, 28, 133, 149, 136, 165, 178, 45, 21, 143, 28, 97, 175, 148, 95, 131, 163, 90, 142, 159, 0, 169, 104, 124, 215, 142, 98, 239, 116, 71, 150, 29, 72, 55, 19 },
                            PasswordSalt = new byte[] { 20, 150, 132, 62, 208, 255, 190, 202, 231, 95, 82, 1, 43, 109, 219, 246, 114, 35, 240, 7, 124, 45, 229, 130, 161, 100, 147, 174, 54, 240, 176, 253, 60, 121, 64, 186, 100, 192, 161, 1, 64, 50, 61, 115, 100, 84, 189, 255, 35, 254, 48, 15, 100, 249, 248, 93, 100, 249, 157, 174, 181, 185, 105, 86, 107, 47, 7, 78, 178, 161, 92, 141, 4, 42, 189, 253, 65, 68, 103, 9, 115, 182, 90, 75, 231, 250, 129, 230, 204, 244, 5, 142, 11, 114, 116, 95, 24, 224, 83, 135, 35, 81, 106, 135, 45, 249, 61, 35, 119, 99, 245, 67, 23, 48, 93, 15, 242, 174, 171, 177, 67, 126, 213, 199, 166, 232, 178, 10 },
                            RoleId = 1L
                        },
                        new
                        {
                            Id = 222L,
                            CreationDate = new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(923),
                            Email = "customer@mail.ru",
                            FirstName = "customer",
                            IsActive = true,
                            LastModified = new DateTime(2023, 3, 19, 10, 10, 29, 717, DateTimeKind.Utc).AddTicks(923),
                            LastName = "customer",
                            Login = "customer",
                            PasswordHash = new byte[] { 172, 29, 197, 221, 97, 76, 234, 156, 124, 214, 229, 182, 208, 88, 121, 92, 192, 245, 86, 146, 186, 63, 149, 157, 154, 136, 134, 117, 203, 92, 170, 25, 143, 120, 121, 229, 62, 25, 127, 194, 34, 14, 14, 202, 215, 247, 252, 1, 55, 82, 182, 150, 10, 187, 59, 214, 112, 201, 7, 135, 150, 245, 188, 243 },
                            PasswordSalt = new byte[] { 20, 150, 132, 62, 208, 255, 190, 202, 231, 95, 82, 1, 43, 109, 219, 246, 114, 35, 240, 7, 124, 45, 229, 130, 161, 100, 147, 174, 54, 240, 176, 253, 60, 121, 64, 186, 100, 192, 161, 1, 64, 50, 61, 115, 100, 84, 189, 255, 35, 254, 48, 15, 100, 249, 248, 93, 100, 249, 157, 174, 181, 185, 105, 86, 107, 47, 7, 78, 178, 161, 92, 141, 4, 42, 189, 253, 65, 68, 103, 9, 115, 182, 90, 75, 231, 250, 129, 230, 204, 244, 5, 142, 11, 114, 116, 95, 24, 224, 83, 135, 35, 81, 106, 135, 45, 249, 61, 35, 119, 99, 245, 67, 23, 48, 93, 15, 242, 174, 171, 177, 67, 126, 213, 199, 166, 232, 178, 10 },
                            RoleId = 2L
                        });
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.CartItem", b =>
                {
                    b.HasOne("MarketPlace.Data.Persistent.Classes.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketPlace.Data.Persistent.Classes.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.OrderItem", b =>
                {
                    b.HasOne("MarketPlace.Data.Persistent.Classes.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketPlace.Data.Persistent.Classes.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Product", b =>
                {
                    b.HasOne("MarketPlace.Data.Persistent.Classes.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Entities.User", b =>
                {
                    b.HasOne("MarketPlace.Data.Persistent.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Classes.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MarketPlace.Data.Persistent.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
