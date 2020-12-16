using System;
using System.ComponentModel.DataAnnotations;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Commands.Models.Order;

namespace Streetwood.Infrastructure.CustomValidators
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OrderAddressValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (AddOrderCommandModel)value;
            if (model.Address == null && model.AddressId == null)
            {
                return new ValidationResult(ErrorsMessages.MissingAddressInformation, new[] { nameof(model.Address), nameof(model.AddressId) });
            }

            if (model.Address != null && model.AddressId != null)
            {
                return new ValidationResult(ErrorsMessages.ProvidedBothAddresses, new[] { nameof(model.Address), nameof(model.AddressId) });
            }

            return ValidationResult.Success;
        }
    }
}
