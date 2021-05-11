using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WoW_Guild_Tools.Infrastructure
{
    public class EnumValidationAttribute : ValidationAttribute
    {
        public int MinValue { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = new ValidationResult(null);
            
            // This would not handle enums that are long, ulong etc.
            if (value is Enum && ((int)value > MinValue))
            {
                validationResult = ValidationResult.Success;
            }
            else
            {
                validationResult.ErrorMessage = $"Must select a {validationContext.MemberName}";
            }

            return validationResult;
        }
    }
}
