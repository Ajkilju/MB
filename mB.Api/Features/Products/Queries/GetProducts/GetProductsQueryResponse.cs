using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}
