using System;
using AutoFixture;
using AutoMapper;
using Moq;
using Streetwood.Infrastructure.Commands.Handlers.Order;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Services.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;
using Streetwood.Infrastructure.Services.Abstract.Queries;
using Streetwood.Test.Helpers.Fixtures;

namespace Streetwood.Infrastructure.Tests.CommandHandlers
{
    public class AddOrderCommandHandlerFixture : EntitiesFixtures
    {
        public Mock<IUserQueryService> UserQueryServiceMock { get; }

        public Mock<IShipmentQueryService> ShipmentQueryServiceMock { get; }

        public Mock<IOrderDiscountQueryService> OrderDiscountQueryServiceMock { get; }

        public Mock<IProductOrderQueryService> ProductOrderQueryServiceMock { get; }

        public Mock<IAddressQueryService> AddressQueryServiceMOck { get; }

        public Mock<IOrderCommandService> OrderCommandServiceMock { get; }

        public Mock<IEmailService> EmailServiceMock { get; }

        public Mock<IMapper> MapperMock { get; }

        public AddOrderCommandHandler Sut { get; }

        public AddOrderCommandModel Request { get; }

        public AddOrderCommandHandlerFixture()
        {
            UserQueryServiceMock = new Mock<IUserQueryService>();
            ShipmentQueryServiceMock = new Mock<IShipmentQueryService>();
            OrderDiscountQueryServiceMock = new Mock<IOrderDiscountQueryService>();
            ProductOrderQueryServiceMock = new Mock<IProductOrderQueryService>();
            AddressQueryServiceMOck = new Mock<IAddressQueryService>();
            OrderCommandServiceMock = new Mock<IOrderCommandService>();
            EmailServiceMock = new Mock<IEmailService>();
            MapperMock = new Mock<IMapper>();
            Sut = new AddOrderCommandHandler(UserQueryServiceMock.Object, ShipmentQueryServiceMock.Object, OrderDiscountQueryServiceMock.Object,
                ProductOrderQueryServiceMock.Object, AddressQueryServiceMOck.Object, OrderCommandServiceMock.Object, EmailServiceMock.Object, MapperMock.Object);
            Request = Fixture.Build<AddOrderCommandModel>()
                .Do(s => s.SetUserId(Guid.NewGuid()))
                .Create();
        }
    }
}
