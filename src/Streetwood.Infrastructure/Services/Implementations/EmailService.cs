using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract;

namespace Streetwood.Infrastructure.Services.Implementations
{
    internal class EmailService : IEmailService
    {
        private readonly IEmailTemplatesManager emailTemplatesManager;
        private readonly IEmailManager emailManager;

        public EmailService(IEmailTemplatesManager emailTemplatesManager, IEmailManager emailManager)
        {
            this.emailTemplatesManager = emailTemplatesManager;
            this.emailManager = emailManager;
        }

        public async Task SendNewOrderEmailAsync(OrderDto order)
        {
            var template = await emailTemplatesManager.PrepareNewOrderEmailAsync(order);
            await emailManager.SendAsync(order.User.Email, order.User.FullName, $"New order no.{order.Id}", template);
        }

        public async Task SendNewUserEmailAsync(UserDto user)
        {
            var template = await emailTemplatesManager.PrepareNewUserEmailAsync(user);
            await emailManager.SendAsync(user.FirstName, user.FullName, "Welcome in streetwood !", template);
        }

        public async Task SendForgottenPasswordEmailAsync(User user)
        {
            var template = await emailTemplatesManager.PrepareForgottenPasswordEmailAsync(user);
            await emailManager.SendAsync(user.Email, user.FullName, "Streetwood Password Reset", template);
        }
    }
}