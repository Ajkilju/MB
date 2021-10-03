using mB.Loader.Models;
using mB.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mB.Loader.Services.Extractors
{
    public class XmlProductExtractor : ProductExtractor, IProductExtractor
    {
        public XmlProductExtractor(ILogger logger) : base(logger, LoadSource.XML)
        {

        }

        protected override List<Product> ExtractFromFile(FileInfo file)
        {
            var res = new List<Product>();

            if (file.Extension.ToLower() != ".xml")
                return res;

            var serializer = new XmlSerializer(typeof(Product));

            using (var fs = new FileStream(file.FullName, FileMode.Open))
            {
                var product = (Product)serializer
                    .Deserialize(fs);

                res.Add(product);
            }
            
            return res;
        }
    }
}
