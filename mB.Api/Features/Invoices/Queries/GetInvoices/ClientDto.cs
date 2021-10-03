using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Queries.GetInvoices
{
    public class ClientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
