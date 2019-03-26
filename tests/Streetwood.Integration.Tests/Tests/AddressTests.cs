using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Streetwood.API;
using Streetwood.Test.Helpers;
using Xunit;

namespace Streetwood.Integration.Tests.Tests
{
    public class AddressTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> factory;
        private readonly string baseEndpoint;

        public AddressTests(InMemoryWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
            baseEndpoint = "api/Addresses";
        }

        [Fact]
        public async Task Get_Should_Return_Unauthorized_For_No_Auth_Header()
        {
            //arrange
            var httpClient = factory.CreateClient();
            var expected = HttpStatusCode.Unauthorized;

            //act
            var httpResponse = await httpClient.GetAsync(baseEndpoint);

            // assert
            httpResponse.StatusCode.Should().Be(expected);
        }

        [Fact]
        public async Task Get_With_Correct_Auth_Token_Should_Return_Ok_Status()
        {
            //arrange
            var expected = HttpStatusCode.OK;
            var httpClient = factory.CreateClient();
            var token = await UserFactory.AuthenticateUser(httpClient, "test@gmail.com", "1qaz@WSX");

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            //act
            var response = await httpClient.GetAsync(baseEndpoint);

            // assert
            response.StatusCode.Should().Be(expected);
        }
    }
}
