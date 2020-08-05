using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.CustomValidations;
using FluentValidation;
using MediatR;

namespace Application.ValidationBehavior
{
   public class ValidationBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest:IRequest<TResponse>
   {
       //this return every validator in DI container for this specific request 
       private readonly IEnumerable<IValidator<TRequest>> _validators;

       public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
       {
           _validators = validators;
       }

       public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //pre 
            var context =new ValidationContext(request);
            var failures = _validators.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .Select(x=>new RequestInValidException.DataTypeExceptionError
                {
                    Code = x.ErrorCode,
                    PropertyName=x.PropertyName
                })
                .ToList();

            if (failures.Any())
            {
                throw new RequestInValidException(failures.ToArray());
            }

            //behavior 
            return next();

            //post

        }
    }
}
