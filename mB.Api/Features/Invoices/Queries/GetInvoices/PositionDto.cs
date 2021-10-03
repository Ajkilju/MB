using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Queries.GetInvoices
{
    public class PositionDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Count { get; set; }

        public decimal Cost { get; set; }
    }
}
