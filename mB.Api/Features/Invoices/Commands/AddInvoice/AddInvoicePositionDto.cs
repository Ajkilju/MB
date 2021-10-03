using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Commands.AddInvoice
{
    public class AddInvoicePositionDto
    {
        public int ProductId { get; set; }

        public int Count { get; set; }

    }
}
