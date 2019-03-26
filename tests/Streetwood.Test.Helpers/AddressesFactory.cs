using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class AddressesFactory
    {
        public static Address GetAddress()
            => new Address("Some street", "New York", "United States", "55-555", 123456789);
    }
}
