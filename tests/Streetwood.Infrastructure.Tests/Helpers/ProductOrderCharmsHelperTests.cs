using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Implementations.Helpers;
using Xunit;

namespace Streetwood.Infrastructure.Tests.Helpers
{
    public class ProductOrderCharmsHelperTests
    {
        private readonly ProductOrderCharmsHelper sut;

        public ProductOrderCharmsHelperTests()
        {
            sut = new ProductOrderCharmsHelper();
        }

        [Theory]
        [AutoData]
        public void When_Creating_Product_Order_Charms_And_Charm_Does_Not_Exists_Then_Throws_Exception(
            IEnumerable<CharmOrderDto> charmsOrderDto, IList<Charm> charms)
        {
            // Act
            Action action = () => sut.CreateProductOrderCharms(charmsOrderDto, charms);

            // Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void When_Creating_Product_Order_Charms_Then_Returns_Correct_Ordered_Product_Order_Charms()
        {
            // Arrange
            var (charmsOrderDto, charms) = CreateData();
            var productOrderCharms = new List<ProductOrderCharm>();
            foreach (var charmOrder in charmsOrderDto)
            {
                var charm = charms.SingleOrDefault(s => s.Id == charmOrder.CharmId);
                var productOrderCharm = new ProductOrderCharm(charm, charmOrder.Sequence);
                productOrderCharms.Add(productOrderCharm);
            }

            var expected = productOrderCharms.OrderBy(x => x.Sequence).ToList();

            // Act
            var result = sut.CreateProductOrderCharms(charmsOrderDto, charms);

            // Assert
            result.Should().BeEquivalentTo(expected, x => x.Excluding(y => y.Id));
        }

        private (IList<CharmOrderDto>, IList<Charm>) CreateData()
        {
            var fixture = new Fixture();
            var charms = fixture.CreateMany<Charm>().ToList();
            var charmsOrderDto = new List<CharmOrderDto>
            {
                new CharmOrderDto {CharmId = charms.ElementAt(0).Id, Sequence = fixture.Create<int>()},
                new CharmOrderDto {CharmId = charms.ElementAt(1).Id, Sequence = fixture.Create<int>()},
                new CharmOrderDto {CharmId = charms.ElementAt(2).Id, Sequence = fixture.Create<int>()}
            };
            return (charmsOrderDto, charms);
        }
    }
}