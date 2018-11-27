using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IAddressQueryService
    {
        Task<IList<AddressDto>> GetByUserAsync(Guid userId);
    }
}
