using System;
using FluentAssertions;
using Streetwood.Core.Domain.Entities;
using Xunit;

namespace Streetwood.Core.Tests.Entities
{
    public class OrderEntityTests
    {
        [Fact]
        public void SetIsClosed_ShouldUpdated_ClosedDateTime()
        {
            // arrange
            var order = new Order(null, null, null, null, 50, 60, "", null);
            var expected = DateTime.UtcNow.ToString("s");
            // act
            order.SetIsClosed(true);
            var closedDateTime = order.ClosedDateTime;
            // assert
            closedDateTime.HasValue.Should().BeTrue();
            closedDateTime.Value.ToString("s").Should().Be(expected);
        }
    }
}
