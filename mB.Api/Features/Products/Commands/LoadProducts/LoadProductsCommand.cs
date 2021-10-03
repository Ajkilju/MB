using mB.Loader;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Commands.LoadProducts
{
    public class LoadProductsCommand : IRequest<LoadProductsCommandResponse>
    {
        public LoadSource Source { get; set; }
    }
}
