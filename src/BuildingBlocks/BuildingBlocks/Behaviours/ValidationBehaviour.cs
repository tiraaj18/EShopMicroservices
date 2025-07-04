﻿namespace BuildingBlocks.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest: ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var errors = validationResults
                .SelectMany(result => result.Errors)
                .Where(error => error is not null)
                .ToList();
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            return await next();
        }
    }
}
