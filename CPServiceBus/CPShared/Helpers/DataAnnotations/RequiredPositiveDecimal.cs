using CPShared.Extensions;
using System.ComponentModel.DataAnnotations;

namespace CPShared.Helpers.DataAnnotations
{
    public class RequiredPositiveDecimal : RequiredAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                this.ErrorMessage = "The 'Amount' value is required.";
                return false;
            }

            var canParse = decimal.TryParse(value.ToString(), out var decimalValue);

            if (!canParse)
            {
                this.ErrorMessage = "The value entered for 'Amount' is not a valid decimal";
                return false;
            }

            if (!decimalValue.IsGreaterThanZero())
            {
                this.ErrorMessage = "The 'Amount' value must be greater than zero.";
                return false;
            }

            return true;
        }
    }
}
