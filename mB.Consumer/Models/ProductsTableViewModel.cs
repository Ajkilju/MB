using mB.Consumer.OpenAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Consumer.Models
{
    public class ProductsTableViewModel
    {
        public bool Fail => !string.IsNullOrWhiteSpace(Error);

        public string Error { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
