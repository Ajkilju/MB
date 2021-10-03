using mB.Loader.Models;
using mB.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Services.Extractors
{
    public abstract class ProductExtractor
    {
        protected readonly ILogger logger;

        public LoadSource Source { get; private set; }

        public ProductExtractor(ILogger logger, LoadSource source)
        {
            this.logger = logger;
            this.Source = source;
        }

        protected abstract List<Product> ExtractFromFile(FileInfo file);

        public List<Product> Extract(string dirPath)
        {
            var res = new List<Product>();

            var dir = new DirectoryInfo(dirPath);

            if (!dir.Exists)
                throw new Exception($"Directory {dir.FullName} not exists.");


            foreach(var file in dir.GetFiles())
            {
                try
                {
                    var products = ExtractFromFile(file);

                    res.AddRange(products);
                }
                catch (Exception e)
                {
                    logger.Error(e);
                }
            }

            return res;
        }



    }
}
