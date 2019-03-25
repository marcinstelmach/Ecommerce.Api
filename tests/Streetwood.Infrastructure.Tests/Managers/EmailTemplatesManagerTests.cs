using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Managers.Implementations;
using Xunit;

namespace Streetwood.Infrastructure.Tests.Managers
{
    public class EmailTemplatesManagerTests
    {
        private readonly Mock<IPathManager> pathManager;

        public EmailTemplatesManagerTests()
        {
            pathManager = new Mock<IPathManager>();
        }

        [Fact]
        public async Task ReadTemplateAsync_Should_Return_Proper_Template()
        {
            // arrange
            pathManager.Setup(s => s.GetEmailTemplatePath(It.IsAny<string>()))
                .Returns("./Resources/Emails/NewOrder.html");
            var templateName = "whatever";
            var sut = new EmailTemplatesManager(pathManager.Object);

            //act
            var result = await sut.ReadTemplateAsync(templateName);

            // assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadTemplateAsync_Should_Throw_Exception_WithCode_EmailTemplateNotExists()
        {
            // arrange
            pathManager.Setup(s => s.GetEmailTemplatePath(It.IsAny<string>()))
                .Returns("./Resources/Emails/WrongTemplate.html");
            var templateName = "NewOrder.html";
            var sut = new EmailTemplatesManager(pathManager.Object);

            //act
            Func<Task<string>> result = async () => await sut.ReadTemplateAsync(templateName);

            // assert
            result.Should().Throw<StreetwoodException>()
                .Which.ErrorCode.Should().BeEquivalentTo(ErrorCode.EmailTemplateNotExists(templateName));
        }
    }
}
