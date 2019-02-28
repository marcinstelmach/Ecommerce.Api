using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Implementations.Commands;
using Xunit;

namespace Streetwood.Infrastructure.Tests.CommandServices
{
    public class ProductOrderCharmCommandServiceTests
    {
        [Fact]
        public void Create_ShouldReturnProper_ProductOrderCharm_WithProductId()
        {
            // arrange
            var charms = CreateCharms(7);
            var charmsids = charms.Select(s => s.Id).ToList();
            var productWithCharmsOrderDtos = PrepareTest_ProductWithCharmOrderDto(charmsids);
            var sut = new ProductOrderCharmCommandService();

            // act
            var result = sut.Create(productWithCharmsOrderDtos, charms);
            // assert
            result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Create_ShouldAssignRightCharmsToProduct()
        {
            // arrange
            var charms = CreateCharms(7);
            var charmIds = charms.Select(s => s.Id).ToList();
            var productWithCharmsOrderDtos = PrepareTest_ProductWithCharmOrderDto(charmIds);
            var sut = new ProductOrderCharmCommandService();

            var firstProduct = productWithCharmsOrderDtos.First(s => s.ProductId == 1);
            var expectedResult = firstProduct
                .Charms
                .Select(s => s.CharmId);

            // act
            var result = sut.Create(productWithCharmsOrderDtos, charms);

            // assert
            result.Where(s => s.productId == 1)
                .Select(s => s.Item1.Charm.Id)
                .Should()
                .BeEquivalentTo(expectedResult);
        }

        private List<ProductWithCharmsOrderDto> PrepareTest_ProductWithCharmOrderDto(IList<Guid> charmIds)
        {
            var productWithCharmsOrderDtos = new List<ProductWithCharmsOrderDto>();
            var count = 1;
            var timesOfLoop = (int)charmIds.Count / 3;

            for (int i = 0; i < timesOfLoop; i++)
            {
                var productWithCharmOrderDto = new ProductWithCharmsOrderDto
                {
                    ProductId = i + 1, Charms = new List<CharmOrderDto>()
                };
                foreach (var charmId in charmIds)
                {
                    if (count <= 3)
                    {
                        productWithCharmOrderDto.Charms.Add(new CharmOrderDto
                        {
                            CharmId = charmId,
                            Sequence = count
                        });
                        count++;
                    }
                    else
                    {
                        count = 1;
                        break;
                    }
                }

                productWithCharmsOrderDtos.Add(productWithCharmOrderDto);
            }

            return productWithCharmsOrderDtos;
        }

        private IList<Charm> CreateCharms(int count)
        {
            var charms = new List<Charm>();
            for (int i = 0; i < count; i++)
            {
                charms.Add(new Charm($"Charm{i}", $"Charm{i}", "somePath", 5));
            }

            return charms;
        }
    }
}