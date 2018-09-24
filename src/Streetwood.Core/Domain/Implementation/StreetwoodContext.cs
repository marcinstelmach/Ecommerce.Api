using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation
{
    internal class StreetwoodContext : DbContext, IDbContext
    {
        public StreetwoodContext(DbContextOptions<StreetwoodContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Shippment> Shippments { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<ProductOrderCharm> ProductOrderCharms { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Charm> Charms { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<CharmCategory> CharmCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
