using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Queries.GetInvoices
{
    public class GetInvoicesQueryResponse
    {
        public List<InvoiceDto> Invoices { get; set; }
    }
}
