using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Utils
{
    public interface ILogger
    {
        void Info(string msg);

        void Success(string msg);

        void Error(string msg);

        void Error(Exception e);
    }
}
