using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Test.Helpers
{
    public class ShipmentFactory
    {
        public static Shipment GetShipment()
        {
            return new Shipment("UPS", "UPS", "Delivery by UPS", "Delivery by UPS", 15, ShipmentType.Courier);
        }

        public static IEnumerable<Shipment> GetShipments()
        {
            var shipments = new List<Shipment>
            {
                new Shipment("Kurier", "Courier", "SomeDescription", "SomeDescription", 15, ShipmentType.Courier),
                new Shipment("Osobisty", "Personal", "SomeDescription", "SomeDescription", 0, ShipmentType.Personal),
                new Shipment("Pobranie", "Pay on delivery", "SomeDescription", "SomeDescription", 15, ShipmentType.CashOnDelivery),
            };

            return shipments;
        }
    }
}
