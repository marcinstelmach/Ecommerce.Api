using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Streetwood.API;
using Streetwood.Core.Domain.Entities;
using Xunit;

namespace Streetwood.Integration.Tests.Tests
{
    public class CharmCategoriesTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> factory;
        private readonly string baseEndpoint;

        public CharmCategoriesTests(InMemoryWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            baseEndpoint = "/api/CharmCategories";
        }

        [Fact]
        public async Task Get_Should_Return_3_Charms_Categories()
        {
            // arrange
            var httpClient = factory.CreateClient();
            var expected = 3;

            // act
            var response = await httpClient.GetAsync(baseEndpoint);
            var message = await response.Content.ReadAsStringAsync();
            var charmCategories = JsonConvert.DeserializeObject<List<CharmCategory>>(message);

            // assert
            charmCategories.Count.Should().Be(expected);
        }
    }
}
