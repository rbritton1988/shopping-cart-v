using Microsoft.EntityFrameworkCore;
using System;
using VeygoShoppingCart.Domain.Models;


namespace VeygoShoppingCart.Domain
{
    public class EFCoreContext : DbContext
    {
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartDiscount> ShoppingCartDiscounts { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupTables(modelBuilder);
            SetupEntityRelationships(modelBuilder);
            SetupEntityConstraints(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private void SetupTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Discount>().ToTable("Discounts");
            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCarts");
            modelBuilder.Entity<CartDiscount>().ToTable("CartDiscounts").HasKey(cd => new { cd.ShoppingCartId, cd.DiscountId });
            modelBuilder.Entity<CartItem>().ToTable("CartItems").HasKey(ci => new { ci.ShoppingCartId, ci.ItemId });
        }

        private void SetupEntityRelationships(ModelBuilder modelBuilder)
        {                
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.ShoppingCart)
                .WithMany(i => i.CartItems)
                .HasForeignKey(ci => ci.ShoppingCartId);
            modelBuilder.Entity<CartItem>()
                .HasOne(i => i.Item)
                .WithMany(ci => ci.CartItems)
                .HasForeignKey(i => i.ItemId);
                
            modelBuilder.Entity<CartDiscount>()
                .HasOne(cd => cd.ShoppingCart)
                .WithMany(d => d.CartDiscounts)
                .HasForeignKey(cd => cd.ShoppingCartId);
            modelBuilder.Entity<CartDiscount>()
                .HasOne(d => d.Discount)
                .WithMany(cd => cd.CartDiscounts)
                .HasForeignKey(d => d.DiscountId);
        }

        private void SetupEntityConstraints(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>()
                .Property(ci => ci.Quantity)
                .IsRequired();

            modelBuilder.Entity<ShoppingCart>()
                .Property(sc => sc.Complete)
                .HasDefaultValue(false)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ShoppingCart>()
                .Property(sc => sc.TotalPrice)
                .HasDefaultValue(0.00M)
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Name)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Description)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Price)
                .IsRequired();

            modelBuilder.Entity<Discount>()
                .Property(d => d.Code)
                .HasMaxLength(15);

            modelBuilder.Entity<Discount>()
                .HasIndex(d => d.Code)
                .IsUnique();

            modelBuilder.Entity<Discount>()
                .Property(d => d.Description)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Discount>()
                .Property(d => d.Percentage)                
                .IsRequired();
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { 
                    Id = 1, 
                    Name = "VEGETABLE SELECTION BOX - SMALL", 
                    Description = "Containing a hand-chosen variety of our most popular vegetables (see product information below for items). The contents will change every month to reflect the seasonality of the produce, but will always include staples such as onions and potatoes, as well as seasonal ‘stars’.", 
                    Price = 11.49M },
                new Item
                {
                    Id=2,
                    Name = "SALAD SELECTION BOX - MEDIUM",
                    Description = "Containing a hand-chosen variety of our most popular salad (see product information below for items). Contents will change every month to reflect the seasonality of the produce, but will always include popular items such salad potatoes, tomatoes and lettuce as well as seasonal ‘stars’.",
                    Price = 17.95M
                });
            modelBuilder.Entity<Discount>().HasData(
                new Discount
                {
                    Id = 1,
                    Code= "FIRST15UK",
                    Description= "Save 15% on Your Order",
                    Percentage=0.15
                },
                new Discount
                {
                    Id=2,
                    Code= "VC08AURX7G",
                    Description= "Save 20% on Your Order",
                    Percentage=0.20
                },
                new Discount
                {
                    Id = 3,
                    Code = "VC08A9VSK7",
                    Description = "Save 5% on Your Order",
                    Percentage = 0.05
                });
        }
    }


}
