namespace Streetwood.API.CustomValidators
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Streetwood.API.ViewModels.Orders;
    using Streetwood.Core.Exceptions;

    [AttributeUsage(AttributeTargets.Class)]
    public class OrderAddressValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (CreateOrderViewModel)value;
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
