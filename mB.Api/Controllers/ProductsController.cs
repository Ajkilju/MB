using mB.Api.Features.Products.Commands.LoadProducts;
using mB.Api.Features.Products.Commands.UpdateProduct;
using mB.Api.Features.Products.Queries.GetProducts;
using mB.Api.Features.Shared.Models;
using mB.Utils;
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
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(
            IMediator mediator,
            ILogger<ProductsController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProductsQueryResponse>> GetAllProducts()
        {
            try
            {
                var query = new GetProductsQuery();

                var res = await mediator.Send(query);

                return Ok(res);
            }
            catch (Exception e)
            {
                logger.LogError(e, nameof(GetAllProducts));

                return BadRequest(e.Message);
            }
        }

        [HttpPost("load", Name = "LoadProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoadProductsCommandResponse>> LoadProducts(LoadProductsCommand request)
        {
            try
            {
                var res = await mediator.Send(request);

                return Ok(res);
            }
            catch (Exception e)
            {
                logger.LogError(e, nameof(LoadProducts));

                return BadRequest(e.Message);
            }
        }

        [HttpPost("update", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UpdateProductCommandResponse>> UpdateProduct(UpdateProductCommand request)
        {
            try
            {
                var res = await mediator.Send(request);

                return Ok(res);
            }
            catch (Exception e)
            {
                logger.LogError(e, nameof(UpdateProduct));

                return BadRequest(e.Message);
            }
        }


    }
}
