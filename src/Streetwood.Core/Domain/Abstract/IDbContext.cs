using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract
{
    public interface IDbContext : IDisposable
    {
        DbSet<Address> Addresses { get; set; }

        DbSet<Charm> Charms { get; set; }

        DbSet<CharmCategory> CharmCategories { get; set; }

        DbSet<Image> Images { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<OrderDiscount> OrderDiscounts { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<DiscountCategory> DiscountCategories { get; set; }

        DbSet<ProductCategoryDiscount> ProductCategoryDiscounts { get; set; }

        DbSet<ProductOrder> ProductOrders { get; set; }

        DbSet<ProductOrderCharm> ProductOrderCharms { get; set; }

        DbSet<Shipment> Shipments { get; set; }

        DbSet<Payment> Payments { get; set; }

        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        bool EnsureDatabaseCreated();
    }
}
