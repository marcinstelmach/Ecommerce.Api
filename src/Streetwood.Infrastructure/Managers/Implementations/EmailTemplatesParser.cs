using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    public class EmailTemplatesParser : IEmailTemplateParser
    {
        public string PrepareNewOrderEmailAsync(OrderDto order, string stringTemplate)
        {
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

        public async Task<string> PrepareNewUserEmailAsync(UserDto user)
        {
            // just for test
            return await Task.FromResult($"{user.Email}, {user.FirstName}");
        }

        public async Task<string> PrepareForgottenPasswordEmailAsync(User user)
        {
            // just for test
            var content = $"Email:{user.Email},<br>Token: {user.ChangePasswordToken}<br>"
                + $"Url: <a href=\"http://localhost:4200/password/recovery?token={user.ChangePasswordToken}\">http://localhost:4200/password/recovery?token={user.ChangePasswordToken}</a>";
            return await Task.FromResult(content);
        }
    }
}