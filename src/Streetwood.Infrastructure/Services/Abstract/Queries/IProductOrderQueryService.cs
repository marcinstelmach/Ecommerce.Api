using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IProductOrderQueryService
    {
        Task<IList<ProductOrder>> CreateAsync(IList<ProductWithCharmsOrderDto> productsWithCharmsOrder);
    }
}