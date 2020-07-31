using Domain_Example.Notification.Domain;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behavior
{

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IDomainNotificationContext _notificationContext;


        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IDomainNotificationContext notificationContext)
        {
            _validators = validators;
            _notificationContext = notificationContext;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any() ? Notify(failures) : next();
        }

        private Task<TResponse> Notify(IEnumerable<ValidationFailure> failures)
        {
            var result = default(TResponse);

            foreach (var failure in failures)
            {
                _notificationContext.NotifyError(failure.ErrorMessage);
            }

            return Task.FromResult(result);
        }
    }

}
