using mB.Api.Model;
using mB.Api.Services;
using mB.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ProductService service;
        private readonly ILogger logger;

        public ProductsController(ProductService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            try
            {
                var data = await service.GetAll();

                return Ok(data);
            }
            catch(Exception e)
            {
                logger.Error(e);

                return BadRequest();
            }
        }


    }
}
