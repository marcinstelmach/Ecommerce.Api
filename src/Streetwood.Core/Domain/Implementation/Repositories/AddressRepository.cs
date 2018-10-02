using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(IDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
