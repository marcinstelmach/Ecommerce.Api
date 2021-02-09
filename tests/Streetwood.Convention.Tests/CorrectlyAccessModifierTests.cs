namespace Streetwood.Convention.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using FluentAssertions;
    using Streetwood.API.Mappings;
    using Streetwood.Core.Exceptions;
    using Xunit;
    using Xunit.Abstractions;

    public class CorrectlyAccessModifierTests
    {
        private readonly ITestOutputHelper output;

        public CorrectlyAccessModifierTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(typeof(StreetwoodException))]
        [InlineData(typeof(AutoMapperConfig))]
        public void ServicesShouldBeInternal_WhenImplementsPublicInterface(Type type)
        {
            //arrange, act
            var services = Assembly.GetAssembly(type)
                .GetTypes()
                .Where(s => s.IsClass)
                .Where(s => s.Name.EndsWith("Service"))
                .Where(s => s.IsPublic);

            //assert
            services.Count().Should().Be(0);
        }

        [Theory]
        [InlineData(typeof(StreetwoodException))]
        [InlineData(typeof(AutoMapperConfig))]
        public void ServicesShouldImplementInterface(Type type)
        {
            //arrange
            var services = Assembly.GetAssembly(type)
                .GetTypes()
                .Where(s => s.IsClass)
                .Where(s => s.Name.EndsWith("Service"));
            var countOfNonImplementingClasses = 0;

            foreach (var service in services)
            {
                var interfaces = service.GetInterfaces();
                if (!interfaces.Any())
                {
                    output.WriteLine($"{service.Name}\n");
                    countOfNonImplementingClasses++;
                }
            }

            //assert
            countOfNonImplementingClasses.Should().Be(0);
        }
    }
}
