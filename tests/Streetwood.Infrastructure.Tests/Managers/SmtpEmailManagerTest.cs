using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Managers.Implementations;
using Streetwood.Test.Helpers;
using Xunit;

namespace Streetwood.Infrastructure.Tests.Managers
{
    public class SmtpEmailManagerTest
    {
        //Azure pipelines not ready for this test
//        [Fact]
//        public void SendAsync_Should_Not_Throw_Exception_When_Correct_Credentials()
//        {
//            // arrange
//            var options = Options.Create(EmailHelper.GetTestEmailOptions());
//
//            //act
//            IEmailManager sut = new SmtpEmailManager(options);
//            Func<Task> sendEmail = async() => await sut.SendAsync(EmailHelper.GetReceiverAddress(), "Test name", "Test", "Body");
//
//            //assert
//            sendEmail.Should().NotThrow();
//        }
    }
}
