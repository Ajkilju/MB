using mB.Api.Features.Invoices.Commands.AddInvoice;
using mB.Api.Features.Invoices.Queries.GetInvoices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<InvoicesController> logger;

        public InvoicesController(
            IMediator mediator,
            ILogger<InvoicesController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet(Name = "GetInvoices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetInvoicesQueryResponse>> GetInvoices(int clientId)
        {
            try
            {
                var query = new GetInvoicesQuery
                {
                    ClientId = clientId
                };

                var res = await mediator.Send(query);

                return Ok(res);
            }
            catch (Exception e)
            {
                logger.LogError(e, nameof(GetInvoices));

                return BadRequest(e.Message);
            }
        }

        [HttpPost("add", Name = "AddInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddInvoiceCommandResponse>> AddInvoice(AddInvoiceCommand request)
        {
            try
            {
                var res = await mediator.Send(request);

                return Ok(res);
            }
            catch (Exception e)
            {
                logger.LogError(e, nameof(AddInvoice));

                return BadRequest(e.Message);
            }
        }


    }
}
