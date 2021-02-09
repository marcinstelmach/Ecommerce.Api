namespace Streetwood.Convention.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Castle.Core.Internal;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore.Internal;
    using Streetwood.API.Mappings;
    using Streetwood.Core.Exceptions;
    using Xunit;
    using Xunit.Abstractions;

    public class MethodTests
    {
        private readonly ITestOutputHelper output;

        public MethodTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(typeof(StreetwoodException))]
        [InlineData(typeof(AutoMapperConfig))]
        public void AsyncMethodsShouldEndsWithAsync(Type type)
        {
            // arrange
            var types = Assembly.GetAssembly(type).GetTypes();

            // act
            var result = types
                .SelectMany(s => s.GetMethods())
                .Where(s => s.ReturnType.IsAssignableFrom(typeof(Task<>)))
                .Where(s => !s.ReturnType.IsEquivalentTo(typeof(object))) // because of System methods
                .Where(s => !s.Name.EndsWith("Async"))
                .Where(s => s.DisplayName() != "DbContext.Find")
                .ToList(); // because of EF method

            // assert
            if (!result.IsNullOrEmpty())
            {
                output.WriteLine(string.Join('\n', result.Select(s => s.DisplayName())));
            }

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(typeof(StreetwoodException))]
        [InlineData(typeof(AutoMapperConfig))]
        public void AllServicesImplementsInterface(Type type)
        {
            // arrange
            var types = Assembly.GetAssembly(type).GetTypes();
            var expected = 0;

            var services = types
                .Where(s => s.Name.EndsWith("Service"))
                .Where(s => s.IsClass)
                .ToList();

            // act
            var nakedServices = 0;
            foreach (var service in services)
            {
                var interfaces = service.GetInterfaces();
                if (!interfaces.Any())
                {
                    nakedServices++;
                    output.WriteLine(service.DisplayName());
                }
            }

            //assert
            nakedServices.Should().Be(expected);
        }
    }
}
