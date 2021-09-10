using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mB.Loader.Model
{
    public class ProductXmlModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }
    }
}
