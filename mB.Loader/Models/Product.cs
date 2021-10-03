using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id == product.Id &&
                   Name == product.Name &&
                   Category == product.Category &&
                   Price == product.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Category, Price);
        }
    }
}
