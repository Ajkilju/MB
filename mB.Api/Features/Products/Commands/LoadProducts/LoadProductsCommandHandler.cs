using mB.Loader;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Commands.LoadProducts
{
    public class LoadProductsCommandHandler : IRequestHandler<LoadProductsCommand, LoadProductsCommandResponse>
    {
        private readonly ProductLoader productLoader;
        private readonly Paths paths;

        public LoadProductsCommandHandler(ProductLoader productLoader, IOptions<Paths> paths)
        {
            this.productLoader = productLoader;
            this.paths = paths.Value;
        }

        public Task<LoadProductsCommandResponse> Handle(LoadProductsCommand request, CancellationToken cancellationToken)
        {
            var res = new LoadProductsCommandResponse();

            var loaderRes = productLoader
                .Load(request.Source, paths.LoaderSource);

            res.LoadedProductIds = loaderRes.LoadedProductIds;

            return Task.FromResult(res);
        }
    }
}
