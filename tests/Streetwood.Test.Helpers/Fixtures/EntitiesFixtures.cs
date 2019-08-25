using System;
using System.Collections.Generic;
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

        public Shipment Shipment { get; private set; }

        public OrderDiscount OrderDiscount { get; private set; }

        public Order Order { get; private set; }

        public EntitiesFixtures()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            CreateUser();
            CreateProducts();
            CreateShipment();
            CreateOrderDiscount();
            CreateOrder();
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
    }
}