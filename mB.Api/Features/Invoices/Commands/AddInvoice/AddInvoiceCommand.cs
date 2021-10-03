using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommand : IRequest<AddInvoiceCommandResponse>
    {
        public int ClientId { get; set; }

        public List<AddInvoicePositionDto> Positions { get; set; }
    }


}
