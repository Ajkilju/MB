using mB.Db;
using mB.Db.Entities;
using mB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mB.Api.Services
{
    public class DbLogger : ILogger
    {
        private readonly Context ctx;

        public DbLogger(Context ctx)
        {
            this.ctx = ctx;
        }

        public void Error(string msg) => AddAndSave(msg, LogType.Error);

        public void Error(Exception e) => Error(e.Message);

        public void Info(string msg) => AddAndSave(msg, LogType.Info);

        public void Success(string msg) => AddAndSave(msg, LogType.Success);

        private void AddAndSave(string msg, string type)
        {
            var log = new Log
            {
                Message = msg,
                Type = type
            };

            ctx.Add(log);
            ctx.SaveChanges();
        }


    }
}
