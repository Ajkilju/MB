using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Shared.Validations
{
    public static class ValidationResultExtensions
    {
        public static void ThrowIfErrors(this ValidationResult result)
        {
            if (result.Errors.Count > 0)
            {
                var errors = result.Errors
                    .Select(x => x.ErrorMessage)
                    .ToList();

                var message = string.Join("; ", errors);

                throw new Exception(message);
            }
        }


    }
}
