using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Streetwood.API;
using Streetwood.Infrastructure.Dto;
using Xunit;

namespace Streetwood.Integration.Tests.Tests
{
    public class ShipmentsControllerTests :  IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> factory;

        public ShipmentsControllerTests(InMemoryWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_Return_AllShipments()
        {
            //arrange
            var httpClient = factory.CreateClient();
            
            //act
            var response = await httpClient.GetAsync("api/shipments");
            var stringResponse = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            //assert
            var shipments = JsonConvert.DeserializeObject<List<ShipmentDto>>(stringResponse);
            shipments.Count.Should().Be(3);
        }
    }
}
