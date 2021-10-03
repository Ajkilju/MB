using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Queries.GetInvoices
{
    public class GetInvoicesQuery : IRequest<GetInvoicesQueryResponse>
    {
        public int ClientId { get; set; }
    }
}
