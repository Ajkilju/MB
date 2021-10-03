using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Services.Extractors
{
    public class ProductExtractorFactory
    {
        private readonly IEnumerable<IProductExtractor> productExtractors;

        public ProductExtractorFactory(IEnumerable<IProductExtractor> productExtractors)
        {
            this.productExtractors = productExtractors;
        }

        public IProductExtractor Create(LoadSource source)
        {
            var extractor = productExtractors
                .Where(x => x.Source == source)
                .FirstOrDefault();

            return extractor;
        }

    }




}
