using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(s => s.Id)
               .NotEmpty().WithMessage("{Id} is Required")
               .NotNull()
               .GreaterThan(50).WithMessage("{Id} should be greater than zero");

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
