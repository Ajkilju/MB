using FluentValidation;
using mB.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommandValidator : AbstractValidator<AddInvoiceCommand>
    {
        private readonly Context ctx;

        public AddInvoiceCommandValidator(Context ctx)
        {
            this.ctx = ctx;

            RuleFor(x => x)
                .MustAsync(ClientExists)
                .WithMessage("Client not found.");
        }

        public async Task<bool> ClientExists(AddInvoiceCommand e, CancellationToken token)
        {
            var exists = await ctx.Clients
                .AnyAsync(x => x.Id == e.ClientId);

            return exists;
        }


    }
}
