using mB.Loader.Services;
using System;

namespace mB.Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = App.Get<Processor>();

            processor.Process();

            Console.ReadKey();
        }
    }
}
