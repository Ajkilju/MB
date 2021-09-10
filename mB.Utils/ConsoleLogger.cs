using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Utils
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string msg) => Console.WriteLine($"[ERROR] {msg}");

        public void Error(Exception e) => Error(e.Message);

        public void Info(string msg) => Console.WriteLine(msg);

        public void Success(string msg) => Console.WriteLine($"[SUCCESS] {msg}");
    }
}
