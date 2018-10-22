using System;
using System.ComponentModel.DataAnnotations;

namespace Streetwood.Infrastructure.CustomValidators
{
    public class ValidGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Guid.TryParse(value.ToString(), out var guid) && !guid.Equals(Guid.Empty))
            {
                return ValidationResult.Success;
            }

            return null;
        }
    }
}
