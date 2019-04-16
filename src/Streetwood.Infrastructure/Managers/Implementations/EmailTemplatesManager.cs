using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streetwood.Core.Constants;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class EmailTemplatesManager : IEmailTemplatesManager
    {
        private readonly IPathManager pathManager;

        public EmailTemplatesManager(IPathManager pathManager)
        {
            this.pathManager = pathManager;
        }

        public async Task<string> ReadTemplateAsync(string templateName)
        {
            var templatePath = pathManager.GetEmailTemplatePath(templateName);
            if (!File.Exists(templatePath))
            {
                throw new StreetwoodException(ErrorCode.EmailTemplateNotExists(templateName));
            }

            var emailTemplate = await File.ReadAllTextAsync(templatePath);
            return emailTemplate;
        }

        public async Task<string> PrepareNewOrderEmailAsync(Order order)
        {
            var stringTemplate = await ReadTemplateAsync(ConstantValues.NewEmailOrderTemplate);
            var startIndex = stringTemplate.IndexOf("<!--starter-->", StringComparison.Ordinal) + 14;
            var endIndex = stringTemplate.IndexOf("<!--ender-->", startIndex, StringComparison.Ordinal);
            var template = stringTemplate.Substring(startIndex, endIndex - startIndex);
            var productsTemplate = new StringBuilder();

            foreach (var productOrder in order.ProductOrders)
            {
                var tempTemplate = template.Replace("{{{ProductName}}}", productOrder.Product.Name);
                tempTemplate = tempTemplate.Replace("{{{ProductAmount}}}", productOrder.Amount.ToString(CultureInfo.InvariantCulture));
                var charms = string.Empty;
                if (productOrder.ProductOrderCharms.Any())
                {
                    var charmsNames = productOrder.ProductOrderCharms.Select(s => s.Charm.Name);
                    charms = $"({string.Join(" +", charmsNames)})";
                }

                tempTemplate = tempTemplate.Replace("{{{Charms}}}", charms);
                tempTemplate = tempTemplate.Replace("{{{Price}}}",
                    productOrder.FinalPrice.ToString(CultureInfo.InvariantCulture));
                productsTemplate.Append(tempTemplate);
            }

            stringTemplate = stringTemplate.Remove(startIndex, endIndex - startIndex);
            stringTemplate = stringTemplate.Insert(startIndex, productsTemplate.ToString());
            stringTemplate = stringTemplate.Replace("{{{TotalPrice}}}",
                order.FinalPrice.ToString(CultureInfo.InvariantCulture));

            return stringTemplate;
        }

        public async Task<string> PrepareNewUserEmailAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> PrepareForgottenPasswordEmailAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
