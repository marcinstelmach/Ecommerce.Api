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
    using Streetwood.Core.Domain.Abstract.Repositories;

    public class AddOrderCommandHandlerFixture : EntitiesFixtures
    {
        public Mock<IUserQueryService> UserQueryServiceMock { get; }

        public Mock<IShipmentQueryService> ShipmentQueryServiceMock { get; }

        public Mock<IOrderDiscountQueryService> OrderDiscountQueryServiceMock { get; }

        public Mock<IProductOrderQueryService> ProductOrderQueryServiceMock { get; }

        public Mock<IAddressQueryService> AddressQueryServiceMock { get; }

        public Mock<IOrderFactory> OrderCommandServiceMock { get; }

        public Mock<IEmailService> EmailServiceMock { get; }

        public Mock<IPaymentsRepository> PaymentsRepositoryMock { get; }

        public CreateOrderCommandHandler Sut { get; }

        public CreateOrderCommandModel Request { get; }

        public AddOrderCommandHandlerFixture()
        {
            UserQueryServiceMock = new Mock<IUserQueryService>();
            ShipmentQueryServiceMock = new Mock<IShipmentQueryService>();
            OrderDiscountQueryServiceMock = new Mock<IOrderDiscountQueryService>();
            ProductOrderQueryServiceMock = new Mock<IProductOrderQueryService>();
            AddressQueryServiceMock = new Mock<IAddressQueryService>();
            OrderCommandServiceMock = new Mock<IOrderFactory>();
            EmailServiceMock = new Mock<IEmailService>();
            PaymentsRepositoryMock = new Mock<IPaymentsRepository>();
            Sut = new CreateOrderCommandHandler(UserQueryServiceMock.Object, ShipmentQueryServiceMock.Object,
                OrderDiscountQueryServiceMock.Object,
                ProductOrderQueryServiceMock.Object, AddressQueryServiceMock.Object, OrderCommandServiceMock.Object,
                EmailServiceMock.Object, PaymentsRepositoryMock.Object);
            Request = Fixture.Build<CreateOrderCommandModel>()
                .With(x => x.UserId, Guid.NewGuid)
                .Create();
        }
    }
}