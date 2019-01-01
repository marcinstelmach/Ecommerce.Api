using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using FluentAssertions;
using Streetwood.Infrastructure.Modules;
using Xunit;
using Xunit.Abstractions;

namespace Streetwood.API.Tests.IoCTests
{
    public class RegistrationTests
    {
        private readonly ITestOutputHelper output;

        public RegistrationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void AllServicesAreRegistered()
        {
            //arrange
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServicesModule>();
            var container = builder.Build();

            var services = Assembly
                .GetAssembly(typeof(ServicesModule))
                .GetTypes()
                .Where(s => s.IsInterface)
                .Where(s => s.Name.EndsWith("Service"))
                .ToList();

            var unregistered = new List<string>();
            var expected = 0;

            //act
            foreach (var service in services)
            {
                if (!container.IsRegistered(service))
                {
                    unregistered.Add(service.FullName);
                }
            }

            output.WriteLine($"Registered Services: {services.Count()}");
            output.WriteLine("Unregistered: ");
            unregistered.ForEach(s => output.WriteLine(s));

            //assert
            unregistered.Count.Should().Be(expected);
        }
    }
}
