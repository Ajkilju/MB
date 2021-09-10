using mB.Api.Model;
using mB.Db;
using mB.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Services
{
    public class ProductService
    {
        private readonly Context ctx;

        public ProductService(Context ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var res = await ctx.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                    Added = x.Added
                })
                .ToListAsync();

            return res;
        }
    }
}
