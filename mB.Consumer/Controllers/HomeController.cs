using mB.Consumer.Models;
using mB.Consumer.OpenAPIs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Consumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsClient client;

        public HomeController(ProductsClient client)
        {
            this.client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("products")]
        public async Task<ActionResult> LoadProductsTable()
        {
            var vm = new ProductsTableViewModel();

            try
            {
                var products = await client
                    .GetAllProductsAsync();

                vm.Products = products.ToList();
            }
            catch(Exception e)
            {
                vm.Error = "Coś poszło nie tak...";
            }

            return PartialView("_ProductsTable", vm);
        }

       
    }
}
