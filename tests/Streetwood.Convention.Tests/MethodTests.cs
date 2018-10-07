using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Castle.Core.Internal;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Mappers;
using Xunit;
using Xunit.Abstractions;

namespace Streetwood.Convention.Tests
{
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
            var result = types.SelectMany(s => s.GetMethods())
                .Where(s => s.ReturnType.IsAssignableFrom(typeof(Task<>)) && !s.Name.EndsWith("Async"))
                .Where(s => s.DisplayName() != "DbContext.Find"); // because of EF method

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
        public void AllServicesHasOwnInterface(Type type)
        {
            // arrange
            var types = Assembly.GetAssembly(type).GetTypes();

            // act
            var services = types
                .Where(s => s.Name.EndsWith("Service"))
                .Where(s => s.IsClass);

            var interfaces = types
                .Where(s => s.Name.EndsWith("Service"))
                .Where(s => s.IsInterface);

            //assert
            services.Count().Should().Be(interfaces.Count());
        }
    }
}
