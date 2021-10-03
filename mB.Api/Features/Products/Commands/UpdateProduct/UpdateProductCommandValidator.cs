using FluentValidation;
using mB.Api.Features.Shared.Validations;
using mB.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly Context ctx;

        public UpdateProductCommandValidator(Context ctx)
        {
            this.ctx = ctx;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ValidatorMessage.IsRequired);

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage(ValidatorMessage.IsRequired);

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage(ValidatorMessage.IsRequired);

            RuleFor(x => x)
                .MustAsync(ProductExists)
                .WithMessage("Product not found.");
        }

        public async Task<bool> ProductExists(UpdateProductCommand e, CancellationToken token)
        {
            var exists = await ctx.Products
                .Where(x => x.Id == e.Id)
                .AnyAsync();

            return exists;
        }

    }
}
