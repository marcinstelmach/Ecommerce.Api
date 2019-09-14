using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Managers.Implementations;
using Streetwood.Test.Helpers.SpecimenBuilders;

namespace Streetwood.Test.Helpers.Fixtures
{
    public class EntitiesFixtures
    {
        public IFixture Fixture { get; }

        public User User { get; private set; }

        public IEnumerable<Product> Products { get; private set; }

        public Product Product => Products.First();

        public Shipment Shipment { get; private set; }

        public OrderDiscount OrderDiscount { get; private set; }

        public Order Order { get; private set; }

        public ProductCategoryDiscount ProductCategoryDiscount { get; private set; }

        public ProductOrder ProductOrder { get; private set; }

        public EntitiesFixtures()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            CreateUser();
            CreateProducts();
            CreateShipment();
            CreateOrderDiscount();
            CreateOrder();
            CreateProductOrder();
            CreateProductCategoryDiscount();
        }

        private void CreateUser()
        {
            User = Fixture.Build<User>()
                .Do(x => x.SetRefreshToken(Fixture.Create<string>()))
                .Do(x => x.SetPassword(Fixture.Create<string>(), new PasswordEncrypter()))
                .Do(x => x.SetRefreshToken(Fixture.Create<string>()))
                .Create();
        }

        private void CreateProducts()
        {
            Products = Fixture.CreateMany<Product>();
        }

        private void CreateShipment()
        {
            Shipment = Fixture.Create<Shipment>();
        }

        private void CreateOrderDiscount()
        {
            Fixture.Customizations.Add(new DateFromSpecimenBuilder());
            Fixture.Customizations.Add(new DateToSpecimenBuilder());

            // Need to put values to constructor
            OrderDiscount = Fixture.Create<OrderDiscount>();
        }

        private void CreateOrder()
        {
            Fixture.Register<OrderDiscount>(() => OrderDiscount);
            Order = Fixture.Create<Order>();
        }

        private void CreateProductOrder()
        {
            ProductOrder = Fixture.Create<ProductOrder>();
            ProductOrder.AddProduct(Product);
        }

        private void CreateProductCategoryDiscount()
        {
            var rnd = new Random();
            var percentValue = rnd.Next(1, 99);
            ProductCategoryDiscount = Fixture.Build<ProductCategoryDiscount>()
                .Do(x => x.SetPercentValue(percentValue))
                .Create();
        }
    }
}