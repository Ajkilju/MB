using mB.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsQueryResponse>
    {
        private readonly Context ctx;

        public GetProductsQueryHandler(Context ctx)
        {
            this.ctx = ctx;
        }

        public async Task<GetProductsQueryResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var res = new GetProductsQueryResponse();

            var products = await ctx.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    Added = x.Added,
                    Price = x.Price
                })
                .ToListAsync();

            res.Products = products;

            return res;
        }

    }
}
