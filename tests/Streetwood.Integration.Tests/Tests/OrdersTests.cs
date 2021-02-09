using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Streetwood.API;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Dto.Products;
using Streetwood.Test.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Streetwood.Integration.Tests.Tests
{
    public class OrdersTests : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private readonly InMemoryWebApplicationFactory<Startup> factory;
        private readonly ITestOutputHelper output;
        private readonly string baseEndpoint;

        public OrdersTests(InMemoryWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            this.factory = factory;
            this.output = output;
            baseEndpoint = "api/orders";
        }

//        [Fact]
        public async Task AddOrder_Should_Correctly_Add_Order_For_Non_Charm_Product_Without_Discounts()
        {
            // arrange
            var shipment = await GetShipmentForTest();
            var product = await GetNonCharmProductForTest();
            var httpClient = factory.CreateClient();
            var expectedOrderPrice = 35;
            var expectedOrderPriceAndShipment = 35 + shipment.Price;

            var token = await UserFactory.AuthenticateUser(httpClient, "test@gmail.com", "1qaz@WSX");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var addOrderCommand = new AddOrderCommandModel
            {
                ShipmentId = shipment.Id,
                Address = new NewAddressDto
                {
                    City = "NY", Country = "USA", PhoneNumber = 123456789, PostCode = "234-987", Street = "Main"
                },
                Products = new List<ProductWithCharmsOrderDto>
                {
                    new ProductWithCharmsOrderDto
                    {
                        Amount = 1, ProductId = product.Id
                    }
                }
            };

            // act
            var result = await httpClient.PostAsJsonAsync(baseEndpoint, addOrderCommand);
            var content = await result.Content.ReadAsStringAsync();
            if (!result.IsSuccessStatusCode)
            {
                output.WriteLine(content);
            }
            var newId = JsonConvert.DeserializeObject<NewOrderDto>(content);
            var newOrder = await GetOrder(newId.Id);

            // assert
            newOrder.BasePrice.Should().Be(expectedOrderPrice);
            newOrder.Address.Should().NotBe(null);
            newOrder.ProductOrders.Count().Should().Be(1);
            (newOrder.FinalPrice + newOrder.ShipmentPrice).Should().Be(expectedOrderPriceAndShipment);
        }

        private async Task<ShipmentDto> GetShipmentForTest()
        {
            var httpClient = factory.CreateClient();
            var response = await httpClient.GetAsync("api/shipments");
            var stringResponse = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<ShipmentDto>>(stringResponse).First();
        }

        private async Task<ProductDto> GetNonCharmProductForTest()
        {
            var httpClient = factory.CreateClient();
            var response = await httpClient.GetAsync("api/products");
            var stringResponse = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<ProductDto>>(stringResponse)
                .First(s => s.Name == "Product0");
        }

        private async Task<OrderDto> GetOrder(int id)
        {
            var httpClient = factory.CreateClient();
            var response = await httpClient.GetAsync($"api/orders/{id}");
            var stringResponse = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<OrderDto>(stringResponse);
        }
    }
}
