namespace Streetwood.API.Mappers
{
    using AutoMapper;
    using Streetwood.API.ViewModels.Orders;
    using Streetwood.Infrastructure.Commands.Models.Order;

    public class OrdersViewModelProfile : Profile
    {
        public OrdersViewModelProfile()
        {
            CreateMap<CreateOrderViewModel, CreateOrderCommandModel>();
        }
    }
}