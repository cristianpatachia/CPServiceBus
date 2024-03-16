using CPShared.Models;
using FluentValidation;

namespace CPShared.Validators
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.From)
                .NotEmpty().WithMessage("'From' cannot be empty")
                .MinimumLength(3)
                .MaximumLength(128);
            
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("'To' cannot be empty")
                .MinimumLength(3)
                .MaximumLength(128);

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("'Amount' cannot be empty")
                .GreaterThan(0).WithMessage("'Amount' must be greater than zero");
        }
    }
}
