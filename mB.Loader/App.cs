using mB.Db;
using mB.Loader.Services;
using mB.Utils;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mB.Loader
{
    public static class App
    {
        private static IKernel services = new StandardKernel();

        static App()
        {
            var solutionDirInDebugMode = "../../../../";

            services.Bind<Context>().ToMethod(c => 
                new Context($"{solutionDirInDebugMode}mB.Db/mB.db"));

            services.Bind<ProductLoader>().ToMethod(c =>
            {
                var sourceDirectoryPath = Path.GetFullPath($"{solutionDirInDebugMode}SOURCE");
                var logger = c.Kernel.Get<ILogger>();
                var loader = new ProductLoader(logger, sourceDirectoryPath);

                return loader;
            });

            services.Bind<ILogger>().To<ConsoleLogger>();
            services.Bind<ProductService>().ToSelf();
            services.Bind<Processor>().ToSelf();
        }

        public static T Get<T>() => services.Get<T>();
    }
}
