using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Entities.Configuration;

namespace Streetwood.Core.Domain.Implementation
{
    internal class StreetwoodContext : DbContext, IDbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Charm> Charms { get; set; }

        public DbSet<CharmCategory> CharmCategories { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDiscount> OrderDiscounts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<DiscountCategory> DiscountCategories { get; set; }

        public DbSet<ProductCategoryDiscount> ProductCategoryDiscounts { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<ProductOrderCharm> ProductOrderCharms { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<User> Users { get; set; }

        public bool EnsureDatabaseCreated()
            => Database.EnsureCreated();

        public StreetwoodContext(DbContextOptions<StreetwoodContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new CharmCategoryConfiguration());
            builder.ApplyConfiguration(new CharmCategoryConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDiscountConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductCategoryDiscountConfiguration());
            builder.ApplyConfiguration(new ProductOrderConfiguration());
            builder.ApplyConfiguration(new ProductOrderCharmConfiguration());
            builder.ApplyConfiguration(new ShipmentConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DiscountCategoryConfiguration());
            builder.ApplyConfiguration(new ProductColorConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}
