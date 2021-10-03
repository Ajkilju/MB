using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Db.Entities
{
    public class InvoiceProduct : Entity
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int Count { get; set; }
    }
}
