using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
        {
            private readonly IEnumerable<IValidator<TRequest>> _validators;

            public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
            {
                _validators = validators;
            }

            public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
            {
                if (!_validators.Any())
                {
                    return await next();
                }

                var context = new ValidationContext<TRequest>(request);
                var validationResults = new List<ValidationResult>();

                foreach (var validator in _validators)
                {
                    var validationResult = await validator.ValidateAsync(context, cancellationToken);
                    validationResults.Add(validationResult);

                    if (!validationResult.IsValid)
                    {
                        var errors = validationResult.Errors
                            .Where(x => x != null)
                            .Select(x => $"{x.PropertyName} => {x.ErrorMessage}");

                        var errorMessage = string.Join(Environment.NewLine, errors);

                        throw new ValidationException(errorMessage);
                    }
                }

                return await next();
            }


        }
    
}
