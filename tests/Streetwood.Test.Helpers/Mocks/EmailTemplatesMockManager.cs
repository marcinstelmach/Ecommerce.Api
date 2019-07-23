using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Test.Helpers.Mocks
{
    public class EmailTemplatesMockManager : IEmailTemplatesManager
    {
        public async Task<string> ReadTemplateAsync(string templateName)
        {
            throw new NotImplementedException();
        }

        public Task<string> PrepareNewOrderEmailAsync(OrderDto order)
        {
            return Task.FromResult("Test template");
        }

        public async Task<string> PrepareNewUserEmailAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> PrepareForgottenPasswordEmailAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
