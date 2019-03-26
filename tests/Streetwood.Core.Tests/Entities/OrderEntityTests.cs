using System;
using System.Collections.Generic;
using FluentAssertions;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Test.Helpers;
using Xunit;

namespace Streetwood.Core.Tests.Entities
{
    public class OrderEntityTests
    {
        [Fact]
        public void SetIsClosed_ShouldUpdate_ClosedDateTime()
        {
            // arrange
            var shipment = new Shipment("Test1", "Test1", "", "", 50M, ShipmentType.Courier);
            var order = new Order(UserFactory.CreateUser(), new List<ProductOrder>(), null, shipment, 50, 60, "", null);
            var expected = DateTime.UtcNow.ToString("f");

            // act
            order.SetIsClosed(true);
            var closedDateTime = order.ClosedDateTime;

            // assert
            closedDateTime.HasValue.Should().BeTrue();
            closedDateTime.Value.ToString("f").Should().Be(expected);
        }
    }
}
