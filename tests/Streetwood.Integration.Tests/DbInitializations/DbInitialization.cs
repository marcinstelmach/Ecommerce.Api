using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Test.Helpers;

namespace Streetwood.Integration.Tests.DbInitializations
{
    public static class DbInitialization
    {
        public static void InitDb(IDbContext dbContext)
        {
            var shipments = new List<Shipment>
            {
                new Shipment("Kurier", "Courier", "SomeDescription", "SomeDescription", 15, ShipmentType.Courier),
                new Shipment("Osobisty", "Personal", "SomeDescription", "SomeDescription", 0, ShipmentType.Personal),
                new Shipment("Pobranie", "Pay on delivery", "SomeDescription", "SomeDescription", 15,
                    ShipmentType.CashOnDelivery)
            };

            dbContext.Shipments.AddRange(shipments);

            var user = UserFactory.CreateUser();
            dbContext.Users.Add(user);

            dbContext.SaveChanges();
        }
    }
}
