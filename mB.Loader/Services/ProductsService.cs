using mB.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Services
{
    public class ProductsService
    {
        private readonly Context ctx;

        public ProductsService(Context ctx)
        {
            this.ctx = ctx;
        }

        public void AddOrUpdate(List<Models.Product> products, LoadSource source)
        {
            if (products == null || !products.Any())
                return;

            foreach(var product in products)
            {
                var existing = ctx.Products
                    .Find(product.Id);

                if(existing == null)
                {
                    ctx.Add(new Db.Entities.Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Category = product.Category,
                        Price = product.Price,
                        Added = DateTime.Now,
                        Source = source.ToString()
                    });
                }
                else
                {
                    existing.Name = product.Name;
                    existing.Category = product.Category;
                    existing.Price = product.Price;
                }
            }

            ctx.SaveChanges();
        }

    }
}
