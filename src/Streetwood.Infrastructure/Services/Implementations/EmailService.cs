using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streetwood.Core.Constants;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract;

namespace Streetwood.Infrastructure.Services.Implementations
{
    internal class EmailService : IEmailService
    {
        private readonly IEmailTemplatesManager emailTemplatesManager;

        public EmailService(IEmailTemplatesManager emailTemplatesManager)
        {
            this.emailTemplatesManager = emailTemplatesManager;
        }

        public async Task SendAsync(string receiver, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public async Task<string> PrepareNewOrderEmailAsync(Order order)
        {
            var stringTemplate = await emailTemplatesManager.ReadTemplateAsync(ConstantValues.NewEmailOrderTemplate);
            var startIndex = stringTemplate.IndexOf("<!--starter-->", StringComparison.Ordinal) + 14;
            var endIndex = stringTemplate.IndexOf("<!--ender-->", startIndex, StringComparison.Ordinal);
            var template = stringTemplate.Substring(startIndex, endIndex);
            var productsTemplate = new StringBuilder();

            foreach (var productOrder in order.ProductOrders)
            {
                var tempTemplate = template.Replace("{{{ProductName}}}", productOrder.Product.Name);
                var charms = string.Empty;
                if (productOrder.ProductOrderCharms.Any())
                {
                    var charmsNames = productOrder.ProductOrderCharms.Select(s => s.Charm.Name);
                    charms = $"({string.Join(" +", charmsNames)})";
                }

                tempTemplate = tempTemplate.Replace("{{{Charms}}}", charms);
                tempTemplate = tempTemplate.Replace("{{{Price}}}", productOrder.FinalPrice.ToString(CultureInfo.InvariantCulture));
                productsTemplate.Append(tempTemplate);
            }

            stringTemplate = stringTemplate.Remove(startIndex, endIndex - startIndex);
            stringTemplate = stringTemplate.Insert(startIndex, productsTemplate.ToString());
            stringTemplate = stringTemplate.Replace("{{{TotalPrice}}", order.FinalPrice.ToString(CultureInfo.InvariantCulture));

            return stringTemplate;
        }

        public async Task<string> PrepareNewUserEmailAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ForgottenPasswordEmailAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
