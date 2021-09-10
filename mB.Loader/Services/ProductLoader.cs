using mB.Db.Entities;
using mB.Loader.Model;
using mB.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mB.Loader.Services
{
    public class ProductLoader
    {
        private readonly ILogger logger;

        public string SourceDirectoryPath { get; private set; }

        public ProductLoader(ILogger logger, string sourceDirectoryPath)
        {
            this.logger = logger;
            this.SourceDirectoryPath = sourceDirectoryPath;
        }

        public List<ProductXmlModel> Load()
        {
            var res = new List<ProductXmlModel>();

            var dir = new DirectoryInfo(SourceDirectoryPath);

            var xmls = dir.GetFiles()
                .Where(x => x.Extension.ToLower() == ".xml")
                .ToList();

            var serializer = new XmlSerializer(typeof(ProductXmlModel));

            foreach(var xml in xmls)
            {
                using (var fs = new FileStream(xml.FullName, FileMode.Open))
                {
                    try
                    {
                        var product = (ProductXmlModel)serializer
                            .Deserialize(fs);

                        res.Add(product);
                    }
                    catch(Exception e)
                    {
                        logger.Error(e);
                    } 
                }
            }

            return res;
        }

    }
}
