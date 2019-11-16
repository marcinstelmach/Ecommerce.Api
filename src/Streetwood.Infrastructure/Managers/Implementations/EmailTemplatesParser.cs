using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    public class EmailTemplatesParser : IEmailTemplateParser
    {
        private readonly ClientOptions clientOptions;

        public EmailTemplatesParser(IOptions<ClientOptions> clientOptions)
        {
            this.clientOptions = clientOptions.Value;
        }

        public string PrepareNewOrderEmailAsync(OrderDto order, string stringTemplate)
        {
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);

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
                    charms = $"({string.Join(" | ", charmsNames)})";
                }

                tempTemplate = tempTemplate.Replace("{{{Charms}}}", charms);
                tempTemplate = tempTemplate.Replace("{{{Price}}}",
                    (productOrder.FinalPrice * productOrder.Amount).ToString(CultureInfo.InvariantCulture));
                productsTemplate.Append(tempTemplate);
            }

            stringTemplate = stringTemplate.Remove(startIndex, endIndex - startIndex);
            stringTemplate = stringTemplate.Insert(startIndex, productsTemplate.ToString());
            stringTemplate = stringTemplate.Replace("{{{TotalPrice}}}", order.FinalPrice.ToString(CultureInfo.InvariantCulture));
            stringTemplate = stringTemplate.Replace("{{{FullName}}}", order.User.FullName);
            stringTemplate = stringTemplate.Replace("{{{Street}}}", order.Address.Street);
            stringTemplate = stringTemplate.Replace("{{{PhoneNumber}}}", order.Address.PhoneNumber.ToString(CultureInfo.InvariantCulture));
            stringTemplate = stringTemplate.Replace("{{{PostCode}}}", order.Address.PostCode);
            stringTemplate = stringTemplate.Replace("{{{City}}}", order.Address.City);
            stringTemplate = stringTemplate.Replace("{{{ShipmentName}}}", order.Shipment.Name);
            stringTemplate = stringTemplate.Replace("{{{ShipmentPrice}}}", order.ShipmentPrice.ToString("F", CultureInfo.InvariantCulture));
            stringTemplate = stringTemplate.Replace("{{{OrderPrice}}}", (order.FinalPrice + order.ShipmentPrice).ToString("F", CultureInfo.InvariantCulture));
            
            return stringTemplate;
        }

        public string PrepareActivateNewUserEmail(User user, string stringTemplate)
        {
            var url = $"{clientOptions.Url}activate";
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{url}}}", url);
            stringTemplate = stringTemplate.Replace("{{{name}}}", user.FullName);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);
            return stringTemplate;
        }

        public string PrepareResetPasswordEmail(User user, string stringTemplate)
        {
            var url = $"{clientOptions.Url}password/recovery?token={user.ChangePasswordToken}";
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{url}}}", url);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);
            return stringTemplate;
        }

        public string PrepareOrderWasShippedEmail(OrderDto order, string stringTemplate)
        {
            var url = $"{clientOptions.Url}profile/my-orders/{order.Id}";
            var today = DateTime.Today.ToString("d", CultureInfo.InvariantCulture);
            stringTemplate = stringTemplate.Replace("{{{today}}}", today);
            stringTemplate = stringTemplate.Replace("{{{name}}}", order.User.FirstName);
            stringTemplate = stringTemplate.Replace("{{{orderId}}}", order.Id.ToString(CultureInfo.InvariantCulture));
            stringTemplate = stringTemplate.Replace("{{{url}}}", url);
            return stringTemplate;
        }
    }
}