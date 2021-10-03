using mB.Api.Features.Shared.Validations;
using mB.Db;
using mB.Db.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, AddInvoiceCommandResponse>
    {
        private readonly Context ctx;
        private readonly AddInvoiceCommandValidator validator;

        public AddInvoiceCommandHandler(Context ctx, AddInvoiceCommandValidator validator)
        {
            this.ctx = ctx;
            this.validator = validator;
        }

        public async Task<AddInvoiceCommandResponse> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            (await validator.ValidateAsync(request))
                .ThrowIfErrors();

            var invoice = new Invoice
            {
                ClientId = request.ClientId,
                Added = DateTime.Now,
                Paid = false,
                Products = request.Positions.Select(x => new InvoiceProduct
                {
                    Added = DateTime.Now,
                    Count = x.Count,
                    ProductId = x.ProductId
                }).ToList()
            };

            await ctx.AddAsync(invoice);
            await ctx.SaveChangesAsync();

            var res = new AddInvoiceCommandResponse
            {
                InvoiceId = invoice.Id
            };

            return res;
        }


    }
}
