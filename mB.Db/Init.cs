using mB.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Db
{
    public static class ContextInitExtension
    {
        public static void Init(this Context ctx)
        {
            if (!ctx.Clients.Any())
            {
                var client = new Client
                {
                    Id = 1,
                    Added = DateTime.Now,
                    Name = "Jan",
                    LastName = "Kowalski"
                };

                ctx.Add(client);
                ctx.SaveChanges();
            }
        }


    }
}
