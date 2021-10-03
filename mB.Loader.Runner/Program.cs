using System;

namespace mB.Loader.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader =  App.Get<ProductLoader>();

            loader.Load(LoadSource.XML, "../../../../_SOURCE");

            Console.ReadKey();
        }


    }
}
