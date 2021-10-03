using mB.Api.Features.Shared.Validations;
using mB.Db;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly Context ctx;
        private readonly UpdateProductCommandValidator validator;

        public UpdateProductCommandHandler(
            Context ctx,
            UpdateProductCommandValidator validator)
        {
            this.ctx = ctx;
            this.validator = validator;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            (await validator.ValidateAsync(request))
                .ThrowIfErrors();

            var product = await ctx.Products
                .FindAsync(request.Id);

            product.Name = request.Name;
            product.Category = request.Category;
            product.Price = request.Price;

            await ctx.SaveChangesAsync();

            var res = new UpdateProductCommandResponse();

            return res;
        }


    }
}
