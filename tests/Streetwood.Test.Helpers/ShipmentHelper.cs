using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Test.Helpers
{
    public class ShipmentHelper
    {
        public static Shipment GetShipment()
        {
            return new Shipment("UPS", "UPS", "Delivery by UPS", "Delivery by UPS", 15, ShipmentType.Courier);
        }
    }
}
