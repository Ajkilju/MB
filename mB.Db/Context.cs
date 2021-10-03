using mB.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace mB.Db
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Log> Logs { get; set; }

        public Context() : this($".\\mB.db")
        {

        }

        public Context(string dbPath) : this(new DbContextOptionsBuilder<Context>().UseSqlite($"Data Source={dbPath}").Options)
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.Init();
        }

    }
}
