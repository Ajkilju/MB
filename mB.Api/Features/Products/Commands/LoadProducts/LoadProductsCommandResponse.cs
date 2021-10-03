using mB.Api.Features.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Commands.LoadProducts
{
    public class LoadProductsCommandResponse 
    {
        public List<int> LoadedProductIds { get; set; }
    }
}
