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
    public class CsvProductExtractor : ProductExtractor, IProductExtractor
    {
        public CsvProductExtractor(ILogger logger) : base(logger, LoadSource.CSV)
        {

        }

        protected override List<Product> ExtractFromFile(FileInfo file)
        {
            var res = new List<Product>();

            if (file.Extension.ToLower() != ".csv")
                return res;

            using (var reader = new StreamReader(file.FullName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if(
                        int.TryParse(values[0], out var id) 
                        && decimal.TryParse(values[3], out var price) 
                        && !string.IsNullOrWhiteSpace(values[1]))
                    {
                        var product = new Product
                        {
                            Id = id,
                            Price = price,
                            Name = values[1],
                            Category = values[2]
                        };

                        res.Add(product);
                    }
                }
            }

            return res;
        }


    }
}
