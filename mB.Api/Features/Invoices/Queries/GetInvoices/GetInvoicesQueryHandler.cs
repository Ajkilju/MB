using mB.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Queries.GetInvoices
{
    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, GetInvoicesQueryResponse>
    {
        private readonly Context ctx;

        public GetInvoicesQueryHandler(Context ctx)
        {
            this.ctx = ctx;
        }

        public async Task<GetInvoicesQueryResponse> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var res = new GetInvoicesQueryResponse();

            var invoices = await ctx.Invoices
                .Where(x => x.ClientId == request.ClientId)
                .Select(x => new InvoiceDto
                {
                    Id = x.Id,
                    Added = x.Added,
                    Paid = x.Paid,
                    Client = new ClientDto
                    {
                        Id = x.Client.Id,
                        Name = x.Client.Name,
                        LastName = x.Client.LastName
                    },
                    Positions = x.Products.Select(p => new PositionDto
                    {
                        ProductId = p.Product.Id,
                        ProductName = p.Product.Name,
                        Count = p.Count,
                        Cost = p.Product.Price * p.Count
                    }).ToList()
                })
                .ToListAsync();

            res.Invoices = invoices;

            return res;
        }

    }
}
