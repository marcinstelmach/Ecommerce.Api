using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var charms = CreateCharms();
            var charmsids = charms.Select(s => s.Id).ToList();
            var productWithCharmsOrderDtos = PrepareTest_ProductWithCharmOrderDto(charmsids);
            var sut = new ProductOrderCharmCommandService();

            // act
            var result = sut.Create(productWithCharmsOrderDtos, charms);
            // assert
            result.Should().NotBeNullOrEmpty();
        }

        private List<ProductWithCharmsOrderDto> PrepareTest_ProductWithCharmOrderDto(IList<Guid> charmIds)
        {
            var productWithCharmsOrderDtos = new List<ProductWithCharmsOrderDto>();
            var count = 1;
            var timesOfLoop = (int)charmIds.Count / 3;
            
            for (int i = 0; i < timesOfLoop; i++)
            {
                var productWithCharmOrderDto = new ProductWithCharmsOrderDto{ProductId = i, Charms = new List<CharmOrderDto>()};
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

        private IList<Charm> CreateCharms()
        {
            var charms = new List<Charm>();
            for (int i = 0; i < 7; i++)
            {
                charms.Add(new Charm($"Charm{i}", "", "", 5));
            }

            return charms;
        }
    }
}