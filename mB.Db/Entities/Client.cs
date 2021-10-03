using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Db.Entities
{
    public class Client : Entity
    { 
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
