using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IAddressQueryService
    {
        Task<IList<AddressDto>> GetByUserAsync(Guid userId);

        Task<Address> GetAsync(NewAddressDto addressDto, Guid? addressId, Guid userId);
    }
}
