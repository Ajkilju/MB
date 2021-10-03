using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Db.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }
        
        public string Source { get; set; }
    }

    public static class ProductSource
    {
        public const string XmlFile = "XML file";
        public const string CsvFile = "CSV file";
    }
}
