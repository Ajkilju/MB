using mB.Loader;
using mB.Loader.Services;
using mB.Loader.Services.Extractors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Registrations
{
    public static class ProductsLoaderRegistration
    {
        public static IServiceCollection AddProductsLoader(this IServiceCollection services)
        {
            services.AddScoped<ProductLoader>();
            services.AddScoped<ProductExtractorFactory>();
            services.AddScoped<ProductsService>();
            services.AddScoped<IProductExtractor, XmlProductExtractor>();
            services.AddScoped<IProductExtractor, CsvProductExtractor>();
            services.AddScoped<Utils.ILogger, Utils.ConsoleLogger>();

            return services;
        }
    }
}
