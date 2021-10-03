using mB.Api.Features.Invoices.Commands.AddInvoice;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Features.Invoices.Registrations
{
    public static class InvoicesRegistration
    {
        public static IServiceCollection AddInvoices(this IServiceCollection services)
        {
            services.AddScoped<AddInvoiceCommandValidator>();

            return services;
        }
    }
}
