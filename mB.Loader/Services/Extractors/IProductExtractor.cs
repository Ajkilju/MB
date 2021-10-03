using mB.Loader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader.Services.Extractors
{
    public interface IProductExtractor
    {
        LoadSource Source { get; }

        List<Product> Extract(string dirPath);
    }
}
