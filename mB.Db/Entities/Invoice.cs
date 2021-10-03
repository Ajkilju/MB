using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Db.Entities
{
    public class Invoice : Entity
    { 
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public List<InvoiceProduct> Products { get; set; }

        public bool Paid { get; set; }
    }
}
