using mB.Db;
using mB.Db.Entities;
using mB.Loader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Services
{
    public class ProductService
    {
        private readonly Context ctx; 

        public ProductService(Context ctx)
        {
            this.ctx = ctx;
        }

        public void AddOrUpdate(List<ProductXmlModel> products)
        {
            foreach(var product in products)
            {
                var existing = ctx.Products
                    .Find(product.Id);

                if (existing == null)
                {
                    ctx.Add(new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Category = product.Category,
                        Added = DateTime.Now,
                        Source = ProductSource.XmlFile
                    });
                }
                else
                {
                    existing.Name = product.Name;
                    existing.Category = product.Category;
                }
            }

            ctx.SaveChanges();
        }

    }
}
