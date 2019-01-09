using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Filters;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class OrderQueryService : IOrderQueryService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderQueryService(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            var order = await orderRepository.GetFullAsync(id);
            var mapped = mapper.Map<OrderDto>(order);
            return mapped;
        }

        public async Task<IList<OrderDto>> GetFilteredAsync(OrderQueryFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
