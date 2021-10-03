using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Db.Entities
{
    public class Log : Entity
    {
        public string Type { get; set; }

        public string Message { get; set; }
    }

    public static class LogType
    {
        public const string Success = "SUCCESS";

        public const string Error = "ERROR";

        public const string Info = "INFO";
    }
}
