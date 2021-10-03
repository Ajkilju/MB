using mB.Loader.Services;
using mB.Loader.Services.Extractors;
using mB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mB.Loader
{
    public class ProductLoader
    {
        private readonly ProductExtractorFactory productExtractorFactory;
        private readonly ProductsService productsService;

        public ProductLoader(
            ProductExtractorFactory productExtractorFactory,
            ProductsService productsService)
        {
            this.productExtractorFactory = productExtractorFactory;
            this.productsService = productsService;
        }

        public ProductLoaderResult Load(LoadSource source, string dirPath)
        {
            var res = new ProductLoaderResult();

            var extractor = productExtractorFactory
                .Create(source);

            var products = extractor
                .Extract(dirPath);

            productsService
                .AddOrUpdate(products, source);

            res.LoadedProductIds = products
                .Select(x => x.Id)
                .ToList();

            return res;
        }
    }

    public class ProductLoaderResult
    {
        public List<int> LoadedProductIds { get; set; }
    }


}
