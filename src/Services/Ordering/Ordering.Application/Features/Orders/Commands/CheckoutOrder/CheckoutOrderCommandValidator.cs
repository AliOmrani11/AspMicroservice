using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(s => s.UserName)
                .NotEmpty().WithMessage("{Username} is Required")
                .NotNull()
                .MaximumLength(50).WithMessage("{Username} is not exceed 50 characters");

            RuleFor(s => s.EmailAddress)
                .NotEmpty().WithMessage("{EmailAddress} is Required");

            RuleFor(s => s.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is Required")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero");
        }
    }
}
