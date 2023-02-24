using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Pipelines.MediatR.Validation.FluentValidation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> validationContext = new(request);

            List<ValidationResult> validationResults = _validators.Select(validator => validator.Validate(validationContext)).ToList();

            List<ValidationFailure> validationFailures = validationResults.SelectMany(validationResult  => validationResult.Errors)
                                                                          .Where(failure=>failure != null)
                                                                          .ToList();

            this.CheckIfFailuresExists(validationFailures);

            return next();
        }

        private void CheckIfFailuresExists(List<ValidationFailure> validationFailures)
        {
            if (validationFailures.Count != 0)
                throw new ValidationException(validationFailures);
        }
    }
}
