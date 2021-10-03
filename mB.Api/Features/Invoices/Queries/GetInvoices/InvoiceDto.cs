using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Queries.GetInvoices
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        public DateTime Added { get; set; }

        public bool Paid { get; set; }

        public ClientDto Client { get; set; }

        public List<PositionDto> Positions { get; set; }
    }

}
