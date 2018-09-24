using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract
{
    public interface IDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<Address> Addresses { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Shippment> Shippments { get; set; }

        DbSet<Discount> Discounts { get; set; }

        DbSet<ProductOrder> ProductOrders { get; set; }

        DbSet<ProductOrderCharm> ProductOrderCharms { get; set; }

        DbSet<Image> Images { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Charm> Charms { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<CharmCategory> CharmCategories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
