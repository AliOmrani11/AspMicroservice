using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<Tresponse> Handle(TRequest request, CancellationToken cancellationToken
            , RequestHandlerDelegate<Tresponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(_validators.Select(s=>s.ValidateAsync(context,cancellationToken)));

                var failures = validationResult.SelectMany(s => s.Errors).Where(f => f != null).ToList();
                if (failures.Any())
                {
                    throw new Exceptions.ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
