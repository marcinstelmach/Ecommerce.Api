using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
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

        public async Task<OrderDiscountDto> GetValueByCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }

            var discount = await orderDiscountRepository
                .GetByCodeAsync(code);

            if (discount == null)
            {
                throw new StreetwoodException(ErrorCode.GenericNotExist(typeof(OrderDiscount)));
            }

            return mapper.Map<OrderDiscountDto>(discount);
        }

        public async Task<IList<OrderDiscountDto>> GetAsync()
        {
            var discounts = await orderDiscountRepository.GetListAsync();
            return mapper.Map<IList<OrderDiscountDto>>(discounts);
        }
    }
}
