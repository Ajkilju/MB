using mB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Tests.Utils
{
    public class TestLogger : ILogger
    {
        public void Error(string msg)
        {
            throw new NotImplementedException();
        }

        public int ErrorExceptionHits { get; private set; } = 0;

        public void Error(Exception e)
        {
            ErrorExceptionHits++;
        }

        public void Info(string msg)
        {
            throw new NotImplementedException();
        }

        public void Success(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
