using FluentValidation;
using mB.Api.Features.Products.Commands.UpdateProduct;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Products.Registrations
{
    public static class ProductsRegistration
    {
        public static IServiceCollection AddProducts(this IServiceCollection services)
        {
            services.AddScoped<UpdateProductCommandValidator>();

            return services;
        }
    }
}
