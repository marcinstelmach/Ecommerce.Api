﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Filters;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class OrderQueryService : IOrderQueryService
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public OrderQueryService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var order = await ordersRepository.GetFullAndEnsureExistsAsync(id);
            var mapped = mapper.Map<OrderDto>(order);

            return mapped;
        }

        public async Task<Order> GetRawAndEnsureExistsAsync(int id)
            => await ordersRepository.GetFullAndEnsureExistsAsync(id);

        public async Task<IList<OrderOverviewDto>> GetFilteredAsync(OrderQueryFilter filter)
        {
            var orders = ordersRepository.GetQueryable()
                .AsNoTracking()
                .Include(s => s.User)
                .Include(x => x.OrderShipment)
                .Include(x => x.OrderPayment)
                .AsQueryable();

            if (filter.Id.HasValue)
            {
                var order = await orders.FirstOrDefaultAsync(s => s.Id == filter.Id.Value);

                if (order == null && filter.UserType == UserType.Admin)
                {
                    throw new StreetwoodException(ErrorCode.OrderNotFound);
                }

                return mapper.Map<IList<OrderOverviewDto>>(new List<Order> { order });
            }

            if (filter.UserType == UserType.Customer)
            {
                orders = orders.Where(s => s.User.Id == filter.UserId);
            }

            if (filter.DateFrom.HasValue)
            {
                orders = orders.Where(s => s.CreationDateTime >= filter.DateFrom.Value);
            }

            if (filter.DateTo.HasValue)
            {
                orders = orders.Where(s => s.CreationDateTime <= filter.DateTo.Value);
            }

            if (filter.IsClosed.HasValue)
            {
                orders = orders.Where(s => s.IsClosed == filter.IsClosed);
            }

            if (filter.PaymentStatus.HasValue)
            {
                var paymentStatus = mapper.Map<PaymentStatusDto, PaymentStatus>(filter.PaymentStatus.Value);
                orders = orders.Where(s => s.OrderPayment.Status == paymentStatus);
            }

            if (filter.ShipmentStatus.HasValue)
            {
                var shipmentStatus = mapper.Map<ShipmentStatusDto, ShipmentStatus>(filter.ShipmentStatus.Value);
                orders = orders.Where(s => s.OrderShipment.Status == shipmentStatus);
            }

            orders = orders.OrderByDescending(x => x.CreationDateTime);

            if (filter.Take.HasValue)
            {
                orders = orders.Take(filter.Take.Value);
            }

            var ordersList = await orders
                .ToListAsync();
            return mapper.Map<IList<OrderOverviewDto>>(ordersList);
        }
    }
}
