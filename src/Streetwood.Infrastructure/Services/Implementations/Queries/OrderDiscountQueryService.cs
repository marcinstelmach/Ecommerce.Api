using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class OrderDiscountQueryService : IOrderDiscountQueryService
    {
        private readonly IOrderDiscountRepository orderDiscountRepository;
        private readonly IMapper mapper;

        public OrderDiscountQueryService(IOrderDiscountRepository orderDiscountRepository, IMapper mapper)
        {
            this.orderDiscountRepository = orderDiscountRepository;
            this.mapper = mapper;
        }

        public async Task<IList<OrderDiscountDto>> GetAsync()
        {
            var discounts = await orderDiscountRepository.GetListAsync();
            return mapper.Map<IList<OrderDiscountDto>>(discounts);
        }
    }
}
