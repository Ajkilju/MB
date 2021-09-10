using mB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Services
{
    public class Processor
    {
        private readonly ProductLoader loader;
        private readonly ProductService service;
        private readonly ILogger logger;

        public Processor(
            ProductLoader loader, 
            ProductService service,
            ILogger logger)
        {
            this.loader = loader;
            this.service = service;
            this.logger = logger;
        }

        public void Process()
        {
            try
            {
                logger.Info(
                    $"Start loading xml product files. Source: {loader.SourceDirectoryPath}");

                var products = loader.Load();

                if(products.Any())
                {
                    service.AddOrUpdate(products);

                    logger.Success($"{products.Count} products saved");
                }
                else
                {
                    logger.Success($"no one product to saved");
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }

        }



    }
}
